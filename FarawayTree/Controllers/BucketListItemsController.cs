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
    public class BucketListItemsController : Controller
    {
        private readonly FarawayTreeContext _context;

        public BucketListItemsController(FarawayTreeContext context)
        {
            _context = context;
        }

        // GET: BucketListItems
        public async Task<IActionResult> Index()
        {
              return _context.BucketListItem != null ? 
                          View(await _context.BucketListItem.ToListAsync()) :
                          Problem("Entity set 'FarawayTreeContext.BucketListItem'  is null.");
        }

        // GET: BucketListItems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.BucketListItem == null)
            {
                return NotFound();
            }

            var bucketListItem = await _context.BucketListItem
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bucketListItem == null)
            {
                return NotFound();
            }

            return View(bucketListItem);
        }

        // GET: BucketListItems/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: BucketListItems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,PeopleInvolved,Notes,Requirements,IsCompleted,TargetCompletionDate,ActualCompletionDate,Location,Cost")] BucketListItem bucketListItem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bucketListItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(bucketListItem);
        }

        // GET: BucketListItems/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.BucketListItem == null)
            {
                return NotFound();
            }

            var bucketListItem = await _context.BucketListItem.FindAsync(id);
            if (bucketListItem == null)
            {
                return NotFound();
            }
            return View(bucketListItem);
        }

        // POST: BucketListItems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,PeopleInvolved,Notes,Requirements,IsCompleted,TargetCompletionDate,ActualCompletionDate,Location,Cost")] BucketListItem bucketListItem)
        {
            if (id != bucketListItem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bucketListItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BucketListItemExists(bucketListItem.Id))
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
            return View(bucketListItem);
        }

        // GET: BucketListItems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.BucketListItem == null)
            {
                return NotFound();
            }

            var bucketListItem = await _context.BucketListItem
                .FirstOrDefaultAsync(m => m.Id == id);
            if (bucketListItem == null)
            {
                return NotFound();
            }

            return View(bucketListItem);
        }

        // POST: BucketListItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.BucketListItem == null)
            {
                return Problem("Entity set 'FarawayTreeContext.BucketListItem'  is null.");
            }
            var bucketListItem = await _context.BucketListItem.FindAsync(id);
            if (bucketListItem != null)
            {
                _context.BucketListItem.Remove(bucketListItem);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BucketListItemExists(int id)
        {
          return (_context.BucketListItem?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
