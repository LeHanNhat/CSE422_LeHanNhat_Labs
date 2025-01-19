using LeHanNhat_Lab2_CSE422.Models;
using LeHanNhat_Lab2_CSE422.Services;
using Microsoft.AspNetCore.Mvc;

namespace LeHanNhat_Lab2_CSE422.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View(DataStore.Users);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(User user)
        {
            if (ModelState.IsValid)
            {
                user.Id = DataStore.Users.Count > 0 ?
                    DataStore.Users.Max(x => x.Id) + 1 : 1;
                DataStore.Users.Add(user);
                return RedirectToAction(nameof(Index));
            }
            return View(user);
        }

        public IActionResult Edit(int id)
        {
            var user = DataStore.Users.FirstOrDefault(x => x.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        [HttpPost]
        public IActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                var existingUser = DataStore.Users.FirstOrDefault(x => x.Id == user.Id);
                if (existingUser != null)
                {
                    existingUser.Name = user.Name;
                    return RedirectToAction(nameof(Index));
                }
            }
            return View(user);
        }

        public IActionResult Delete(int id)
        {
            var user = DataStore.Users.FirstOrDefault(x => x.Id == id);
            if (user == null)
            {
                return NotFound();
            }
            return View(user);
        }

        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var user = DataStore.Users.FirstOrDefault(x => x.Id == id);
            if (user != null)
            {
                DataStore.Users.Remove(user);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
