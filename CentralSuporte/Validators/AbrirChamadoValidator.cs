using CentralSuporte.Entities;

namespace CentralSuporte.Validators
{
    public class AbrirChamadoValidator
    {
        public List<string> Validar(Chamado chamado)
        {
            var erros = new List<string>();

            if (string.IsNullOrWhiteSpace(chamado.Titulo))
                erros.Add("Título do chamado é obrigatória.");

            if (string.IsNullOrWhiteSpace(chamado.Descricao))
                erros.Add("Descrição do chamado é obrigatória.");

            if(string.IsNullOrWhiteSpace(chamado.Cargo))
                erros.Add("Cargo é obrigatório.");



            return erros;
        }
    }
}
