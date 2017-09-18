using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using SisAlunos.ModelData.Dados;

namespace SisAlunos.Controllers
{
    public class GraficosController : BaseController
    {
        private EscolaEntities db = new EscolaEntities();

        public ActionResult Index()
        {
            return View();
        }


        public JsonResult GetChartDataAlunosCidade()
        {
            List<Cidades> listCidades = db.Cidades.OrderBy(x => x.Alunos.Count).ToList();

            var data = new object[listCidades.Count + 1]; 

            data[0] = new object[] { "Cidade", "Alunos" };

            int i = 1;

            foreach (var item in listCidades)
            {
                data[i] = new object[] { item.NomeCidade, item.Alunos.Count };
                i++;
            }
            return Json(data, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetChartDataAlunosData()
        {
            List<Alunos> listCidades = db.Alunos.OrderBy(x => x.DataCadastro).ToList();

            var somaAlunosCadastradosData = listCidades.GroupBy(c => c.DataCadastro.Date).Select(group => new { Data = group.Key, qtde = group.Count() });

            var data = new object[somaAlunosCadastradosData.Count() + 1];

            data[0] = new object[] { "Data", "Alunos" };

            int i = 1;

            foreach (var item in somaAlunosCadastradosData)
            {
                data[i] = new object[] { item.Data.ToString("d"), item.qtde };
                i++;
            }
            return Json(data, JsonRequestBehavior.AllowGet);
        }


    }
}