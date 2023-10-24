using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoFuncionarios.Models
{
    [Table("Escala")]
    public class Escala
    {
        [Column("EscalaId")]
        [Display(Name = "Código da Escala")]
        public int Id { get; set; }

        [Column("DescricaoEscala")]
        [Display(Name = "Descrição da Escala")]

        public string DescricaoEscala { get; set; } = string.Empty;

        [Column("HorarioEntrada")]
        [Display(Name = "Horário de Entrada")]
        public string HorarioEntrada { get; set; } = string.Empty;

        [Column("IntervaloSaida")]
        [Display(Name = "Saída para o Intervalo")]
        public string IntervaloSaida { get; set; } = string.Empty;

        [Column("IntervaloRetorno")]
        [Display(Name = "Retorno do Intervalo")]
        public string IntervaloRetorno { get; set; } = string.Empty;

        [Column("HorarioSaida")]
        [Display(Name = "Horário de Saída")]
        public string HorarioSaida { get; set; } = string.Empty;
    }
}
