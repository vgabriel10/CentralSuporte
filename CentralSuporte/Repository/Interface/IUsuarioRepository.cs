using CentralSuporte.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralSuporte.Repository.Interface
{
    public interface IUsuarioRepository
    {
        public Task<List<Usuario>> ObterTodosAsync();
        public Task AdicionarUsuarioAsync(Usuario usuario);
        public Task<Usuario> FazerLogin(Usuario usuario);
    }
}
