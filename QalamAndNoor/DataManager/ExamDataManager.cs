using QalamAndNoor.Models;
using QalamAndNoor.Shared;
using System.Data;
using System.Data.SqlClient;

namespace QalamAndNoor.DataManager
{
    public abstract class ExamDataManager
    {
        #region Mappers
        private static Exam ExamMapper(IDataReader dataReader)
        {
            Exam tempExam = new Exam()
            {
                ID = Convert.ToInt32(dataReader["ID"].ToString()),
                Type =(ExamTypeEnum)Convert.ToInt32( dataReader["Type"].ToString()),
                Percentage = Convert.ToInt32(dataReader["Percentage"].ToString()),
                ClassId = Convert.ToInt32(dataReader["ClassId"].ToString()),
                Sequence = (int)(dataReader["Sequence"] )
            };
            return tempExam;
        }
        #endregion
        #region PublicMethods
        public static List<Exam> GetExams()
        {
            //SQL Statement
            string sqlStatement = "SELECT * FROM  [dbo].[Exam]";
            //Preparing SQL Command
            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = sqlStatement,
                CommandType = CommandType.Text,
            };
            //Execute Query
            List<Exam> result = BaseDataManager.GetSPItems<Exam>(sqlCommand, ExamMapper);
            return result;
        }
        public static int InsertExam(Exam exam)
        {
            if (exam == null) return 0;

            string sqlStatement = "INSERT INTO  [dbo].[Exam] (Type,Percentage,ClassId,Sequence) " +
                                  "VALUES (@type,@percentage,@classId,@sequence)";


            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = sqlStatement,
                CommandType = CommandType.Text,
            };
            sqlCommand.Parameters.Add(new SqlParameter("@type",(int) exam.Type));
            sqlCommand.Parameters.Add(new SqlParameter("@percentage",exam.Percentage));
            sqlCommand.Parameters.Add(new SqlParameter("@classId",(int) exam.ClassId));
            sqlCommand.Parameters.Add(new SqlParameter("@sequence", (int) exam.Sequence));

            int result = BaseDataManager.ExecuteNonQuery(sqlCommand);
            if (result == 1)
            {
                List<Exam> exams = GetExams();
                return exams.Max(x => x.ID);

            }
            return 0;
        }
        public static int UpdateExam(Exam exam)
        {
            if (exam == null) return 0;

            string sqlStatement = "UPDATE  [dbo].[Exam] SET " +
                                  "Type=@type,Percentage=@percentage,ClassId=@classId,Sequence=@sequence " +
                                  "WHERE ID=@id;";



            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = sqlStatement,
                CommandType = CommandType.Text,
            };
            sqlCommand.Parameters.Add(new SqlParameter("@id", exam.ID));
            sqlCommand.Parameters.Add(new SqlParameter("@type", (int)exam.Type));
            sqlCommand.Parameters.Add(new SqlParameter("@percentage", exam.Percentage));
            sqlCommand.Parameters.Add(new SqlParameter("@classId", (int)exam.ClassId));
            sqlCommand.Parameters.Add(new SqlParameter("@sequence", (int)exam.Sequence));

            int result = BaseDataManager.ExecuteNonQuery(sqlCommand);
            return result;
        }
        public static int DeleteExam(Exam exam)
        {
            if (exam == null) return 0;

            string sqlStatement = "DELETE FROM [dbo].[Exam] WHERE ID=@id;";



            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = sqlStatement,
                CommandType = CommandType.Text,
            };
            sqlCommand.Parameters.Add(new SqlParameter("@id", exam.ID));

            int result = BaseDataManager.ExecuteNonQuery(sqlCommand);
            return result;
        }
        #endregion

    }
}
