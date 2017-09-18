using System.ComponentModel.DataAnnotations;

namespace SisAlunos.Views.ViewModel
{
    public class LoginViewModel
    {

     
        [Required(ErrorMessage = "Campo {0} é obrigatório.")]
        [DataType(DataType.EmailAddress, ErrorMessage = "Informe Email válido.")]
        [Display(Name = "Email")]
        public string Email { get; set; }

        
        [Required(ErrorMessage = "Campo {0} é obrigatória")]
        [Display(Name = "Senha")]
        [StringLength(8, ErrorMessage = "Sua senha deve conter entre 4 à 8 caracteres", MinimumLength = 4)]
        public string Senha { get; set; }

        
    }
}