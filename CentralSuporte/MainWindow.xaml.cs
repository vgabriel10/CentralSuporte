using CentralSuporte.Entities;
using CentralSuporte.Persistence.Data;
using CentralSuporte.Repository;
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
    public MainWindow(IUsuarioRepository usuarioRepository)
    {
        InitializeComponent();

        //var context = new CentralSuporteDbContext("mongodb://localhost:27017", "CentralSuporte");
        _usuarioRepository = usuarioRepository;
    }

    private async void Button_Click(object sender, RoutedEventArgs e)
    {
        string nome = txtNome.Text;
        var usuario = new Usuario
        {
            Nome = nome
        };
        await _usuarioRepository.AdicionarUsuarioAsync(usuario);
        MessageBox.Show("Cadastrado com sucesso!", "Ok", MessageBoxButton.OK, MessageBoxImage.Warning);

    }
}