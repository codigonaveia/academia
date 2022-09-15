using System.ComponentModel.DataAnnotations;

namespace codigonaveia.academias.Application.Models
{
    public class EnderecoViewModel
    {
        [Required(ErrorMessage = "Cep é obrigatório")]
        public string? Cep { get; set; }
        public string? Logradouro { get; set; }
        public string? Complemento { get; set; }
        public string? Bairro { get; set; }
        public string? Cidade { get; set; }
        public string? Uf { get; set; }
    }
}
