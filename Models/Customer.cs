using System.ComponentModel.DataAnnotations;

namespace OrderContext.Models
{
    public class Customer
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Este é um campo obrigatório")]
        [MaxLength(60, ErrorMessage = "Este campo deve ter de 3 a 60 caracteres")]
        [MinLength(3, ErrorMessage = "Este campo deve ter de 3 a 60 caracteres")]
        public string Name { get; set; }

        [MaxLength(250, ErrorMessage = "Este campo deve ter até 250 caracteres")]
        public string Address { get; set; }

        [MaxLength(50, ErrorMessage = "Este campo deve ter até 50 caracteres")]
        public string City { get; set; }

        [MaxLength(20, ErrorMessage = "Este campo deve ter até 50 caracteres")]
        public string ZipCode { get; set; }

        [Required(ErrorMessage = "Este é um campo obrigatório")]
        [MaxLength(60, ErrorMessage = "Este campo deve ter de 3 a 60 caracteres")]
        [MinLength(3, ErrorMessage = "Este campo deve ter de 3 a 60 caracteres")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Este é um campo obrigatório")]
        [MaxLength(20, ErrorMessage = "Este campo deve ter de 8 a 20 caracteres")]
        [MinLength(8, ErrorMessage = "Este campo deve ter de 8 a 20 caracteres")]
        public string Password { get; set; }




    }
}