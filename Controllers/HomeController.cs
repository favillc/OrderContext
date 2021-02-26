using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OrderContext.Data;
using OrderContext.Models;

namespace OrderContext.Controllers
{
    [Route("v1")]
    public class HomeController : Controller
    {
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<dynamic>> Get([FromServices] DataContext context)
        {
            var employee = new Customer { Id = 1, Username = "Eren", Password = "tatakae" };
            var manager = new Customer { Id = 2, Username = "Sasha", Password = "Batata" };
            var category = new Category { Id = 1, Title = "Informática" };
            var product = new Product { Id = 1, Category = category, Title = "Mouse", Price = 299, Description = "Mouse Gamer" };
            context.Customers.Add(employee);
            context.Customers.Add(manager);
            context.Categories.Add(category);
            context.Products.Add(product);
            await context.SaveChangesAsync();

            return Ok(new
            {
                message = "Dados configurados"
            });
        }
    }
}