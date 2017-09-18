using System.ComponentModel.DataAnnotations;

namespace SisAlunos.Util
{
    public static class Enumerators
    {

        public enum EnumSexo
        {
            [Display(Name = "Masculino")]
            Masculino = 1,
            [Display(Name = "Feminino")]
            Feminino = 2
        }

        public enum EnumResponsavel
        {
            [Display(Name = "Pai")]
            Pai = 1,
            [Display(Name = "Mãe")]
            Mae = 2,
            [Display(Name = "Outros")]
            Outros = 3
        }

        public enum EtipoMensagem
        {
            Sucesso = 1, Erro = 2
        }

    }
}