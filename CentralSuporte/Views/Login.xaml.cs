using CentralSuporte.Repository;
using CentralSuporte.Repository.Interface;
using CentralSuporte.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

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

        private async void btnEntrar_Click(object sender, RoutedEventArgs e)
        {
            //var usuarios = await _usuarioRepository.ObterTodosAsync();
        }
    }
}
