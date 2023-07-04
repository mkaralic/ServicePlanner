using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServicePlanner.Application.Common.Models;
using ServicePlanner.Application.Customers.Commands.CreateCustomer;
using ServicePlanner.Application.Customers.Queries.GetCustomersWithPagination;
using ServicePlanner.Application.Customers.Commands.DeleteCustomer;
using ServicePlanner.Application.Customers.Commands.UpdateCustomer;
using ServicePlanner.Application.Customers.Queries.GetCustomer;

namespace ServicePlanner.WebUI.Controllers;
[Authorize]
public class CustomersController : ApiControllerBase
{
    [HttpPost]
    public async Task<ActionResult<int>> Create(CreateCustomerCommand command)
    {
        var result = await Mediator.Send(command);
        return CreatedAtRoute($"NameForGetCustomerEndpoint", new { id = result }, result);
    }

    [HttpGet]
    public async Task<ActionResult<PaginatedList<CustomerBriefDto>>> GetCustomersWithPagination([FromQuery] GetCustomersWithPaginationQuery query)
    {
        return await Mediator.Send(query);
    }

    [HttpGet("{id}", Name = "NameForGetCustomerEndpoint")]
    public async Task<ActionResult> GetCustomer(int id) 
    {
        var command = new GetCustomerQuery() { Id = id };
        var result = await Mediator.Send(command);
        return result != null ? Ok(result) : NotFound();
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, UpdateCustomerCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest();
        }

        await Mediator.Send(command);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> Delete(int id)
    {
        await Mediator.Send(new DeleteCustomerCommand(id));

        return NoContent();
    }
}
