using CentralSuporte.Persistence.Data;
using CentralSuporte.Repository;
using Microsoft.Extensions.DependencyInjection;
using System.Configuration;
using System.Data;
using System.Windows;

namespace CentralSuporte;

/// <summary>
/// Interaction logic for App.xaml
/// </summary>
public partial class App : Application
{
    public static ServiceProvider ServiceProvider { get; private set; }
    protected override void OnStartup(StartupEventArgs e)
    {
        var serviceCollection = new ServiceCollection();
        ConfigureServices(serviceCollection);

        ServiceProvider = serviceCollection.BuildServiceProvider();

        var mainWindow = ServiceProvider.GetRequiredService<MainWindow>();
        mainWindow.Show();
    }

    private void ConfigureServices(IServiceCollection services)
    {
        services.AddSingleton<CentralSuporteDbContext>(provider =>
        {
            var connectionString = "mongodb://localhost:27018";
            var databaseName = "CentralSuporte";
            return new CentralSuporteDbContext(connectionString, databaseName);
        });


        services.AddSingleton<MainWindow>();
        services.AddScoped<IUsuarioRepository,UsuarioRepository>();
    }
}

