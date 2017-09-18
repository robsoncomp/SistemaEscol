using System.Web.Mvc;
using SisAlunos.ModelData.Dados;
using SisAlunos.Util;
using SisAlunos.Views.ViewModel;
using DateTime = System.DateTime;

namespace SisAlunos.Controllers
{
    public class UsuariosController : BaseController
    {
        private EscolaEntities db = new EscolaEntities();

        public ActionResult Cadastro()
        {
            CarregarDropDownCidades();
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Cadastro(CadastroUsuarioViewModel cadastroUsuarioViewModel)
        {
            CarregarDropDownCidades();
            if (ModelState.IsValid)
            {
                var usuario = Mapper.Map<CadastroUsuarioViewModel, Usuarios>(cadastroUsuarioViewModel);
                cadastroUsuarioViewModel = null;
                usuario.DataCadastro = DateTime.Now;
                usuario.Senha = GerarHashMd5(usuario.Senha);
                db.Usuarios.Add(usuario);
                db.SaveChanges();
                EmitirMensagem("Usuário cadastrado com sucesso", Enumerators.EtipoMensagem.Sucesso);
                return View(cadastroUsuarioViewModel);
            }

            EmitirMensagem("Erro ao salvar usuário", Enumerators.EtipoMensagem.Erro);
            return View(cadastroUsuarioViewModel);
        }
        private void CarregarDropDownCidades()
        {
            ViewBag.CidadeID = new SelectList(db.Cidades, "CidadeID", "NomeCidade");
        }

    }
}
