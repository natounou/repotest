using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using testframeworj7.Models;

namespace testframeworj7.Controllers
{
    public class etCont : Controller
    {
        private readonly EtablissementContext _context;

        public etCont(EtablissementContext context)
        {
            _context = context;
        }

        // GET: etCont
        public async Task<IActionResult> Index()
        {
              return _context.etablissement != null ? 
                          View(await _context.etablissement.ToListAsync()) :
                          Problem("Entity set 'EtablissementContext.etablissement'  is null.");
        }

        // GET: etCont/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.etablissement == null)
            {
                return NotFound();
            }

            var etablissement = await _context.etablissement
                .FirstOrDefaultAsync(m => m.etId == id);
            if (etablissement == null)
            {
                return NotFound();
            }

            return View(etablissement);
        }

        // GET: etCont/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: etCont/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("etId,Nom")] Etablissement etablissement)
        {
            if (ModelState.IsValid)
            {
                _context.Add(etablissement);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(etablissement);
        }

        // GET: etCont/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.etablissement == null)
            {
                return NotFound();
            }

            var etablissement = await _context.etablissement.FindAsync(id);
            if (etablissement == null)
            {
                return NotFound();
            }
            return View(etablissement);
        }

        // POST: etCont/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("etId,Nom")] Etablissement etablissement)
        {
            if (id != etablissement.etId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(etablissement);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EtablissementExists(etablissement.etId))
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
            return View(etablissement);
        }

        // GET: etCont/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.etablissement == null)
            {
                return NotFound();
            }

            var etablissement = await _context.etablissement
                .FirstOrDefaultAsync(m => m.etId == id);
            if (etablissement == null)
            {
                return NotFound();
            }

            return View(etablissement);
        }

        // POST: etCont/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.etablissement == null)
            {
                return Problem("Entity set 'EtablissementContext.etablissement'  is null.");
            }
            var etablissement = await _context.etablissement.FindAsync(id);
            if (etablissement != null)
            {
                _context.etablissement.Remove(etablissement);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EtablissementExists(int id)
        {
          return (_context.etablissement?.Any(e => e.etId == id)).GetValueOrDefault();
        }
    }
}
