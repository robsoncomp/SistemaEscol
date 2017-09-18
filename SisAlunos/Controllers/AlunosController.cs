using System;
using System.Data.Entity;
using System.Net;
using System.Web.Mvc;
using SisAlunos.Grid;
using SisAlunos.ModelData.Dados;
using SisAlunos.Util;
using SisAlunos.Views.ViewModel;

namespace SisAlunos.Controllers
{
    public class AlunosController : BaseController
    {
        private EscolaEntities db = new EscolaEntities();

        public ActionResult Index()
        {
            return View();
        }
        //teste
        public ActionResult Criar()
        {
            ViewBag.CidadeID = new SelectList(db.Cidades, "CidadeID", "NomeCidade");
            return View();
        }

        [HttpPost]
        public ActionResult Criar(AlunoViewModel alunoViewModel)
        {
            if (ModelState.IsValid)
            {
                var aluno = Mapper.Map<AlunoViewModel, Alunos>(alunoViewModel);
                aluno.DataCadastro = DateTime.Now;
                aluno.DataUltimaAlteracao = DateTime.Now;
                aluno.NomeUsuarioAlteracao = UsuarioLogado.Nome;
                db.Alunos.Add(aluno);
                db.SaveChanges();
                EmitirMensagem("Aluno salvo com sucesso.", Enumerators.EtipoMensagem.Sucesso);
                return RedirectToAction("Index");
            }
            EmitirMensagem("Erro ao salvar aluno.", Enumerators.EtipoMensagem.Erro);
            ViewBag.CidadeID = new SelectList(db.Cidades, "CidadeID", "NomeCidade", alunoViewModel.CidadeID);
            return View(alunoViewModel);
        }

        [HttpPost]
        public JsonResult SalvarResponsavelAluno(ResponsavelAlunoViewModel responsavel)
        {

            if (ModelState.IsValid)
            {
                var responsaveis = Mapper.Map<ResponsavelAlunoViewModel, Responsaveis>(responsavel);
                responsaveis.DataCadastro = DateTime.Now;
                db.Responsaveis.Add(responsaveis);
                db.SaveChanges();

                EmitirMensagem("Responsável salvo com sucesso.", Enumerators.EtipoMensagem.Sucesso);
                return Json(new { resposta = "OK" });
            }
            EmitirMensagem("Erro ao salvar responsável.", Enumerators.EtipoMensagem.Erro);
            return Json(new { resposta = "ERRO" });
        }

        public ActionResult Editar(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alunos alunos = db.Alunos.Find(id);
            if (alunos == null)
            {
                return HttpNotFound();
            }
            ViewBag.CidadeID = new SelectList(db.Cidades, "CidadeID", "NomeCidade", alunos.CidadeID);
            var aluno = Mapper.Map<Alunos, AlunoViewModel>(alunos);
            return View(aluno);
        }


        [HttpPost]
        public ActionResult Editar(AlunoViewModel alunoViewModel)
        {
            if (ModelState.IsValid)
            {
                var aluno = Mapper.Map<AlunoViewModel, Alunos>(alunoViewModel);
                aluno.DataUltimaAlteracao = DateTime.Now;
                aluno.NomeUsuarioAlteracao = UsuarioLogado.Nome;
                db.Entry(aluno).State = EntityState.Modified;
                db.SaveChanges();
                EmitirMensagem("Aluno alterado com sucesso.", Enumerators.EtipoMensagem.Sucesso);
                return RedirectToAction("Index");
            }
            EmitirMensagem("Erro ao editar aluno.", Enumerators.EtipoMensagem.Erro);
            ViewBag.CidadeID = new SelectList(db.Cidades, "CidadeID", "NomeCidade", alunoViewModel.CidadeID);
            return View(alunoViewModel);
        }


        public ActionResult Excluir(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Alunos alunos = db.Alunos.Find(id);
            if (alunos == null)
            {
                return HttpNotFound();
            }

            var aluno = Mapper.Map<Alunos, AlunoViewModel>(alunos);
            return View(aluno);
        }


        [HttpPost]
        public ActionResult ExcluirConfirmed(int id)
        {
            Alunos alunos = db.Alunos.Find(id);
            db.Alunos.Remove(alunos);
            db.SaveChanges();
            EmitirMensagem("Aluno Excluido com sucesso.", Enumerators.EtipoMensagem.Sucesso);
            return RedirectToAction("Index");
        }


        [HttpGet]
        public JsonResult GetAlunos(int? page, int? limit, string sortBy, string direction, string searchString = null)
        {
            int total;
            var records = new GridModel().GetAlunosGrid(page, limit, sortBy, direction, searchString, 0, out total);
            return Json(new { records, total }, JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public JsonResult GetAlunosPorCidade(int? page, int? limit, string sortBy, string direction, string searchString = null, int id = 0)
        {
            int total;
            var records = new GridModel().GetAlunosGrid(page, limit, sortBy, direction, searchString, id, out total);

            return Json(new { records, total }, JsonRequestBehavior.AllowGet);
        }

    }
}
