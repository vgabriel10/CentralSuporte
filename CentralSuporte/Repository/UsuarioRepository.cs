using CentralSuporte.Entities;
using CentralSuporte.Persistence.Data;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public async Task<List<Usuario>> ObterTodosAsync()
        {
            return await _usuario.Find(_ => true).ToListAsync();
        }
    }
}
