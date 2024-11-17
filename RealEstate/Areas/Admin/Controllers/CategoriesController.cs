using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RealEstate.Models;
using RealEstateData;

namespace RealEstate.Areas.Admin.Controllers;

[Area("Admin")]
public class CategoriesController : Controller
{
    private readonly AppDbContext context;

    private readonly string entityName = "Kategori";

    public CategoriesController(
        AppDbContext context
        )
    {
        this.context = context;
    }

    public async Task<IActionResult> Index()
    {
        var model = await context.Categories.ToListAsync();
        return View(model);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Create(Category model)
    {
        await context.Categories.AddAsync(model);
        await context.SaveChangesAsync();
        TempData["successMessage"] = $"{entityName} ekleme işlemi başarıyla tamamlanmıştır!";
        return RedirectToAction(nameof(Index));
    }


    [HttpGet]
    public async Task<IActionResult> Edit(Guid id)
    {
        var model = await context.Categories.FindAsync(id);
        return View(model);
    }

    [HttpPost]
    public async Task<IActionResult> Edit(Category model)
    {
        context.Categories.Update(model);
        await context.SaveChangesAsync();
        TempData["successMessage"] = $"{entityName} güncelleme işlemi başarıyla tamamlanmıştır!";
        return RedirectToAction(nameof(Index));
    }



    [HttpGet]
    public async Task<IActionResult> Delete(Guid id)
    {
        var model = await context.Categories.FindAsync(id);
        context.Categories.Remove(model);
        await context.SaveChangesAsync();
        TempData["successMessage"] = $"{entityName} silme işlemi başarıyla tamamlanmıştır!";
        return RedirectToAction(nameof(Index));
    }

}
