namespace TodoList.Application.Models;

public class Todo
{
    public int Id { get; set; }
    public string Title { get; set; }
    public bool IsDone { get; set; }

    public Todo() : this( "" ) { }

    public Todo( string title )
    {
        Id = 0;
        Title = title;
        IsDone = false;
    }
}
