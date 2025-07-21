using CentralSuporte.ViewModels;
using System.Windows;


namespace CentralSuporte.Views
{
    /// <summary>
    /// Lógica interna para Login.xaml
    /// </summary>
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
            DataContext = new UsuarioViewModel();
        }
    }
}
