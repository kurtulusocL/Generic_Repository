using GenericRepository.Business.Services.Abstract;
using GenericRepository.Entities.Entities;
using Microsoft.AspNetCore.Mvc;

namespace GenericRepository.WebUI.Controllers
{
    public class CategoryController : Controller
    {
        readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _categoryService.GetAllAsync());
        }
        public async Task<IActionResult> Detail(int? id)
        {
            return View(await _categoryService.GetCategoryAsync(id));
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Category entity)
        {
            var result = await _categoryService.CreateAsync(entity);
            if (result)
                return RedirectToAction(nameof(Create));
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Edit(int? id)
        {
            var data = await _categoryService.GetCategoryAsync(id);
            if (data != null)
            {
                return View(data);
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Category entity)
        {
            var result = await _categoryService.UpdateAsync(entity);
            if (result)
                return RedirectToAction(nameof(Edit), new { id = entity.Id });
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int? id)
        {
            var data = await _categoryService.GetCategoryAsync(id);
            if (data != null)
            {
                var result = await _categoryService.DeleteAsync(data);
                if (result)
                    return RedirectToAction(nameof(Index));               
            }
            return View();
        }
    }
}
