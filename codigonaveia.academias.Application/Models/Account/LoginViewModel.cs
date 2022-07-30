using System.ComponentModel.DataAnnotations;

namespace codigonaveia.academias.Application.Models.Account
{
    public class LoginViewModel
    {

        [Display(Name = "Usuário")]
        [Required(ErrorMessage = "O Usuário é obrigatório")]
        public string? UserName { get; set; }

        [Display(Name = "Senha")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "O Senha é obrigatório")]
        public string? Password { get; set; }
    }
}
