using System.Transactions;
using apbd_kolokwium_2.DTOs;
using apbd_kolokwium_2.Exceptions;
using apbd_kolokwium_2.Services;
using Microsoft.AspNetCore.Mvc;

namespace apbd_kolokwium_2.Controllers;
[ApiController]
[Route("api/[controller]")]
public class OwnersController : ControllerBase
{
    
    private readonly IDbService _dbService;

    public OwnersController(IDbService dbContext)
    {
        _dbService = dbContext;
    }
    
    [HttpGet]
    public async Task<IActionResult> GetOrdersData(int ownerId)
    {
        try
        {
            var orders = await _dbService.GetOwnersData(ownerId);
            return Ok(orders);

        }
        catch (DomainException de)
        {
            return BadRequest(new ExceptionDTO()
            {
                Message = de.Message,
                StatusCode = de.StatusCode
            });
        }
        catch (Exception e)
        {
            return BadRequest(new ExceptionDTO()
            {
                Message = e.Message,
                StatusCode = 500
            });
        }

        
    }
    [HttpPost]
    public async Task<IActionResult> CreateClient(CreateClientDTO request)
    {
        
        using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
        {
            try
            {
                await _dbService.CreateClient(request);

                scope.Complete();
            }
            catch (DomainException de)
            {
                return BadRequest(new ExceptionDTO()
                {
                    Message = de.Message,
                    StatusCode = de.StatusCode
                });
            }
            catch (Exception e)
            {
                return BadRequest(new ExceptionDTO()
                {
                    Message = e.Message,
                    StatusCode = 500
                });
            }
        }

        return Created();
    } 

}