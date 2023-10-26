using Dapper;
using System.Data.SqlClient;
using System.Text;
using Data.Entity;
using System.Configuration;

namespace Data.Busines
{
    class ClimaCidadeBusines
    {
        private string stringConnection = ConfigurationManager.AppSettings["StringConnection"].ToString();

        public async void InsertRequisicao(Cidade cidade)
        {
            using (var db = new SqlConnection(stringConnection))
            {
                await db.OpenAsync();
                await db.ExecuteAsync(GetCommandInseert(cidade));
            }
        }


        private string GetCommandInseert(Cidade cidade)
        {
            var command = new StringBuilder();
            command.Append("INSERT INTO");
            command.Append(" CLIMACIDADE");
            command.Append(" (CIDADENOME, ");
            command.Append(" ESTADO, ");
            command.Append(" ULTIMAATUALIZACAOCIDADE, ");
            command.Append(" ULTIMAATUALIZACAOCLIMA, ");
            command.Append(" CONDICAO, ");
            command.Append(" MIN, ");
            command.Append(" MAX, ");
            command.Append(" INDICEUV, ");
            command.Append(" CONDICAODESCRICAO) ");
            command.Append("VALUES");
            command.Append(" ('" + cidade.CidadeNome + "'");
            command.Append(" ,'" + cidade.Estado + "'");
            command.Append(" ,'" + cidade.UltimaAtualizacao + "'");
            command.Append(" ,'" + cidade.ClimaCidade.UltimaAtualizacao + "'");
            command.Append(" ,'" + cidade.ClimaCidade.Condicao + "'");
            command.Append(" ," + cidade.ClimaCidade.Min);
            command.Append(" ," + cidade.ClimaCidade.Max);
            command.Append(" ," + cidade.ClimaCidade.IndiceUv);
            command.Append(" ,'" + cidade.ClimaCidade.CondicaoDescricao + "')");

            return command.ToString();
        }
    }
}
