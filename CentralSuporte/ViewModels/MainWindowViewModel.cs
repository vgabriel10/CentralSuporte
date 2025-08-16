using CentralSuporte.Commands.MenuNavegacaoCommands;
using CentralSuporte.Service;
using Wpf.Ui;
using Wpf.Ui.Controls;

namespace CentralSuporte.ViewModels
{
    public class MainWindowViewModel
    {
        public MenuNavegacaoCommand MenuNavegacaoCommand { get;}
        public VoltarPaginaCommand VoltarPaginaCommand { get; }
        public AbrirTelaHomeCommand AbrirTelaHomeCommand { get; }
        public static ISnackbarService SnackbarService { get; set; }

        public MainWindowViewModel()
        {
            MenuNavegacaoCommand = new MenuNavegacaoCommand();
            VoltarPaginaCommand = new VoltarPaginaCommand();
            AbrirTelaHomeCommand = new AbrirTelaHomeCommand();
            SnackbarService = new SnackbarService();
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

        public static void ExibirAlertaPendente()
        {
            SnackbarService.Show(
                AlertaService.Titulo,
                AlertaService.Mensagem,
                AlertaService.Aparencia,
                AlertaService.Icone,
                AlertaService.Tempo
            );
            AlertaService.LimparAlertaPendente();
        }
    }
}
