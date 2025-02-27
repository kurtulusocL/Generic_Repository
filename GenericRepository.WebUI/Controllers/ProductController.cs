using GenericRepository.Business.Services.Abstract;
using GenericRepository.Entities.Entities;
using Microsoft.AspNetCore.Mvc;

namespace GenericRepository.WebUI.Controllers
{
    public class ProductController : Controller
    {
        readonly IProductService _productService;
        readonly ICategoryService _categoryService;
        readonly IWarehouseService _warehouseService;
        public ProductController(IProductService productService, ICategoryService categoryService, IWarehouseService warehouseService)
        {
            _productService = productService;
            _categoryService = categoryService;
            _warehouseService = warehouseService;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _productService.GetAll());
        }
        public async Task<IActionResult> Detail(int? id)
        {
            return View(await _productService.GetProductAsync(id));
        }
        public async Task<IActionResult> Warehouse(int id)
        {
            return View(await _productService.GetAllProductByWarehouseIdAsync(id));
        }
        public async Task<IActionResult> Category(int id)
        {
            return View(await _productService.GetAllProductByCategoryIdAsync(id));
        }
        public async Task<IActionResult> Create()
        {
            ViewBag.Warehouses = await _warehouseService.GetWarehouseForAddProductAsync();
            ViewBag.Categories = await _categoryService.GetCategoriesForAddProductAsync();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product entity)
        {
            var result = await _productService.CreateAsync(entity);
            if (result)
                return RedirectToAction(nameof(Create));
            return View();
        }
        public async Task<IActionResult> Edit(int? id)
        {
            ViewBag.Warehouses = await _warehouseService.GetWarehouseForAddProductAsync();
            ViewBag.Categories = await _categoryService.GetCategoriesForAddProductAsync();

            var data = await _productService.GetProductAsync(id);
            if (data != null)
            {
                return View(data);
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Product entity)
        {
            var result = await _productService.UpdateAsync(entity);
            if (result)
                return RedirectToAction(nameof(Edit), new { id = entity.Id });
            return View();
        }
        public async Task<IActionResult> Delete(int? id)
        {
            var data = await _productService.GetProductAsync(id);
            if (data != null)
            {
                var result = await _productService.DeleteAsync(data);
                if (result)
                    return RedirectToAction(nameof(Index));
            }
            return View();
        }
    }
}
