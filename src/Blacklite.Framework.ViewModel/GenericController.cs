using Microsoft.AspNet.Mvc;

namespace Blacklite.Framework.ViewModel
{
    public class GenericController : Controller
    {
        public IActionResult GetGeneric()
        {
            return View();
        }

        public IActionResult PostGeneric()
        {
            return View();
        }
    }
}
