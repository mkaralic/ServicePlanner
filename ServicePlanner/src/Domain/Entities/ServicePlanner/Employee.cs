using System.ComponentModel.DataAnnotations.Schema;
namespace ServicePlanner.Domain.Entities.ServicePlanner;
[Table("People", Schema = "ServicePlanner")]

public class Employee : Person
{
    public IEnumerable<WorkOrder> WorkOrders { get; set; } = null!;
}
