using GenericRepository.Business.Services.Abstract;
using GenericRepository.Entities.Entities;
using Microsoft.AspNetCore.Mvc;

namespace GenericRepository.WebUI.Controllers
{
    public class WarehouseController : Controller
    {
        readonly IWarehouseService _warehouseService;
        public WarehouseController(IWarehouseService warehouseService)
        {
            _warehouseService = warehouseService;
        }
        public async Task<IActionResult> Index()
        {
            return View(await _warehouseService.GetAllAsync());
        }
        public async Task<IActionResult> Detail(int? id)
        {
            return View(await _warehouseService.GetWarehouseAsync(id));
        }
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Warehouse entity)
        {
            var result = await _warehouseService.CreateAsync(entity);
            if (result)
                return RedirectToAction(nameof(Create));
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Edit(int? id)
        {
            var data = await _warehouseService.GetWarehouseAsync(id);
            if (data != null)
            {
                return View(data);
            }
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Warehouse entity)
        {
            var result = await _warehouseService.UpdateAsync(entity);
            if (result)
                return RedirectToAction(nameof(Edit), new { id = entity.Id });
            return RedirectToAction(nameof(Index));
        }
        public async Task<IActionResult> Delete(int? id)
        {
            var data = await _warehouseService.GetWarehouseAsync(id);
            if (data != null)
            {
                var result = await _warehouseService.DeleteAsync(data);
                if (result)
                    return RedirectToAction(nameof(Index));
            }
            return View();
        }
    }
}
