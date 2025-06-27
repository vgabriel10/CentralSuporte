

using CentralSuporte.Commands.ChamadoCommands;
using CentralSuporte.Commands.UsuarioCommands;
using CentralSuporte.Entities;
using CentralSuporte.Enums;
using CentralSuporte.Repository;
using CentralSuporte.Repository.Interface;
using CentralSuporte.Views;
using System.ComponentModel;
using System.Windows;

namespace CentralSuporte.ViewModels
{
    public class UsuarioViewModel : BaseViewModel
    {
        public CriarUsuarioCommand CriarUsuarioCommand { get; }
        public FazerLoginCommand FazerLoginCommand { get; }
        public AbrirTelaCriarNovoUsuarioCommand AbrirTelaCriarNovoUsuarioCommand { get; }
        private readonly IUsuarioRepository _usuarioRepository;
        public UsuarioViewModel()
        {
            _usuarioRepository = new UsuarioRepository();
            CriarUsuarioCommand = new CriarUsuarioCommand(this);
            FazerLoginCommand = new FazerLoginCommand(this);
            AbrirTelaCriarNovoUsuarioCommand = new AbrirTelaCriarNovoUsuarioCommand();
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

        public IEnumerable<TipoUsuario> TiposUsuarios
        => Enum.GetValues(typeof(TipoUsuario)).Cast<TipoUsuario>();

        private TipoUsuario _tipoUsuario;
        public TipoUsuario TipoUsuario
        {
            get => _tipoUsuario;
            set
            {
                if (_tipoUsuario != value)
                {
                    _tipoUsuario = value;
                    OnPropertyChanged(nameof(TipoUsuario));
                }
            }
        }

        public async void AdicionarUsuario()
        {
            Usuario usuario = new Usuario
            {
                Nome = this.Nome,
                Senha = this.Senha,
                TipoUsuario = this.TipoUsuario
            };

            await _usuarioRepository.AdicionarUsuarioAsync(usuario);
        }

        public async void FazerLogin()
        {
            var usuario = new Usuario
            {
                Nome = this.Nome,
                Senha = this.Senha
            };

            bool sucesso = await _usuarioRepository.FazerLogin(usuario);

            if (sucesso)
            {
                MainWindow.Navegador.NavegarPara(new VisualizarChamados());
            }
            else
            {
                MessageBox.Show("Usuário ou senha inválidos","Atenção!");
            }
        }

    }
}
