using codigonaveia.academias.Domain.Entities.Alunos;
using codigonaveia.academias.Domain.Intefaces;
using codigonaveia.academias.Infra.Data.Contexto;
using codigonaveia.academias.Infra.Data.Repositories.Base;

namespace codigonaveia.academias.Infra.Data.Repositories
{
    public class AlunosRepository : RepositoryBase<entidadeAlunos>, IAlunosRepository
    {
        private readonly DataContexto _contexto;

        public AlunosRepository(DataContexto contexto) : base(contexto)
        {
            _contexto = contexto;
        }

        public async Task<IEnumerable<entidadeAlunos>> GetByName(string Nome)
        {
            if (Nome == null)
            {
                throw new ArgumentNullException(nameof(Nome));
            }
            return await _contexto.Set<entidadeAlunos>().Include(x => x.Users.FirstName == Nome).ToListAsync();

        }
    }
}
