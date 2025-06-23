using CentralSuporte.Models.ViewModels;

namespace CentralSuporte.Commands.ChamadoCommands
{
    public class AbrirTelaCriarNovoChamadoCommand : BaseCommand
    {
        private readonly ChamadoViewModel _viewModel;
        public AbrirTelaCriarNovoChamadoCommand(ChamadoViewModel viewModel)
        {
            _viewModel = viewModel;
        }
        public override void Execute(object parameter)
        {
            _viewModel.AbrirTelaCriarNovoChamado();
        }
    }
}
