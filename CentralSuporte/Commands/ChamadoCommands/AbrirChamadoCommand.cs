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
                && !string.IsNullOrWhiteSpace(_viewModel.Responsavel);
        }

        public override void Execute(object parameter)
        {
            //var novoChamado = new Chamado
            //{
            //    Titulo = _viewModel.Titulo,
            //    Descricao = _viewModel.Descricao,
            //    Cargo = _viewModel.Cargo,
            //    Prioridade = _viewModel.Prioridade,
            //    Status = _viewModel.Status,
            //    Responsavel = _viewModel.Responsavel,
            //    DataAbertura = _viewModel.DataAbertura,
            //    DataFechamento = _viewModel.DataFechamento
            //};

            //_viewModel.Chamados.Add(novoChamado);

            //_chamadoRepository.AbrirChamadoAsync(novoChamado);

            _viewModel.AbrirNovoChamado(_viewModel);

            // Limpa os campos
            //_viewModel.Titulo = string.Empty;
            //_viewModel.Descricao = string.Empty;
            //_viewModel.Cargo = string.Empty;
            //_viewModel.Responsavel = string.Empty;
            //_viewModel.DataFechamento = null;

            RaiseCanExecuteChanged();
        }

        
    }
}
