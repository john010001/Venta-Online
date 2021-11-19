using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace VentaOnLine.UI.MVC.Controllers
{
    public class AtendimientoController : Controller
    {
        // GET: Atendimiento
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Despacho()
        {
            return View();
        }
    }
}