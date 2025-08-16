using CentralSuporte.ViewModels;
using System.Windows;
using Wpf.Ui.Controls;

namespace CentralSuporte.Views
{

    public partial class CadastrarNovoUsuario : Window
    {
        public CadastrarNovoUsuario()
        {
            InitializeComponent();
            DataContext = new UsuarioViewModel();
            //UsuarioViewModel.SnackbarService.SetSnackbarPresenter(SnackbarPresenter);
        }
    }
}
