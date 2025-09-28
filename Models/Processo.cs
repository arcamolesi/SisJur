using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;



namespace SisJur.Models
{
    [Table("processos")]
    public class Processo
    {
        public enum Status { Ativo, Suspenso, Arquivado}

        [Display(Name = "ID")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Display(Name = "Descrição")]
        [StringLength(50, MinimumLength = 15)]
        public string descricao { get; set; }

        [Display(Name = "Entrada")]
        [DataType(DataType.DateTime)]
        public DateTime entrada { get; set; }
        
        [Display(Name = "TipoProcesso")]
        public int tipoprocessoid { get; set; }


        [ForeignKey("tipoprocessoid")]
        public virtual TipoProcesso tipoprocesso { get; set; }

        [Display(Name = "Status")]
        public Status status { get; set; }
        
        [Display(Name = "Varas")]
        List<Vara> listaVaras { get; set; } = new List<Vara>();

    }
}
