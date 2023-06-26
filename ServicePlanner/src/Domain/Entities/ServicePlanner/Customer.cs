using System.ComponentModel.DataAnnotations.Schema;
namespace ServicePlanner.Domain.Entities.ServicePlanner;

[Table("Customers", Schema = "ServicePlanner")]
public class Customer : BasePerson
{
    public IEnumerable<WorkOrder> WorkOrders { get; set; }
}
