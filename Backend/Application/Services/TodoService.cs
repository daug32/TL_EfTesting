using TodoList.Api.Dto;
using TodoList.Api.Services;
using TodoList.Application.Models;
using TodoList.Application.Repositories;

namespace TodoList.Application.Services;

public class TodoService : ITodoService
{
    private ITodoRepository _todoRepo;

    public TodoService( ITodoRepository todoRepository )
    {
        _todoRepo = todoRepository;
    }

    public List<TodoDto> GetTodos()
    {
        return _todoRepo.GetTodos()
            .Select( el => ModelToDto( el ) )
            .ToList();
    }

    public TodoDto GetTodo( int id )
    {
        return ModelToDto( _todoRepo.Get( id ) );
    }

    public void CompleteTodo( int todoId )
    {
        var todo = _todoRepo.Get( todoId );
        todo.IsDone = true;
        _todoRepo.Update( todo );
    }

    public void CreateTodo( TodoDto todoDto )
    {
        var todo = new Todo()
        {
            Id = 0,
            Title = todoDto.Title,
            IsDone = todoDto.IsDone
        };
        _todoRepo.Create( todo );
    }

    public void DeleteTodo( int todoId )
    {
        _todoRepo.Delete( todoId );
    }

    private TodoDto ModelToDto( Todo todo )
    {
        return new TodoDto()
        {
            Id = todo.Id,
            Title = todo.Title,
            IsDone = todo.IsDone
        };
    }
}
