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

        public async Task<Chamado> ObterChamadoPorIdAsync(string id)
        {
            return await _chamadoDbContext.Find(Builders<Chamado>.Filter.Eq(c => c.Id, id)).FirstOrDefaultAsync();
        }

        public async Task<List<Chamado>> ObterTodosChamadosAsync()
        {
            return await _chamadoDbContext.Find(Builders<Chamado>.Filter.Empty).ToListAsync();
        }
    }
}
