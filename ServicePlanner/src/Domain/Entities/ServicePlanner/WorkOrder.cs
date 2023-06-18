using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace ServicePlanner.Domain.Entities.ServicePlanner;

[Table("WorkOrder", Schema = "ServicePlanner")]
public class WorkOrder : BaseAuditableEntity
{
    public int WorkOrderStatusId { get; set; }
    public WorkOrderStatus WorkOrderStatus { get; set; }
    public IEnumerable<WorkOrderStatusHistory> WorkOrderStatusHistoryItems { get; set; } = new List<WorkOrderStatusHistory>();
    public int? ClientId { get; set; }
    public Client Client { get; set; }
    public int? EmployeeId { get; set; }
    public Employee Employee { get; set; }

    [Column(TypeName = "Text")]
    public string? Notes { get; set; }

}
