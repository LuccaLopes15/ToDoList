namespace ToDoList.Shared.Domain.Common.Base;

public interface IRepository<TEntity> where TEntity : Entity
{
    Task Add(TEntity entity);
    Task Update(TEntity entity);
    Task Delete(TEntity entity);
    Task<TEntity> Get(Guid id);
}
