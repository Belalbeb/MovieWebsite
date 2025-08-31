using Ecommerce_App.Data.Services;
using Ecommerce_App.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce_App.Controllers
{
    public class CinemaController : Controller
    {
        private readonly ICinema cinemaServices;

        public CinemaController(ICinema cinema)
        {
            this.cinemaServices = cinema;
        }
        public IActionResult Index()
        {
            var allCinema = cinemaServices.GetAll();
            return View(allCinema);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create([Bind("Logo,Name,Description")]Cinema cinema)
        {
            if (ModelState.IsValid)
            {
                cinemaServices.Add(cinema);
                return RedirectToAction("Index");
                

            }
            else
            {
                return View(cinema);
            }

        }
        public IActionResult Edit(int id)
        {
            var Item = cinemaServices.GetById(id);
            return View(Item);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, [Bind("Logo,Name,Description")] Cinema cinema)
        {
            if (ModelState.IsValid)
            {
                await cinemaServices.Update(id, cinema);
                return RedirectToAction("Index");
            }
            else
            {
                return View(cinema);
            }
        }
        public IActionResult Delete(int id)
        {
            var Item = cinemaServices.GetById(id);
            return View(Item);

        }
        [HttpPost]
        public async Task<IActionResult> Delet(int id)
        {
            cinemaServices.Delete(id);
            return RedirectToAction("Index");

        }
        public IActionResult Details(int id)
        {
            var Item = cinemaServices.GetById(id);
            return View(Item);


        }
    }
}
