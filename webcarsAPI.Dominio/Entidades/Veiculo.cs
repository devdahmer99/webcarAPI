using System.ComponentModel.DataAnnotations;

namespace webcarsAPI.Dominio.Entidades
{
    public class Veiculo
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [StringLength(100)]
        public string? Marca { get; set; }
        [Required]
        [StringLength(100)]
        public string? Modelo { get; set; }
        [Required]
        [StringLength(100)]
        [DataType(DataType.Date)]
        public string? Ano { get; set; }
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
        [StringLength(100)]
        public string? Valor { get; set; }
        [Required]
        [StringLength(100)]
        public string? Imagem { get; set; }

        public int UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }
    }
}
