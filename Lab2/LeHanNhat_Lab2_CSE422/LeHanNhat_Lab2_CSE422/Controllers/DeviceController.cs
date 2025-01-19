using LeHanNhat_Lab2_CSE422.Models;
using LeHanNhat_Lab2_CSE422.Services;
using Microsoft.AspNetCore.Mvc;
using System.Numerics;

namespace LeHanNhat_Lab2_CSE422.Controllers
{
    public class DeviceController : Controller
    {
        public IActionResult Index(int? categoryId, DeviceStatus? status, string searchString)
        {
            var devices = DataStore.Devices.AsQueryable();

            if (categoryId.HasValue)
            {
                devices = devices.Where(d => d.CategoryId == categoryId);
            }

            if (status.HasValue)
            {
                devices = devices.Where(d => d.Status == status);
            }

            if (!string.IsNullOrEmpty(searchString))
            {
                devices = devices.Where(d =>
                    d.Name.Contains(searchString, StringComparison.OrdinalIgnoreCase) ||
                    d.Code.Contains(searchString, StringComparison.OrdinalIgnoreCase));
            }

            ViewBag.Categories = DataStore.Categories;
            return View(devices.ToList());
        }

        public IActionResult Create()
        {
            ViewBag.Categories = DataStore.Categories;
            return View();
        }

        [HttpPost]
        public IActionResult Create(Device device)
        {
            if (ModelState.IsValid)
            {
                device.Id = DataStore.Devices.Count > 0 ?
                    DataStore.Devices.Max(x => x.Id) + 1 : 1;
                device.EntryDate = DateTime.Now;
                DataStore.Devices.Add(device);
                return RedirectToAction(nameof(Index));
            }
            ViewBag.Categories = DataStore.Categories;
            return View(device);
        }
        public IActionResult Edit(int id)
        {
            var device = DataStore.Devices.FirstOrDefault(x => x.Id == id);
            if (device == null)
            {
                return NotFound();
            }
            ViewBag.Categories = DataStore.Categories;
            return View(device);
        }

        [HttpPost]
        public IActionResult Edit(Device device)
        {
            if (ModelState.IsValid)
            {
                var existingDevice = DataStore.Devices.FirstOrDefault(x => x.Id == device.Id);
                if (existingDevice != null)
                {
                    existingDevice.Name = device.Name;
                    existingDevice.Code = device.Code;
                    existingDevice.CategoryId = device.CategoryId;
                    existingDevice.Status = device.Status;
                    // Keep the original entry date
                    return RedirectToAction(nameof(Index));
                }
            }
            ViewBag.Categories = DataStore.Categories;
            return View(device);
        }

        public IActionResult Delete(int id)
        {
            var device = DataStore.Devices.FirstOrDefault(x => x.Id == id);
            if (device == null)
            {
                return NotFound();
            }

            ViewBag.Categories = DataStore.Categories;
            // Find the category name and pass it to view
            foreach (var category in DataStore.Categories)
            {
                if (category.Id == device.CategoryId)
                {
                    ViewBag.CategoryName = category.Name;
                    break;
                }
            }
            return View(device);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var device = DataStore.Devices.FirstOrDefault(x => x.Id == id);
            if (device != null)
            {
                DataStore.Devices.Remove(device);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
