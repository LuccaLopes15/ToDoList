using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Server.Api.Lists.Models.Requests;
using ToDoList.Server.Api.Lists.Models.Responses;
using ToDoList.Server.Application.Lists.Commands.Create;

namespace ToDoList.Server.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ListsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ListsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Create([FromBody] CreateListRequest request)
    {
        var command = new CreateListCommand
        {
            Title = request.Title,
            Items = GetListItemsCommand(request.Items)
        };

        var listId = await _mediator.Send(command);

        return CreatedAtAction(nameof(Create), new { id = listId }, listId);
    }

    public async Task<IActionResult> Get(Guid id)
    {
        var query = new GetListByIdQuery { ListId = id };
        var listDto = await _mediator.Send(query);

        if (listDto == null)
            return NotFound();

        var response = ListResponse.FromDto(listDto);
        return Ok(response);
    }

    private ICollection<CreatListItemCommand> GetListItemsCommand(ICollection<CreateListItemRequest> request)
    {
        if (request is null || request.Count == 0)
            return [];

        return request.Select(x => new CreatListItemCommand
        {
            Title = x.Title,
            Description = x.Description,
            Status = x.Status
        }).ToList();
    }
}
