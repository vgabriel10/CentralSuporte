using CentralSuporte.Entities;
using CentralSuporte.Enums;
using CentralSuporte.Models.ViewModels;
using CentralSuporte.Persistence.Data;
using CentralSuporte.Repository;
using CentralSuporte.Repository.Interface;
using CentralSuporte.Service;
using CentralSuporte.ViewModels;
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
    private readonly MainWindowViewModel _viewModel;
    public MainWindow()
    {
        InitializeComponent();
        _viewModel = new MainWindowViewModel();
        DataContext = _viewModel;
        Navegador = new NavigationService(main);
        MainWindowViewModel.SnackbarService.SetSnackbarPresenter(SnackbarPresenter);
    }
}