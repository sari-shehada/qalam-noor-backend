using QalamAndNoor.Models;
using System.Data.SqlClient;
using System.Data;
using QalamAndNoor.Shared;

namespace QalamAndNoor.DataManager
{
    public abstract class SemesterDataManager
    {
        #region Mappers
        private static Semester SemesterMapper(IDataReader dataReader)
        {
            Semester tempSemester = new Semester()
            {
                ID = Convert.ToInt32(dataReader["ID"].ToString()),
                Type = (SemesterTypeEnum)Convert.ToInt32( dataReader["Type"].ToString()),
                YearRecordId = Convert.ToInt32(dataReader["YearRecordId"].ToString()),
            };
            return tempSemester;
        }
        #endregion
        // #region Public Methods
        #region PublicMethods
        public static List<Semester> GetSemesters()
        {
            //SQL Statement
            string sqlStatement = "SELECT * FROM  [dbo].[Semester]";
            //Preparing SQL Command
            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = sqlStatement,
                CommandType = CommandType.Text,
            };
            //Execute Query
            List<Semester> result = BaseDataManager.GetSPItems<Semester>(sqlCommand, SemesterMapper);
            return result;
        }
        public static int InsertSemester(Semester semester)
        {
            if (semester == null) return 0;

            string sqlStatement = "INSERT INTO  [dbo].[Semester] (Type,YearRecordId) " +
                                  "VALUES (@type,@yearRecordId)";


            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = sqlStatement,
                CommandType = CommandType.Text,
            };
            sqlCommand.Parameters.Add(new SqlParameter("@type", (int)semester.Type));
            sqlCommand.Parameters.Add(new SqlParameter("@yearRecordId", semester.YearRecordId));

            int result = BaseDataManager.ExecuteNonQuery(sqlCommand);
            if (result == 1)
            {
                List<Semester> semesters = GetSemesters();
                return semesters.Max(x => x.ID);

            }
            return 0;
        }
        public static int UpdateSemester(Semester semester)
        {
            if (semester == null) return 0;

            string sqlStatement = "UPDATE  [dbo].[Semester] SET " +
                                  "Type=@type,YearRecordId=@yearRecordId " +
                                  "WHERE ID=@id;";

            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = sqlStatement,
                CommandType = CommandType.Text,
            };
            sqlCommand.Parameters.Add(new SqlParameter("@id", semester.ID));
            sqlCommand.Parameters.Add(new SqlParameter("@type", (int)semester.Type));
            sqlCommand.Parameters.Add(new SqlParameter("@yearRecordId", semester.YearRecordId));

            int result = BaseDataManager.ExecuteNonQuery(sqlCommand);
            return result;
        }
        public static int DeleteSemester(Semester semester)
        {
            if (semester == null) return 0;

            string sqlStatement = "DELETE FROM [dbo].[Semester] WHERE ID=@id;";

            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = sqlStatement,
                CommandType = CommandType.Text,
            };
            sqlCommand.Parameters.Add(new SqlParameter("@id", semester.ID));

            int result = BaseDataManager.ExecuteNonQuery(sqlCommand);
            return result;
        }


        #endregion
    }
}
