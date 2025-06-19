
using System.Windows.Controls;

namespace CentralSuporte.Service
{
    public class NavigationService : INavigationService
    {
        private readonly Frame _frame;

        public NavigationService(Frame frame)
        {
            _frame = frame;
        }

        public void NavegarPara(Page pagina)
        {
            _frame.Navigate(pagina);
        }
    }
}
