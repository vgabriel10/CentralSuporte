
using CentralSuporte.Views;

namespace CentralSuporte.Commands.ChamadoCommands
{
    public class VisualizarChamadoCommand : BaseCommand
    {
        public VisualizarChamadoCommand()
        {
            
        }
        public override void Execute(object parameter)
        {
            MainWindow.Navegador.NavegarPara(new CadastrarNovoUsuario());
        }
    }
}
