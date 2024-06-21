using apbd_kolokwium_2.DTOs;

namespace apbd_kolokwium_2.Services;

public interface IDbService
{
    Task<GetOwnerDataDTO> GetOwnersData(int ownerId);
    Task CreateClient(CreateClientDTO request);
}