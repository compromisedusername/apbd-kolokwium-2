using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace apbd_kolokwium_2.Models;

[Table("Object")]
public class ObjectColumn
{
    [Key]
    public int ID { get; set; }
    public int Warehouse_ID { get; set; }
    public int Object_Type_ID { get; set; }
    [DataType("decimal")]
    [Precision(4,2)]
    public decimal Width { get; set; }
    [DataType("decimal")]
    [Precision(4,2)]
    public decimal Height{ get; set; }
    
    [ForeignKey(nameof(Object_Type_ID))]
    public ObjectType ObjectType { get; set; }
    [ForeignKey(nameof(Warehouse_ID))]
    public Warehouse Warehouse { get; set; }
    
    public IEnumerable<ObjectOwner> ObjectOwners { get; set; } = new HashSet<ObjectOwner>();

}