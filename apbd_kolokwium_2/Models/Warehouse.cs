using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace apbd_kolokwium_2.Models;
[Table("Warehouse")]

public class Warehouse
{
    [Key]
    public int ID { get; set; }
    [MaxLength(50)]
    public string Name { get; set; }
    public IEnumerable<ObjectColumn> Objects { get; set; } = new HashSet<ObjectColumn>();

}