using System.Configuration;
using System.Data.SqlClient;
using System.Text;
using Dapper;
using Data.Entity;

namespace Data.Busines
{
    class ClimaAeroportoBusines
    {
        private string stringConnection = ConfigurationManager.AppSettings["StringConnection"].ToString();

        public async void InsertRequisicao(ClimaAeroporto climaAeroporto)
        {
            using (var db = new SqlConnection(stringConnection))
            {
                await db.OpenAsync();
                await db.ExecuteAsync(GetCommandInseert(climaAeroporto));
            }
        }


        private string GetCommandInseert(ClimaAeroporto climaAeroporto)
        {
            var command = new StringBuilder();
            command.Append("INSERT INTO");
            command.Append(" CLIMAAEROPORTO");
            command.Append(" (CODIGOICAO, ");
            command.Append(" ULTIMAATUALIZACAO, ");
            command.Append(" PRESSAOATSMOFERICA, ");
            command.Append(" VISIBILIDADE, ");
            command.Append(" VENTO, ");
            command.Append(" DIRECAOVENTO, ");
            command.Append(" UMIDADE, ");
            command.Append(" CONDICAO, ");
            command.Append(" CONDICAODESCRICAO, ");
            command.Append(" TEMP) ");
            command.Append("VALUES");
            command.Append(" ('" + climaAeroporto.CodigoIcao + "'");
            command.Append(" ,'" + climaAeroporto.UltimaAtualizacao + "'");
            command.Append(" ,'" + climaAeroporto.PressaoAtmosferica + "'");
            command.Append(" ,'" + climaAeroporto.Visibilidade + "'");
            command.Append(" ,'" + climaAeroporto.Vento + "'");
            command.Append(" ," + climaAeroporto.DirecaoVento);
            command.Append(" ," + climaAeroporto.Umidade);
            command.Append(" ,'" + climaAeroporto.Condicao + "'");
            command.Append(" ,'" + climaAeroporto.CondicaoDescricao + "'");
            command.Append(" ," + climaAeroporto.Temp + ")");

            return command.ToString();
        }
    }
}
