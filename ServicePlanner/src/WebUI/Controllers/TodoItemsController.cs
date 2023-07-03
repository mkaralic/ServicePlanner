﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ServicePlanner.Application.Common.Models;
using ServicePlanner.Application.Employees.Commands.CreateEmployee;
using ServicePlanner.Application.Employees.Commands.UpdateEmployee;
using ServicePlanner.Application.TodoItems.Commands.CreateTodoItem;
using ServicePlanner.Application.TodoItems.Commands.DeleteTodoItem;
using ServicePlanner.Application.TodoItems.Commands.UpdateTodoItem;
using ServicePlanner.Application.TodoItems.Commands.UpdateTodoItemDetail;
using ServicePlanner.Application.TodoItems.Queries.GetTodoItemsWithPagination;

namespace ServicePlanner.WebUI.Controllers;
[Authorize]
public class TodoItemsController : ApiControllerBase
{
    [HttpGet]
    public async Task<ActionResult<PaginatedList<TodoItemBriefDto>>> GetTodoItemsWithPagination([FromQuery] GetTodoItemsWithPaginationQuery query)
    {
        return await Mediator.Send(query);
    }

    [HttpPost]
    public async Task<ActionResult<int>> Create(CreateTodoItemCommand command)
    {
        return await Mediator.Send(command);
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

    [HttpPut("[action]")]
    public async Task<ActionResult> UpdateItemDetails(int id, UpdateTodoItemDetailCommand command)
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
