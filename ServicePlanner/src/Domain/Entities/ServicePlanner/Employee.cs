using System.ComponentModel.DataAnnotations.Schema;
namespace ServicePlanner.Domain.Entities.ServicePlanner;

[Table("Employee", Schema = "ServicePlanner")]
public class Employee : BasePerson
{
    public IEnumerable<WorkOrder> WorkOrders { get; set; }
}
