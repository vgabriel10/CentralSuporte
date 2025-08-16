using CentralSuporte.ViewModels;
using System.Windows.Controls;

namespace CentralSuporte.Views
{
    public partial class VisualizarDetalhesChamado : Page
    {
        public VisualizarDetalhesChamado(string idChamado)
        {
            InitializeComponent();
            DataContext = new VisualizarDetalhesChamadoViewModel(idChamado);
        }
    }
}
