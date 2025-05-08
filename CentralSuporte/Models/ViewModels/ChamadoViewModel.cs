
using CentralSuporte.Enums;

namespace CentralSuporte.Models.ViewModels
{
    public class ChamadoViewModel
    {
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public string Cargo { get; set; }
        public Prioridade Prioridade { get; set; }
        public Status Status { get; set; }
        public string Responsavel { get; set; }
        public DateTime DataAbertura { get; set; } = DateTime.Now;
        public DateTime? DataFechamento { get; set; }
    }
}
