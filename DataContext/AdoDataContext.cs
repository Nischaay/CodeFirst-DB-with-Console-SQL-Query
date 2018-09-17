using System;
using System.Data;
using System.Data.SqlClient;

namespace DataContext
{
   public class AdoDataContext
    {
        public DataBaseModel ExecuteCommand(string query)
        {
            var dbModel = new DataBaseModel();
            try
            {
                using (var conn = DatabaseSettings.GetSqlConnection())
                {
                    conn.Open();
                    var command = new SqlCommand(query, conn);
                    dbModel.DataTable.Load(command.ExecuteReader());
                }
            }
            catch (Exception e)
            {
                dbModel.Exceptions.Add(e);
            }
            return dbModel;
        }
    }
}
