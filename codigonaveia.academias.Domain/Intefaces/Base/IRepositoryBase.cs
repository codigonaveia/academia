namespace codigonaveia.academias.Domain.Intefaces.Base
{
    public interface IRepositoryBase<TEntity> where TEntity : class
    {
        Task Insert(TEntity entity);
        Task Update(int Id, TEntity entity);
        Task<TEntity> GetById(int Id);
        Task<IEnumerable<TEntity>> GetAll();
        Task Delete(int Id);
    }
}
