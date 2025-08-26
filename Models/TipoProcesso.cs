using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SisJur.Models
{
    [Table("tipoprocessos")]
    public class TipoProcesso
    {
        [Display]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Display(Name = "Descrição")]
        [Required(ErrorMessage = "O campo Descrição é obrigatório.")]
        [StringLength(25, ErrorMessage ="Tamanho do campo tem que ser menor que 25 caracteres")]
        public string descricao { get; set; }

        [Display(Name = "Processos")]
        public List<Processo> listaProcessos { get; set; }


    }
}
