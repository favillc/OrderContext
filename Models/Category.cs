using System.ComponentModel.DataAnnotations;

namespace OrderContext.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Este é um campo obrigatório")]
        [MaxLength(60, ErrorMessage = "Este campo deve ter de 3 a 60 caracteres")]
        [MinLength(3, ErrorMessage = "Este campo deve ter de 3 a 60 caracteres")]
        public string Title { get; set; }
    }
}