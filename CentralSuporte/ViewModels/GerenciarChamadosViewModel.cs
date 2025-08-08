

using CentralSuporte.Commands.ChamadoCommands;
using CentralSuporte.Entities;
using CentralSuporte.Enums;
using CentralSuporte.Repository.Interface;
using CentralSuporte.Repository;
using System.Collections.ObjectModel;

namespace CentralSuporte.ViewModels
{
    public class GerenciarChamadosViewModel : BaseViewModel
    {

        private ObservableCollection<Chamado> _chamados;
        public ObservableCollection<Chamado> Chamados
        {
            get => _chamados;
            set
            {
                _chamados = value;
                OnPropertyChanged(nameof(Chamados));
            }
        }
        public AbrirChamadoCommand AbrirChamadoCommand { get; }
        public AbrirTelaCriarNovoChamadoCommand AbrirTelaCriarNovoChamadoCommand { get; }
        public VisualizarChamadoCommand VisualizarChamadoCommand { get; }
        private readonly IChamadoRepository _chamadoRepository;
        private readonly IUsuarioRepository _usuarioRepository;

        public GerenciarChamadosViewModel()
        {
            Chamados = new ObservableCollection<Chamado>();
            VisualizarChamadoCommand = new VisualizarChamadoCommand(this);
            _chamadoRepository = new ChamadoRepository();
            _usuarioRepository = new UsuarioRepository();
            CarregarTodosChamados();
            CarregarCbStatus();
            CarregarCbResponsavel();
        }

        private string _titulo;
        public string Titulo
        {
            get => _titulo;
            set
            {
                if (_titulo != value)
                {
                    _titulo = value;
                    OnPropertyChanged(nameof(Titulo));
                    AbrirChamadoCommand.RaiseCanExecuteChanged();
                }
            }
        }

        private string _descricao;
        public string Descricao
        {
            get => _descricao;
            set
            {
                if (_descricao != value)
                {
                    _descricao = value;
                    OnPropertyChanged(nameof(Descricao));
                    AbrirChamadoCommand.RaiseCanExecuteChanged();
                }
            }
        }

        private string _cargo;
        public string Cargo
        {
            get => _cargo;
            set
            {
                _cargo = value;
                OnPropertyChanged(nameof(Cargo));
            }
        }

        private Prioridade _prioridade;
        public Prioridade Prioridade
        {
            get => _prioridade;
            set
            {
                _prioridade = value;
                OnPropertyChanged(nameof(Prioridade));
            }
        }

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
        //            AbrirChamadoCommand.RaiseCanExecuteChanged();
        //        }
        //    }
        //}

        private DateTime _dataAbertura = DateTime.Now;
        public DateTime DataAbertura
        {
            get => _dataAbertura;
            set
            {
                _dataAbertura = value;
                OnPropertyChanged(nameof(DataAbertura));
            }
        }

        private DateTime? _dataFechamento;
        public DateTime? DataFechamento
        {
            get => _dataFechamento;
            set
            {
                _dataFechamento = value;
                OnPropertyChanged(nameof(DataFechamento));
            }
        }


        private Status _status;
        public Status Status
        {
            get => _status;
            set
            {
                if (_status != value)
                {
                    _status = value;
                    OnPropertyChanged(nameof(Status));
                }
            }
        }

        public List<StatusComboItem> CbStatus { get; set; }

        private Status? _statusSelecionado;
        public Status? StatusSelecionado
        {
            get => _statusSelecionado;
            set
            {
                if (_statusSelecionado != value)
                {
                    _statusSelecionado = value;
                    OnPropertyChanged(nameof(StatusSelecionado));
                    FiltrarChamados();
                }
            }
        }

        private List<Usuario> _responsaveis;
        public List<Usuario> Responsaveis
        {
            get => _responsaveis;
            set
            {
                if (_responsaveis != value)
                {
                    _responsaveis = value;
                    OnPropertyChanged(nameof(Responsaveis));
                }
            }
        }

        private Usuario _responsavelSelecionado;
        public Usuario ResponsavelSelecionado
        {
            get => _responsavelSelecionado;
            set
            {
                if (_responsavelSelecionado != value)
                {
                    _responsavelSelecionado = value;
                    OnPropertyChanged(nameof(ResponsavelSelecionado));
                    FiltrarChamados();
                }
            }
        }

        private async Task CarregarTodosChamados()
        {
            var chamados = await _chamadoRepository.ObterTodosChamadosAsync();
            Chamados.Clear();
            chamados.ForEach(c => Chamados.Add(c));
        }

        private async Task CarregarCbStatus()
        {
            CbStatus = new List<StatusComboItem>
            {
                new StatusComboItem { Nome = "Todos", Valor = null },
                new StatusComboItem { Nome = "Aberto", Valor = Status.Aberto },
                new StatusComboItem { Nome = "Em Andamento", Valor = Status.EmAndamento },
                new StatusComboItem { Nome = "Resolvido", Valor = Status.Resolvido },
                new StatusComboItem { Nome = "Cancelado", Valor = Status.Cancelado }
            };
        }

        private async Task CarregarCbResponsavel()
        {
            Responsaveis = await _usuarioRepository.ObterTodosUsuariosSuporte();
            Responsaveis.Insert(0, new Usuario { Id = string.Empty });
        }

        private async Task FiltrarChamados()
        {
            await CarregarTodosChamados();
            var chamadosFiltrados = Chamados.AsEnumerable();

            if (ResponsavelSelecionado != null && !string.IsNullOrWhiteSpace(ResponsavelSelecionado.Id))
                chamadosFiltrados = chamadosFiltrados.Where(c => c.ResponsavelId == ResponsavelSelecionado.Id);
            if(StatusSelecionado.HasValue)
                chamadosFiltrados = chamadosFiltrados.Where(c => c.Status == StatusSelecionado);

            Chamados = new ObservableCollection<Chamado>(chamadosFiltrados);
        }
    }
}
