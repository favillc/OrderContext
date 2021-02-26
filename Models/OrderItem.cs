using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OrderContext.Models
{
    public class OrderItem
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Este é um campo obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "Categoria inválida.")]
        public int ProductId { get; set; }

        public Product Product { get; set; }



    }
}