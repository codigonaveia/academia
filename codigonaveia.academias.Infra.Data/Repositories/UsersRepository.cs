using codigonaveia.academias.Domain.Entities.Account;
using codigonaveia.academias.Domain.Intefaces;
using codigonaveia.academias.Infra.Data.Contexto;
using codigonaveia.academias.Infra.Data.Repositories.Base;

namespace codigonaveia.academias.Infra.Data.Repositories
{
    public class UsersRepository: RepositoryBase<Users>, IUsersRepository
    {
        private readonly DataContexto _contexto;  
        public UsersRepository(DataContexto contexto):base(contexto)
        {
            _contexto = contexto;
        }

        
    }
}
