using TodoList.Application.Models;
using TodoList.Application.Repositories;

namespace TodoList.Infrastructure.Repositories;

public class TodoRepository : ITodoRepository
{
    private TodoListDbContext _dbContext;

    public TodoRepository( TodoListDbContext dbContext )
    {
        _dbContext = dbContext;
    }

    public List<Todo> GetTodos()
    {
        return _dbContext.Set<Todo>().ToList();
    }

    public Todo Get( int id )   
    {
        return _dbContext.Set<Todo>().FirstOrDefault( el => el.Id == id );
    }

    public void Create( Todo todo )
    {
        _dbContext.Add( todo );
    }

    public void Update( Todo todo )
    {
        _dbContext.Update( todo );
    }

    public void Delete( int todoId )
    {
        var todo = Get( todoId );
        _dbContext.Remove( todo );
    }
}
