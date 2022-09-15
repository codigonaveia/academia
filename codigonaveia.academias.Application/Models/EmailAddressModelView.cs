using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace codigonaveia.academias.Application.Models
{
    [Table("EmailServices")]
    public class EmailAddressModelView
    {
        [Required]
        public string? From { get; set; }
        [Required]
        public string? To { get; set; }
        [Required]
        public string? Subject { get; set; }
        [Required]
        public string? Body { get; set; }
    }
}
