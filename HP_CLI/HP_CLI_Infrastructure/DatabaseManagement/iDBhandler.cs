using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace HP_CLI_Infrastructure
{
    public interface iDBhandler
    {
        IDbConnection CreateConnection();
        void CloseConnection(IDbConnection conn);
        IDbCommand CreateCommand(string cmdText, CommandType cmdType, IDbConnection conn);
        IDataAdapter CreateAdapter(IDbCommand cmd);
        IDbDataParameter CreateParameter(IDbCommand cmd);
        DataTable executeSelectQuery(string query, SqlParameter[] sqlParameters);


    }
}
