using CentralSuporte.Entities;
using CentralSuporte.Models.ViewModels;
using CentralSuporte.Persistence.Data;
using CentralSuporte.Repository;
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

        // Preenche com alguns dados de exemplo
        Chamados = new ObservableCollection<ChamadoViewModel>
            {
                new ChamadoViewModel {Titulo = "Erro ao abrir aplicativo" },
                new ChamadoViewModel { Titulo = "Sistema lento"},
                new ChamadoViewModel { Titulo = "Falha na exportação" }
            };

        // Vincula ao DataGrid
        dataGridChamados.ItemsSource = Chamados;

    }

    private async void Button_Click(object sender, RoutedEventArgs e)
    {
        //string nome = txtNome.Text;
        //var usuario = new Usuario
        //{
        //    Nome = nome
        //};
        //await _usuarioRepository.AdicionarUsuarioAsync(usuario);
        MessageBox.Show("Cadastrado com sucesso!", "Ok", MessageBoxButton.OK, MessageBoxImage.Warning);

    }

}