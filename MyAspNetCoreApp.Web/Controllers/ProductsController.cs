using Microsoft.AspNetCore.Mvc;
using MyAspNetCoreApp.Web.Helpers;
using MyAspNetCoreApp.Web.Models;

namespace MyAspNetCoreApp.Web.Controllers
{
    public class ProductsController : Controller
    {
        private AppDbContext _context;
        private readonly ProductRepository _productRepository;
        public IHelper _helper;
        private ProductsController(AppDbContext context, IHelper helper)
        {
            //DI CONTAINER
            //Dependency Injection Pattern 
            _productRepository = new ProductRepository();
            _helper = helper;
            _context = context;
           
        if (!_context.Products.Any())
            {
                _context.Products.Add(new Product() { Name = "Kalem 1", Price = 100, Stock = 100});
                _context.Products.Add(new Product() { Name = "Kalem 2", Price = 200, Stock = 200});
                _context.Products.Add(new Product() { Name = "Kalem 3", Price = 300, Stock = 300});
                _context.SaveChanges();
            }
        }
        public IActionResult Index()
        {
            var products = _context.Products.ToList();
            return View(products);
        }

        public IActionResult Remove(int id)
        {
            var removeProduct = _context.Products.Find(id);
            _context.Products.Remove(removeProduct);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Add(Product newProduct)
        {
            // 1. Way of doing
            //var name = HttpContext.Request.Form["Name"].ToString();
            //var price = Decimal.Parse(HttpContext.Request.Form["Price"].ToString());
            //var stock = int.Parse(HttpContext.Request.Form["Stock"].ToString());

            //_context.Products.Add(new Product() { Name = name, Price = price, Stock = stock });
            //_context.SaveChanges();

            //2. Way of doing (parameters)
            //_context.Products.Add(new Product() { Name = Name, Price = Price, Stock = Stock });

            //3. Way of doing (with model parameter instance)
            _context.Products.Add(newProduct);
            _context.SaveChanges();

            return RedirectToAction("Index");
        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            var product = _context.Products.Find(id);
            TempData["status"] = "Ürün başarıyla eklendi!";
            return View(product);
        }
        [HttpPost]
        public IActionResult Update(Product updateProduct, int productId)
        {
            updateProduct.Id = productId;
            _context.Products.Update(updateProduct);
            _context.SaveChanges();
            TempData["status"] = "Ürün başarıyla güncellendi!";
            return RedirectToAction("Index");
        }
    }
}
