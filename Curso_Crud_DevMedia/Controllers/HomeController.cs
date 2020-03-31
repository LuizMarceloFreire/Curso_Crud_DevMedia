using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Curso_Crud_DevMedia.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Aplicação voltada para estudos";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "...";

            return View();
        }
    }
}