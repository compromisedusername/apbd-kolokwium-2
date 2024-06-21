using apbd_kolokwium_2.Models;
using Microsoft.EntityFrameworkCore;

namespace apbd_kolokwium_2.Data;

public class ApplicationContext : DbContext
{
    protected ApplicationContext(){}
    public ApplicationContext(DbContextOptions options) : base(options){}

    
    public DbSet<ObjectColumn> ObjectColumns { get; set; } 
    public DbSet<ObjectOwner> ObjectOwners  { get; set; } 
    public DbSet<ObjectType> ObjectTypes   { get; set; } 
    public DbSet<Owner> Owners   { get; set; } 
    public DbSet<Warehouse> Warehouse   { get; set; } 
    

   
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ObjectColumn>().HasData(new List<ObjectColumn>
        {
            new ObjectColumn
            {
                ID = 1,
                Warehouse_ID = 1,
                Object_Type_ID = 1,
                Width = 1,
                Height = 2,
            }
        });modelBuilder.Entity<ObjectOwner>().HasData(new List<ObjectOwner>
        {
            new ObjectOwner
            {
                Object_ID = 1,
                Owner_ID = 1,
            }

        });modelBuilder.Entity<ObjectType>().HasData(new List<ObjectType>
        {
            new ObjectType
            {
                ID = 1,
                Name = "Name1",
            }

        });modelBuilder.Entity<Owner>().HasData(new List<Owner>
        {
            new Owner
            {
                ID = 1,
                FirstName = "Name1",
                LastName = "LastName1",
                PhoneNumber = "555555555",
            }

        });modelBuilder.Entity<Warehouse>().HasData(new List<Warehouse>
        {
            new Warehouse
            {
                ID = 1,
                Name = "Name1",
            }

        });

    }
}