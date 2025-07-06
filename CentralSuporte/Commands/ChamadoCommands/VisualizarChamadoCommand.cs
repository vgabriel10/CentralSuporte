
using CentralSuporte.Entities;
using CentralSuporte.Models.ViewModels;
using CentralSuporte.ViewModels;
using CentralSuporte.Views;

namespace CentralSuporte.Commands.ChamadoCommands
{
    public class VisualizarChamadoCommand : BaseCommand
    {
        private readonly GerenciarChamadosViewModel _viewModel;
        public VisualizarChamadoCommand(GerenciarChamadosViewModel viewModel)
        {
            _viewModel = viewModel;
        }
        public override void Execute(object parameter)
        {
            if (parameter is Chamado chamadoSelecionado)
            {
                string id = chamadoSelecionado.Id;
                MainWindow.Navegador.NavegarPara(new CadastrarNovoUsuario());
            }
        }
    }
}
