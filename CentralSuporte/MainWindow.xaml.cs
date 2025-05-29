using CentralSuporte.Entities;
using CentralSuporte.Models.ViewModels;
using CentralSuporte.Persistence.Data;
using CentralSuporte.Repository;
using CentralSuporte.Repository.Interface;
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

namespace CentralSuporte;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private readonly IUsuarioRepository _usuarioRepository;
    public ObservableCollection<ChamadoViewModel> Chamados { get; set; }

    public MainWindow(IUsuarioRepository usuarioRepository)
    {
        InitializeComponent();

        //var context = new CentralSuporteDbContext("mongodb://localhost:27017", "CentralSuporte");
        _usuarioRepository = usuarioRepository;

        //main.Content = new Login(_usuarioRepository);
        //main.Content = new CadastrarNovoUsuario();
        main.Content = new VisualizarChamados();

        // Preenche com alguns dados de exemplo
        //Chamados = new ObservableCollection<ChamadoViewModel>
        //    {
        //        new ChamadoViewModel {Titulo = "Erro ao abrir aplicativo" },
        //        new ChamadoViewModel { Titulo = "Sistema lento"},
        //        new ChamadoViewModel { Titulo = "Falha na exportação" }
        //    };
    }

    private async void Button_Click(object sender, RoutedEventArgs e)
    {
        

    }

}