using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SuperDrogueriaFenix.Models;
using WebApplication1.Data;

namespace WebApplication1.Controllers
{
    public class ProductoTiendaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ProductoTiendaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: ProductoTienda
        public async Task<IActionResult> Index()
        {
            return View(await _context.ProductoTiendas.ToListAsync());
        }

        // GET: ProductoTienda/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productoTienda = await _context.ProductoTiendas
                .FirstOrDefaultAsync(m => m.IdProductoTienda == id);
            if (productoTienda == null)
            {
                return NotFound();
            }

            return View(productoTienda);
        }

        // GET: ProductoTienda/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ProductoTienda/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdProductoTienda,IdProducto,IdTienda")] ProductoTienda productoTienda)
        {
            if (ModelState.IsValid)
            {
                _context.Add(productoTienda);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(productoTienda);
        }

        // GET: ProductoTienda/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productoTienda = await _context.ProductoTiendas.FindAsync(id);
            if (productoTienda == null)
            {
                return NotFound();
            }
            return View(productoTienda);
        }

        // POST: ProductoTienda/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdProductoTienda,IdProducto,IdTienda")] ProductoTienda productoTienda)
        {
            if (id != productoTienda.IdProductoTienda)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(productoTienda);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ProductoTiendaExists(productoTienda.IdProductoTienda))
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
            return View(productoTienda);
        }

        // GET: ProductoTienda/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var productoTienda = await _context.ProductoTiendas
                .FirstOrDefaultAsync(m => m.IdProductoTienda == id);
            if (productoTienda == null)
            {
                return NotFound();
            }

            return View(productoTienda);
        }

        // POST: ProductoTienda/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var productoTienda = await _context.ProductoTiendas.FindAsync(id);
            _context.ProductoTiendas.Remove(productoTienda);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ProductoTiendaExists(int id)
        {
            return _context.ProductoTiendas.Any(e => e.IdProductoTienda == id);
        }
    }
}
