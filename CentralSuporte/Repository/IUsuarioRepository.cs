using CentralSuporte.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralSuporte.Repository
{
    public interface IUsuarioRepository
    {
        public Task<List<Usuario>> ObterTodosAsync();
        public Task AdicionarUsuarioAsync(Usuario usuario);
    }
}
