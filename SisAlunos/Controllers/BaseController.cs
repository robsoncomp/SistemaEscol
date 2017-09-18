using System.Security.Cryptography;
using System.Text;
using System.Web.Mvc;
using AutoMapper;
using SisAlunos.ModelData.Dados;
using SisAlunos.Util;
using SisAlunos.Views.ViewModel;

namespace SisAlunos.Controllers
{
    public abstract class BaseController : Controller
    {
        protected readonly IMapper Mapper;

        public UsuarioSession UsuarioLogado = (UsuarioSession)System.Web.HttpContext.Current.Session["DadosUsuario"];
        protected BaseController()
        {
           

            var config = new MapperConfiguration(x =>
            {
                //Cadastro de Usuarios
                x.CreateMap<CadastroUsuarioViewModel, Usuarios>();
                x.CreateMap<Usuarios, CadastroUsuarioViewModel>();

                //Login
                x.CreateMap<LoginViewModel, Usuarios>();
                x.CreateMap<Usuarios, LoginViewModel>();

                //CRUD Cidades
                x.CreateMap<CidadeViewModel, Cidades>();
                x.CreateMap<Cidades, CidadeViewModel>();

                //CRUD Alunos
                x.CreateMap<AlunoViewModel, Alunos>();
                x.CreateMap<Alunos, AlunoViewModel>();

                //Responsavel Aluno
                x.CreateMap<ResponsavelAlunoViewModel, Responsaveis>();
                x.CreateMap<Responsaveis, ResponsavelAlunoViewModel>();

            });

            Mapper = config.CreateMapper();
        }


        public void EmitirMensagem(string mensagem, Enumerators.EtipoMensagem etipoMensagem)
        {
            switch (etipoMensagem)
            {
                case Enumerators.EtipoMensagem.Erro:
                    TempData["MensagemErro"] = mensagem;
                    break;
                case Enumerators.EtipoMensagem.Sucesso:
                    TempData["MensagemSucesso"] = mensagem;
                    break;
            }
        }

        public static string GerarHashMd5(string input)
        {
            MD5 md5Hash = MD5.Create();
            // Converter a String para array de bytes, que é como a biblioteca trabalha.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Cria-se um StringBuilder para recompôr a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop para formatar cada byte como uma String em hexadecimal
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            return sBuilder.ToString();
        }

    }
}