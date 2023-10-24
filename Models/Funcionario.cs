using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace FuncionariosFinal.Models
{
    [Table("Funcionario")]
    public class Funcionario
    {

        [Column("FuncionarioId")]
        [Display(Name = "Código do Funcionário")]
        public int Id { get; set; }

        [Column("NomeFuncionario")]
        [Display(Name = "Nome do Funcionário")]
        public string NomeFuncionario { get; set; } = string.Empty;

        [ForeignKey("CargoId")]
        public int CargoId { get; set; }

        public Cargo? Cargo { get; set; }
    }
}

