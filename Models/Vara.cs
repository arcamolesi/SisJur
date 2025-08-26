using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SisJur.Models
{
    [Table("varas")]
    public class Vara
    {
        [Display(Name = "ID")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }
        
        [Display(Name = "Processo")]
        public int processoid { get; set; }

        [Display(Name = "Processo")]
        [ForeignKey("processoid")]
        public virtual Processo Processo { get; set; }


        [Display(Name = "Advogado")]    
        public int advogadoid { get; set; }

        [Display(Name = "Advogado")]
        [ForeignKey("advogadoid")]
        public virtual Advogado Advogado { get; set; }

        [Display(Name = "Juiz")]
        [StringLength(35, MinimumLength = 5, ErrorMessage = "Tamanho entre 5 e 35 caracteres")]
        public string juiz { get; set; }

        [Display(Name = "Valor da Causa")]
        [DataType(DataType.Currency)]
        [DisplayFormat(DataFormatString = "{0:C2}", ApplyFormatInEditMode = false)]
        public float valorcausa { get; set; }

    }
}
