using TodoList.Api.Dto;
using TodoList.Api.Services;
using Microsoft.AspNetCore.Mvc;

namespace TodoList.Api.Controllers;

[ApiController]
[Route( "rest/[controller]" )]
public class TodoController : ControllerBase
{
    private IUnitOfWork _unitOfWork;
    private ITodoService _todoService;

    public TodoController( ITodoService todoService, IUnitOfWork unitOfWork )
    {
        _unitOfWork = unitOfWork;
        _todoService = todoService;
    }

    [HttpGet( "get-all" )]
    public IActionResult GetAll()
    {
        var todoDtos = _todoService.GetTodos();
        return Ok( todoDtos );
    }

    [HttpGet( "{todoId}" )]
    public IActionResult Get( int todoId )
    {
        var todoDto = _todoService.GetTodo( todoId );
        if ( todoDto.Id < 1 )
        {
            return BadRequest( "Todo with this id doesn't exist" );
        }
        return Ok( todoDto );
    }

    [HttpPost( "create" )]
    public IActionResult Create( [FromBody] TodoDto todoDto )
    {
        _todoService.CreateTodo( todoDto );
        _unitOfWork.Commit();
        return Ok();
    }

    [HttpPut( "{todoId}/complete" )]
    public IActionResult Complete( int todoId )
    {
        _todoService.CompleteTodo( todoId );
        _unitOfWork.Commit();
        return Ok();
    }

    [HttpDelete( "{todoId}/delete" )]
    public IActionResult Delete( int todoId )
    {
        _todoService.DeleteTodo( todoId );
        _unitOfWork.Commit();
        return Ok( );
    }
}
