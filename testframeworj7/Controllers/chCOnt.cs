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
    public class chCOnt : Controller
    {
        private readonly ChambresContext _context;

        public chCOnt(ChambresContext context)
        {
            _context = context;
        }

        // GET: chCOnt
        public async Task<IActionResult> Index()
        {
            var chambresContext = _context.chambres.Include(c => c.typedechambres);
            return View(await chambresContext.ToListAsync());
        }

        // GET: chCOnt/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.chambres == null)
            {
                return NotFound();
            }

            var chambres = await _context.chambres
                .Include(c => c.typedechambres)
                .FirstOrDefaultAsync(m => m.chambreID == id);
            if (chambres == null)
            {
                return NotFound();
            }

            return View(chambres);
        }

        // GET: chCOnt/Create
        public IActionResult Create()
        {
            ViewData["typeID"] = new SelectList(_context.typedechambres, "typeID", "typeID");
            return View();
        }

        // POST: chCOnt/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("chambreID,Nom,typeID")] Chambres chambres)
        {
            if (ModelState.IsValid)
            {
                _context.Add(chambres);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["typeID"] = new SelectList(_context.typedechambres, "typeID", "typeID", chambres.typeID);
            return View(chambres);
        }

        // GET: chCOnt/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.chambres == null)
            {
                return NotFound();
            }

            var chambres = await _context.chambres.FindAsync(id);
            if (chambres == null)
            {
                return NotFound();
            }
            ViewData["typeID"] = new SelectList(_context.typedechambres, "typeID", "typeID", chambres.typeID);
            return View(chambres);
        }

        // POST: chCOnt/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("chambreID,Nom,typeID")] Chambres chambres)
        {
            if (id != chambres.chambreID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(chambres);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ChambresExists(chambres.chambreID))
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
            ViewData["typeID"] = new SelectList(_context.typedechambres, "typeID", "typeID", chambres.typeID);
            return View(chambres);
        }

        // GET: chCOnt/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.chambres == null)
            {
                return NotFound();
            }

            var chambres = await _context.chambres
                .Include(c => c.typedechambres)
                .FirstOrDefaultAsync(m => m.chambreID == id);
            if (chambres == null)
            {
                return NotFound();
            }

            return View(chambres);
        }

        // POST: chCOnt/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.chambres == null)
            {
                return Problem("Entity set 'ChambresContext.chambres'  is null.");
            }
            var chambres = await _context.chambres.FindAsync(id);
            if (chambres != null)
            {
                _context.chambres.Remove(chambres);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ChambresExists(int id)
        {
          return (_context.chambres?.Any(e => e.chambreID == id)).GetValueOrDefault();
        }
    }
}
