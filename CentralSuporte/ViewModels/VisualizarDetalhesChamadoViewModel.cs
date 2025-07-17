using CentralSuporte.Commands.ChamadoCommands;
using CentralSuporte.Entities;
using CentralSuporte.Enums;
using CentralSuporte.Repository;
using CentralSuporte.Repository.Interface;

namespace CentralSuporte.ViewModels
{
    public class VisualizarDetalhesChamadoViewModel : BaseViewModel
    {
        public SalvarDetalhesChamadoCommand SalvarDetalhesChamadoCommand { get; }
        private readonly IChamadoRepository _chamadoRepository;
        private readonly IUsuarioRepository _usuarioRepository;
        public Dictionary<string, Status> ListaStatus { get; set; }
        public List<string> UsuariosSuporte { get; set; } = new List<string>();
        public VisualizarDetalhesChamadoViewModel(string idChamado)
        {
            SalvarDetalhesChamadoCommand = new SalvarDetalhesChamadoCommand(this);
            _chamadoRepository = new ChamadoRepository();
            _usuarioRepository = new UsuarioRepository();
            ListaStatus = new Dictionary<string, Status>
            {
                { "Aberto", Status.Aberto },
                { "Em andamento", Status.EmAndamento },
                { "Resolvido", Status.Resolvido },
                { "Cancelado", Status.Cancelado }
            };
            BuscarChamado(idChamado);
            ObterTodosUsuariosSuporte();
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

        private async Task BuscarChamado(string idChamado)
        {
            Chamado = await _chamadoRepository.ObterChamadoPorIdAsync(idChamado);
        }

        private async Task ObterTodosUsuariosSuporte()
        {
            var usuariosSuporte = await _usuarioRepository.ObterTodosUsuariosSuporte();
            if(usuariosSuporte != null)
                usuariosSuporte.ForEach(u => UsuariosSuporte.Add(u.Nome));
        }

        public async Task SalvarAlteracoesChamado()
        {
            if (Chamado != null)
            {
                await _chamadoRepository.EditarChamado(Chamado);
            }
        }

    }
}
