using System;

namespace Data.Entity
{
    class ClimaCidade
    {
        public int ClimaCidadeId { get; set; }
        public DateTime UltimaAtualizacao { get; set; }
        public string Condicao { get; set; }
        public int Min { get; set; }
        public int Max { get; set; }
        public int IndiceUv { get; set; }
        public string CondicaoDescricao { get; set; }
        public int CidadeId { get; set; }
    }
}
