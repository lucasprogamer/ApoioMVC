using ApoioMVC.MODEL;
using ApoioMVC.REPOSITORIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace APOIO_ITPAC.Controllers
{
    public class AtivoController : Controller
    {
        // GET: Ativo
        //
        // GET: /Professor/
        List<Ativo> AtivoList;
        AtivoRepositorio _AtivoRep = new AtivoRepositorio();
        private void CarregaLista()
        {      
                AtivoList = _AtivoRep.Lista(new AtivoMapper());
                Session["Lista"] = AtivoList;
        }
        public ActionResult Index()
        {
            CarregaLista();
            return View(AtivoList);
        }
        public ActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Create(Ativo A)
        {
            CarregaLista();
            _AtivoRep.ADD(A);
            A.ID = AtivoList.Count == 0 ? 0 : AtivoList.Last().ID + 1;
            Session["Lista"] = AtivoList;
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int id)
        {
            CarregaLista();
            return View(AtivoList.Where(X => X.ID == id).First());
        }
        [HttpPost]
        public ActionResult Delete(Ativo A)
        {
            CarregaLista();
            _AtivoRep.Delete(AtivoList.Where(X => X.ID == A.ID).First());
            return RedirectToAction("Index");
        }
        public ActionResult Edit(int id)
        {
            CarregaLista();
            //passando uma model P
            Ativo A = AtivoList.Where(X => X.ID == id).First();
            CarregaLista();
            return View(A);
        }
        [HttpPost]
        public ActionResult Edit(Ativo A)
        {
            //carrega lista e traz um objeto da lista para ser editado

            _AtivoRep.Update(A);
            CarregaLista();
            return RedirectToAction("Index");

        }
        public ActionResult Details(int id)
        {
            CarregaLista();
            return View(AtivoList.Where(X => X.ID == id).First());
        }
    }
}