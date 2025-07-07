


using CentralSuporte.Entities;

namespace CentralSuporte.Repository.Interface
{
    public interface IChamadoRepository
    {
        public Task<List<Chamado>> ObterTodosChamadosAsync();
        public Task AbrirChamadoAsync(Chamado chamado);
        public Task<Chamado> ObterChamadoPorIdAsync(string id);
    }
}
