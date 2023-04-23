using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SyntaxMedical.web.Data;

namespace SyntaxMedical.web.Controllers
{
    public class ParishesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ParishesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Parishes
        public async Task<IActionResult> Index()
        {
              return _context.Parishes != null ? 
                          View(await _context.Parishes.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.Parishes'  is null.");
        }

        // GET: Parishes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Parishes == null)
            {
                return NotFound();
            }

            var parish = await _context.Parishes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (parish == null)
            {
                return NotFound();
            }

            return View(parish);
        }

        // GET: Parishes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Parishes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,ParishName")] Parish parish)
        {
            if (ModelState.IsValid)
            {
                _context.Add(parish);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(parish);
        }

        // GET: Parishes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Parishes == null)
            {
                return NotFound();
            }

            var parish = await _context.Parishes.FindAsync(id);
            if (parish == null)
            {
                return NotFound();
            }
            return View(parish);
        }

        // POST: Parishes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,ParishName")] Parish parish)
        {
            if (id != parish.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(parish);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ParishExists(parish.Id))
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
            return View(parish);
        }

        // GET: Parishes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Parishes == null)
            {
                return NotFound();
            }

            var parish = await _context.Parishes
                .FirstOrDefaultAsync(m => m.Id == id);
            if (parish == null)
            {
                return NotFound();
            }

            return View(parish);
        }

        // POST: Parishes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Parishes == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Parishes'  is null.");
            }
            var parish = await _context.Parishes.FindAsync(id);
            if (parish != null)
            {
                _context.Parishes.Remove(parish);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ParishExists(int id)
        {
          return (_context.Parishes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
