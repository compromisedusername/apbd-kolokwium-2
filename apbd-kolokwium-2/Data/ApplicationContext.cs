using Microsoft.EntityFrameworkCore;

namespace apbd_kolokwium_2.Data;

public class ApplicationContext : DbContext
{
    protected ApplicationContext(){}
    public ApplicationContext(DbContextOptions options) : base(options){}

    
    public DbSet<object> Backpacks { get; set; } 
    

   
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<object>().HasData(new List<object>
        {

        });

    }
}