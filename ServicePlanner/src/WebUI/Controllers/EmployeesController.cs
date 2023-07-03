using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServicePlanner.Application.Common.Models;
using ServicePlanner.Application.Employees.Commands.CreateEmployee;
using ServicePlanner.Application.Employees.Queries.GetEmployeesWithPagination;
using ServicePlanner.Application.TodoItems.Commands.CreateTodoItem;
using ServicePlanner.Application.TodoItems.Commands.DeleteTodoItem;
using ServicePlanner.Application.TodoItems.Commands.UpdateTodoItem;
using ServicePlanner.Application.TodoItems.Commands.UpdateTodoItemDetail;

namespace ServicePlanner.WebUI.Controllers;
[Authorize]
public class EmployeesController : ApiControllerBase
{
    [HttpPost]
    public async Task<ActionResult<int>> Create(CreateEmployeeCommand command)
    {
        return await Mediator.Send(command);
    }

    [HttpGet]
    public async Task<ActionResult<PaginatedList<EmployeeBriefDto>>> GetEmployeesWithPagination([FromQuery] GetEmployeesWithPaginationQuery query)
    {
        return await Mediator.Send(query);
    }

    [HttpPut("{id}")]
    public async Task<ActionResult> Update(int id, UpdateTodoItemCommand command)
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
        await Mediator.Send(new DeleteTodoItemCommand(id));

        return NoContent();
    }
}
