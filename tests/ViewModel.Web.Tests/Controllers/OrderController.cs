using Microsoft.AspNet.Mvc;

namespace ViewModel.Web.Tests.Controllers
{
    public class OrderController : Controller
    {


        public IActionResult Index()
        {
            return View();
        }
    }
}
