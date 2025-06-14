

using CentralSuporte.Commands.ChamadoCommands;
using CentralSuporte.Commands.UsuarioCommands;
using System.ComponentModel;

namespace CentralSuporte.ViewModels
{
    public class UsuarioViewModel : BaseViewModel
    {
        public FazerLoginCommand FazerLoginCommand { get; }
        public UsuarioViewModel()
        {
            FazerLoginCommand = new FazerLoginCommand(this);
        }
        private string _nome;
        public string Nome 
        {
            get => _nome;
            set
            {
                if (_nome != value)
                {
                    _nome = value;
                    OnPropertyChanged(nameof(Nome));
                    //FazerLoginCommand.RaiseCanExecuteChanged();
                }
            } 
        }

        private string _senha;
        public string Senha
        {
            get => _senha;
            set
            {
                if (_senha != value)
                {
                    _senha = value;
                    OnPropertyChanged(nameof(Senha));
                    //FazerLoginCommand.RaiseCanExecuteChanged();
                }
            }
        }

    }
}
