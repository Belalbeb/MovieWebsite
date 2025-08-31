using Ecommerce_App.Data.Services;
using Ecommerce_App.Models;
using Microsoft.AspNetCore.Mvc;

namespace Ecommerce_App.Controllers
{
    public class ActorsController : Controller
    {
        private readonly IActorsServices actorsServices;

        public ActorsController(IActorsServices actorsServices)
        {
            this.actorsServices = actorsServices;
        }

   

        public IActionResult Index()
        {
            var Data = actorsServices.GetAll();
            return View(Data);
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("FullName,ProfilePictureUrl,Bio")]Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);

            }
            actorsServices.Add(actor);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Details(int id)
        {
         var  actorDetails= actorsServices.GetById(id);
            if (actorDetails == null) return View("NotFound");
            return View(actorDetails);
        }
        public async Task<IActionResult> Edit(int id)
        {
            var actorDetails = actorsServices.GetById(id);
            if (actorDetails == null) return View("NotFound");
            return View(actorDetails);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id,[Bind("FullName,ProfilePictureUrl,Bio")] Actor actor)
        {
            if (!ModelState.IsValid)
            {
                return View(actor);

            }
            actorsServices.Update(id,actor);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int id)
        {
            var actorDetails = actorsServices.GetById(id);
            if (actorDetails == null) return View("NotFound");
            return View(actorDetails);
        }
        [HttpPost,ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmd(int id)
        {
            var actorDetails = actorsServices.GetById(id);
            if (actorDetails == null) return View("NotFound");
            actorsServices.Delete(id);
           
            return RedirectToAction("Index");
        }
    }
}
