using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace HP_CLI_Infrastructure
{
    public class MongoAccess : iDBhandler
    {
        // MongoDB for ACID... 
        // What kind of data i should store?

        public IDbConnection CreateConnection()
        {
            throw new NotImplementedException();
        }

        public void CloseConnection(IDbConnection conn)
        {
            throw new NotImplementedException();
        }

        public IDbCommand CreateCommand(string cmdText, CommandType cmdType, IDbConnection conn)
        {
            throw new NotImplementedException();
        }

        public IDataAdapter CreateAdapter(IDbCommand cmd)
        {
            throw new NotImplementedException();
        }

        public IDbDataParameter CreateParameter(IDbCommand cmd)
        {
            throw new NotImplementedException();
        }

        public DataTable executeSelectQuery(string query, SqlParameter[] sqlParameters)
        {
            throw new NotImplementedException();
        }
    }
}
