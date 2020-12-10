using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FinalProjectBandits.Data;
using FinalProjectBandits.Models;
using Microsoft.AspNetCore.Authorization;

namespace FinalProjectBandits.Controllers
{
    public class TaskListItemsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TaskListItemsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TaskListItems1
        public async Task<IActionResult> Index()
        {
            var finalProjectBanditsContext = _context.TaskListItems.Include(t => t.Customer);
            return View(await finalProjectBanditsContext.ToListAsync());
        }

        // GET: TaskListItems1/Details/5
        [AllowAnonymous]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taskListItem = await _context.TaskListItems
                .Include(t => t.Customer)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (taskListItem == null)
            {
                return NotFound();
            }

            return View(taskListItem);
        }

        //[Authorize(Policy = "CustomerOnly")]
        [Authorize]
        public async Task<IActionResult> CheckOut(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taskListItem = await _context.TaskListItems
                .Include(t => t.Customer)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (taskListItem == null)
            {
                return NotFound();
            }

            if (taskListItem.Status == Models.Enums.ItemStatus.Open)
            {
                taskListItem.Status = Models.Enums.ItemStatus.CheckedOut;
                _context.Update(taskListItem);
                await _context.SaveChangesAsync();
            }

            return View(taskListItem);
        }

        public async Task<IActionResult> MarkDone(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taskListItem = await _context.TaskListItems
                .Include(t => t.Customer)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (taskListItem == null)
            {
                return NotFound();
            }
            if (taskListItem.Status == Models.Enums.ItemStatus.CheckedOut)
            {
                taskListItem.Status = Models.Enums.ItemStatus.Done;
                _context.Update(taskListItem);
                await _context.SaveChangesAsync();
            }

            return View(taskListItem);
        }

        // GET: TaskListItems1/Create
        [Authorize]
        public IActionResult Create()
        {
            ViewData["CustomerID"] = new SelectList(_context.Set<Customer>(), "ID", "ID");
            return View();
        }

        // POST: TaskListItems1/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TaskTitle,TaskDescription,Status,Category,TaskStartDate,Expiration,DatePosted,CustomerID")] TaskListItem taskListItem)
        {
            if (ModelState.IsValid)
            {
                _context.Add(taskListItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["CustomerID"] = new SelectList(_context.Set<Customer>(), "ID", "ID", taskListItem.CustomerID);
            return View(taskListItem);
        }

        // GET: TaskListItems1/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taskListItem = await _context.TaskListItems.FindAsync(id);

            if (taskListItem == null)
            {
                return NotFound();
            }
            ViewData["CustomerID"] = new SelectList(_context.Set<Customer>(), "ID", "ID", taskListItem.CustomerID);
            return View(taskListItem);
        }

        // POST: TaskListItems1/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TaskTitle,TaskDescription,Status,Category,TaskStartDate,Expiration,DatePosted,CustomerID")] TaskListItem taskListItem)
        {
            if (id != taskListItem.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(taskListItem);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TaskListItemExists(taskListItem.Id))
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

            ViewData["CustomerID"] = new SelectList(_context.Set<Customer>(), "ID", "ID", taskListItem.CustomerID);
            return View(taskListItem);
        }

        // GET: TaskListItems1/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taskListItem = await _context.TaskListItems
                .Include(t => t.Customer)
                .FirstOrDefaultAsync(m => m.Id == id);

            if (taskListItem == null)
            {
                return NotFound();
            }

            return View(taskListItem);
        }

        // POST: TaskListItems1/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var taskListItem = await _context.TaskListItems.FindAsync(id);
            _context.TaskListItems.Remove(taskListItem);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TaskListItemExists(int id)
        {
            return _context.TaskListItems.Any(e => e.Id == id);
        }
    }
}
