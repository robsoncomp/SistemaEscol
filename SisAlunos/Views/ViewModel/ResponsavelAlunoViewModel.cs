using System.ComponentModel.DataAnnotations;
using SisAlunos.Util;

namespace SisAlunos.Views.ViewModel
{
    public class ResponsavelAlunoViewModel
    {

        public int ResponsavelID { get; set; }

        public int AlunoID { get; set; }

        [Required(ErrorMessage = "Campo {0} é obrigatório.")]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo {0} é obrigatório.")]
        [Display(Name = "RG")]
        public string RG { get; set; }

        [Required(ErrorMessage = "Campo {0} é obrigatório.")]
        [Display(Name = "CPF")]
        [StringLength(11, ErrorMessage = "{0} deve ter 11 caracteres", MinimumLength = 11)]
        public string CPF { get; set; }
 

        [Display(Name = "Parentesco")]
        [Required(ErrorMessage = "Campo {0} é obrigatório.")]
        [Range(1, int.MaxValue, ErrorMessage = "Selecione o {0}")]
        public Enumerators.EnumResponsavel TipoParentesco { get; set; }

        [Required(ErrorMessage = "Campo {0} é obrigatório.")]
        [Display(Name = "Profissão")]
        public string Profissao { get; set; }

        [Required(ErrorMessage = "Campo {0} é obrigatório.")]
        [Display(Name = "Telefone Celular")]
        public string Celular { get; set; }

        public string DataCadastro { get; set; }
    }
}