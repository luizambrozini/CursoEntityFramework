using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Ecomerce.Data
{
    [Table("EnderecosEntrega")]
    [Index(nameof(CEP), IsUnique = true)]
    [Index(nameof(CEP))]
    public class EnderecoEntrega
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(200)]
        public string NomeEndereco { get; set; } = string.Empty;
        [MaxLength(20)]
        public string CEP { get; set; } = string.Empty;
        [MaxLength(2)]
        public string Estado { get; set; } = string.Empty;
        [MaxLength(200)]
        public string Cidade { get; set; } = string.Empty;
        [MaxLength(100)]
        public string Bairro { get; set; } = string.Empty;
        [MaxLength(200)]
        public string Endereco { get; set; } = string.Empty;
        [MaxLength(20)]
        public string? Numero { get; set; } = null;
        [MaxLength(100)]
        public string? Complemento { get; set; } = null;
        public int UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }
    }
}
