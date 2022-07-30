using System.ComponentModel.DataAnnotations;

namespace codigonaveia.academias.Application.Models.Account
{
    public class ResetPasswordViewModel
    {
        public string? Token { get; set; }
        public string? Email { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage ="A Senha é obrigatória")]
        public string? Password { get; set; }

        [DataType(DataType.Password)]
        [Required(ErrorMessage = "Confirme senha é obrigatória")]
        [Compare("Password", ErrorMessage ="As senhas não são iguais")]
        public string? ConfirmPassword { get; set; }
    }
}
