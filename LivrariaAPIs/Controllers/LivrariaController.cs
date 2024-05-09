using LivrariaAPIs.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LivrariaAPIs.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivrariaController: ControllerBase
    {
        private readonly ToDbContext _context;

        public LivrariaController(ToDbContext context)
        {
            _context = context;

            if (!_context.todoProducts.Any())
            {
                _context.todoProducts.Add(new Livro { ID = 1, Nome = "How to win friends and influence people", Preco = 159.00, Quant = 1, Categoria = "Auto", Img = "teste" });
                _context.todoProducts.Add(new Livro { ID = 2, Nome = "How to win friends and influence people II", Preco = 159.00, Quant = 1, Categoria = "Auto", Img = "teste" });
                _context.todoProducts.Add(new Livro { ID = 3, Nome = "How to win friends and influence people III", Preco = 159.00, Quant = 1, Categoria = "Auto", Img = "teste" });
                _context.todoProducts.Add(new Livro { ID = 4, Nome = "How to win friends and influence people IV", Preco = 159.00, Quant = 1, Categoria = "Auto", Img = "teste" });
                _context.todoProducts.Add(new Livro { ID = 5, Nome = "How to win friends and influence people V", Preco = 159.00, Quant = 1, Categoria = "Auto", Img = "teste" });

                _context.SaveChanges();
            }
        }


        [HttpGet] //pegar todos registros
        public async Task<ActionResult<IEnumerable<Livro>>> GetLivro()
        {
            return await _context.todoProducts.ToListAsync(); 
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Livro>> GetItem(int id)
        {
            var item = await _context.todoProducts.FindAsync(id);

            if(item == null)
            {
                return NotFound();
            }
            else
            {
                return item;
            }
        }
    }
}
