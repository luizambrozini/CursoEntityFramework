using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecomerce.Data
{
    [Table("Usuarios")]
    [Index(nameof(CPF), nameof(RG), IsUnique = true)]
    [Index(nameof(CPF), nameof(Nome))]
    public class Usuario
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(200)]
        public string Nome { get; set; } = string.Empty;
        [MaxLength(150)]
        public string Email { get; set; } = string.Empty;
        [MaxLength(1)]
        public string? Sexo { get; set; } = null;
        [MaxLength(15)]
        public string? RG { get; set; } = null;
        [Required]
        public string CPF { get; set; } = string.Empty;
        [MaxLength(200)]
        public string? Mae { get; set; } = null;
        [MaxLength(1)]
        public string? SituacaoCadastro { get; set; } = null;
        public DateTimeOffset DataCadastro { get; set; }
        public Contato? Contato { get; set; } = null;
        public IQueryable<EnderecoEntrega>? EnderecoEntrega { get; set; } = null;
        public IQueryable<Departamento>? Departamento { get; set; } = null;
    }
}
