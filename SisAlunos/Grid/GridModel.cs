using System.Collections.Generic;
using System.Linq;
using SisAlunos.ModelData.Dados;


namespace SisAlunos.Grid
{
    public class GridModel
    {
        public List<GridCidades> GetCidadesGrid(int? page, int? limit, string sortBy, string direction, string searchString, out int total)
        {

            EscolaEntities escolaEntities = new EscolaEntities();
            List<Cidades> listCidades = escolaEntities.Cidades.ToList();
            List<GridCidades> listGridCidades = new List<GridCidades>();


            foreach (var item in listCidades)
            {
                GridCidades g = new GridCidades();
                g.ID = item.CidadeID;
                g.Nome = item.NomeCidade;
                g.CEP = item.CEP;
                g.Estado = item.Estado;
                g.NumeroAlunos = item.Alunos.Count;
                listGridCidades.Add(g);
            }

            var records = listGridCidades.AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchString))
            {
                records = records.Where(p => p.Nome.Contains(searchString) || p.Estado.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(sortBy) && !string.IsNullOrEmpty(direction))
            {
                if (direction.Trim().ToLower() == "asc")
                {
                    records = SortHelper.OrderBy(records, sortBy);
                }
                else
                {
                    records = SortHelper.OrderByDescending(records, sortBy);
                }
            }

            if (page.HasValue && limit.HasValue)
            {
                int start = (page.Value - 1) * limit.Value;
                records = records.Skip(start).Take(limit.Value);
            }

            total = records.Count();
            return records.ToList();

        }


        public List<GridAlunos> GetAlunosGrid(int? page, int? limit, string sortBy, string direction, string searchString, int idCidade, out int total)
        {

            EscolaEntities escolaEntities = new EscolaEntities();
            List<Alunos> listAlunos = new List<Alunos>();

            if (idCidade != 0)
            {
                listAlunos = escolaEntities.Alunos.Where(e =>e.CidadeID == idCidade).ToList();
            }
            else
            {
                listAlunos = escolaEntities.Alunos.ToList();
            }

            List<GridAlunos> listGridAlunos = new List<GridAlunos>();


            foreach (var item in listAlunos)
            {
                GridAlunos g = new GridAlunos();
                g.ID = item.AlunoID;
                g.Nome = item.Nome;
                g.CPF = item.CPF;
                g.Sexo = item.Sexo;
                g.TelefoneFixo = item.TelefoneFixo;
                g.DataCadastro = item.DataCadastro.ToString("d");
                g.Cidade = item.Cidades.NomeCidade;
                listGridAlunos.Add(g);
            }

            var records = listGridAlunos.AsQueryable();

            if (!string.IsNullOrWhiteSpace(searchString))
            {
                records = records.Where(p => p.Nome.Contains(searchString) || p.CPF.Contains(searchString));
            }

            if (!string.IsNullOrEmpty(sortBy) && !string.IsNullOrEmpty(direction))
            {
                if (direction.Trim().ToLower() == "asc")
                {
                    records = SortHelper.OrderBy(records, sortBy);
                }
                else
                {
                    records = SortHelper.OrderByDescending(records, sortBy);
                }
            }

            if (page.HasValue && limit.HasValue)
            {
                int start = (page.Value - 1) * limit.Value;
                records = records.Skip(start).Take(limit.Value);
            }

            total = records.Count();
            return records.ToList();

        }


    }
}