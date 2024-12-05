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
    public class tarCont : Controller
    {
        private readonly TarifsContext _context;

        public tarCont(TarifsContext context)
        {
            _context = context;
        }

        // GET: tarCont
        public async Task<IActionResult> Index()
        {
            var tarifsContext = _context.tarifs.Include(t => t.typedechambres);
            return View(await tarifsContext.ToListAsync());
        }

        // GET: tarCont/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.tarifs == null)
            {
                return NotFound();
            }

            var tarifs = await _context.tarifs
                .Include(t => t.typedechambres)
                .FirstOrDefaultAsync(m => m.tarID == id);
            if (tarifs == null)
            {
                return NotFound();
            }

            return View(tarifs);
        }

        // GET: tarCont/Create
        public IActionResult Create()
        {
            ViewData["typeID"] = new SelectList(_context.typedechambres, "typeID", "typeID");
            return View();
        }

        // POST: tarCont/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("datet,prix,typeID")] Tarifs tarifs)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tarifs);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["typeID"] = new SelectList(_context.typedechambres, "typeID", "typeID", tarifs.typeID);
            return View(tarifs);
        }

        // GET: tarCont/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.tarifs == null)
            {
                return NotFound();
            }

            var tarifs = await _context.tarifs.FindAsync(id);
            if (tarifs == null)
            {
                return NotFound();
            }
            ViewData["typeID"] = new SelectList(_context.typedechambres, "typeID", "typeID", tarifs.typeID);
            return View(tarifs);
        }

        // POST: tarCont/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("tarID,datet,prix,typeID")] Tarifs tarifs)
        {
            if (id != tarifs.tarID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tarifs);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TarifsExists(tarifs.tarID))
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
            ViewData["typeID"] = new SelectList(_context.typedechambres, "typeID", "typeID", tarifs.typeID);
            return View(tarifs);
        }

        // GET: tarCont/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.tarifs == null)
            {
                return NotFound();
            }

            var tarifs = await _context.tarifs
                .Include(t => t.typedechambres)
                .FirstOrDefaultAsync(m => m.tarID == id);
            if (tarifs == null)
            {
                return NotFound();
            }

            return View(tarifs);
        }

        // POST: tarCont/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.tarifs == null)
            {
                return Problem("Entity set 'TarifsContext.tarifs'  is null.");
            }
            var tarifs = await _context.tarifs.FindAsync(id);
            if (tarifs != null)
            {
                _context.tarifs.Remove(tarifs);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TarifsExists(int id)
        {
          return (_context.tarifs?.Any(e => e.tarID == id)).GetValueOrDefault();
        }
    }
}
