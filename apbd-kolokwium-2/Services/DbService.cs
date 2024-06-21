

using apbd_kolokwium_2.Data;

namespace apbd_kolokwium_2.Services;

public class DbService : IDbService
{
    private readonly ApplicationContext _applicationContext;

    public DbService(ApplicationContext applicationContext)
    {
        _applicationContext = applicationContext;
    }
    
    
}