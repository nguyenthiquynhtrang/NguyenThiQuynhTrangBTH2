using NguyenThiQuynhTrangBTH2.Data;
using NguyenThiQuynhTrangBTH2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace NguyenThiQuynhTrangBTH2.Controllers
{
    public class StudentController : Controller
    {
        //khai bao DBcontext de lam viec voi Database
        private readonly ApplicationDbContext _context;
        public StudentController (ApplicationDbContext context)
        {
            _context = context;
        }
        // Action tra ve View hien thi danh sach sinh vien
        public async Task<IActionResult> Index()
        {
            var model = await _context.Students.ToListAsync();
            return View(model);
        }
        //Action tra ve View them moi danh sach sinh vien
        public IActionResult Create()
        {
            return View();
        }
        //Action xu ly du lieu sinh vien gui len tu view va luu vao Database
        [HttpPost]
        public async Task<IActionResult> Create(Student std)
        {
            if(ModelState.IsValid)
            {
                _context.Add(std);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            }
            return View(std);
        }
       //GET: Student/Edit/5
     public async Task<IActionResult> Edit(string id)
     {
        if(id == null)
        {
            return View("NotFound");
        }
        var student = await _context.Students.FindAsync(id);
        if (student == null)
        {
            return View("NotFound");
        }
        return View(student);
     }
       //POST :Student/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(string id, [Bind("StudentID,StudentName")] Student std)
    {
        if (id !=std.StudentID)
        {
            return View("NotFound");
        }
        if (ModelState.IsValid)
        {
            try
            {
                _context.Update(std);
                await _context.SaveChangesAsync();
            }
        catch (DbUpdateConcurrencyException)
        {
            if (!StudentExists(std.StudentID))
            {
                return View("NotFound");
            }
            else
            {
                throw;
            }
        }
        return RedirectToAction(nameof(Index));
        }
        return View(std);
    }
    //GET: Student/Delete/5
    public async Task<IActionResult> Delete(string id)
    {
        if (id == null)
        {
            return View("NotFound");
        }
        var std = await _context.Students
         .FirstOrDefaultAsync(m => m.StudentID == id);
        if (std == null)
        {
            return View("NotFound");
        }
        return View(std);
    }
    //POST: Product/Delete/5
    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> DeleteConfirmed(string id)
    {
        var std = await _context.Students.FindAsync(id);
        _context.Students.Remove(std);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
    private bool StudentExists(string id)
    {
        return _context.Students.Any(e => e.StudentID == id);
    }
    }
}
