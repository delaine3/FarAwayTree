using Microsoft.AspNetCore.Mvc;

namespace FarawayTree.Controllers
{
    public class BucketlistController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }


    }
}
