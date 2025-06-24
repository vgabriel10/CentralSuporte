
using CentralSuporte.Commands.ChamadoCommands;
using CentralSuporte.Entities;
using CentralSuporte.Enums;
using CentralSuporte.Repository;
using CentralSuporte.Repository.Interface;
using CentralSuporte.ViewModels;
using CentralSuporte.Views;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace CentralSuporte.Models.ViewModels
{
    public class ChamadoViewModel : BaseViewModel
    {
        public ObservableCollection<Chamado> Chamados { get; set; }
        public AbrirChamadoCommand AbrirChamadoCommand { get; }
        public AbrirTelaCriarNovoChamadoCommand AbrirTelaCriarNovoChamadoCommand { get; }
        private readonly IChamadoRepository _chamadoRepository;

        public ChamadoViewModel()
        {
            Chamados = new ObservableCollection<Chamado>();
            //Chamados.Add(new Chamado
            //{
            //    Titulo = "Erro ao acessar o sistema",
            //    Descricao = "Usuário relata que não consegue acessar o sistema após a última atualização.",
            //    Cargo = "Analista de Suporte",
            //    Prioridade = Prioridade.Alta, // Supondo que Prioridade é um enum
            //    Status = Status.Aberto,       // Supondo que Status é um enum
            //    Responsavel = "João Silva",
            //    DataAbertura = new DateTime(2025, 5, 23, 10, 30, 0),
            //    DataFechamento = null
            //});
            //Chamados.Add(new Chamado
            //{
            //    Titulo = "Erro ao acessar o sistema",
            //    Descricao = "Usuário relata que não consegue acessar o sistema após a última atualização.",
            //    Cargo = "Analista de Suporte",
            //    Prioridade = Prioridade.Alta, // Supondo que Prioridade é um enum
            //    Status = Status.Aberto,       // Supondo que Status é um enum
            //    Responsavel = "João Silva",
            //    DataAbertura = new DateTime(2025, 5, 23, 10, 30, 0),
            //    DataFechamento = null
            //});
            //Chamados.Add(new Chamado
            //{
            //    Titulo = "Erro ao acessar o sistema",
            //    Descricao = "Usuário relata que não consegue acessar o sistema após a última atualização.",
            //    Cargo = "Analista de Suporte",
            //    Prioridade = Prioridade.Alta, // Supondo que Prioridade é um enum
            //    Status = Status.Aberto,       // Supondo que Status é um enum
            //    Responsavel = "João Silva",
            //    DataAbertura = new DateTime(2025, 5, 23, 10, 30, 0),
            //    DataFechamento = null
            //});

            AbrirChamadoCommand = new AbrirChamadoCommand(this);
            AbrirTelaCriarNovoChamadoCommand = new AbrirTelaCriarNovoChamadoCommand(this);
            _chamadoRepository = new ChamadoRepository();
            CarregarTodosChamados();
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

        private Status _status;
        public Status Status
        {
            get => _status;
            set
            {
                _status = value;
                OnPropertyChanged(nameof(Status));
            }
        }

        private string _responsavel;
        public string Responsavel
        {
            get => _responsavel;
            set
            {
                if (_responsavel != value)
                {
                    _responsavel = value;
                    OnPropertyChanged(nameof(Responsavel));
                    AbrirChamadoCommand.RaiseCanExecuteChanged();
                }
            }
        }

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

        public void AbrirTelaCriarNovoChamado()
        {
            MainWindow.Navegador.NavegarPara(new AbrirChamado());
        }

        private async Task CarregarTodosChamados() 
        {
            var chamados = await _chamadoRepository.ObterTodosChamadosAsync();
            Chamados.Clear();
            chamados.ForEach(c => Chamados.Add(c));
        }

        public void AbrirNovoChamado(ChamadoViewModel chamado)
        {
            var novoChamado = new Chamado
            {
                Titulo = chamado.Titulo,
                Descricao = chamado.Descricao,
                Cargo = chamado.Cargo,
                Prioridade = chamado.Prioridade,
                Status = chamado.Status,
                Responsavel = chamado.Responsavel,
                DataAbertura = chamado.DataAbertura,
                DataFechamento = chamado.DataFechamento
            };

            chamado.Chamados.Add(novoChamado);

            _chamadoRepository.AbrirChamadoAsync(novoChamado);

            // Limpa os campos
            chamado.Titulo = string.Empty;
            chamado .Descricao = string.Empty;
            chamado.Cargo = string.Empty;
            chamado.Responsavel = string.Empty;
            chamado.DataFechamento = null;

            MainWindow.Navegador.NavegarPara(new VisualizarChamados());
        }

    }
}
