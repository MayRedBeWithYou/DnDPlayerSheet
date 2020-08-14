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
    public class CombatActionsController : Controller
    {
        private readonly DatabaseContext _context;

        public CombatActionsController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: CombatActions
        public async Task<IActionResult> Index()
        {
            return View(await _context.CombatActions.ToListAsync());
        }

        // GET: CombatActions/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var combatAction = await _context.CombatActions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (combatAction == null)
            {
                return NotFound();
            }

            return View(combatAction);
        }

        // GET: CombatActions/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CombatActions/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Description,OppurtunityAttack,IsFree,IsFullRound")] CombatAction combatAction)
        {
            if (ModelState.IsValid)
            {
                _context.Add(combatAction);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(combatAction);
        }

        // GET: CombatActions/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var combatAction = await _context.CombatActions.FindAsync(id);
            if (combatAction == null)
            {
                return NotFound();
            }
            return View(combatAction);
        }

        // POST: CombatActions/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Description,OppurtunityAttack,IsFree,IsFullRound")] CombatAction combatAction)
        {
            if (id != combatAction.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(combatAction);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CombatActionExists(combatAction.Id))
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
            return View(combatAction);
        }

        // GET: CombatActions/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var combatAction = await _context.CombatActions
                .FirstOrDefaultAsync(m => m.Id == id);
            if (combatAction == null)
            {
                return NotFound();
            }

            return View(combatAction);
        }

        // POST: CombatActions/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var combatAction = await _context.CombatActions.FindAsync(id);
            _context.CombatActions.Remove(combatAction);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CombatActionExists(int id)
        {
            return _context.CombatActions.Any(e => e.Id == id);
        }
    }
}
