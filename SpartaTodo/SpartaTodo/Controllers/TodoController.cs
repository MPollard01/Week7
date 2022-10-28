using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SpartaTodo.Data;
using SpartaTodo.Models;
using SpartaTodo.Models.ViewModels;
using SpartaTodo.Services;

namespace SpartaTodo.Controllers
{
    public class TodoController : Controller
    {
        private readonly ITodoService _context;

        public TodoController(ITodoService context)
        {
            _context = context;
        }

        // GET: ToDo
        public async Task<IActionResult> Index()
        {
            var todos = await _context.GetAllAsync();
            return View(todos.Select(t => Utils.ToViewModel(t)).ToList());
        }

        // GET: ToDo/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.GetAllAsync().Result == null)
            {
                return NotFound();
            }

            var toDo = await _context.GetAsync(id.Value);
            if (toDo == null)
            {
                return NotFound();
            }

            return View(Utils.ToViewModel(toDo));
        }

        // GET: ToDo/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: ToDo/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Description,Complete,Date")] Todo toDo)
        {
            if (ModelState.IsValid)
            {
                await _context.AddAsync(toDo);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(Utils.ToViewModel(toDo));
        }

        // GET: ToDo/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.GetAllAsync().Result == null)
            {
                return NotFound();
            }

            var toDo = await _context.GetAsync(id.Value);
            if (toDo == null)
            {
                return NotFound();
            }
            return View(Utils.ToViewModel(toDo));
        }

        // POST: ToDo/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Description,Complete")] Todo toDo)
        {
            if (id != toDo.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(toDo);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ToDoExists(toDo.Id))
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
            return View(Utils.ToViewModel(toDo));
        }

        // GET: ToDo/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.GetAllAsync().Result == null)
            {
                return NotFound();
            }


            var toDo = await _context.FindAsync(id.Value);
            if (toDo == null)
            {
                return NotFound();
            }

            return View(Utils.ToViewModel(toDo));
        }

        // POST: ToDo/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.GetAllAsync().Result == null)
            {
                return Problem("Entity set 'SpartaToDoContext.ToDos'  is null.");
            }

            var toDo = await _context.FindAsync(id);
            if (toDo != null)
            {
                await _context.RemoveAsync(toDo);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ToDoExists(int id)
        {
            return _context.Exists(id);
        }
    }
}
