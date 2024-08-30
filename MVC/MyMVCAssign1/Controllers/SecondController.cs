using Microsoft.AspNetCore.Mvc;

namespace MyMVCAssign1.Controllers
{
    public class SecondController : Controller
    {
        public IActionResult Index1()
        {
            return Content("This is SecondController - Index1");
        }
        public IActionResult Index2()
        {
            return Content("This is SecondController - Index2");
        }

        public IActionResult Index3()
        {
            return Content("This is SecondController - Index3");
        }
    }
}
