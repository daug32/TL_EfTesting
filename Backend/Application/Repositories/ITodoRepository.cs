using TodoList.Application.Models;

namespace TodoList.Application.Repositories;

public interface ITodoRepository
{
    /// <summary>
    /// Returns all task from database
    /// </summary>
    IEnumerable<Todo> GetTodos();

    /// <summary>
    /// Returns task by its id or default
    /// </summary>
    Todo Get( int id );

    /// <summary>
    /// Creates new task in the database
    /// </summary>
    void Create( Todo todo );

    /// <summary>
    /// Updates task in the database
    /// </summary>
    void Update( Todo todo );

    /// <summary>
    /// Deletes task from database
    /// </summary>
    void Delete( int todo );
}
