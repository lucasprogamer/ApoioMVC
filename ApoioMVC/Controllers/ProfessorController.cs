using ApoioMVC.REPOSITORIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ApoioMVC.Controllers
{
    public class ProfessorController : Controller
    {
        //
        // GET: /Professor/
        ProfessorRepositorio _ProfRep = new ProfessorRepositorio();

        public ActionResult Index()
        {
            return View(_ProfRep.Lista(new ProfessorMapper()));
        }

    }
}
