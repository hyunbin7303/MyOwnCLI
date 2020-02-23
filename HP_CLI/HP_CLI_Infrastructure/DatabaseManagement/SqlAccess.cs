using System;
using System.Data;
using System.Data.SqlClient;

/* Use the Appropriate Data-Access Object.
    Always use the DataReader's streaming data access for read-only data retrieval operations.
    Use the DataSet object for data update operations only if you need to perform the updates in disconnected mode.

    Write dedicated update stored procedures.
    Use the DataView Object when you want to work with filtered views
    of a larger DataSet Object.

    The DataView object provides many of the benefits of the DataSet object,
    but without as much overhead.


    Use Stored Procedure, Not Embedded T-SQL
    An accepted T-SQL design appraoch is to compile your data manipulation language
    (DML) statement into stored procedures.

    Stored Procedures execute much faster than T-SQL statements because they are precompiled on the database server
    and are reusable.

 https://www.itprotoday.com/web-application-management/9-data-access-best-practices-tips
 read later.
     */

    // using stored procedures & Functions to query Data.
namespace HP_CLI_Infrastructure
{


    // source from http://csharpdocs.com/generic-data-access-layer-in-c-using-factory-pattern/
    public class SqlAccess : iDBhandler
    {
        private string ConnString { get; set; }

        public SqlAccess(string ConnString) => (this.ConnString) = (ConnString);
        public IDbConnection CreateConnection() => (new SqlConnection(ConnString));
        public void CloseConnection(IDbConnection conn)
        {
            var sqlConn = (SqlConnection) conn;
            sqlConn.Close();
            sqlConn.Dispose();
        }
        public IDbCommand CreateCommand(string cmdText, CommandType cmdType, IDbConnection conn)
        {
            return new SqlCommand
            {
                CommandText = cmdText,
                Connection = (SqlConnection) conn,
                CommandType = cmdType
            };
        }
        public IDataAdapter CreateAdapter(IDbCommand cmd) => (new SqlDataAdapter((SqlCommand)cmd));

        public IDbDataParameter CreateParameter(IDbCommand cmd)
        {
            SqlCommand sqlcmd = (SqlCommand) cmd;
            return sqlcmd.CreateParameter();
        }

        public DataTable executeSelectQuery(string query, SqlParameter[] sqlParameters)
        {
            SqlCommand cmd = new SqlCommand();
            DataTable datatable = new DataTable();
            datatable = null;
            DataSet ds = new DataSet();
            try
            {
                cmd.Connection = new SqlConnection();
                var check = CreateConnection();

                cmd.CommandText = query;

                cmd.Parameters.AddRange(sqlParameters);

                cmd.ExecuteNonQuery();
                
                CloseConnection(check);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw;
            }

            return datatable;
        }
    }
}
