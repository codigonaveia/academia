
namespace codigonaveia.academias.Application.Models
{
    public class entidadeAlunosViewModel
    {
        public int IdAlunos { get; set; }
        public byte[]? FotoAvatar { get; set; }
        public DateTime DataRegistro { get; set; }
        public string? CPF { get; set; }
        public string? Celular { get; set; }
        public string? Email { get; set; }
        public DateTime DataNascimento { get; set; }
        //public string? UserId { get; set; }
        //public Users? Users { get; set; }
    }
}
