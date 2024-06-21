using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace apbd_kolokwium_2.Models;
[Table("Object_Owner")]
[PrimaryKey(nameof(Object_ID),nameof(Owner_ID))]
public class ObjectOwner
{
    public int Object_ID { get; set; }
    public int Owner_ID { get; set; }
    [ForeignKey(nameof(Owner_ID))]
    public Owner Owner { get; set; }
    [ForeignKey(nameof(Object_ID))]
    public ObjectColumn ObjectColumn { get; set; }
}