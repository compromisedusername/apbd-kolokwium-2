

using apbd_kolokwium_2.Data;
using apbd_kolokwium_2.DTOs;
using apbd_kolokwium_2.Exceptions;
using apbd_kolokwium_2.Models;
using Microsoft.EntityFrameworkCore;

namespace apbd_kolokwium_2.Services;

public class DbService : IDbService
{
    private readonly ApplicationContext _applicationContext;

    public DbService(ApplicationContext applicationContext)
    {
        _applicationContext = applicationContext;
    }


    public async Task<GetOwnerDataDTO> GetOwnersData(int ownerId)
    {
        var ownerExist = await GetOwner(ownerId);
        if (ownerExist is null)
        {
            throw new DomainException()
            {
                Message = "No owner found",
                StatusCode = 404
            };
        }

            var objectTypes = await _applicationContext.ObjectColumns
                .Include(e => e.ObjectOwners)
                .ThenInclude(e => e.Owner.ObjectOwners.Where(ee => ee.Owner_ID == ownerId))
                .Include(e => e.Warehouse)
                .Include(e => e.ObjectType)
                .ToListAsync();


            
            var res = new GetOwnerDataDTO
            {
                FirstName = ownerExist.FirstName,
                LastName = ownerExist.LastName,
                PhoneNumber = ownerExist.PhoneNumber,
                ObjectOwnersDtos = objectTypes.Select(e => new ObjectOwnersDTO
                {
                    ID = e.ID,
                    Width = e.Width,
                    Height = e.Height,
                    Type = e.ObjectType.Name,
                    Warehouse = e.Warehouse.Name
                })
            };

            return res;
    }



    public async Task CreateClient(CreateClientDTO request)
    {
        var owner = await GetOwnerByName(request);
        if (owner == null)
        {
            owner = await CreateNewOwner(request.FirstName, request.LastName, request.PhoneNumber);
        }

        List<ObjectColumn> objectColumns = new List<ObjectColumn>();

        foreach (var x in request.ownerObject)
        {
            var item = await GetObject(x);
            if (item == null)
            {
                throw new DomainException()
                {
                    Message = "Item does not exist!",
                    StatusCode = 404
                };
            }

            objectColumns.Add(item);
        }

        

        var objectOwner = new List<ObjectOwner> { };
        foreach (var objectColumn in objectColumns)
        {
            var addItem = await UpdateObjectOwner(owner, objectColumn);
            objectOwner.Add(addItem);
        }

        try
        {
            await _applicationContext.ObjectOwners.AddRangeAsync(objectOwner);
            await _applicationContext.SaveChangesAsync();
        }
        catch (Exception e)
        {
            throw new DomainException() { Message = "Duplicate item for this owner! Cannot add to database!", StatusCode = 400 };
        }

    }

    private async Task<ObjectOwner> UpdateObjectOwner(Owner owner, ObjectColumn objectColumn)
    {
        var objectOwner = new ObjectOwner
        {
            Owner = owner,
            Object_ID = objectColumn.ID
        };


        return objectOwner;
    }

    private async Task<Owner> CreateNewOwner(string firstName, string lastName, string phoneNumber)
    {
        var owner = new Owner
        {
            FirstName = firstName,
            LastName = lastName,
            PhoneNumber = phoneNumber,
        };
        await _applicationContext.Owners.AddAsync(owner);
        await _applicationContext.SaveChangesAsync();

        return owner;
    }

    private async Task<ObjectColumn> GetObject(int i)
    {
        return await _applicationContext.ObjectColumns.FindAsync(i);
    }

    private async Task<Owner> GetOwner(int ownerId)
        {
            return await _applicationContext.Owners.FindAsync(ownerId);
        }


        private async Task<Owner> GetOwnerByName(CreateClientDTO request)
        {
            return await _applicationContext.Owners.FirstOrDefaultAsync(e => e.FirstName == request.FirstName && e.LastName == request.LastName && e.PhoneNumber == request.PhoneNumber );

        }
    }