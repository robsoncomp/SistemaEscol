using System.Linq;
using System.Web.Mvc;
using SisAlunos.ModelData.Dados;
using SisAlunos.Util;
using SisAlunos.Views.ViewModel;

namespace SisAlunos.Controllers
{
    public class HomeController : BaseController
    {

        private EscolaEntities db = new EscolaEntities();

        public ActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Login(LoginViewModel usuarioLogin)
        {
            if (ModelState.IsValid)
            {

                string senha = GerarHashMd5(usuarioLogin.Senha);
                var usuario = db.Usuarios.FirstOrDefault(us => us.Email.Equals(usuarioLogin.Email) && us.Senha.Equals(senha));
                if (usuario != null)
                {
                    UsuarioSession usuarioLogado = new UsuarioSession();
                    usuarioLogado.UsuarioId = usuario.UsuarioID;
                    usuarioLogado.Nome = usuario.Nome;
                    usuarioLogado.Email = usuario.Email;
                    Session["DadosUsuario"] = usuarioLogado;
                    EmitirMensagem("Login efetuado com sucesso.", Enumerators.EtipoMensagem.Sucesso);
                    return RedirectToAction("HomeLogado");
                }
                else
                {
                    EmitirMensagem("Usuario ou senha invalida", Enumerators.EtipoMensagem.Erro);
                }

            }
            return View(usuarioLogin);
        }

        public ActionResult HomeLogado()
        {
            if (Session["DadosUsuario"] != null)
            {
                ViewBag.NomeUsuario = UsuarioLogado.Nome;
                return View();
            }
            else
            {
                EmitirMensagem("Você deve ser logar para acessar essa pagina.", Enumerators.EtipoMensagem.Erro);
                return RedirectToAction("Login");

            }

        }

        public ActionResult Sair()
        {
            Session["DadosUsuario"] = null;
            {
                EmitirMensagem("Você deve ser logar para acessar essa pagina.", Enumerators.EtipoMensagem.Erro);
                return RedirectToAction("Login");
            }

        }
    }
}