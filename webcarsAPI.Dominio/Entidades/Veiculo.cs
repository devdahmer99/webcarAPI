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
        [StringLength(4)]
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
        [StringLength(9)]
        public string? Chassi { get; set; }

        [Required]
        [StringLength(100)]
        public string? Cidade { get; set; }

        [Required]
        [StringLength(1000)]
        public string? Descricao { get; set; }

        [Required]
        [StringLength(11)]
        public string? Telefone { get; set; }

        [Required]
        [StringLength(11)]
        public string? Renavam { get; set; }
        [Required]
        public decimal Valor { get; set; }
        [StringLength(100)]
        public byte[]? Imagem { get; set; }
        public int UsuarioId { get; set; }
        public Usuario? Usuario { get; set; }
    }
}
