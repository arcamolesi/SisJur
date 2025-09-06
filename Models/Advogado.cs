using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Runtime.CompilerServices;

namespace SisJur.Models
{
    [Table("advogados")]
    public class Advogado
    {
        [Display(Name = "ID")]
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int id { get; set; }

        [Display(Name = "NOME")]
        [Column("nome", TypeName = "varchar(35)")]
        [StringLength(35, ErrorMessage = "Campo excede 35 caracteres")]
        [Required(ErrorMessage = "O campo Nome é obrigatório.")]
        public string nome { get; set; }

        [Display(Name = "CIDADE")]
        [StringLength(25, MinimumLength =5 , ErrorMessage ="tamanho entre 5 e 25 caracteres")]
        [Required(ErrorMessage = "O campo Cidade é obrigatório.")]
        public string cidade { get; set; }

        [Display(Name = "ESTADO")]
        [StringLength(2)]
        [Required(ErrorMessage = "O campo Estado é obrigatório.")]
        public string estado { get; set; }
        
        [Display(Name = "IDADE")]
        [Range(21, 110, ErrorMessage = "A idade deve estar entre 18 e 120 anos.")]
        public int idade { get; set; }

       
        public int areaid { get; set; }

        [Display(Name = "ÁREA")]
        [ForeignKey("areaid")]
        public virtual Area area { get; set; }

        [Display(Name = "Varas")]
        List<Vara> listaVaras { get; set; } = new List<Vara>();

        }
}
