

using CentralSuporte.Commands.ChamadoCommands;
using CentralSuporte.Commands.UsuarioCommands;
using CentralSuporte.Entities;
using CentralSuporte.Enums;
using CentralSuporte.Repository;
using CentralSuporte.Repository.Interface;
using CentralSuporte.Service;
using CentralSuporte.Validators;
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
        private CriarUsuarioValidator _criarUsuarioValidator;
        public UsuarioViewModel()
        {
            _usuarioRepository = new UsuarioRepository();
            CriarUsuarioCommand = new CriarUsuarioCommand(this);
            FazerLoginCommand = new FazerLoginCommand(this);
            AbrirTelaCriarNovoUsuarioCommand = new AbrirTelaCriarNovoUsuarioCommand();
            _criarUsuarioValidator = new CriarUsuarioValidator();
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

            var erros = _criarUsuarioValidator.Validar(usuario);
            if(erros.Any())
            {
                MessageBox.Show(string.Join(Environment.NewLine, erros), "Atenção!");
                return;
            }

            await _usuarioRepository.AdicionarUsuarioAsync(usuario);

            MessageBox.Show($"Usuário {usuario.Nome} criado com sucesso", "Sucesso!");

            Application.Current.Windows
                        .OfType<Window>()
                        .FirstOrDefault(w => w is CadastrarNovoUsuario)
                        ?.Close();
        }

        public async void FazerLogin()
        {
            var usuarioLogin = new Usuario
            {
                Nome = this.Nome,
                Senha = this.Senha
            };

            var usuario = await _usuarioRepository.FazerLogin(usuarioLogin);

            if (usuario != null)
            {
                if (MainWindow.Navegador is null)
                {
                    var janelaPrincipal = new MainWindow();
                    janelaPrincipal.Show();

                    // Fecha a janela de login (Login.xaml)
                    Application.Current.Windows
                        .OfType<Window>()
                        .FirstOrDefault(w => w is Login)
                        ?.Close();
                }
               
                switch (usuario.TipoUsuario)
                {
                    case TipoUsuario.Usuario:
                        MainWindow.Navegador.NavegarPara(new VisualizarChamados());
                        SessaoService.TipoUsuarioLogado = TipoUsuario.Usuario;
                        break;
                    case TipoUsuario.Suporte:
                        MainWindow.Navegador.NavegarPara(new GerenciarChamado());
                        SessaoService.TipoUsuarioLogado = TipoUsuario.Suporte;
                        break;
                }                   
            }
            else
            {
                MessageBox.Show("Usuário ou senha inválidos","Atenção!");
            }
        }

    }
}
