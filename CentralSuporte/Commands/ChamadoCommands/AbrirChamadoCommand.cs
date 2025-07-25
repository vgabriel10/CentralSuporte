using CentralSuporte.Entities;
using CentralSuporte.Models.ViewModels;
using CentralSuporte.Persistence.Data;
using CentralSuporte.Repository;
using CentralSuporte.Repository.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentralSuporte.Commands.ChamadoCommands
{
    public class AbrirChamadoCommand : BaseCommand
    {
        private readonly ChamadoViewModel _viewModel;
        private readonly IChamadoRepository _chamadoRepository;

        public AbrirChamadoCommand(ChamadoViewModel viewModel)
        {
            _viewModel = viewModel;

            _chamadoRepository = new ChamadoRepository();
        }

        public override bool CanExecute(object parameter)
        {
            return !string.IsNullOrWhiteSpace(_viewModel.Titulo)
                && !string.IsNullOrWhiteSpace(_viewModel.Descricao)
                && !string.IsNullOrWhiteSpace(_viewModel.Cargo);
        }

        public async override void Execute(object parameter)
        {
            await _viewModel.AbrirNovoChamado();
            RaiseCanExecuteChanged();
        }

        
    }
}
