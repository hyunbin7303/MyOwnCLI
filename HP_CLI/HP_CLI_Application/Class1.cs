using System;
using System.Data;
using HP_CLI_Infrastructure;



// How 
namespace HP_CLI_Application
{
    public class Class1
    {

        public bool CallStoredProcedure(string dbname, string [] paras)
        {
            SqlAccess sqlAccess = new SqlAccess("database Connection String.");
            var db = sqlAccess.CreateConnection();
            try
            {
                var sqlCommand = sqlAccess.CreateCommand("", CommandType.StoredProcedure, db);
                var sqlParaeters= sqlAccess.CreateParameter(sqlCommand);



            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                sqlAccess.CloseConnection(db);
                return false;
            }

            return true;
        }

    }
}
