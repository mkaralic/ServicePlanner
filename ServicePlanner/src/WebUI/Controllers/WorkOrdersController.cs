using Microsoft.AspNetCore.Mvc;
using ServicePlanner.Application.Common.Models;
using ServicePlanner.Application.WorkOrders.Commands.CreateWorkOrder;
using ServicePlanner.Application.WorkOrders.Commands.DeleteWorkOrder;
using ServicePlanner.Application.WorkOrders.Commands.UpdateWorkOrder;
using ServicePlanner.Application.WorkOrders.Queries.GetWorkOrder;
using ServicePlanner.Application.WorkOrders.Queries.GetWorkOrdersWithPagination;
using ServicePlanner.WebUI.Controllers;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebUI.Controllers;
[Route("api/[controller]")]
[ApiController]
public class WorkOrdersController : ApiControllerBase
{
    // POST api/<WorkOrdersController>
    [HttpPost]
    public async Task<ActionResult<int>> Create(CreateWorkOrderCommand command)
    {
        var result = await Mediator.Send(command);
        return CreatedAtRoute("NameForGetWorkOrderEndpoint", new { id = result }, result);
    }

    // GET: api/<WorkOrdersController>
    [HttpGet]
    public async Task<ActionResult<PaginatedList<WorkOrderBriefDto>>> GetWorkOrdersWithPagination([FromQuery] GetWorkOrdersWithPaginationQuery query)
    {
        return await Mediator.Send(query);
    }

    // GET api/<WorkOrdersController>/5
    [HttpGet("{id}", Name = "NameForGetWorkOrderEndpoint")]
    public async Task<ActionResult> GetWorkOrder(int id)
    {
        var command = new GetWorkOrderQuery() { Id = id };
        var result = await Mediator.Send(command);
        return result != null ? Ok(result) : NotFound();
    }

    // PUT api/<WorkOrdersController>/5
    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, UpdateWorkOrderCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest();
        }

        await Mediator.Send(command);

        return NoContent();
    }

    // DELETE api/<WorkOrdersController>/5
    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await Mediator.Send(new DeleteWorkOrderCommand(id));

        return NoContent();
    }
}
