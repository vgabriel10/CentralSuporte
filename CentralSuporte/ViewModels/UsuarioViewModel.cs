using CentralSuporte.Commands.MenuNavegacaoCommands;
using CentralSuporte.Commands.UsuarioCommands;
using CentralSuporte.Entities;
using CentralSuporte.Enums;
using CentralSuporte.Repository;
using CentralSuporte.Repository.Interface;
using CentralSuporte.Service;
using CentralSuporte.Validators;
using CentralSuporte.Views;
using System.Windows;
using Wpf.Ui;
using Wpf.Ui.Controls;

namespace CentralSuporte.ViewModels
{
    public class UsuarioViewModel : BaseViewModel
    {
        public CriarUsuarioCommand CriarUsuarioCommand { get; }
        public FazerLoginCommand FazerLoginCommand { get; }
        public AbrirTelaCriarNovoUsuarioCommand AbrirTelaCriarNovoUsuarioCommand { get; }
        public FecharAplicacaoCommand FecharAplicacaoCommand { get; }
        private readonly IUsuarioRepository _usuarioRepository;
        private CriarUsuarioValidator _criarUsuarioValidator;
        public static ISnackbarService SnackbarService { get; set; }

        public UsuarioViewModel()
        {
            _usuarioRepository = new UsuarioRepository();
            CriarUsuarioCommand = new CriarUsuarioCommand(this);
            FazerLoginCommand = new FazerLoginCommand(this);
            AbrirTelaCriarNovoUsuarioCommand = new AbrirTelaCriarNovoUsuarioCommand();
            FecharAplicacaoCommand = new FecharAplicacaoCommand();
            _criarUsuarioValidator = new CriarUsuarioValidator();
            if(SnackbarService?.GetSnackbarPresenter() == null)
                SnackbarService = new SnackbarService();
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
                }
            }
        }

        private string _cargo;
        public string Cargo
        {
            get => _cargo;
            set
            {
                if (_cargo != value)
                {
                    _cargo = value;
                    OnPropertyChanged(nameof(Cargo));
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
                Cargo = this.Cargo,
                TipoUsuario = this.TipoUsuario
            };

            var erros = _criarUsuarioValidator.Validar(usuario);
            if(erros.Any())
            {
                ExibirAlerta("Erro ao criar usuário!",
                    string.Join("\n", erros),
                    TimeSpan.FromSeconds(6),
                    ControlAppearance.Danger,
                    new SymbolIcon(SymbolRegular.ErrorCircle24));
                return;
            }
            await _usuarioRepository.AdicionarUsuarioAsync(usuario);
            Application.Current.Windows
                        .OfType<Window>()
                        .FirstOrDefault(w => w is CadastrarNovoUsuario)
                        ?.Close();

            ExibirAlerta($"Usuário {usuario.Nome} criado com sucesso",
                "Sucesso!",
                TimeSpan.FromSeconds(4),
                ControlAppearance.Success,
                new SymbolIcon(SymbolRegular.Circle12));
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

                SessaoService.IdUsuarioLogado = usuario.Id;
                SessaoService.NomeUsuarioLogado = usuario.Nome;
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
                ExibirAlerta("Erro ao fazer login!",
                    "Usuário ou senha inválidos.",
                    TimeSpan.FromSeconds(6),
                    ControlAppearance.Danger,
                    new SymbolIcon(SymbolRegular.ErrorCircle24));
            }
        }

        public static void ExibirAlerta(string titulo, string mensagem, TimeSpan tempo, ControlAppearance aparencia, SymbolIcon icone)
        {
            SnackbarService.Show(
                    titulo,
                    mensagem,
                    aparencia,
                    icone,
                    tempo
            );
        }
    }
}
