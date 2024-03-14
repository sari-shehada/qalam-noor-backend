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
                Name = dataReader["Name"].ToString(),
                SchoolYearId = (int)(dataReader["SchoolYearId"]),
                IsDone = Convert.ToBoolean(dataReader["IsDone"].ToString()),
                PreviousSemesterId  = dataReader["PreviousSemesterId"].ToString().Trim() == string.Empty ? null : Convert.ToInt32(dataReader["PreviousSemesterId"].ToString()),
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

            string sqlStatement = "INSERT INTO  [dbo].[Semester] (Name,SchoolYearId,IsDone,PreviousSemesterId) " +
                                  "VALUES (@name,@schoolYearId,@isDone,@previousSemesterId)";


            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = sqlStatement,
                CommandType = CommandType.Text,
            };
            sqlCommand.Parameters.Add(new SqlParameter("@name", semester.Name));
            sqlCommand.Parameters.Add(new SqlParameter("@schoolYearId", semester.SchoolYearId));
            sqlCommand.Parameters.Add(new SqlParameter("@isDone", semester.IsDone ? "1" : "0"));
            sqlCommand.Parameters.Add(new SqlParameter("@previousSemesterId", semester.PreviousSemesterId == null ? DBNull.Value : semester.PreviousSemesterId));
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
                                  "Name=@name,SchoolYearId=@schoolYearId," +
                                  "IsDone=@isDone,PreviousSemesterId=@previousSemesterId " +
                                  "WHERE ID=@id;";

            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = sqlStatement,
                CommandType = CommandType.Text,
            };
            sqlCommand.Parameters.Add(new SqlParameter("@id", semester.ID));
            sqlCommand.Parameters.Add(new SqlParameter("@name", semester.Name));
            sqlCommand.Parameters.Add(new SqlParameter("@schoolYearId", semester.SchoolYearId));
            sqlCommand.Parameters.Add(new SqlParameter("@isDone", semester.IsDone ? "1" : "0"));
            sqlCommand.Parameters.Add(new SqlParameter("@previousSemesterId", semester.PreviousSemesterId == null ? DBNull.Value : semester.PreviousSemesterId));

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

        public static int FinishSemester(Semester semester)
        {
            if (semester == null) return 0;

            string sqlStatement = "UPDATE  [dbo].[Semester] SET " +
                                  "IsDone=1 " +
                                  "WHERE ID=@id;";

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
