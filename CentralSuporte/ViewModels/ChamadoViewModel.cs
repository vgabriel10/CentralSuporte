
using CentralSuporte.Commands.ChamadoCommands;
using CentralSuporte.Entities;
using CentralSuporte.Enums;
using CentralSuporte.Repository;
using CentralSuporte.Repository.Interface;
using CentralSuporte.Validators;
using CentralSuporte.ViewModels;
using CentralSuporte.Views;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace CentralSuporte.Models.ViewModels
{
    public class ChamadoViewModel : BaseViewModel
    {
        public ObservableCollection<Chamado> Chamados { get; set; }
        public AbrirChamadoCommand AbrirChamadoCommand { get; }
        public AbrirTelaCriarNovoChamadoCommand AbrirTelaCriarNovoChamadoCommand { get; }
        private readonly IChamadoRepository _chamadoRepository;
        private readonly AbrirChamadoValidator _abrirChamadoValidator = new AbrirChamadoValidator();

        public ChamadoViewModel()
        {
            Chamados = new ObservableCollection<Chamado>();
            AbrirChamadoCommand = new AbrirChamadoCommand(this);
            AbrirTelaCriarNovoChamadoCommand = new AbrirTelaCriarNovoChamadoCommand(this);
            _chamadoRepository = new ChamadoRepository();
            _abrirChamadoValidator = new AbrirChamadoValidator();
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
                AbrirChamadoCommand.RaiseCanExecuteChanged();
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
                    //AbrirChamadoCommand.RaiseCanExecuteChanged();
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

        public async Task AbrirNovoChamado()
        {            
            var novoChamado = new Chamado
            {
                Titulo = this.Titulo,
                Descricao = this.Descricao,
                Cargo = this.Cargo,
                Prioridade = this.Prioridade,
                Status = this.Status,
                Responsavel = null,
                DataAbertura = this.DataAbertura,
                DataFechamento = this.DataFechamento
            };
            _abrirChamadoValidator.Validar(novoChamado);
            var erros = _abrirChamadoValidator.Validar(novoChamado);
            if (erros.Any())
            {
                MessageBox.Show(string.Join(Environment.NewLine, erros), "Atenção!");
                return;
            }

            Chamados.Add(novoChamado);

            await _chamadoRepository.AbrirChamadoAsync(novoChamado);

            // Limpa os campos
            Titulo = string.Empty;
            Descricao = string.Empty;
            Cargo = string.Empty;
            Responsavel = string.Empty;
            DataFechamento = null;

            MainWindow.Navegador.NavegarPara(new VisualizarChamados());
        }

    }
}
