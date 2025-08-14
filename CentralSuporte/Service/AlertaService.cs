

using CentralSuporte.ViewModels;
using Wpf.Ui.Controls;

namespace CentralSuporte.Service
{
    public static class AlertaService
    {
        public static bool AlertaPendente { get; set; } = false;
        public static string Titulo { get; set; }
        public static string Mensagem { get; set; }
        public static TimeSpan Tempo { get; set; }
        public static ControlAppearance Aparencia { get; set; }
        public static SymbolIcon Icone { get; set; }
        public static void RegistrarAlertaPendente(string titulo, string mensagem, TimeSpan tempo, ControlAppearance aparencia, SymbolIcon icone)
        {
            AlertaPendente = true;
            Titulo = titulo;
            Mensagem = mensagem;
            Tempo = tempo;
            Aparencia = aparencia;
            Icone = icone;

            //MainWindowViewModel.SnackbarService.Show(
            //    titulo,
            //    mensagem,
            //    aparencia,
            //    icone,
            //    tempo
            //);
        }
    }
}
