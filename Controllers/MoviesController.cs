using Ecommerce_App.Data.Services;
using Ecommerce_App.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Build.ObjectModelRemoting;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce_App.Controllers
{
    public class MoviesController : Controller
    {
        private readonly IMovies movies;

        public AppDbContext Context { get; }

        public MoviesController(IMovies movies,AppDbContext context)
        {
            this.movies = movies;
            Context = context;
        }

        public IActionResult Index()
        {
            var allMovies = movies.GetAll();
            return View(allMovies);
        }
        public IActionResult Details(int id)
        {
            var item = movies.GetById(id);
            if (item == null) return View("NotFound");
            return View(item);
        }
        public IActionResult Create()
        {
            ViewBag.Cinemas = new SelectList(Context.Cinemas, "Id", "Name");
            ViewBag.Producers = new SelectList(Context.Producers, "Id", "FullName");

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("Name,Description,Price,ImageUrl,StartDate,EndDate,MovieCategory,ProducerId,CinemaId")]Movie movie)
        {

            if (ModelState.IsValid)
            {
                 movies.Add(movie);
                return RedirectToAction("Index");
            }
            else
            {
                return View(movie);
            }

        }
        public IActionResult Edit(int id)
        {


            var item = movies.GetById(id);
            if (item == null) return View("NotFound");
            ViewBag.Cinemas = new SelectList(Context.Cinemas, "Id", "Name", item.CinemaId);

            ViewBag.Producers = new SelectList(Context.Producers, "Id", "FullName",item.ProducerId);
            return View(item);
        }
        [HttpPost]
        public IActionResult Edit(int id, [Bind("Name,Description,Price,ImageUrl,StartDate,EndDate,MovieCategory,ProducerId,CinemaId")] Movie movie)
        {
            if (ModelState.IsValid)
            {
                movies.Update(id, movie);
                return RedirectToAction("Index");
            }
            else
            {
                return View(movie);
            }
        }
        public IActionResult Delete(int id)
        {
            var item = movies.GetById(id);

            
            ViewBag.Cinemas = new SelectList(Context.Cinemas, "Id", "Name", item.CinemaId);
            ViewBag.Producers = new SelectList(Context.Producers, "Id", "FullName", item.ProducerId);

            return View(item);
        }

        [HttpPost]
        public IActionResult Delet(int id)
        {
            movies.Delete(id);
            return RedirectToAction("Index");
        }
        public IActionResult Filter(string searchString)
        {
            var FilterByName = movies.FillterByName(searchString);
            return View("Index", FilterByName);

        }
    }
}
