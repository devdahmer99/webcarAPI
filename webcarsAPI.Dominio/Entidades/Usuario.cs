
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using webcarsAPI.Dominio.Enums;
namespace webcarsAPI.Dominio.Entidades {
    public class Usuario {

        public Usuario()
        {
            Veiculos = new Collection<Veiculo>();
        }

        [Key]
        public int Id { get; set; }
        [Required]
        public string? Nome { get; set; }
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        public string? Senha { get; set; }

        public Guid Identificador { get; set; } = Guid.NewGuid();

        [Required]
        public string Permissao { get; set; } = Permissoes.Usuario;

        public ICollection<Veiculo>? Veiculos { get; set; }
    }
}