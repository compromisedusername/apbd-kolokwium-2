using System.ComponentModel.DataAnnotations;

namespace apbd_kolokwium_2.DTOs;

public class GetOwnerDataDTO
{
    [Required]
    public string FirstName { get; set; }
    [Required]
    public string LastName { get; set; }
    [Required]
    public string PhoneNumber { get; set; }
    
    public IEnumerable<ObjectOwnersDTO> ObjectOwnersDtos { get; set; }
}

public class ObjectOwnersDTO
{
    public int ID { get; set; }
    public decimal Width { get; set; }
    public decimal Height { get; set; }
    public string Type { get; set; }
    public string Warehouse { get; set; }
}