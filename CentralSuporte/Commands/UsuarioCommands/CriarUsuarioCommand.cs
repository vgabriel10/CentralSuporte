

using CentralSuporte.Entities;
using CentralSuporte.Models.ViewModels;
using CentralSuporte.Repository;
using CentralSuporte.Repository.Interface;
using CentralSuporte.ViewModels;
using System.Windows.Input;

namespace CentralSuporte.Commands.UsuarioCommands
{
    public class CriarUsuarioCommand : BaseCommand
    {
        private readonly UsuarioViewModel _viewModel;

        public CriarUsuarioCommand(UsuarioViewModel usuarioViewModel)
        {
            _viewModel = usuarioViewModel;
        }


        public override void Execute(object parameter)
        {
            _viewModel.AdicionarUsuario();
        }
    }
}
