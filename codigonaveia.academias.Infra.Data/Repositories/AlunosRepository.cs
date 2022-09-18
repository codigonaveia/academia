using codigonaveia.academias.Domain.Entities.Alunos;
using codigonaveia.academias.Domain.Intefaces;
using codigonaveia.academias.Infra.Data.Contexto;
using codigonaveia.academias.Infra.Data.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace codigonaveia.academias.Infra.Data.Repositories
{
    public class AlunosRepository : RepositoryBase<entidadeAlunos>, IAlunosRepository
    {
        private readonly DataContexto _contexto;

        public AlunosRepository(DataContexto contexto) : base(contexto)
        {
            _contexto = contexto;
        }

        public async Task<IEnumerable<entidadeAlunos>> GetAlunos()
        {

            return await _contexto.Set<entidadeAlunos>().AsNoTracking().ToListAsync(); ;



        }
    }
}
