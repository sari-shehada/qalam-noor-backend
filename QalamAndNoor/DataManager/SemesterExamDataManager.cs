using QalamAndNoor.Models;
using System.Data;
using System.Data.SqlClient;

namespace QalamAndNoor.DataManager
{
    public abstract class SemesterExamDataManager
    {
        #region Mappers
        private static SemesterExam SemesterExamMapper(IDataReader dataReader)
        {
            SemesterExam tempSemesterExam = new SemesterExam()
            {
                ID = Convert.ToInt32(dataReader["ID"].ToString()),
                ExamId = Convert.ToInt32(dataReader["ExamId"].ToString()),
                SemesterYearecordId = Convert.ToInt32(dataReader["SemesterId"].ToString()),
                ObtainedGrade = Convert.ToDouble(dataReader["ObtainedGrade"].ToString()),
                CourseId = Convert.ToInt32(dataReader["CourseId"].ToString()),
            };
            return tempSemesterExam;
        }
        #endregion


        #region PublicMethods
        public static List<SemesterExam> GetSemesterExams()
        {
            //SQL Statement
            string sqlStatement = "SELECT * FROM  [dbo].[SemesterExam]";
            //Preparing SQL Command
            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = sqlStatement,
                CommandType = CommandType.Text,
            };
            //Execute Query
            List<SemesterExam> result = BaseDataManager.GetSPItems<SemesterExam>(sqlCommand, SemesterExamMapper);
            return result;
        }
        public static int InsertSemesterExam(SemesterExam semesterExam)
        {
            if (semesterExam == null) return 0;

            string sqlStatement = "INSERT INTO  [dbo].[SemesterExam] (ExamId,SemesterId,ObtainedGrade,CourseId) " +
                                  "VALUES (@examId,@semesterId,@obtainedGrade,@courseId)";


            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = sqlStatement,
                CommandType = CommandType.Text,
            };
            sqlCommand.Parameters.Add(new SqlParameter("@examId", semesterExam.ExamId));
            sqlCommand.Parameters.Add(new SqlParameter("@semesterId", semesterExam.SemesterYearecordId));
            sqlCommand.Parameters.Add(new SqlParameter("@obtainedGrade", semesterExam.ObtainedGrade));
            sqlCommand.Parameters.Add(new SqlParameter("@courseId", semesterExam.CourseId));

            int result = BaseDataManager.ExecuteNonQuery(sqlCommand);
            if (result == 1)
            {
                List<SemesterExam> semesterExams = GetSemesterExams();
                return semesterExams.Max(x => x.ID);

            }
            return 0;
        }
        public static int UpdateSemesterExam(SemesterExam semesterExam)
        {
            if (semesterExam == null) return 0;

            string sqlStatement = "UPDATE  [dbo].[SemesterExam] SET " +
                                  "ExamId=@examId,SemesterId=@semesterId,ObtainedGrade=@obtainedGrade,CourseId=@courseId " +
                                  "WHERE ID=@id;";

            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = sqlStatement,
                CommandType = CommandType.Text,
            };
            sqlCommand.Parameters.Add(new SqlParameter("@id", semesterExam.ID));
            sqlCommand.Parameters.Add(new SqlParameter("@examId", semesterExam.ExamId));
            sqlCommand.Parameters.Add(new SqlParameter("@semesterId", semesterExam.SemesterYearecordId));
            sqlCommand.Parameters.Add(new SqlParameter("@obtainedGrade", semesterExam.ObtainedGrade));
            sqlCommand.Parameters.Add(new SqlParameter("@courseId", semesterExam.CourseId));

            int result = BaseDataManager.ExecuteNonQuery(sqlCommand);
            return result;
        }
        public static int DeleteSemesterExam(SemesterExam semesterExam)
        {
            if (semesterExam == null) return 0;

            string sqlStatement = "DELETE FROM [dbo].[SemesterExam] WHERE ID=@id;";
            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = sqlStatement,
                CommandType = CommandType.Text,
            };
            sqlCommand.Parameters.Add(new SqlParameter("@id", semesterExam.ID));

            int result = BaseDataManager.ExecuteNonQuery(sqlCommand);
            return result;
        }

        #endregion
    }

}
