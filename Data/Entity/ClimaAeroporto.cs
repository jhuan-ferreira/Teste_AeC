using System;

namespace Data.Entity
{
    class ClimaAeroporto
    {
        public int ClimaAeroportoId { get; set; }
        public string CodigoIcao { get; set; }
        public DateTime UltimaAtualizacao { get; set; }
        public string PressaoAtmosferica { get; set; }
        public string Visibilidade { get; set; }
        public int Vento { get; set; }
        public int DirecaoVento { get; set; }
        public int Umidade { get; set; }
        public string Condicao { get; set; }
        public string CondicaoDescricao { get; set; }
        public int Temp { get; set; }
    }
}
