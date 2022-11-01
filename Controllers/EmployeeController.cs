using NguyenThiQuynhTrangBTH2.Data;
using NguyenThiQuynhTrangBTH2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace NguyenThiQuynhTrangBTH2.Controllers
{
    public class EmployeeController : Controller
    {
        //khai bao DBcontext de lam viec voi Database
        private readonly ApplicationDbContext _context;
        public EmployeeController (ApplicationDbContext context)
        {
            _context = context;
        }
        // Action tra ve View hien thi danh sach 
        public async Task<IActionResult> Index()
        {
            var model = await _context.Employees.ToListAsync();
            return View(model);
        }
        //Action tra ve View them moi danh sach 
        public IActionResult Create()
        {
            return View();
        }
        //Action xu ly du lieu gui len tu view va luu vao Database
        [HttpPost]
        public async Task<IActionResult> Create(Employee std)
        {
            if(ModelState.IsValid)
            {
                _context.Add(std);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            }
            return View(std);
        }
    //GET: Employee/Edit/5
     public async Task<IActionResult> Edit(string id)
     {
        if(id == null)
        {
            return View("NotFound");
        }
        var employee = await _context.Employees.FindAsync(id);
        if (employee == null)
        {
            return View("NotFound");
        }
        return View(employee);
     }
       //POST :Employee/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(string id, [Bind("EmployeeID,EmployeeName")] Employee std)
    {
        if (id !=std.EmployeeID)
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
            if (!EmployeeExists(std.EmployeeID))
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
    //GET: Employee/Delete/5
    public async Task<IActionResult> Delete(string id)
    {
        if (id == null)
        {
            return View("NotFound");
        }
        var std = await _context.Employees
         .FirstOrDefaultAsync(m => m.EmployeeID == id);
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
        var std = await _context.Employees.FindAsync(id);
        _context.Employees.Remove(std);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
    private bool EmployeeExists(string id)
    {
        return _context.Employees.Any(e => e.EmployeeID == id);
    }

    }
}