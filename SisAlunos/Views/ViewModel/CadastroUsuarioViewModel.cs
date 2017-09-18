using System.ComponentModel.DataAnnotations;
using SisAlunos.Util;

namespace SisAlunos.Views.ViewModel
{
    public class CadastroUsuarioViewModel
    {

        [Required(ErrorMessage = "Campo {0} é obrigatório.")]
        [Display(Name = "Nome")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Campo CPF é obrigatório.")]
        [Display(Name = "CPF")]
        [StringLength(11, ErrorMessage = "{0} deve ter 11 caracteres", MinimumLength = 11)]
        public string CPF { get; set; }

        [Display(Name = "Sexo")]
        [Required(ErrorMessage = "Campo {0} é obrigatório.")]
        [Range(1, int.MaxValue, ErrorMessage = "Selecione o {0}")]
        public Enumerators.EnumSexo Sexo { get; set; }

        [Required(ErrorMessage = "Campo {0} é obrigatório.")]
        [Display(Name = "Cidade")]
        public int CidadeID { get; set; }

        [Required(ErrorMessage = "Campo {0} é obrigatório.")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Informe email válido.")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Campo {0} é obrigatório.")]
        [StringLength(8, ErrorMessage = "{0} deve ter entre 4 e 8 caracteres", MinimumLength = 4)]
        [DataType(DataType.Password)]
        [Display(Name = "Senha")]
        public string Senha { get; set; }

        [Required(ErrorMessage = "Campo {0} é obrigatório.")]
        [StringLength(8, ErrorMessage = "{0} deve ter entre 4 e 8 caracteres", MinimumLength = 4)]
        [DataType(DataType.Password)]
        [Compare("Senha")]
        [Display(Name = "Confirmar Senha")]
        public string ConfSenha { get; set; }




    }
}