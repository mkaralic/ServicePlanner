using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ServicePlanner.Domain.Entities.ServicePlanner;

[Table("WorkOrderStatus", Schema = "ServicePlanner")]
public class WorkOrderStatus
{
    [Key]
    [DatabaseGenerat‌ed(DatabaseGeneratedOp‌​tion.None)]
    public int Id { get; set; }

    [MaxLength(30)]
    public string Name { get; set; }

    [MaxLength(250)]
    public string Description { get; set; }

    public IEnumerable<WorkOrder> WorkOrders { get; set; } = null!;
}
