

using CentralSuporte.Commands.MenuNavegacaoCommands;

namespace CentralSuporte.ViewModels
{
    public class MainWindowViewModel
    {
        public MenuNavegacaoCommand MenuNavegacaoCommand { get;}
        public VoltarPaginaCommand VoltarPaginaCommand { get; }
        public MainWindowViewModel()
        {
            MenuNavegacaoCommand = new MenuNavegacaoCommand();
            VoltarPaginaCommand = new VoltarPaginaCommand();
        }
    }
}
