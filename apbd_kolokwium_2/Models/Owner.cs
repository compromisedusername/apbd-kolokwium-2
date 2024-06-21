using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apbd_kolokwium_2.Models;

[Table("Owner")]
public class Owner
{
    [Key] public int ID { get; set; }
    [MaxLength(50)]
    public string FirstName { get; set; }
    [MaxLength(50)]
    public string LastName { get; set; }
    [MaxLength(9)]
    public string PhoneNumber { get; set; }

    public IEnumerable<ObjectOwner> ObjectOwners { get; set; } = new HashSet<ObjectOwner>();


}