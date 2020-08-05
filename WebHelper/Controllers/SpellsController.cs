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
    public class SpellsController : Controller
    {
        private readonly DatabaseContext _context;

        public SpellsController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: Spells
        public async Task<IActionResult> Index()
        {
            return View(await _context.Spells.ToListAsync());
        }

        // GET: Spells/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spell = await _context.Spells
                .FirstOrDefaultAsync(m => m.Id == id);
            if (spell == null)
            {
                return NotFound();
            }

            return View(spell);
        }

        // GET: Spells/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Spells/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,School,Tier,Level,Components,CastTime,Range,Target,Duration,SavingThrow,SpellResistance,Description,MaterialComponent")] Spell spell)
        {
            if (ModelState.IsValid)
            {
                _context.Add(spell);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(spell);
        }

        // GET: Spells/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spell = await _context.Spells.FindAsync(id);
            if (spell == null)
            {
                return NotFound();
            }
            return View(spell);
        }

        // POST: Spells/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,School,Tier,Level,Components,CastTime,Range,Target,Duration,SavingThrow,SpellResistance,Description,MaterialComponent")] Spell spell)
        {
            if (id != spell.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(spell);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SpellExists(spell.Id))
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
            return View(spell);
        }

        // GET: Spells/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var spell = await _context.Spells
                .FirstOrDefaultAsync(m => m.Id == id);
            if (spell == null)
            {
                return NotFound();
            }

            return View(spell);
        }

        // POST: Spells/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var spell = await _context.Spells.FindAsync(id);
            _context.Spells.Remove(spell);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SpellExists(int id)
        {
            return _context.Spells.Any(e => e.Id == id);
        }
    }
}
