using System.ComponentModel.DataAnnotations.Schema;
namespace ServicePlanner.Domain.Entities.ServicePlanner;

[Table("WorkOrderStatusHistory", Schema = "ServicePlanner")]
public class WorkOrderStatusHistory : BaseAuditableEntity
{
    public int WorkOrderId { get; set; }
    public WorkOrder WorkOrder { get; set; }
    public int WorkOrderStatusId { get; set; }
    WorkOrderStatus WorkOrderStatus { get; set; }
}
