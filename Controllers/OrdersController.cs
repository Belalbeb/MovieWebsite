using Ecommerce_App.Data.Services;
using Ecommerce_App.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Ecommerce_App.Controllers
{
    public class OrdersController : Controller
    {

        private readonly IOrderServices orderServices;
        private readonly AppDbContext _context;

        public UserManager<ApplicationUser> UserManager { get; }

        public OrdersController(IOrderServices orderServices,UserManager<ApplicationUser> userManager,AppDbContext context)
        {
            this.orderServices = orderServices;
            UserManager = userManager;
            this._context = context;
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Cart()
        {
            var userId = UserManager.GetUserId(User);

            if (userId == null)
            {
                return Unauthorized();
            } 

            var cart = _context.orders
                .Include(o => o.Items)
                .ThenInclude(i => i.Movie)
                .FirstOrDefault(o => o.UserId == userId);

            if (cart == null)
            {
                cart = new Order { Items = new List<OrderItem>() };
            }

            return View(cart);
        }
        [HttpPost]
        public IActionResult UpdateQuantity(int itemId, int quantity)
        {
            var item = _context.Items.FirstOrDefault(i => i.Id == itemId);

            if (item != null && quantity > 0)
            {
               item.Quantity = quantity;
                _context.SaveChanges();
            }

            return RedirectToAction("Cart");
        }
        [HttpPost]
        public IActionResult RemoveItem(int itemId)
        {
            var item = _context.Items.FirstOrDefault(i => i.Id == itemId);

            if (item != null)
            {
                _context.Items.Remove(item);
                _context.SaveChanges();
            }

            return RedirectToAction("Cart");
        }



        public IActionResult AddItemToShoppingCart(int Id)
        {
            var userId = UserManager.GetUserId(User);

            if (userId == null)
            {
                return RedirectToAction("Login","Account"); 
            } 

            
            var cart = _context.orders
                .Include(o => o.Items)
                .FirstOrDefault(o => o.UserId == userId);

            if (cart == null)
            {
                
                cart = new Order
                {
                    UserId = userId,
                    Items = new List<OrderItem>()
                };
                _context.orders.Add(cart);
            }

            
            var existingItem = cart.Items.FirstOrDefault(i => i.MovieId == Id);

            if (existingItem != null)
            {
                
                existingItem.Quantity++;
            }
            else
            {
                
                var orderItem = new OrderItem
                {
                    MovieId = Id,
                    Quantity = 1
                };
                cart.Items.Add(orderItem);
            }

          
            _context.SaveChanges();

            return RedirectToAction("Cart");
        }


    }
}
