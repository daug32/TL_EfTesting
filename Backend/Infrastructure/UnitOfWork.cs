using TodoList.Api;

namespace TodoList.Infrastructure;

public class UnitOfWork : IUnitOfWork
{
    private TodoListDbContext _dbContext;

    public UnitOfWork( TodoListDbContext dbContext )
    {
        _dbContext = dbContext;
    }

    public void Commit()
    {
        _dbContext.SaveChanges();
    }
}
