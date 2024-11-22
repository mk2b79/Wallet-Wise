using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Wallet.Wise.BLL.DTOs;
using Wallet.Wise.BLL.Services;
using Wallet.Wise.DAL.Entities;

namespace Wallet.Wise.WebApp.Controllers;

public class RecordsController : Controller
{
    private readonly RecordServices _recordServices;
    private readonly CategoryServices _categoryServices;
    private readonly IMapper _mapper;

    public RecordsController(RecordServices recordServices, CategoryServices categoryServices, IMapper mapper)
    {
        _recordServices = recordServices;
        _categoryServices = categoryServices;
        _mapper = mapper;
    }

    public IActionResult Index(int CategoryId, string Mount)
    {
        var date = DateTime.Parse(Mount + "-01");
        var data = _categoryServices.GetByIdWithMountAsync(CategoryId, date).Result;
        var model = new RecordsHistoryDto()
        {
            Category = _mapper.Map<CategoryWithAmontDto>(data),
            RecordHistory = _mapper.Map<List<RecordDto>>(data.Records)
        };
        ViewData["CategoryId"] = CategoryId;
        ViewData["Mount"] = Mount;
        return View(model);
    }
    [HttpPost]
    public IActionResult Delete(int Id, int CategoryId, string Mount)
    {
        _recordServices.DeleteAsync(Id).Wait();
        return RedirectToAction("Index","Records", new { CategoryId, Mount });
    }
    
    [HttpGet]
    public IActionResult Create(int CategoryId)
    {
        ViewBag.Categories = new SelectList(_categoryServices.GetAllAsync().Result, "Id", "Name");
        return View(new Record(){Category_Id = CategoryId,Date = DateTime.Now});
    }
    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Record record)
    {
        ModelState.Remove(nameof(record.Category));
        if (ModelState.IsValid)
        {
            _recordServices.AddAsync(record).Wait();
            var date = DateTime.Now.ToString("yyyy-MM");
            return RedirectToAction("Index","Categories",new{date} );
        }
        ViewBag.Categories = new SelectList(_categoryServices.GetAllAsync().Result, "Id", "Name");
        return View(record);
    }
}