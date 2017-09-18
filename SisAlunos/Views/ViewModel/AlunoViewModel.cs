using System;
using System.ComponentModel.DataAnnotations;
using SisAlunos.Util;

namespace SisAlunos.Views.ViewModel
{
    public class AlunoViewModel
    {

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

        [Required(ErrorMessage = "Campo {0} é obrigatório.")]
        [Display(Name = "Data de Nascimento")]
        [DataType(DataType.Date)]
        public DateTime DataNascimento { get; set; }

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
        [Display(Name = "Endereço")]
        public string Endereco { get; set; }

        [Required(ErrorMessage = "Campo {0} é obrigatório.")]
        [Display(Name = "Matrícula")]
        public string Matricula { get; set; }

        [Required(ErrorMessage = "Campo {0} é obrigatório.")]
        [Display(Name = "Telefone Fixo")]
        public string TelefoneFixo { get; set; }

        [Required(ErrorMessage = "Campo {0} é obrigatório.")]
        [Display(Name = "Telefone Celular")]
        public string TelefoneCelular { get; set; }

        public string DataCadastro { get; set; }

    }
}













