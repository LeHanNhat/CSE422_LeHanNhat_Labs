using LeHanNhat_Lab2_CSE422.Models;
using LeHanNhat_Lab2_CSE422.Services;
using Microsoft.AspNetCore.Mvc;

namespace LeHanNhat_Lab2_CSE422.Controllers
{
    public class DeviceCategoryController : Controller
    {
        public IActionResult Index()
        {
            return View(DataStore.Categories);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(DeviceCategory category)
        {
            if (ModelState.IsValid)
            {
                category.Id = DataStore.Categories.Count > 0 ?
                    DataStore.Categories.Max(x => x.Id) + 1 : 1;
                DataStore.Categories.Add(category);
                return RedirectToAction(nameof(Index));
            }
            return View(category);
        }

        public IActionResult Edit(int id)
        {
            var category = DataStore.Categories.FirstOrDefault(x => x.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpPost]
        public IActionResult Edit(DeviceCategory category)
        {
            if (ModelState.IsValid)
            {
                var existingCategory = DataStore.Categories.FirstOrDefault(x => x.Id == category.Id);
                if (existingCategory != null)
                {
                    existingCategory.Name = category.Name;
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(category);
        }

        public IActionResult Delete(int id)
        {
            var category = DataStore.Categories.FirstOrDefault(x => x.Id == id);
            if (category == null)
            {
                return NotFound();
            }
            return View(category);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var category = DataStore.Categories.FirstOrDefault(x => x.Id == id);
            if (category != null)
            {
                DataStore.Categories.Remove(category);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
