using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicePlanner.Domain.Entities.ServicePlanner;
[Table("People", Schema = "ServicePlanner")]
public abstract class Person : BaseAuditableEntity
{
    [MaxLength(30)]
    [Required]
    public string FirstName { get; set; }

    [MaxLength(50)]
    public string LastName { get; set; }

    [MaxLength(20)]
    public string Phone { get; set; }

    [MaxLength(200)]
    public string Address { get; set; }

    [MaxLength(50)]
    public string City { get; set; }

    [MaxLength(50)]
    public string Country { get; set; }

    [Column(TypeName = "Text")]
    public string Notes { get; set; }
}
