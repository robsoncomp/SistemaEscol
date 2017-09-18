using System;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SisAlunos.Grid;
using SisAlunos.ModelData.Dados;
using SisAlunos.Views.ViewModel;

namespace SisAlunos.Controllers
{
    [NoCache]
    public class CidadesController : BaseController
    {
        private EscolaEntities db = new EscolaEntities();

        public ActionResult AlunosCidade()
        {
            return View(db.Cidades.ToList());
        }

        public ActionResult Criar()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Criar(CidadeViewModel cidadeViewModel)
        {
            if (ModelState.IsValid)
            {
                var cidades = Mapper.Map<CidadeViewModel, Cidades>(cidadeViewModel);
                db.Cidades.Add(cidades);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(cidadeViewModel);
        }


        public ActionResult Editar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cidades cidadeModel = db.Cidades.Find(id);
            if (cidadeModel == null)
            {
                return HttpNotFound();
            }
            var cidade = Mapper.Map<Cidades, CidadeViewModel>(cidadeModel);
            return View(cidade);
        }

        [HttpPost]
        public ActionResult Editar(CidadeViewModel cidadeViewModel)
        {
            if (ModelState.IsValid)
            {
                var cidades = Mapper.Map<CidadeViewModel, Cidades>(cidadeViewModel);
                db.Entry(cidades).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(cidadeViewModel);
        }

        public ActionResult Excluir(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Cidades cidades = db.Cidades.Find(id);
            var cidade = Mapper.Map<Cidades, CidadeViewModel>(cidades);
            return View(cidade);
        }

        [HttpPost]
        public ActionResult ConfirmarExclusao(int id)
        {
            Cidades cidades = db.Cidades.Find(id);
            if (cidades != null)
                db.Cidades.Remove(cidades);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public JsonResult GetCidades(int? page, int? limit, string sortBy, string direction, string searchString = null)
        {

            int total;
            var records = new GridModel().GetCidadesGrid(page, limit, sortBy, direction, searchString, out total);
            return Json(new { records, total }, JsonRequestBehavior.AllowGet);
        }


        [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method)]
        public sealed class NoCacheAttribute : ActionFilterAttribute
        {
            public override void OnResultExecuting(ResultExecutingContext filterContext)
            {
                filterContext.HttpContext.Response.Cache.SetExpires(DateTime.UtcNow.AddDays(-1));
                filterContext.HttpContext.Response.Cache.SetValidUntilExpires(false);
                filterContext.HttpContext.Response.Cache.SetRevalidation(HttpCacheRevalidation.AllCaches);
                filterContext.HttpContext.Response.Cache.SetCacheability(HttpCacheability.NoCache);
                filterContext.HttpContext.Response.Cache.SetNoStore();
                base.OnResultExecuting(filterContext);
            }
        }

    }


}





