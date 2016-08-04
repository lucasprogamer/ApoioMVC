using ApoioMVC.MODEL;
using ApoioMVC.REPOSITORIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ApoioMVC.Controllers
{
    public class SalaController : Controller
    {
        List<Sala> SalaList;
        SalaRepositorio _SalaRep = new SalaRepositorio();
        private void CarregaLista()
        {
                SalaList = _SalaRep.Lista(new SalaMapper());
                Session["ListaSala"] = SalaList;
            
        }
        public ActionResult Index()
        {
            CarregaLista();
            return View(SalaList);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Sala S)
        {
            CarregaLista();
            _SalaRep.ADD(S);
            S.ID = SalaList.Count == 0 ? 0 : SalaList.Last().ID + 1;
            Session["ListaSala"] = SalaList;
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            CarregaLista();
            return View(SalaList.Where(X => X.ID == id).First());
        }
        [HttpPost]
        public ActionResult Delete(Sala S)
        {
            CarregaLista();
            _SalaRep.Delete(SalaList.Where(X => X.ID == S.ID).First());
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            CarregaLista();

            Sala S = SalaList.Where(X => X.ID == id).First();
            CarregaLista();
            return View(S);
        }
        [HttpPost]
        public ActionResult Edit(Sala S)
        {
            //carrega lista e traz um objeto da lista para ser editado

            _SalaRep.Update(S);
            CarregaLista();
            return RedirectToAction("Index");

        }
        public ActionResult Details(int id)
        {
            CarregaLista();
            return View(SalaList.Where(X => X.ID == id).First());
        }
    }
}
