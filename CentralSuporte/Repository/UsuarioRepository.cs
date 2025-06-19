using CentralSuporte.Entities;
using CentralSuporte.Persistence.Data;
using CentralSuporte.Repository.Interface;
using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;


namespace CentralSuporte.Repository
{
    class UsuarioRepository : IUsuarioRepository
    {
        private readonly CentralSuporteDbContext? _context;
        private readonly IMongoCollection<Usuario> _usuario;

        public UsuarioRepository()
        {
            _context = App.ServiceProvider.GetRequiredService<CentralSuporteDbContext>();
            _usuario = _context.GetCollection<Usuario>("Usuarios");
        }

        public async Task AdicionarUsuarioAsync(Usuario usuario)
        {
            await _usuario.InsertOneAsync(usuario);
        }

        public async Task<bool> FazerLogin(Usuario usuario)
        {
            var filtro = Builders<Usuario>.Filter.Where(u => u.Nome == usuario.Nome && u.Senha == usuario.Senha);
            var existeUsuario = await _usuario.Find(filtro).FirstOrDefaultAsync();
            return existeUsuario != null;
        }

        public async Task<List<Usuario>> ObterTodosAsync()
        {
            return await _usuario.Find(_ => true).ToListAsync();
        }
    }
}
