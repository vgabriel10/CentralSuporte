using CentralSuporte.Entities;
using CentralSuporte.Persistence.Data;
using CentralSuporte.Repository.Interface;
using MongoDB.Driver;


namespace CentralSuporte.Repository
{
    class UsuarioRepository : IUsuarioRepository
    {
        private readonly IMongoCollection<Usuario> _usuario;

        public UsuarioRepository(CentralSuporteDbContext context)
        {
            _usuario = context.GetCollection<Usuario>("Usuarios");
        }

        public async Task AdicionarUsuarioAsync(Usuario usuario)
        {
            await _usuario.InsertOneAsync(usuario);
        }

        public async Task<bool> FazerLogin(Usuario usuario)
        {
            var existeUsuario = await _usuario.FindAsync(u => u.Nome == usuario.Nome && u.Senha == usuario.Senha);
            return existeUsuario != null ? true : false;
        }

        public async Task<List<Usuario>> ObterTodosAsync()
        {
            return await _usuario.Find(_ => true).ToListAsync();
        }
    }
}
