
using System.Windows.Controls;

namespace CentralSuporte.Service
{
    public interface INavigationService
    {
        void NavegarPara(Page page);
        void Voltar();
        bool PodeVoltar();
    }
}