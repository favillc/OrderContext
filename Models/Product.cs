using System.ComponentModel.DataAnnotations;

namespace OrderContext.Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Este é um campo obrigatório")]
        [MaxLength(60, ErrorMessage = "Este campo deve ter de 3 a 60 caracteres")]
        [MinLength(3, ErrorMessage = "Este campo deve ter de 3 a 60 caracteres")]
        public string Title { get; set; }

        [MaxLength(250, ErrorMessage = "Este campo deve ter até 250 caracteres")]
        public string Description { get; set; }

        [Required(ErrorMessage = "Este é um campo obrigatório")]
        [Range(0.1, int.MaxValue, ErrorMessage = "Este campo não pode ser nulo")]
        public decimal Price { get; set; }

        [Required(ErrorMessage = "Este é um campo obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "Este campo não pode ser nulo")]
        public int Quantity { get; set; }

        [Required(ErrorMessage = "Este é um campo obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "Categoria inválida.")]
        public int CategoryId { get; set; }

        public Category Category { get; set; }


    }
}