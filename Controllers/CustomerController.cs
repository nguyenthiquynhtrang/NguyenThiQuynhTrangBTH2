using NguyenThiQuynhTrangBTH2.Data;
using NguyenThiQuynhTrangBTH2.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace NguyenThiQuynhTrangBTH2.Controllers
{
    public class CustomerController : Controller
    {
        //khai bao DBcontext de lam viec voi Database
        private readonly ApplicationDbContext _context;
        public CustomerController (ApplicationDbContext context)
        {
            _context = context;
        }
        // Action tra ve View hien thi danh sach 
        public async Task<IActionResult> Index()
        {
            var model = await _context.Customers.ToListAsync();
            return View(model);
        }
        //Action tra ve View them moi danh sach 
        public IActionResult Create()
        {
            return View();
        }
        //Action xu ly du lieu gui len tu view va luu vao Database
        [HttpPost]
        public async Task<IActionResult> Create(Customer std)
        {
            if(ModelState.IsValid)
            {
                _context.Add(std);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));

            }
            return View(std);
        }
    //GET: Customer/Edit/5
     public async Task<IActionResult> Edit(string id)
     {
        if(id == null)
        {
            return View("NotFound");
        }
        var customer = await _context.Customers.FindAsync(id);
        if (customer == null)
        {
            return View("NotFound");
        }
        return View(customer);
     }
       //POST :Customer/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit(string id, [Bind("CustomerID,CustomerName")] Customer std)
    {
        if (id !=std.CustomerID)
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
            if (!CustomerExists(std.CustomerID))
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
    //GET: Customer/Delete/5
    public async Task<IActionResult> Delete(string id)
    {
        if (id == null)
        {
            return View("NotFound");
        }
        var std = await _context.Customers
         .FirstOrDefaultAsync(m => m.CustomerID == id);
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
        var std = await _context.Customers.FindAsync(id);
        _context.Customers.Remove(std);
        await _context.SaveChangesAsync();
        return RedirectToAction(nameof(Index));
    }
    private bool CustomerExists(string id)
    {
        return _context.Customers.Any(e => e.CustomerID == id);
    }
    }
}