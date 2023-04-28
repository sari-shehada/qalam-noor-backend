using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace QalamAndNoor.DataManager
{
    public abstract class BaseDataManager
    {
        //private const string connectionString = @"Data Source=DESKTOP-TNMF32K;Integrated Security=True;
        //                                        Initial Catalog=KalamAndNoor;
        //                                        Connect Timeout=30;Encrypt=False;
        //                                        TrustServerCertificate=False;
        //                                        ApplicationIntent=ReadWrite;
        //                                        MultiSubnetFailover=False";
        private const string connectionString = "Data Source=SQL8005.site4now.net;Initial Catalog=db_a982d3_qalamnoor2;User Id=db_a982d3_qalamnoor2_admin;Password=qalam123";

       // private const string connectionString = "Data Source=SQL8005.site4now.net;Initial Catalog=db_a982d3_qalamnoor2;" +
                          //                      "User Id=db_a982d3_qalamnoor1_admin;Password=qalam123";
        public static int ExecuteNonQuery(SqlCommand command)
        {
            try
            {
                int affectedRowsCount = 0;
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    command.Connection = sqlConnection;
                    sqlConnection.Open();
                    affectedRowsCount = command.ExecuteNonQuery();
                    sqlConnection.Close();
                    return affectedRowsCount;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error Occured While Executing {command.CommandText}: {e.Message}");
                return 0;
            }
        }
        public static List<T> GetSPItems<T>(SqlCommand command, Func<IDataReader, T> mapper)
        {
            try
            {
                using (SqlConnection sqlConnection = new SqlConnection(connectionString))
                {
                    command.Connection = sqlConnection;
                    sqlConnection.Open();
                    IDataReader reader = command.ExecuteReader();
                    List<T> items = new List<T>();
                    while (reader.Read())
                    {
                        items.Add(mapper(reader));
                    }
                    reader.Close();
                    sqlConnection.Close();
                    return items;
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine($"Error Occured While Executing {command.CommandText}: {e.Message}");
                return null;
            }

        }
    }
}
