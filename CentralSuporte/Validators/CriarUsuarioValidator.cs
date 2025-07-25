
using CentralSuporte.Entities;

namespace CentralSuporte.Validators
{
    public class CriarUsuarioValidator
    {
        public List<string> Validar(Usuario usuario)
        {
            var erros = new List<string>();

            if (string.IsNullOrWhiteSpace(usuario.Nome))
                erros.Add("Usuário é obrigatório.");

            if (string.IsNullOrWhiteSpace(usuario.Senha))
                erros.Add("Senha é obrigatória.");

                return erros;
        }
    }
}
