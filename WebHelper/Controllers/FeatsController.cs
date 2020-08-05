using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DnDPlayerSheet.Models;
using WebHelper.EntityFramework;

namespace WebHelper.Controllers
{
    public class FeatsController : Controller
    {
        private readonly DatabaseContext _context;

        public FeatsController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: Feats
        public async Task<IActionResult> Index()
        {
            return View(await _context.Feats.ToListAsync());
        }

        // GET: Feats/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var feat = await _context.Feats
                .FirstOrDefaultAsync(m => m.Id == id);
            if (feat == null)
            {
                return NotFound();
            }

            return View(feat);
        }

        // GET: Feats/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Feats/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Type,Requirements,Description")] Feat feat)
        {
            if (ModelState.IsValid)
            {
                _context.Add(feat);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(feat);
        }

        // GET: Feats/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var feat = await _context.Feats.FindAsync(id);
            if (feat == null)
            {
                return NotFound();
            }
            return View(feat);
        }

        // POST: Feats/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Type,Requirements,Description")] Feat feat)
        {
            if (id != feat.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(feat);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FeatExists(feat.Id))
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
            return View(feat);
        }

        // GET: Feats/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var feat = await _context.Feats
                .FirstOrDefaultAsync(m => m.Id == id);
            if (feat == null)
            {
                return NotFound();
            }

            return View(feat);
        }

        // POST: Feats/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var feat = await _context.Feats.FindAsync(id);
            _context.Feats.Remove(feat);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FeatExists(int id)
        {
            return _context.Feats.Any(e => e.Id == id);
        }
    }
}
