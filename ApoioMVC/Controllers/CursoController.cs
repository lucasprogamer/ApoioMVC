using ApoioMVC.REPOSITORIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ApoioMVC.Controllers
{
    public class CursoController : Controller
    {
        //
        // GET: /Curso/
        CursoRepositorio _CursoRep = new CursoRepositorio();

        public ActionResult Index()
        {
            return View(_CursoRep.Lista(new CursoMapper()));
        }

    }
}
