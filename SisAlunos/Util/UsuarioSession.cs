using System;

namespace SisAlunos.Util
{
    [Serializable]
    public class UsuarioSession
    {
        public int UsuarioId { get; set; }

        public string Nome { get; set; }

        public string Email { get; set; }

    }
}