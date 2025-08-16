using CentralSuporte.Service;
using CentralSuporte.ViewModels;
using System.Windows;
using NavigationService = CentralSuporte.Service.NavigationService;

namespace CentralSuporte;

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