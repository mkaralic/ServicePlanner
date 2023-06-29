using System.ComponentModel.DataAnnotations.Schema;
namespace ServicePlanner.Domain.Entities.ServicePlanner;

[Table("People", Schema = "ServicePlanner")]
public class Customer : Person
{
    public IEnumerable<WorkOrder> WorkOrders { get; set; } = Enumerable.Empty<WorkOrder>();
}
