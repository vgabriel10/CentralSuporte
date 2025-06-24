using CentralSuporte.Models.ViewModels;
using System.Windows.Controls;

namespace CentralSuporte.Views
{
    /// <summary>
    /// Interação lógica para AbrirChamado.xam
    /// </summary>
    public partial class AbrirChamado : Page
    {
        public AbrirChamado()
        {
            InitializeComponent();
            DataContext = new ChamadoViewModel();
        }
    }
}
