using CentralSuporte.ViewModels;
using System.Windows.Controls;


namespace CentralSuporte.Views
{
    /// <summary>
    /// Lógica interna para Login.xaml
    /// </summary>
    public partial class Login : Page
    {
        public Login()
        {
            InitializeComponent();
            DataContext = new UsuarioViewModel();
        }
    }
}
