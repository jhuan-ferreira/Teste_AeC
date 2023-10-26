using System.Configuration;
using System.Data.SqlClient;
using System.Text;
using Dapper;
using Data.Entity;

namespace Data.Busines
{
    class LogErroBusines
    {
        private string stringConnection = ConfigurationManager.AppSettings["StringConnection"].ToString();

        public async void InsertRequisicao(LogErro logErro)
        {
            using (var db = new SqlConnection(stringConnection))
            {
                await db.OpenAsync();
                await db.ExecuteAsync(GetCommandInseert(logErro));
            }
        }


        private string GetCommandInseert(LogErro logErro)
        {
            var command = new StringBuilder();
            command.Append("INSERT INTO");
            command.Append(" LOGERRO");
            command.Append(" (DATA, ");
            command.Append(" ERRO) ");
            command.Append("VALUES");
            command.Append(" ('" + logErro.Data + "'");
            command.Append(" ,'" + logErro.Erro + "')");

            return command.ToString();
        }
    }
}
