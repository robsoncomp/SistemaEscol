using System.ComponentModel.DataAnnotations;

namespace SisAlunos.Views.ViewModel
{
    public class CidadeViewModel
    {
        public int CidadeID { get; set; }

        [Required(ErrorMessage = "Campo {0} é obrigatório.")]
        [Display(Name = "Nome da Cidade")]
        public string NomeCidade { get; set; }

        [Required(ErrorMessage = "Campo {0} é obrigatório.")]
        [Display(Name = "Estado (Sigla)")]
        public string Estado { get; set; }

        [Required(ErrorMessage = "Campo {0} é obrigatório.")]
        [Display(Name = "CEP")]
        public string CEP { get; set; }
    }
}