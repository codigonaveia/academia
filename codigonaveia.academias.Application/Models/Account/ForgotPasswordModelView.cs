using System.ComponentModel.DataAnnotations;

namespace codigonaveia.academias.Application.Models.Account
{
    public class ForgotPasswordModelView
    {
        [Required(ErrorMessage ="E-mail é obrigatório")]
        [EmailAddress(ErrorMessage = "E-mail invalido")]
        public string? Email { get; set; }
    }
}
