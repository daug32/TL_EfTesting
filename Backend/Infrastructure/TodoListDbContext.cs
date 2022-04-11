using Microsoft.EntityFrameworkCore;
using TodoList.Infrastructure.Configurations;

namespace TodoList.Infrastructure;

public class TodoListDbContext : DbContext
{
    public TodoListDbContext( DbContextOptions options ) : base( options )
    {
    }

    protected override void OnModelCreating( ModelBuilder modelBuilder )
    {
        modelBuilder.ApplyConfiguration( new TodoConfiguration() );
    }
}
