using CentralSuporte.Persistence.Data;
using CentralSuporte.Repository;
using CentralSuporte.Repository.Interface;
using CentralSuporte.Views;
using Microsoft.Extensions.DependencyInjection;
using System.Windows;

namespace CentralSuporte;

public partial class App : Application
{
    public static ServiceProvider ServiceProvider { get; private set; }
    protected override void OnStartup(StartupEventArgs e)
    {
        var serviceCollection = new ServiceCollection();
        ConfigureServices(serviceCollection);
        ServiceProvider = serviceCollection.BuildServiceProvider();
        var loginWindow = ServiceProvider.GetRequiredService<Login>();
        loginWindow.Show();
    }

    private void ConfigureServices(IServiceCollection services)
    {
        services.AddSingleton<CentralSuporteDbContext>(provider =>
        {
            var connectionString = "mongodb://localhost:27018";
            var databaseName = "CentralSuporte";
            return new CentralSuporteDbContext(connectionString, databaseName);
        });

        services.AddSingleton<Login>();
        services.AddSingleton<MainWindow>();
        services.AddScoped<IUsuarioRepository,UsuarioRepository>();
    }
}

