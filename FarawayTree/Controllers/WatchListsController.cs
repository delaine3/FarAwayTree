using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FarawayTree.Data;
using FarawayTree.Models;

namespace FarawayTree.Controllers
{
    public class WatchListsController : Controller
    {
        private readonly FarawayTreeContext _context;

        public WatchListsController(FarawayTreeContext context)
        {
            _context = context;
        }

        // GET: WatchLists
        public async Task<IActionResult> Index()
        {
              return _context.WatchList != null ? 
                          View(await _context.WatchList.ToListAsync()) :
                          Problem("Entity set 'FarawayTreeContext.WatchList'  is null.");
        }

        // GET: WatchLists/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.WatchList == null)
            {
                return NotFound();
            }

            var watchList = await _context.WatchList
                .FirstOrDefaultAsync(m => m.Id == id);
            if (watchList == null)
            {
                return NotFound();
            }

            return View(watchList);
        }

        // GET: WatchLists/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: WatchLists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Type,OnAir,SeasonStart,SeasonEnd,Watched")] WatchList watchList)
        {
            if (ModelState.IsValid)
            {
                _context.Add(watchList);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(watchList);
        }

        // GET: WatchLists/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.WatchList == null)
            {
                return NotFound();
            }

            var watchList = await _context.WatchList.FindAsync(id);
            if (watchList == null)
            {
                return NotFound();
            }
            return View(watchList);
        }

        // POST: WatchLists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Type,OnAir,SeasonStart,SeasonEnd,Watched")] WatchList watchList)
        {
            if (id != watchList.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(watchList);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!WatchListExists(watchList.Id))
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
            return View(watchList);
        }

        // GET: WatchLists/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.WatchList == null)
            {
                return NotFound();
            }

            var watchList = await _context.WatchList
                .FirstOrDefaultAsync(m => m.Id == id);
            if (watchList == null)
            {
                return NotFound();
            }

            return View(watchList);
        }

        // POST: WatchLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.WatchList == null)
            {
                return Problem("Entity set 'FarawayTreeContext.WatchList'  is null.");
            }
            var watchList = await _context.WatchList.FindAsync(id);
            if (watchList != null)
            {
                _context.WatchList.Remove(watchList);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool WatchListExists(int id)
        {
          return (_context.WatchList?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
