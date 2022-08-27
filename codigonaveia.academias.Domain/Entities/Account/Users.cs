using codigonaveia.academias.Domain.Entities.Alunos;
using Microsoft.AspNetCore.Identity;
namespace codigonaveia.academias.Domain.Entities.Account
{
    public class Users:IdentityUser
    {
        
        public string? FirstName { get; set; }
        public string? LastName { get; set; }  
        public entidadeAlunos? Alunos { get; set; }
        
    }
}
