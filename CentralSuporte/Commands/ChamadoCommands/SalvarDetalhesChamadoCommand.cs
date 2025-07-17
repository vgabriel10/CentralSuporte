
using CentralSuporte.ViewModels;

namespace CentralSuporte.Commands.ChamadoCommands
{
    public class SalvarDetalhesChamadoCommand : BaseCommand
    {
        private VisualizarDetalhesChamadoViewModel _viewModel;
        public SalvarDetalhesChamadoCommand(VisualizarDetalhesChamadoViewModel viewModel)
        {
            _viewModel = viewModel;
        }
        public async override void Execute(object parameter)
        {
            await _viewModel.SalvarAlteracoesChamado();
        }
    }
}
