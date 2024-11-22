using System.Globalization;
using Microsoft.AspNetCore.Mvc;
using Wallet.Wise.BLL.Services;
using Wallet.Wise.DAL.Entities;

namespace Wallet.Wise.WebApp.Controllers;

public class CategoriesController : Controller
{
    private readonly CategoryServices _categoryServices;

    public CategoriesController(CategoryServices categoryServices)
    {
        _categoryServices = categoryServices;
    }

    public IActionResult Index(string SelectedMonth)
    {
        var selectedDate = DateTime.TryParseExact(SelectedMonth + "-01", "yyyy-MM-dd", CultureInfo.InvariantCulture, DateTimeStyles.None, out var date) 
            ? date 
            : DateTime.Now;
        ViewData["SelectedMonth"] = selectedDate.ToString("yyyy-MM");
        
        var categories = _categoryServices.GetAllWithMountAsync(selectedDate).Result;
        return View(categories);
    }
    public IActionResult Create()
    {
        return View();
    }
    [HttpPost]
    public IActionResult Create(Category category)
    {
        if (ModelState.IsValid)
        {
            _categoryServices.AddAsync(category).Wait();
            return RedirectToAction("Index");
        }
        return View(category);
    }
    [HttpGet]
    public IActionResult Edit(int id)
    {
        var data= _categoryServices.GetByIdAsync(id).Result;
        return View(data);
    }
    [HttpPost]
    public IActionResult Edit(Category category)
    {
        if (ModelState.IsValid)
        {
            _categoryServices.UpdateAsync(category).Wait();
            return RedirectToAction("Index");
        }
        return View(category);
    }
    [HttpGet]
    public IActionResult Delete(int id)
    {
        _categoryServices.DeleteAsync(id).Wait();
        return RedirectToAction("Index");
    }

   

}