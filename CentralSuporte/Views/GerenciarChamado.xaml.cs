using CentralSuporte.ViewModels;
using System.Windows.Controls;


namespace CentralSuporte.Views
{
    public partial class GerenciarChamado : Page
    {
        public GerenciarChamado()
        {
            InitializeComponent();
            DataContext = new GerenciarChamadosViewModel();
        }
    }
}
