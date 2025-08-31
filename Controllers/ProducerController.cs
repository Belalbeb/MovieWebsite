using Ecommerce_App.Data.Services;
using Ecommerce_App.Models;
using Microsoft.AspNetCore.Mvc;
using System.ClientModel.Primitives;

namespace Ecommerce_App.Controllers
{
    public class ProducerController : Controller
    {
        private readonly IProducerServices producerServices;

        public ProducerController(IProducerServices producerServices)
        {
            this.producerServices = producerServices;
        }

        public IActionResult Index()
        {
            var allProducer = producerServices.GetAll();
            return View(allProducer);
        }
        public async Task<IActionResult> Details(int id)
        {
            var pro = producerServices.GetById(id);
            if (pro == null) return View("NotFound");
            return View(pro);
        }
        public async Task<IActionResult> Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create([Bind("ProfilePictureUrl,FullName,Bio")]Producer producer)
        {
            if (ModelState.IsValid)
            {
              producerServices.Add(producer);
               return RedirectToAction("Index");
            }
            else
            {
                return View(producer);
            }

        }
        public async Task<IActionResult> Edit(int id)
        {
            var Pro = producerServices.GetById(id);
            return View(Pro);

        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id,[Bind("ProfilePictureUrl,FullName,Bio")]Producer producer)
        {
            if (!ModelState.IsValid) return View(producer);
           await producerServices.Update(id, producer);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Delete(int id)
        {
            var Pro = producerServices.GetById(id);
            return View(Pro);

        }
        [HttpPost]
        public async Task<IActionResult> Delet(int id)
        {

            producerServices.Delete(id);
            return RedirectToAction("Index");

        }

    }
}
