using Microsoft.AspNetCore.Mvc;
using ServicePlanner.Application.Common.Models;
using ServicePlanner.Application.WorkOrders.Commands.CreateWorkOrder;
using ServicePlanner.Application.WorkOrders.Commands.DeleteWorkOrder;
using ServicePlanner.Application.WorkOrders.Commands.UpdateWorkOrder;
using ServicePlanner.Application.WorkOrders.Queries.GetWorkOrder;
using ServicePlanner.Application.WorkOrders.Queries.GetWorkOrdersWithPagination;
using ServicePlanner.Application.WorkOrderStatuses.Queries.GetWorkOrderStatuses;
using ServicePlanner.Domain.Entities.ServicePlanner;
using ServicePlanner.WebUI.Controllers;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebUI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class WorkOrderStatusesController : ApiControllerBase
{
    // GET: api/<WorkOrderStatuses>
    [HttpGet]
    public async Task<ActionResult<List<WorkOrderStatus>>> GetWorkOrderStatuses([FromQuery] GetWorkOrderStatusesQuery query)
    {
        return await Mediator.Send(query);
    }
}
