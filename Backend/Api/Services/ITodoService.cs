using TodoList.Api.Dto;

namespace TodoList.Api.Services;

public interface ITodoService
{
    IEnumerable<TodoDto> GetTodos();

    /// <summary>
    /// Get task dto object by its id
    /// </summary>
    TodoDto GetTodo( int todoId );

    /// <summary>
    /// Registers new task
    /// </summary>
    /// <returns>Returns Id of new task</returns>
    void CreateTodo( TodoDto todo );

    /// <summary>
    /// Mark the task as completed
    /// </summary>
    /// <returns>Retruns false if task wasn't marked</returns>
    void CompleteTodo( int todoId );

    /// <summary>
    /// Delete task by id
    /// </summary>
    void DeleteTodo( int todoId );
}
