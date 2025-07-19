using CentralSuporte.Enums;
using CentralSuporte.Service;
using CentralSuporte.Views;

namespace CentralSuporte.Commands.MenuNavegacaoCommands
{
    public class AbrirTelaHomeCommand : BaseCommand
    {
        public override void Execute(object parameter)
        {
            switch (SessaoService.TipoUsuarioLogado)
            {
                case TipoUsuario.Usuario:
                    MainWindow.Navegador.NavegarPara(new VisualizarChamados());
                    MainWindow.Navegador.LimparPilhaNavegacao();
                    break;
                case TipoUsuario.Suporte:
                    MainWindow.Navegador.NavegarPara(new GerenciarChamado());
                    MainWindow.Navegador.LimparPilhaNavegacao();
                    break;
            }
        }
    }
}
