

using CentralSuporte.Views;

namespace CentralSuporte.Commands.UsuarioCommands
{
    public class AbrirTelaCriarNovoUsuarioCommand : BaseCommand
    {

        public override void Execute(object parameter)
        {
            MainWindow.Navegador.NavegarPara(new CadastrarNovoUsuario());
        }
    }
}
