using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServicePlanner.Application.Common.Models;
using ServicePlanner.Application.Employees.Commands.CreateEmployee;
using ServicePlanner.Application.Employees.Commands.DeleteEmployee;
using ServicePlanner.Application.Employees.Commands.UpdateEmployee;
using ServicePlanner.Application.Employees.Queries.GetEmployee;
using ServicePlanner.Application.Employees.Queries.GetEmployeesWithPagination;
using ServicePlanner.Application.WorkOrders.Commands.UpdateWorkOrder;
using ServicePlanner.Application.WorkOrders.Queries.GetWorkOrdersWithPagination;
using ServicePlanner.Domain.Entities.ServicePlanner;

namespace ServicePlanner.WebUI.Controllers;
[Authorize]
public class EmployeesController : ApiControllerBase
{
    [HttpPost]
    public async Task<ActionResult<int>> CreateEmployee(CreateEmployeeCommand command)
    {
        var result = await Mediator.Send(command);
        return CreatedAtRoute($"NameForGetEmployeeEndpoint", new { id = result }, result);
    }

    [HttpGet]
    public async Task<ActionResult<PaginatedList<EmployeeBriefDto>>> GetEmployeesWithPagination([FromQuery] GetEmployeesWithPaginationQuery query)
    {
        return await Mediator.Send(query);
    }

    [HttpGet("{id}", Name = "NameForGetEmployeeEndpoint")]
    public async Task<ActionResult<Employee>> GetEmployee(int id)
    {
        var command = new GetEmployeeQuery() { Id = id };
        var result = await Mediator.Send(command);
        return result != null ? Ok(result) : NotFound();
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> UpdateEmployee(int id, UpdateEmployeeCommand command)
    {
        if (id != command.Id)
        {
            return BadRequest();
        }

        await Mediator.Send(command);

        return NoContent();
    }

    [HttpDelete("{id}")]
    public async Task<ActionResult> DeleteEmployee(int id)
    {
        await Mediator.Send(new DeleteEmployeeCommand(id));

        return NoContent();
    }
}
