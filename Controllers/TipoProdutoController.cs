using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SistemaDeProdutos.Data;
using SistemaDeProdutos.Models;

namespace SistemaDeProdutos.Controllers
{
    public class TipoProdutoController : Controller
    {
        private readonly TipoProdutoContext _context;

        public TipoProdutoController(TipoProdutoContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            return View(await _context.TipoProdutos.ToListAsync());
        }

        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoProduto = await _context.TipoProdutos
                .FirstOrDefaultAsync(m => m.IdTipo == id);
            if (tipoProduto == null)
            {
                return NotFound();
            }

            return View(tipoProduto);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTipo,DescricaoTipo,StringToBool")] TipoProduto tipoProduto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoProduto);
                await _context.SaveChangesAsync();
                TempData["mensagem"] = "Produto cadastrado com sucesso!";
                return RedirectToAction(nameof(Index));
            }
            return View(tipoProduto);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoProduto = await _context.TipoProdutos.FindAsync(id);
            if (tipoProduto == null)
            {
                return NotFound();
            }
            return View(tipoProduto);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTipo,DescricaoTipo,StringToBool")] TipoProduto tipoProduto)
        {
            if (id != tipoProduto.IdTipo)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoProduto);
                    await _context.SaveChangesAsync();
                    TempData["mensagem"] = "Produto alterado com sucesso!";
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoProdutoExists(tipoProduto.IdTipo))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(tipoProduto);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var tipoProduto = await _context.TipoProdutos.FindAsync(id);
            _context.TipoProdutos.Remove(tipoProduto);
            await _context.SaveChangesAsync();
            TempData["mensagem"] = "Produto deletado com sucesso!";
            return RedirectToAction(nameof(Index));
        }

        private bool TipoProdutoExists(int id)
        {
            return _context.TipoProdutos.Any(e => e.IdTipo == id);
        }
    }
}
