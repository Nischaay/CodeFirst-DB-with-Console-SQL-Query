using System.Data.SqlClient;

namespace DataContext
{
    public class DatabaseSettings
    {
        private static readonly string connectionString = System.Configuration.ConfigurationManager.ConnectionStrings["connectionString"].ConnectionString.ToString();

        public static SqlConnection GetSqlConnection()
        {
            return new SqlConnection(connectionString);
        }
    }
}
