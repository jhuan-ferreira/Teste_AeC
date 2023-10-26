using Dapper;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Busines.Busines
{
    class ClimaCidadeBusines
    {
        public static void Main()
        {

        }


        public string InsertRequisicao()
        {
            var query = new StringBuilder();

            query.Append("INSERT INTO");
            query.Append(" CLIMACIDADE");
            query.Append(" (CIDADENOME,");
            query.Append(" ESTADO,");
            query.Append(" ULTIMAATUALIZACAO,");
            query.Append(" ULTIMAATUALIZACAOCLIMA,");
            query.Append(" CONDICAO,");
            query.Append(" MIN,");
            query.Append(" MAX,");
            query.Append(" INDICEUV,");
            query.Append(" CONDICAODESCRICAO) ");

            return "a";

        }

    }
}
