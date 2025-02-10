using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace webcarsAPI.Dominio.Entidades
{
    public class Veiculo
    {
        [Key]
        public Guid Id { get; set; }
        [Required]
        [StringLength(100)]
        public string? Marca { get; set; }
        [Required]
        [StringLength(100)]
        public string? Modelo { get; set; }
        [Required]
        public int? Ano { get; set; }
        [Required]
        [StringLength(100)]
        public string? Placa { get; set; }
        [Required]
        [StringLength(100)]
        public string? Cor { get; set; }
        [Required]
        [StringLength(100)]
        public string? Combustivel { get; set; }
        [Required]
        [StringLength(100)]
        public string? Quilometragem { get; set; }
        [Required]
        [StringLength(30)]
        public string? Chassi { get; set; }
        [Required]
        [StringLength(100)]
        public string? Cidade { get; set; }
        [StringLength(1000)]
        public string? Descricao { get; set; }
        [Required]
        [StringLength(11)]
        public string? Telefone { get; set; }
        [Required]
        [StringLength(11)]
        public string? Renavam { get; set; }
        [Required]
        [Column(TypeName = "decimal(18, 2)")]
        public decimal Valor { get; set; }
        [StringLength(100)]
        public string? Imagem { get; set; }
        public Guid UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }
    }
}