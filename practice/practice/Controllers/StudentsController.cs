using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using practice.Context;
using practice.Models;

namespace practice.Controllers
{
	public class StudentsController : Controller
	{
		private readonly GeneralContext _context;

		public StudentsController(GeneralContext context)
		{
			_context = context;
		}

		// GET: Students
		public async Task<IActionResult> Index()
		{
			var classes = await _context.Classes.ToListAsync();
			return View(classes);
		}
		public async Task<IActionResult> GetStudents(int? classID)
		{
			return _context.Students != null ?
						Json(await _context.Students.Where(x=>classID==null || x.ClassID==classID).Include(x => x.Class).ToListAsync(), new JsonSerializerOptions { ReferenceHandler = ReferenceHandler.IgnoreCycles }) :
						Problem("Entity set 'GeneralContext.Students'  is null.");
		}

		// GET: Students/Details/5
		public async Task<IActionResult> Details(int? id)
		{
			if (id == null || _context.Students == null)
			{
				return NotFound();
			}

			var student = await _context.Students
				.FirstOrDefaultAsync(m => m.StudentID == id);
			if (student == null)
			{
				return NotFound();
			}

			return View(student);
		}

		// GET: Students/Create
		public IActionResult Create()
		{
			List<SelectListItem> classes = _context.Classes.Select(@class => new SelectListItem() { Text = @class.ClassName, Value = @class.ClassID.ToString() }).ToList();
			ViewBag.Classes = classes;
			return View();
		}

		// POST: Students/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("StudentID,StudentName,StudentSurname,StudentAddress,ClassID")] Student student)
		{
			if (ModelState.IsValid)
			{
				_context.Add(student);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			return View(student);
		}

		// GET: Students/Edit/5
		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null || _context.Students == null)
			{
				return NotFound();
			}

			var student = await _context.Students.FindAsync(id);
			if (student == null)
			{
				return NotFound();
			}
			return View(student);
		}

		// POST: Students/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, [Bind("StudentID,StudentName,StudentSurname,StudentAddress,ClassID")] Student student)
		{
			if (id != student.StudentID)
			{
				return NotFound();
			}

			if (ModelState.IsValid)
			{
				try
				{
					_context.Update(student);
					await _context.SaveChangesAsync();
				}
				catch (DbUpdateConcurrencyException)
				{
					if (!StudentExists(student.StudentID))
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
			return View(student);
		}

		// GET: Students/Delete/5
		public async Task<IActionResult> Delete(int? id)
		{
			if (id == null || _context.Students == null)
			{
				return NotFound();
			}

			var student = await _context.Students
				.FirstOrDefaultAsync(m => m.StudentID == id);
			if (student == null)
			{
				return NotFound();
			}

			return View(student);
		}

		// POST: Students/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			if (_context.Students == null)
			{
				return Problem("Entity set 'GeneralContext.Students'  is null.");
			}
			var student = await _context.Students.FindAsync(id);
			if (student != null)
			{
				_context.Students.Remove(student);
			}

			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		private bool StudentExists(int id)
		{
			return (_context.Students?.Any(e => e.StudentID == id)).GetValueOrDefault();
		}
	}
}
