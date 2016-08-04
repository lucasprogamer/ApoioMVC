using ApoioMVC.MODEL;
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
        List<Curso> CursoList;
        CursoRepositorio _CursoRep = new CursoRepositorio();
        private void CarregaLista()
        {
            CursoList = _CursoRep.Lista(new CursoMapper());
            Session["ListaCurso"] = CursoList;

        }

        public ActionResult Index()
        {
            CarregaLista();
            return View(CursoList);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Curso C)
        {
            CarregaLista();
            _CursoRep.ADD(C);
            C.ID = CursoList.Count == 0 ? 0 : CursoList.Last().ID + 1;
            Session["Lista"] = CursoList;
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            CarregaLista();
            return View(CursoList.Where(X => X.ID == id).First());
        }
        [HttpPost]
        public ActionResult Delete(Curso C)
        {
            CarregaLista();
            _CursoRep.Delete(CursoList.Where(X => X.ID == C.ID).First());
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            CarregaLista();
            //passando uma model C
            Curso C = CursoList.Where(X => X.ID == id).First();
            CarregaLista();
            return View(C);
        }
        [HttpPost]
        public ActionResult Edit(Curso C)
        {
            //carrega lista e traz um objeto da lista para ser editado

            _CursoRep.Update(C);
            CarregaLista();
            return RedirectToAction("Index");

        }
        public ActionResult Details(int id)
        {
            CarregaLista();
            return View(CursoList.Where(X => X.ID == id).First());
        }
    }
}
