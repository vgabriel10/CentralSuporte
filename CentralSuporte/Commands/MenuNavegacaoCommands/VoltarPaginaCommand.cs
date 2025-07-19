
using System.Windows.Controls;
using System.Windows.Navigation;

namespace CentralSuporte.Commands.MenuNavegacaoCommands
{
    public class VoltarPaginaCommand : BaseCommand
    {
        public override void Execute(object parameter)
        {
            if (MainWindow.Navegador.PodeVoltar())
                MainWindow.Navegador.Voltar();
        }

    }
}
