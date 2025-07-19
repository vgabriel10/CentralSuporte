
using System.Windows.Controls;

namespace CentralSuporte.Service
{
    public class NavigationService : INavigationService
    {
        private readonly Frame _frame;
        private readonly Stack<Page> _historico = new Stack<Page>();

        public NavigationService(Frame frame)
        {
            _frame = frame;
        }

        public void NavegarPara(Page novaPagina)
        {
            if (_frame.Content is Page paginaAtual)
                _historico.Push(paginaAtual);

            _frame.Navigate(novaPagina);
        }

        public void Voltar()
        {
            if (_historico.Count > 0)
            {
                var paginaAnterior = _historico.Pop();
                _frame.Navigate(paginaAnterior);
            }
        }

        public bool PodeVoltar()
        {
            return _historico.Count > 0;
        }

        public void LimparPilhaNavegacao()
        {
            _historico.Clear();
        }
    }
}
