using System.ComponentModel.DataAnnotations;

namespace apbd_kolokwium_2.DTOs;

public class CreateClientDTO
{
    [Required]
    [MaxLength(50)]
    public string FirstName { get; set; }

    [MaxLength(50)]
    public string LastName { get; set; }
    [MaxLength(9)]
    public string PhoneNumber { get; set; }

    public List<int> ownerObject { get; set; } = new List<int>();
}