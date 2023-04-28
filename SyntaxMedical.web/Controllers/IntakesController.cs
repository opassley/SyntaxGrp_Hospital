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
    public class IntakesController : Controller
    {
        private readonly ApplicationDbContext _context;

        public IntakesController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Intakes
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Intakes.Include(i => i.Condition).Include(i => i.Doctor).Include(i => i.Patient).Include(i => i.Procedure).Include(i => i.Room);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Intakes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Intakes == null)
            {
                return NotFound();
            }

            var intake = await _context.Intakes
                .Include(i => i.Condition)
                .Include(i => i.Doctor)
                .Include(i => i.Patient)
                .Include(i => i.Procedure)
                .Include(i => i.Room)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (intake == null)
            {
                return NotFound();
            }

            return View(intake);
        }

        // GET: Intakes/Create
        public IActionResult Create()
        {
            ViewData["ConditionId"] = new SelectList(_context.Conditions, "Id", "Name");
            ViewData["DoctorId"] = new SelectList(_context.Doctors, "Id", "Id");
            ViewData["PatientId"] = new SelectList(_context.Patients, "Id", "Id");
            ViewData["ProcedureId"] = new SelectList(_context.Procedures, "Id", "Id");
            ViewData["RoomId"] = new SelectList(_context.Rooms, "Id", "RoomNumber");
            return View();
        }

        // POST: Intakes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PatientId,IntakeDate,ConditionId,ProcedureId,DoctorId,RoomId")] Intake intake)
        {
            if (ModelState.IsValid)
            {
                _context.Add(intake);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ConditionId"] = new SelectList(_context.Conditions, "Id", "Id", intake.ConditionId);
            ViewData["DoctorId"] = new SelectList(_context.Doctors, "Id", "Id", intake.DoctorId);
            ViewData["PatientId"] = new SelectList(_context.Patients, "Id", "Id", intake.PatientId);
            ViewData["ProcedureId"] = new SelectList(_context.Procedures, "Id", "Id", intake.ProcedureId);
            ViewData["RoomId"] = new SelectList(_context.Rooms, "Id", "Id", intake.RoomId);
            return View(intake);
        }

        // GET: Intakes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Intakes == null)
            {
                return NotFound();
            }

            var intake = await _context.Intakes.FindAsync(id);
            if (intake == null)
            {
                return NotFound();
            }
            ViewData["ConditionId"] = new SelectList(_context.Conditions, "Id", "Id", intake.ConditionId);
            ViewData["DoctorId"] = new SelectList(_context.Doctors, "Id", "Id", intake.DoctorId);
            ViewData["PatientId"] = new SelectList(_context.Patients, "Id", "Id", intake.PatientId);
            ViewData["ProcedureId"] = new SelectList(_context.Procedures, "Id", "Id", intake.ProcedureId);
            ViewData["RoomId"] = new SelectList(_context.Rooms, "Id", "Id", intake.RoomId);
            return View(intake);
        }

        // POST: Intakes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PatientId,IntakeDate,ConditionId,ProcedureId,DoctorId,RoomId")] Intake intake)
        {
            if (id != intake.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(intake);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!IntakeExists(intake.Id))
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
            ViewData["ConditionId"] = new SelectList(_context.Conditions, "Id", "Id", intake.ConditionId);
            ViewData["DoctorId"] = new SelectList(_context.Doctors, "Id", "Id", intake.DoctorId);
            ViewData["PatientId"] = new SelectList(_context.Patients, "Id", "Id", intake.PatientId);
            ViewData["ProcedureId"] = new SelectList(_context.Procedures, "Id", "Id", intake.ProcedureId);
            ViewData["RoomId"] = new SelectList(_context.Rooms, "Id", "Id", intake.RoomId);
            return View(intake);
        }

        // GET: Intakes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Intakes == null)
            {
                return NotFound();
            }

            var intake = await _context.Intakes
                .Include(i => i.Condition)
                .Include(i => i.Doctor)
                .Include(i => i.Patient)
                .Include(i => i.Procedure)
                .Include(i => i.Room)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (intake == null)
            {
                return NotFound();
            }

            return View(intake);
        }

        // POST: Intakes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Intakes == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Intakes'  is null.");
            }
            var intake = await _context.Intakes.FindAsync(id);
            if (intake != null)
            {
                _context.Intakes.Remove(intake);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool IntakeExists(int id)
        {
          return (_context.Intakes?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
