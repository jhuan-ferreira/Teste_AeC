using System;

namespace Data.Entity
{
    class Cidade
    {
        public Cidade()
        {
            ClimaCidade = new ClimaCidade();
        }

        public int CidadeId { get; set; }
        public string CidadeNome { get; set; }
        public string Estado { get; set; }
        public DateTime UltimaAtualizacao { get; set; }

        public ClimaCidade ClimaCidade { get; set; }
    }
}
