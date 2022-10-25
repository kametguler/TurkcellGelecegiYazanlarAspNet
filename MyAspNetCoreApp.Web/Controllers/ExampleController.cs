using Microsoft.AspNetCore.Mvc;

namespace MyAspNetCoreApp.Web.Controllers
{
    public class Product2
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }
    public class ExampleController : Controller
    {
        public IActionResult Index(int id)
        {
            //ViewBag.name = "Kamet Güler";
            //ViewBag.names = new List<string> {"Kamet", "Güler", "Kaan", "Kahraman", "Erk" };
            //ViewData["age"] = 15;
            //ViewBag.person = new { id = 1, name = "Kamet Güler", age = 22 };

            //TempData["id"] = "kamet";

            var productList = new List<Product2>()
            {
                new(){Id = 1,Name = "Kalem"},
                new(){Id = 2, Name= "Kitap"},
                new(){Id = 3, Name= "Defter"},
            };

            return View(productList);
        }

        public IActionResult ParameterView(int id)
        { 
            return RedirectToAction("JsonResultParameter", "Example", new {id=id});
        }
        public IActionResult Index2()
        {  
            return View();
        }

        public IActionResult Index3()
        {
            return RedirectToAction("Index");
            //return View();
        }

        public IActionResult JsonResultParameter(int id)
        {
            return Json(new { Id = id});
        }


        public IActionResult ContentResult()
        {
            return Content("Content Result");
        }
        public IActionResult JsonResult()
        {
            return Json(new {Id = 1, name = "pencil", price = 15});
        }

        public IActionResult EmptyResult()
        {
            return new EmptyResult();
        }
    }
}
