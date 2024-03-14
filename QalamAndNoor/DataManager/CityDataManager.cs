using QalamAndNoor.Models;
using System.Data;
using System.Data.SqlClient;

namespace QalamAndNoor.DataManager
{
    public abstract class CityDataManager
    {
        #region Mappers
        private static City CityMapper(IDataReader dataReader)
        {
            City tempCity = new City()
            {
                ID = Convert.ToInt32(dataReader["ID"].ToString()),
                Name = dataReader["Name"].ToString(),
            };
            return tempCity;
        }
        #endregion
        // #region Public Methods
        #region PublicMethods
        public static List<City> GetCities()
        {
            //SQL Statement
            string sqlStatement = "SELECT * FROM  [dbo].[City]";
            //Preparing SQL Command
            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = sqlStatement,
                CommandType = CommandType.Text,
            };
            //Execute Query
            List<City> result = BaseDataManager.GetSPItems<City>(sqlCommand, CityMapper);
            return result;
        }
        public static int InsertCity(City city)
        {
            if (city == null) return 0;

            string sqlStatement = "INSERT INTO  [dbo].[City] (Name) " +
                                  "VALUES (@name)";


            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = sqlStatement,
                CommandType = CommandType.Text,
            };
            sqlCommand.Parameters.Add(new SqlParameter("@name", city.Name));

            int result = BaseDataManager.ExecuteNonQuery(sqlCommand);
            if (result == 1)
            {
                List<City> cities = GetCities();
                return cities.Max(x => x.ID);

            }
            return 0;
        }
        public static int UpdateCity(City city)
        {
            if (city == null) return 0;

            string sqlStatement = "UPDATE  [dbo].[City] SET " +
                                  "Name=@name " +
                                  "WHERE ID=@id;";

            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = sqlStatement,
                CommandType = CommandType.Text,
            };
            sqlCommand.Parameters.Add(new SqlParameter("@id", city.ID));
            sqlCommand.Parameters.Add(new SqlParameter("@name", city.Name));

            int result = BaseDataManager.ExecuteNonQuery(sqlCommand);
            return result;
        }
        public static int DeleteCity(City city)
        {
            if (city == null) return 0;

            string sqlStatement = "DELETE FROM [dbo].[City] WHERE ID=@id;";

            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = sqlStatement,
                CommandType = CommandType.Text,
            };
            sqlCommand.Parameters.Add(new SqlParameter("@id", city.ID));

            int result = BaseDataManager.ExecuteNonQuery(sqlCommand);
            return result;
        }
     

        #endregion
    }
}
