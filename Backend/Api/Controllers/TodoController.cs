using System.Text.Json;
using TodoList.Api.Dto;
using TodoList.Api.Services;
using Microsoft.AspNetCore.Mvc;
using System.Runtime.Serialization;

namespace TodoList.Api.Controllers;

[Route( "rest/[controller]" )]
[ApiController]
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
        var todos = _todoService.GetTodos().ToArray();
        var json = JsonSerializer.Serialize( todos );
        return Ok( json );
    }

    [HttpGet( "{todoId}" )]
    public IActionResult Get( int todoId )
    {
        var todo = _todoService.GetTodo( todoId );
        var json = JsonSerializer.Serialize( todo );
        return Ok( json );
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
        return Ok( "true" );
    }
}
