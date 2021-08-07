using System.Data;
using DirectQueriesStandard;
using doof = MySql.Data.MySqlClient;


namespace UoWRepo.Tools
{
    public class DirectQuery
    {
        public DirectQuery()
        {
        }

        public DataSet QueryToSQL(string connectionString, string strQuery)
        {

            return new RawQueries().QueryToSQL(connectionString, strQuery);
        }


    }
}
