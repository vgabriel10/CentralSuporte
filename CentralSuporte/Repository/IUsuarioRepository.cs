using CentralSuporte.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralSuporte.Repository
{
    interface IUsuarioRepository
    {
        Task<List<Usuario>> ObterTodosAsync();
        Task AdicionarUsuarioAsync(Usuario usuario);
    }
}
