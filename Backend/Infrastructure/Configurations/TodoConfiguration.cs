using TodoList.Application.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace TodoList.Infrastructure.Configurations;

public class TodoConfiguration : IEntityTypeConfiguration<Todo>
{
    public void Configure( EntityTypeBuilder<Todo> builder )
    {
        builder.HasKey( x => x.Id );
        builder.Property( x => x.Title );
        builder.Property( x => x.IsDone );
    }

}
