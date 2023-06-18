using System.ComponentModel.DataAnnotations.Schema;
namespace ServicePlanner.Domain.Entities.ServicePlanner;

[Table("Client", Schema = "ServicePlanner")]
public class Client : BasePerson
{
    public IEnumerable<WorkOrder> WorkOrders { get; set; }
}
