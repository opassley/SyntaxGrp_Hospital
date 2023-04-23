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
    public class EmergencyRelationshipsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmergencyRelationshipsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EmergencyRelationships
        public async Task<IActionResult> Index()
        {
              return _context.EmergencyRelationships != null ? 
                          View(await _context.EmergencyRelationships.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.EmergencyRelationships'  is null.");
        }

        // GET: EmergencyRelationships/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.EmergencyRelationships == null)
            {
                return NotFound();
            }

            var emergencyRelationship = await _context.EmergencyRelationships
                .FirstOrDefaultAsync(m => m.Id == id);
            if (emergencyRelationship == null)
            {
                return NotFound();
            }

            return View(emergencyRelationship);
        }

        // GET: EmergencyRelationships/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: EmergencyRelationships/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,RelationshipType")] EmergencyRelationship emergencyRelationship)
        {
            if (ModelState.IsValid)
            {
                _context.Add(emergencyRelationship);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(emergencyRelationship);
        }

        // GET: EmergencyRelationships/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.EmergencyRelationships == null)
            {
                return NotFound();
            }

            var emergencyRelationship = await _context.EmergencyRelationships.FindAsync(id);
            if (emergencyRelationship == null)
            {
                return NotFound();
            }
            return View(emergencyRelationship);
        }

        // POST: EmergencyRelationships/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,RelationshipType")] EmergencyRelationship emergencyRelationship)
        {
            if (id != emergencyRelationship.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(emergencyRelationship);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EmergencyRelationshipExists(emergencyRelationship.Id))
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
            return View(emergencyRelationship);
        }

        // GET: EmergencyRelationships/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.EmergencyRelationships == null)
            {
                return NotFound();
            }

            var emergencyRelationship = await _context.EmergencyRelationships
                .FirstOrDefaultAsync(m => m.Id == id);
            if (emergencyRelationship == null)
            {
                return NotFound();
            }

            return View(emergencyRelationship);
        }

        // POST: EmergencyRelationships/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.EmergencyRelationships == null)
            {
                return Problem("Entity set 'ApplicationDbContext.EmergencyRelationships'  is null.");
            }
            var emergencyRelationship = await _context.EmergencyRelationships.FindAsync(id);
            if (emergencyRelationship != null)
            {
                _context.EmergencyRelationships.Remove(emergencyRelationship);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EmergencyRelationshipExists(int id)
        {
          return (_context.EmergencyRelationships?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
