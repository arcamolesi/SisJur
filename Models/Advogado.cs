using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SisJur.Models
{
    [Table("Advogados")]
    public class Advogado
    {
        [Display(Name = "ID")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Display(Name = "Nome")]
        [StringLength(35)]
        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        public string nome { get; set; }

        [Display(Name = "Cidade")]
        [StringLength(25)]
        [Required(ErrorMessage = "O campo Cidade é obrigatório.")]
        public string cidade { get; set; }

        [Display(Name = "Estado")]
        [StringLength(2)]
        [Required(ErrorMessage = "O campo Estado é obrigatório.")]
        public string estado { get; set; }
        
        [Display(Name = "Idade")]
        [Range(21, 110, ErrorMessage = "A idade deve estar entre 18 e 120 anos.")]
        public int idade { get; set; }

        [Display(Name = "Area")]
        public Area area { get; set; }

    }
}
