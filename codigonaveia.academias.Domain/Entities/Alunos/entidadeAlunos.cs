using codigonaveia.academias.Domain.Entities.Account;
using codigonaveia.academias.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace codigonaveia.academias.Domain.Entities.Alunos
{
    public class entidadeAlunos:Endereco
    {
        [Key]
        public int IdAlunos { get; set; }
        public byte[]? FotoAvatar { get; set; }
        public DateTime DataRegistro { get; set; }
        public string? CPF { get; set; }
        public string? Celular { get; set; }
        public string? Email { get; set; }
        public DateTime DataNascimento { get; set; }
        public string? UserId { get; set; }
        public Users? Users { get; set; }
    }
}
