using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using FinalProjectBandits.Data;
using FinalProjectBandits.Models;
using FinalProjectBandits.Models.Enums;
using Microsoft.AspNetCore.Identity;

namespace FinalProjectBandits.Controllers
{
    public class TaskListItems2Controller : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<IdentityUser> _userManager;

        public TaskListItems2Controller(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            _context = context;
            _userManager = userManager;
        }

        // GET: TaskListItems
        public async Task<IActionResult> Index()
        {
            var taskListItems = await _context.TaskListItems.ToListAsync();
            return View(taskListItems);
            //return View(FakeDataSeed.GetTaskListItems());
        }

        // GET: TaskListItems/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taskListItem = await _context.TaskListItems
                .FirstOrDefaultAsync(m => m.Id == id);
            if (taskListItem == null)
            {
                return NotFound();
            }

            return View(taskListItem);
        }

        // GET: TaskListItems/CheckOut/5
        public async Task<IActionResult> CheckOut(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taskListItem = await _context.TaskListItems
                .FirstOrDefaultAsync(m => m.Id == id);

            //try
            //{
            //    _context.Update(taskListItem);
            //    await _context.SaveChangesAsync();
            //}
            //catch (DbUpdateConcurrencyException)
            //{
            //    if (!TaskListItemExists(taskListItem.Id))
            //    {
            //        return NotFound();
            //    }
            //    else
            //    {
            //        throw;
            //    }
            //}
 
            if (taskListItem == null)
            {
                return NotFound();
            }
            var customer = await _context.Customers
                .FirstOrDefaultAsync(m => m.ID == taskListItem.CustomerID);
            taskListItem.Customer = customer;
            return View(taskListItem);
        }

        // GET: TaskListItems/Create
        public IActionResult Create()
        {
            ViewData["CustomerID"] = new SelectList(_context.Customers, "ID", "ID");
            return View();
        }

        // POST: TaskListItems/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TaskTitle,TaskDescription,Status,Category,TaskStartDate,Expiration,DatePosted,CustomerID")] TaskListItem taskListItem)
        {

            if (ModelState.IsValid)
            {
                var user = await _userManager.GetUserAsync(HttpContext.User);
                var Customer = await _context.Customers.FirstOrDefaultAsync(x => x.UserId == user.Id);
                taskListItem.CustomerID = Customer.ID;
                _context.Add(taskListItem);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(taskListItem);
        }

        // GET: TaskListItems/Edit/5
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
            return View(taskListItem);
        }

        // POST: TaskListItems/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TaskTitle,TaskDescription,Status,Category,TaskStartDate,Expiration,DatePosted")] TaskListItem taskListItem)
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
            return View(taskListItem);
        }

        // GET: TaskListItems/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var taskListItem = await _context.TaskListItems
                .FirstOrDefaultAsync(m => m.Id == id);
            if (taskListItem == null)
            {
                return NotFound();
            }

            return View(taskListItem);
        }

        // POST: TaskListItems/Delete/5
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
