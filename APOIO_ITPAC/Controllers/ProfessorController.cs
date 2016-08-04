using ApoioMVC.MODEL;
using ApoioMVC.REPOSITORIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace ApoioMVC.Controllers
{
    public class ProfessorController : Controller
    {
        //
        // GET: /Professor/
        List<Professor> ProfList;
        ProfessorRepositorio _ProfRep = new ProfessorRepositorio();
        private void CarregaLista()
        {
            ProfList = _ProfRep.Lista(new ProfessorMapper());
            Session["Lista"] = ProfList;
        }
        public ActionResult Index()
        {
            CarregaLista();
            return View(ProfList);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Professor P)
        {
            CarregaLista();
            _ProfRep.ADD(P);
            P.ID = ProfList.Count == 0 ? 0 : ProfList.Last().ID + 1;
            Session["Lista"] = ProfList;
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            CarregaLista();
            return View(ProfList.Where(X => X.ID == id).First());
        }
        [HttpPost]
        public ActionResult Delete(Professor P)
        {
            CarregaLista();
            _ProfRep.Delete(ProfList.Where(X => X.ID == P.ID).First());
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            CarregaLista();
            //passando uma model P
            Professor P = ProfList.Where(X => X.ID == id).First();
            CarregaLista();
            return View(P);
        }
        [HttpPost]
        public ActionResult Edit(Professor P)
        {
            //carrega lista e traz um objeto da lista para ser editado
            
            _ProfRep.Update(P);
            CarregaLista();
            return RedirectToAction("Index");

        }
        public ActionResult Details(int id)
        {
            CarregaLista();
            return View(ProfList.Where(X => X.ID == id).First());
        }
    }
}
