﻿using FluentAssertions;
using NUnit.Framework;
using ServicePlanner.Application.Common.Exceptions;
using ServicePlanner.Application.TodoItems.Commands.CreateTodoItem;
using ServicePlanner.Application.TodoItems.Commands.DeleteTodoItem;
using ServicePlanner.Application.TodoLists.Commands.CreateTodoList;
using ServicePlanner.Domain.Entities;

using static Testing;

namespace ServicePlanner.Application.IntegrationTests.TodoItems.Commands;
public class DeleteTodoItemTests : BaseTestFixture
{
    [Test]
    public async Task ShouldRequireValidTodoItemId()
    {
        var command = new DeleteTodoItemCommand(99);

        await FluentActions.Invoking(() =>
            SendAsync(command)).Should().ThrowAsync<NotFoundException>();
    }

    [Test]
    public async Task ShouldDeleteTodoItem()
    {
        var listId = await SendAsync(new CreateTodoListCommand
        {
            Title = "New List"
        });

        var itemId = await SendAsync(new CreateTodoItemCommand
        {
            ListId = listId,
            Title = "New Item"
        });

        await SendAsync(new DeleteTodoItemCommand(itemId));

        var item = await FindAsync<TodoItem>(itemId);

        item.Should().BeNull();
    }
}
