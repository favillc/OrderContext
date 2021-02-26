using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace OrderContext.Models
{
    public class Order
    {
        private List<OrderItem> OrderItems = new List<OrderItem>();
        [Key]
        public int Id { get; set; }

        public string Number { get; set; }

        [Required(ErrorMessage = "Este é um campo obrigatório")]
        [Range(1, int.MaxValue, ErrorMessage = "Cliente inválido.")]
        public int CustomerId { get; set; }

        public Customer Customer { get; set; }

        public List<OrderItem> YourOrder
        {
            get { return OrderItems; }
            set { OrderItems = value; }
        }
    }
}