using Microsoft.Extensions.DependencyInjection;

namespace ToDoList.Shared.Domain.Common.Base;

public class Service<TEntity, TRepository> 
    where TEntity : Entity where TRepository : IRepository<TEntity>
{
    private readonly TRepository _repository;

    public Service(IServiceProvider serviceProvider)
    {
        _repository = serviceProvider.GetRequiredService<TRepository>();
    }

    public async Task Add(TEntity entity)
    {
        await _repository.Add(entity);
    }

    public async Task Update(TEntity entity)
    {
        await _repository.Update(entity);
    }

    public async Task Delete(TEntity entity)
    {
        await _repository.Delete(entity);
    }

    public async Task<TEntity> Get(Guid id)
    {
        return await _repository.Get(id);
    }
}
