using CentralSuporte.ViewModels;
using System.Windows;


namespace CentralSuporte.Views
{
    public partial class Login : Window
    {
        public Login()
        {
            InitializeComponent();
            DataContext = new UsuarioViewModel();
            UsuarioViewModel.SnackbarService.SetSnackbarPresenter(SnackbarPresenter);
        }
    }
}
