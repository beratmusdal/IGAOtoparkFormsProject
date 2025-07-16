using Microsoft.AspNetCore.Mvc;

namespace IGAOtoParkFormsProject.UI.Controllers
{
    public class DashboardController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public PartialViewResult _HeadPartial()
        {
            return PartialView();
        }
        public PartialViewResult _HeaderPartial()
        {
            return PartialView();
        }
        public PartialViewResult _AsidePartial()
        {
            return PartialView();
        }
        public PartialViewResult _SubHeaderPartial()
        {
            return PartialView();
        }
        public PartialViewResult _FooterPartial()
        {
            return PartialView();
        }
        public PartialViewResult _ScriptsPartial()
        {
            return PartialView();
        }
    }
}
