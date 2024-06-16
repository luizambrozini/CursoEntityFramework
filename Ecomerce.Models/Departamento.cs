using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecomerce.Data
{
    [Table("Departamentos")]
    public class Departamento
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(200)]
        public string? Nome { get; set; } = null;
        public IQueryable<Usuario>? Usuarios { get; set; }
    }
}
