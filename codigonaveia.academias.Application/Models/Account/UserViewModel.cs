using System.ComponentModel.DataAnnotations;

namespace codigonaveia.academias.Application.Models.Account
{
    public class UserViewModel
    {
        [Display(Name ="Primeiro Nome")]
        [Required (ErrorMessage = "O Primeiro nome é obrigatório")]
        public string? FirstName { get; set; }

        [Display(Name = "Último Nome")]
        [Required(ErrorMessage = "O Segundo nome é obrigatório")]
        public string? LastName { get; set; }

        [Display(Name = "E-mail")]
        [EmailAddress(ErrorMessage ="E-mail invalido")]
        [Required(ErrorMessage = "O E-mail é obrigatório")]
        public string? Email { get; set; }

        [Display(Name = "Usuário")]
        [Required(ErrorMessage = "O Usuário é obrigatório")]
        public string? UserName { get; set; }

        [Display(Name = "Senha")]
        [DataType(DataType.Password)]
        [Required(ErrorMessage = "O Senha é obrigatório")]
        public string? Password { get; set; }

        [Display(Name = "Confirme a Senha")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage ="As senhas não conferem")]
        [Required(ErrorMessage = "Confirme a senha é obrigatório")]
        public string? ConfirmPassword { get; set; }

    }
}
