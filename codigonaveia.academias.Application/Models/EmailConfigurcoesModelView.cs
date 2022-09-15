using System.ComponentModel.DataAnnotations;

namespace codigonaveia.academias.Application.Models
{
   
    public class EmailConfigurcoesModelView
    {
        [Required(ErrorMessage = "Servidor de saída de e-mails (SMTP) é obrigatório")]
        public string? Smtp { get; set; }
        [Required]
        public int Port { get; set; }
        [Required]
        public string? EmailUser{ get; set; }
       
    }
}
