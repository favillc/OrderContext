using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using OrderContext.Data;
using OrderContext.Models;

namespace OrderContext.Controllers
{
    [Route("categories")]
    public class CategoryController : ControllerBase
    {
        [HttpGet]
        [Route("")]
        [AllowAnonymous]
        [ResponseCache(VaryByHeader = "User-Agent", Location = ResponseCacheLocation.Any, Duration = 30)]
        public async Task<ActionResult<List<Category>>> Get(
            [FromServices] DataContext context
        )
        {
            //Para exibição na tela, o AsNoTracking não utiliza proxy
            var categories = await context.Categories.AsNoTracking().ToListAsync();
            return Ok(categories);
        }

        [HttpGet]
        [Route("{id:int}")]
        [AllowAnonymous]
        public async Task<ActionResult<Category>> GetById(
            int id,
            [FromServices] DataContext context
            )
        {
            var category = await context.Categories.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            return Ok(category);
        }
        //Metodo post (adicionar elementos ao banco)
        [HttpPost]
        [Route("")]
        [Authorize(Roles = "employee")]
        public async Task<ActionResult<Category>> Post(
            [FromServices] DataContext context,
            [FromBody] Category model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            //Adicionar categorias
            try
            {
                context.Categories.Add(model);
                await context.SaveChangesAsync();
                return Ok(model);

            }
            catch (Exception)
            {
                return BadRequest(new { message = "Não foi possível adicionar ao banco" });
            }
        }

        //Método put (atualizar elementos do banco)
        [HttpPut]
        [Route("{id:int}")]
        [Authorize(Roles = "employee")]
        public async Task<ActionResult<Category>> Put(
            int id,
            [FromServices] DataContext context,
            [FromBody] Category model)
        {
            //Verifica se o id informado é o mesmo do modelo
            if (model.Id != id)
                return NotFound(new { message = "Categoria não encontrada." });
            //Verifica se os dados são válidos
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            //Tratamento de erros (exceções são sempre da mais específica para a mais genérica)
            try
            {
                context.Entry<Category>(model).State = EntityState.Modified;
                await context.SaveChangesAsync();
                return model;
            }
            catch (DbUpdateConcurrencyException)
            {
                return BadRequest(new { message = "Registro já atualizado..." });
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Não foi possível atualizar categoria." });
            }
        }

        //Método delete (excluindo uma categoria)
        [HttpDelete]
        [Route("{id:int}")]
        [Authorize(Roles = "employee")]
        public async Task<ActionResult<Category>> Delete(
            int id,
            [FromServices] DataContext context
        )
        {
            //Recuperar a categoria do banco
            var category = await context.Categories.FirstOrDefaultAsync(x => x.Id == id);
            //Se não encontrar nada
            if (category == null)
                return NotFound(new { message = "Categoria não encontrada ou inexistente." });
            //Tratamento de erros e exceções
            try
            {
                context.Categories.Remove(category);
                await context.SaveChangesAsync();
                return Ok(new { message = "Categoria removida!" });
            }
            catch (Exception)
            {
                return BadRequest(new { message = "Não foi possível efetuar a remoção da categoria." });
            }
        }
    }
}