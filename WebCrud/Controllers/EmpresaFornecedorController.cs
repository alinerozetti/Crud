using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebCrud.Models;

namespace WebCrud.Controllers
{
    public class EmpresaFornecedorController : Controller
    {
        private readonly Contexto _context;

        public EmpresaFornecedorController(Contexto context)
        {
            _context = context;
        }

        // GET: EmpresaFornecedor
        public async Task<IActionResult> Index()
        {
            var contexto = _context.EmpresaFornecedor.Include(e => e.Empresa).Include(e => e.Fornecedor);
            return View(await contexto.ToListAsync());
        }

        // GET: EmpresaFornecedor/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.EmpresaFornecedor == null)
            {
                return NotFound();
            }

            var empresaFornecedor = await _context.EmpresaFornecedor
                .Include(e => e.Empresa)
                .Include(e => e.Fornecedor)
                .FirstOrDefaultAsync(m => m.Id_Empresa == id);
            if (empresaFornecedor == null)
            {
                return NotFound();
            }

            return View(empresaFornecedor);
        }

        // GET: EmpresaFornecedor/Create
        public IActionResult Create()
        {
            ViewData["Id_Empresa"] = new SelectList(_context.Empresa, "Id", "Id");
            ViewData["Id_Fornecedor"] = new SelectList(_context.Fornecedor, "Id", "Id");
            return View();
        }

        // POST: EmpresaFornecedor/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id_Empresa,Id_Fornecedor")] EmpresaFornecedor empresaFornecedor)
        {
            if (ModelState.IsValid)
            {
                _context.Add(empresaFornecedor);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["Id_Empresa"] = new SelectList(_context.Empresa, "Id", "Id", empresaFornecedor.Id_Empresa);
            ViewData["Id_Fornecedor"] = new SelectList(_context.Fornecedor, "Id", "Id", empresaFornecedor.Id_Fornecedor);
            return View(empresaFornecedor);
        }

        // GET: EmpresaFornecedor/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.EmpresaFornecedor == null)
            {
                return NotFound();
            }

            var empresaFornecedor = await _context.EmpresaFornecedor.FindAsync(id);
            if (empresaFornecedor == null)
            {
                return NotFound();
            }
            ViewData["Id_Empresa"] = new SelectList(_context.Empresa, "Id", "Id", empresaFornecedor.Id_Empresa);
            ViewData["Id_Fornecedor"] = new SelectList(_context.Fornecedor, "Id", "Id", empresaFornecedor.Id_Fornecedor);
            return View(empresaFornecedor);
        }

        // POST: EmpresaFornecedor/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id_Empresa,Id_Fornecedor")] EmpresaFornecedor empresaFornecedor)
        {
            if (id != empresaFornecedor.Id_Empresa)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(empresaFornecedor);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmpresaFornecedorExists(empresaFornecedor.Id_Empresa))
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
            ViewData["Id_Empresa"] = new SelectList(_context.Empresa, "Id", "Id", empresaFornecedor.Id_Empresa);
            ViewData["Id_Fornecedor"] = new SelectList(_context.Fornecedor, "Id", "Id", empresaFornecedor.Id_Fornecedor);
            return View(empresaFornecedor);
        }

        // GET: EmpresaFornecedor/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.EmpresaFornecedor == null)
            {
                return NotFound();
            }

            var empresaFornecedor = await _context.EmpresaFornecedor
                .Include(e => e.Empresa)
                .Include(e => e.Fornecedor)
                .FirstOrDefaultAsync(m => m.Id_Empresa == id);
            if (empresaFornecedor == null)
            {
                return NotFound();
            }

            return View(empresaFornecedor);
        }

        // POST: EmpresaFornecedor/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.EmpresaFornecedor == null)
            {
                return Problem("Entity set 'Contexto.EmpresaFornecedor'  is null.");
            }
            var empresaFornecedor = await _context.EmpresaFornecedor.FindAsync(id);
            if (empresaFornecedor != null)
            {
                _context.EmpresaFornecedor.Remove(empresaFornecedor);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmpresaFornecedorExists(int id)
        {
          return (_context.EmpresaFornecedor?.Any(e => e.Id_Empresa == id)).GetValueOrDefault();
        }
    }
}
