using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using HP_CLI_Infrastructure;
// All of Business Logic Layer.
// Defines the jobs the software is supposed to do and directs
namespace HP_CLI_Application
{
    public struct Point
    { }


    public class Class1
    {

        //public override bool Equals(object? obj) =>
        //    (obj is Point otherPT) ? this == otherPT : false;

        // Currently just sample name.
        public bool CallStoredProcedure(string dbname, string storedProcedure, Dictionary<string,string> paras)
        {
            SqlAccess sqlAccess = new SqlAccess("database Connection String.");
            var conn = sqlAccess.CreateConnection();
            try
            {
                var sqlCommand = sqlAccess.CreateCommand(storedProcedure, CommandType.StoredProcedure, conn);
                for (int i = 0; i < paras.Count; i++)
                {
                    var sqlparas = (SqlParameter)sqlAccess.CreateParameter(sqlCommand);
                    sqlparas.ParameterName = paras.Keys.ElementAt(i);
                    sqlparas.Value = paras.Values.ElementAt(i);
                    sqlCommand.Parameters.Add(paras);
                }
                sqlCommand.ExecuteReader();
                //specify a value for the command.
                // When the sql Command object executes, the parameter will be replaced with this value.


            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                sqlAccess.CloseConnection(conn);
                return false;
            }

            return true;
        }

    }
}
