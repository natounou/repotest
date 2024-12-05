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
    public class typeCONT : Controller
    {
        private readonly TypesdeChambresContext _context;

        public typeCONT(TypesdeChambresContext context)
        {
            _context = context;
        }

        // GET: typeCONT
        public async Task<IActionResult> Index()
        {
              return _context.typedechambres != null ? 
                          View(await _context.typedechambres.ToListAsync()) :
                          Problem("Entity set 'TypesdeChambresContext.typedechambres'  is null.");
        }

        // GET: typeCONT/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.typedechambres == null)
            {
                return NotFound();
            }

            var typesdeChambres = await _context.typedechambres
                .FirstOrDefaultAsync(m => m.typeID == id);
            if (typesdeChambres == null)
            {
                return NotFound();
            }

            return View(typesdeChambres);
        }

        // GET: typeCONT/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: typeCONT/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("typeID,Nom,etabID")] TypesdeChambres typesdeChambres)
        {
            if (ModelState.IsValid)
            {
                _context.Add(typesdeChambres);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(typesdeChambres);
        }

        // GET: typeCONT/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.typedechambres == null)
            {
                return NotFound();
            }

            var typesdeChambres = await _context.typedechambres.FindAsync(id);
            if (typesdeChambres == null)
            {
                return NotFound();
            }
            return View(typesdeChambres);
        }

        // POST: typeCONT/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("typeID,Nom,etabID")] TypesdeChambres typesdeChambres)
        {
            if (id != typesdeChambres.typeID)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(typesdeChambres);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TypesdeChambresExists(typesdeChambres.typeID))
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
            return View(typesdeChambres);
        }

        // GET: typeCONT/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.typedechambres == null)
            {
                return NotFound();
            }

            var typesdeChambres = await _context.typedechambres
                .FirstOrDefaultAsync(m => m.typeID == id);
            if (typesdeChambres == null)
            {
                return NotFound();
            }

            return View(typesdeChambres);
        }

        // POST: typeCONT/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.typedechambres == null)
            {
                return Problem("Entity set 'TypesdeChambresContext.typedechambres'  is null.");
            }
            var typesdeChambres = await _context.typedechambres.FindAsync(id);
            if (typesdeChambres != null)
            {
                _context.typedechambres.Remove(typesdeChambres);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TypesdeChambresExists(int id)
        {
          return (_context.typedechambres?.Any(e => e.typeID == id)).GetValueOrDefault();
        }
    }
}
