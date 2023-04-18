using QalamAndNoor.Models;
using System.Data.SqlClient;
using System.Data;

namespace QalamAndNoor.DataManager
{
    public abstract class SchoolYearDataManager
    {
        #region Mappers
        private static SchoolYear SchoolYearMapper(IDataReader dataReader)
        {
            SchoolYear tempSchoolYear = new SchoolYear()
            {
                ID = Convert.ToInt32(dataReader["ID"].ToString()),
                Name = dataReader["Name"].ToString(),
            };
            return tempSchoolYear;
        }
        #endregion
        // #region Public Methods
        #region PublicMethods
        public static List<SchoolYear> GetSchoolYears()
        {
            //SQL Statement
            string sqlStatement = "SELECT * FROM  [dbo].[SchoolYear]";
            //Preparing SQL Command
            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = sqlStatement,
                CommandType = CommandType.Text,
            };
            //Execute Query
            List<SchoolYear> result = BaseDataManager.GetSPItems<SchoolYear>(sqlCommand, SchoolYearMapper);
            return result;
        }
        public static int InsertSchoolYear(SchoolYear schoolYear)
        {
            if (schoolYear == null) return 0;

            string sqlStatement = "INSERT INTO  [dbo].[SchoolYear] (Name) " +
                                  "VALUES (@name)";


            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = sqlStatement,
                CommandType = CommandType.Text,
            };
            sqlCommand.Parameters.Add(new SqlParameter("@name", schoolYear.Name));

            int result = BaseDataManager.ExecuteNonQuery(sqlCommand);
            if (result == 1)
            {
                List<SchoolYear> schoolYears = GetSchoolYears();
                return schoolYears.Max(x => x.ID);

            }
            return 0;
        }
        public static int UpdateSchoolYear(SchoolYear schoolYear)
        {
            if (schoolYear == null) return 0;

            string sqlStatement = "UPDATE  [dbo].[SchoolYear] SET " +
                                  "Name=@name " +
                                  "WHERE ID=@id;";

            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = sqlStatement,
                CommandType = CommandType.Text,
            };
            sqlCommand.Parameters.Add(new SqlParameter("@id", schoolYear.ID));
            sqlCommand.Parameters.Add(new SqlParameter("@name", schoolYear.Name));

            int result = BaseDataManager.ExecuteNonQuery(sqlCommand);
            return result;
        }
        public static int DeleteSchoolYear(SchoolYear schoolYear)
        {
            if (schoolYear == null) return 0;

            string sqlStatement = "DELETE FROM [dbo].[SchoolYear] WHERE ID=@id;";

            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = sqlStatement,
                CommandType = CommandType.Text,
            };
            sqlCommand.Parameters.Add(new SqlParameter("@id", schoolYear.ID));

            int result = BaseDataManager.ExecuteNonQuery(sqlCommand);
            return result;
        }


        #endregion
    }
}
