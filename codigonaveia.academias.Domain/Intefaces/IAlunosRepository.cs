using codigonaveia.academias.Domain.Entities.Alunos;
using codigonaveia.academias.Domain.Intefaces.Base;

namespace codigonaveia.academias.Domain.Intefaces
{
    public interface IAlunosRepository : IRepositoryBase<entidadeAlunos>
    {
        Task<IEnumerable<entidadeAlunos>> GetAlunos();
    }
}
