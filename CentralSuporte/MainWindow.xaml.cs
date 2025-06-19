using CentralSuporte.Entities;
using CentralSuporte.Models.ViewModels;
using CentralSuporte.Persistence.Data;
using CentralSuporte.Repository;
using CentralSuporte.Repository.Interface;
using CentralSuporte.Service;
using CentralSuporte.Views;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using NavigationService = CentralSuporte.Service.NavigationService;

namespace CentralSuporte;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    public static INavigationService Navegador;
    public ObservableCollection<ChamadoViewModel> Chamados { get; set; }

    public MainWindow(IUsuarioRepository usuarioRepository)
    {
        InitializeComponent();

        Navegador = new NavigationService(main); // ⬅️ aqui está a mudança
        main.Content = new Login();

    }

    private async void Button_Click(object sender, RoutedEventArgs e)
    {
        

    }

}