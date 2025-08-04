
using System.Windows;

namespace CentralSuporte.Commands.MenuNavegacaoCommands
{
    public class FecharAplicacaoCommand : BaseCommand
    {
        public override void Execute(object parameter)
        {
            Application.Current.Shutdown();
        }
    }
}
