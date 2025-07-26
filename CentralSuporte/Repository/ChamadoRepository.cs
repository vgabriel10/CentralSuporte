using CentralSuporte.Entities;
using CentralSuporte.Persistence.Data;
using CentralSuporte.Repository.Interface;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;

namespace CentralSuporte.Repository
{
    public class ChamadoRepository : IChamadoRepository
    {
        private readonly IMongoCollection<Chamado> _chamadoDbContext;

        private readonly CentralSuporteDbContext? _context;


        public ChamadoRepository()
        {
            _context = App.ServiceProvider.GetRequiredService<CentralSuporteDbContext>();
            _chamadoDbContext = _context.GetCollection<Chamado>("Chamados");
        }

        public async Task AbrirChamadoAsync(Chamado chamado)
        {
            await _chamadoDbContext.InsertOneAsync(chamado);
        }

        public async Task<Chamado> EditarChamado(Chamado chamado)
        {
            if (string.IsNullOrEmpty(chamado.Id))
                throw new ArgumentException("Id do chamado não pode ser nulo ou vazio.");

            var filter = Builders<Chamado>.Filter.Eq(c => c.Id, chamado.Id);

            var resultado = await _chamadoDbContext.ReplaceOneAsync(filter, chamado);

            if (resultado.MatchedCount == 0)
                throw new Exception("Chamado não encontrado para edição.");

            return chamado;
        }

        public async Task<Chamado> ObterChamadoPorIdAsync(string id)
        {
            return await _chamadoDbContext.Find(Builders<Chamado>.Filter.Eq(c => c.Id, id)).FirstOrDefaultAsync();
        }

        public Task<List<Chamado>> ObterChamadosPorUsuarioAsync(string usuarioId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Chamado>> ObterTodosChamadosAsync()
        {
            return await _chamadoDbContext.Find(Builders<Chamado>.Filter.Empty).ToListAsync();
        }
    }
}
