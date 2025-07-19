

using CentralSuporte.Repository.Interface;
using CentralSuporte.Repository;
using CentralSuporte.ViewModels;
using CentralSuporte.Entities;
using System.Runtime.InteropServices.Marshalling;

namespace CentralSuporte.Commands.UsuarioCommands
{
    public class FazerLoginCommand : BaseCommand
    {
        private readonly UsuarioViewModel _viewModel;
        private readonly IUsuarioRepository _UsuarioRepository;

        public FazerLoginCommand(UsuarioViewModel usuarioViewModel)
        {
            _viewModel = usuarioViewModel;
            _UsuarioRepository = new UsuarioRepository();
        }
        public async override void Execute(object parameter)
        {
            _viewModel.FazerLogin();

        }
    }
}
