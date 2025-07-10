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

        public List<string> ListaStatus { get; set; } = Enum.GetNames(typeof(Status)).ToList();


        private async Task BuscarChamado(string idChamado)
        {
            Chamado = await _chamadoRepository.ObterChamadoPorIdAsync(idChamado);
        }
    }
}
