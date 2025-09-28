using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SisJur.Models
{
    [Table("areas")]
    public class Area
    {
        [Display(Name = "ID")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get ; set; }

        [Display(Name = "DESCRIÇÃO")]
        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        [StringLength(25)]
        public string descricao { get; set; }

        [Display(Name = "Advogados")]
        public List<Advogado> advogados { get; set; }


    }
}
