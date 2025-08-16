using CentralSuporte.Models.ViewModels;
using System.Windows.Controls;

namespace CentralSuporte.Views
{
    
    public partial class AbrirChamado : Page
    {
        private readonly ChamadoViewModel _viewModel;
        public AbrirChamado()
        {
            InitializeComponent();
            _viewModel = new ChamadoViewModel();
            DataContext = _viewModel;
        }
    }
}
