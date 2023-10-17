using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoFuncionarios.Models
{
    [Table("Cargo")]
    public class Cargo
    {
        [Column("CargoId")]
        [Display(Name = "Código do Cargo")]
        public int Id { get; set; }

        [Column("DecricaoCargo")]
        [Display(Name = "Descrição do Cargo")]
        public string DecricaoCargo { get; set; } = string.Empty;

        [Column("SalarioCargo")]
        [Display(Name = "Salário do Cargo")]
        public string SalarioCargo { get; set; } = string.Empty;

        [ForeignKey("EscalaId")]
        public int EscalaId { get; set; }

        public Escala? Escala { get; set; }
    }
}
