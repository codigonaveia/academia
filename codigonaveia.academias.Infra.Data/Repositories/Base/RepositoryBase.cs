using codigonaveia.academias.Domain.Intefaces.Base;
using codigonaveia.academias.Infra.Data.Contexto;
using Microsoft.EntityFrameworkCore;

namespace codigonaveia.academias.Infra.Data.Repositories.Base
{
    public class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : class
    {
        private readonly DataContexto _contexto;

        public RepositoryBase(DataContexto contexto)
        {
            _contexto = contexto;
        }
       
        public async Task Delete(int Id)
        {
            var entity = await GetById(Id);
            _contexto.Set<TEntity>().Remove(entity);
            await _contexto.SaveChangesAsync();
        }
        public async Task<IEnumerable<TEntity>> GetAll()
        {
            return await _contexto.Set<TEntity>().AsTracking().ToListAsync();
        }

        public async Task<TEntity> GetById(int Id)
        {
            return await _contexto.Set<TEntity>().FindAsync(Id);
        }

        public async Task Insert(TEntity entity)
        {
            await _contexto.Set<TEntity>().AddAsync(entity);
            await _contexto.SaveChangesAsync();
        }

        public async Task Update(int Id, TEntity entity)
        {
            _contexto.Set<TEntity>().Update(entity);
            await _contexto.SaveChangesAsync();
        }

        public void Dispose()
        {
            _contexto.Dispose();
        }
    }
}
