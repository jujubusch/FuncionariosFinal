using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ProjetoFuncionarios.Models
{
    [Table("Ponto")]
    public class Ponto
    {
        [Column("PontoId")]
        [Display(Name = "Código do Ponto")]
        public int Id { get; set; }

        [Column("HorarioEntrada")]
        [Display(Name = "Horário de Entrada")]
        public DateTime HorarioEntrada { get; set; }

        [Column("SaidaAlmoco")]
        [Display(Name = "Saída para o Almoço")]
        public DateTime SaidaAlmoco { get; set; }

        [Column("VoltaAlmoco")]
        [Display(Name = "Volta do Almoço")]
        public DateTime VoltaAlmoco { get; set; }

        [Column("HorarioSaida")]
        [Display(Name = "Horário de Saída")]
        public DateTime HorarioSaida { get; set; }

        [Column("Data")]
        [Display(Name = "Data")]
        public double Data { get; set; }

        [ForeignKey("FuncionarioId")]
        public int FuncionarioId { get; set; }

        public Funcionario? Funcionario { get; set; }
    }
}
