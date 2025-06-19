

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
        private readonly IUsuarioRepository _UsuarioRepository;

        public CriarUsuarioCommand(UsuarioViewModel usuarioViewModel)
        {
            _viewModel = usuarioViewModel;
            _UsuarioRepository = new UsuarioRepository();
        }

        //public override bool CanExecute(object? parameter)
        //{
        //    return !string.IsNullOrEmpty(_viewModel.Nome) && !string.IsNullOrEmpty(_viewModel.Senha);

        //}

        public override void Execute(object parameter)
        {
            Usuario usuario = new Usuario
            {
                Nome = _viewModel.Nome,
                Senha = _viewModel.Senha
            };

            _UsuarioRepository.AdicionarUsuarioAsync(usuario);
        }
    }
}
