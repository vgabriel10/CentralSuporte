using CentralSuporte.Entities;
using CentralSuporte.Enums;
using CentralSuporte.Repository;
using CentralSuporte.Repository.Interface;

namespace CentralSuporte.ViewModels
{
    public class VisualizarDetalhesChamadoViewModel : BaseViewModel
    {
        private readonly IChamadoRepository _chamadoRepository;
        public VisualizarDetalhesChamadoViewModel(string idChamado)
        {
            _chamadoRepository = new ChamadoRepository();
            BuscarChamado(idChamado);
        }

        private Chamado _chamado;
        public Chamado Chamado
        {
            get => _chamado;
            set
            {
                _chamado = value;
                OnPropertyChanged(nameof(Chamado));
            }
        }

        //private string _titulo;
        //public string Titulo
        //{
        //    get => _titulo;
        //    set
        //    {
        //        if (_titulo != value)
        //        {
        //            _titulo = value;
        //            OnPropertyChanged(nameof(Titulo));
        //        }
        //    }
        //}

        //private string _descricao;
        //public string Descricao
        //{
        //    get => _descricao;
        //    set
        //    {
        //        if (_descricao != value)
        //        {
        //            _descricao = value;
        //            OnPropertyChanged(nameof(Descricao));
        //        }
        //    }
        //}

        //private string _cargo;
        //public string Cargo
        //{
        //    get => _cargo;
        //    set
        //    {
        //        _cargo = value;
        //        OnPropertyChanged(nameof(Cargo));
        //    }
        //}

        //private Prioridade _prioridade;
        //public Prioridade Prioridade
        //{
        //    get => _prioridade;
        //    set
        //    {
        //        _prioridade = value;
        //        OnPropertyChanged(nameof(Prioridade));
        //    }
        //}

        //private Status _status;
        //public Status Status
        //{
        //    get => _status;
        //    set
        //    {
        //        _status = value;
        //        OnPropertyChanged(nameof(Status));
        //    }
        //}

        //private string _responsavel;
        //public string Responsavel
        //{
        //    get => _responsavel;
        //    set
        //    {
        //        if (_responsavel != value)
        //        {
        //            _responsavel = value;
        //            OnPropertyChanged(nameof(Responsavel));
        //        }
        //    }
        //}

        //private DateTime _dataAbertura = DateTime.Now;
        //public DateTime DataAbertura
        //{
        //    get => _dataAbertura;
        //    set
        //    {
        //        _dataAbertura = value;
        //        OnPropertyChanged(nameof(DataAbertura));
        //    }
        //}

        //private DateTime? _dataFechamento;
        //public DateTime? DataFechamento
        //{
        //    get => _dataFechamento;
        //    set
        //    {
        //        _dataFechamento = value;
        //        OnPropertyChanged(nameof(DataFechamento));
        //    }
        //}

        private async Task BuscarChamado(string idChamado)
        {
            Chamado = await _chamadoRepository.ObterChamadoPorIdAsync(idChamado);
        }
    }
}
