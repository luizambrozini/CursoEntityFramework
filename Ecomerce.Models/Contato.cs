using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecomerce.Data
{
    [Table("contatos")]
    [Index(nameof(Telefone), nameof(Celular))]
    public class Contato
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(50)]
        public string? Telefone { get; set; } = null;
        [MaxLength(50)]
        public string? Celular { get; set; } = null;
        public int UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }
    }
}
