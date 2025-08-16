using CentralSuporte.Models.ViewModels;
using System.Windows.Controls;

namespace CentralSuporte.Views
{
    public partial class VisualizarChamados : Page
    {
        public VisualizarChamados()
        {
            InitializeComponent();
            DataContext = new ChamadoViewModel();
        }
    }
}
