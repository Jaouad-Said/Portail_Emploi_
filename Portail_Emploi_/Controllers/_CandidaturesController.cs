using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Portail_Emploi_.Context;
using Portail_Emploi_.Models;

namespace Portail_Emploi_.Controllers
{
    public class _CandidaturesController : Controller
    {
        private readonly CandidaturesContext _context;

        public _CandidaturesController(CandidaturesContext context)
        {
            _context = context;
        }

        // GET: _Candidatures
        public async Task<IActionResult> Index()
        {
              return View(await _context.Candidats.ToListAsync());
        }

        // GET: _Candidatures/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Candidats == null)
            {
                return NotFound();
            }

            var candidat = await _context.Candidats
                .FirstOrDefaultAsync(m => m.ID_Candidat == id);
            if (candidat == null)
            {
                return NotFound();
            }

            return View(candidat);
        }

        // GET: _Candidatures/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: _Candidatures/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("ID_Candidat,Nom,Prenom,Mail,Telephone,N_Etude,N_Experience,D_Employeur,CV")] Candidat candidat)
        {
            if (ModelState.IsValid)
            {
                _context.Add(candidat);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(candidat);
        }

        // GET: _Candidatures/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Candidats == null)
            {
                return NotFound();
            }

            var candidat = await _context.Candidats.FindAsync(id);
            if (candidat == null)
            {
                return NotFound();
            }
            return View(candidat);
        }

        // POST: _Candidatures/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("ID_Candidat,Nom,Prenom,Mail,Telephone,N_Etude,N_Experience,D_Employeur,CV")] Candidat candidat)
        {
            if (id != candidat.ID_Candidat)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(candidat);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CandidatExists(candidat.ID_Candidat))
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
            return View(candidat);
        }

        // GET: _Candidatures/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Candidats == null)
            {
                return NotFound();
            }

            var candidat = await _context.Candidats
                .FirstOrDefaultAsync(m => m.ID_Candidat == id);
            if (candidat == null)
            {
                return NotFound();
            }

            return View(candidat);
        }

        // POST: _Candidatures/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Candidats == null)
            {
                return Problem("Entity set 'CandidaturesContext.Candidats'  is null.");
            }
            var candidat = await _context.Candidats.FindAsync(id);
            if (candidat != null)
            {
                _context.Candidats.Remove(candidat);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CandidatExists(int id)
        {
          return _context.Candidats.Any(e => e.ID_Candidat == id);
        }
    }
}
