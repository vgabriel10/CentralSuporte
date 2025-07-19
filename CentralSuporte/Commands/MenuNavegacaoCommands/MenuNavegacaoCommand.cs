
using CentralSuporte.Views;
using System.Windows.Controls;

namespace CentralSuporte.Commands.MenuNavegacaoCommands
{
    public class MenuNavegacaoCommand : BaseCommand
    {
        /// <summary>
        /// Command para navegar entre páginas de forma genérica
        /// </summary>
        /// <param name="parameter"></param>
        public override void Execute(object parameter)
        {
            if (parameter is Type tipoPagina && typeof(Page).IsAssignableFrom(tipoPagina))
            {
                Page pagina = (Page)Activator.CreateInstance(tipoPagina);
                MainWindow.Navegador.NavegarPara(pagina);
            }
        }
    }
}
