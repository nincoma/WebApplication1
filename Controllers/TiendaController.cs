﻿using System;
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
    public class TiendaController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TiendaController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Tienda
        public async Task<IActionResult> Index()
        {
            return View(await _context.Tiendas.ToListAsync());
        }

        // GET: Tienda/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tienda = await _context.Tiendas
                .FirstOrDefaultAsync(m => m.IdTienda == id);
            if (tienda == null)
            {
                return NotFound();
            }

            return View(tienda);
        }

        // GET: Tienda/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Tienda/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("IdTienda,Nombre,Rut,Direccion,Telefono,Activo,FechaRegistro")] Tienda tienda)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tienda);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tienda);
        }

        // GET: Tienda/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tienda = await _context.Tiendas.FindAsync(id);
            if (tienda == null)
            {
                return NotFound();
            }
            return View(tienda);
        }

        // POST: Tienda/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("IdTienda,Nombre,Rut,Direccion,Telefono,Activo,FechaRegistro")] Tienda tienda)
        {
            if (id != tienda.IdTienda)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tienda);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TiendaExists(tienda.IdTienda))
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
            return View(tienda);
        }

        // GET: Tienda/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tienda = await _context.Tiendas
                .FirstOrDefaultAsync(m => m.IdTienda == id);
            if (tienda == null)
            {
                return NotFound();
            }

            return View(tienda);
        }

        // POST: Tienda/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tienda = await _context.Tiendas.FindAsync(id);
            _context.Tiendas.Remove(tienda);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TiendaExists(int id)
        {
            return _context.Tiendas.Any(e => e.IdTienda == id);
        }
    }
}
