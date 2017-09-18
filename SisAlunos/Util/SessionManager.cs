using System.Web;

namespace SisAlunos.Util
{
    public class SessionManager
    {

        // Gets the current session.
        public static UsuarioSession Current
        {
            get
            {
                UsuarioSession usuarioLogado = (UsuarioSession)HttpContext.Current.Session["DadosUsuario"];
                if (usuarioLogado == null)
                {
                    usuarioLogado = new UsuarioSession();
                    HttpContext.Current.Session["DadosUsuario"] = usuarioLogado;
                }
                return usuarioLogado;
            }
        }

     
    }
}