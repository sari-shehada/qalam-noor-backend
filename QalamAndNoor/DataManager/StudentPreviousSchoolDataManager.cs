
using QalamAndNoor.Models;
using System.Data;
using System.Data.SqlClient;

namespace QalamAndNoor.DataManager
{
    public abstract class StudentPreviousSchoolDataManager
    {
        #region Mappers
        private static StudentPreviousSchool StudentPreviousSchoolMapper(IDataReader dataReader)
        {
            StudentPreviousSchool tempStudentPreviousSchool = new StudentPreviousSchool()
            {
                ID = Convert.ToInt32(dataReader["ID"].ToString()),
                StudentId = Convert.ToInt32(dataReader["StudentId"].ToString()),
                PreviousSchoolId = Convert.ToInt32(dataReader["PreviousSchoolId"].ToString()),
                Note = dataReader["Note"].ToString().Trim() == string.Empty ? null : dataReader["Note"].ToString(),
            };
            return tempStudentPreviousSchool;
        }
        #endregion

        #region PublicMethods
        public static List<StudentPreviousSchool> GetStudentPreviousSchools()
        {
            //SQL Statement
            string sqlStatement = "SELECT * FROM  [dbo].[StudentPreviousSchool]";
            //Preparing SQL Command
            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = sqlStatement,
                CommandType = CommandType.Text,
            };
            //Execute Query
            List<StudentPreviousSchool> result = BaseDataManager.GetSPItems<StudentPreviousSchool>(sqlCommand, StudentPreviousSchoolMapper);
            return result;
        }
        public static int InsertStudentPreviousSchool(StudentPreviousSchool studentPreviousSchool)
        {
            if (studentPreviousSchool == null) return 0;

            string sqlStatement = "INSERT INTO  [dbo].[StudentPreviousSchool] (StudentId,PreviousSchoolId,Note) " +
                                  "VALUES (@studentId,@previousSchoolId,@note)";


            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = sqlStatement,
                CommandType = CommandType.Text,
            };
            sqlCommand.Parameters.Add(new SqlParameter("@studentId", studentPreviousSchool.StudentId));
            sqlCommand.Parameters.Add(new SqlParameter("@previousSchoolId", studentPreviousSchool.PreviousSchoolId));
            sqlCommand.Parameters.Add(new SqlParameter("@note", studentPreviousSchool.Note == null ? DBNull.Value :studentPreviousSchool.Note));

            int result = BaseDataManager.ExecuteNonQuery(sqlCommand);
            if (result == 1)
            {
                List<StudentPreviousSchool> studentPreviousSchools = GetStudentPreviousSchools();
                return studentPreviousSchools.Max(x => x.ID);

            }
            return 0;
        }
        public static int UpdateStudentPreviousSchool(StudentPreviousSchool studentPreviousSchool)
        {
            if (studentPreviousSchool == null) return 0;

            string sqlStatement = "UPDATE  [dbo].[StudentPreviousSchool] SET " +
                                  "StudentId=@studentId,PreviousSchoolId=@previousSchoolId,Note=@note " +
                                  "WHERE ID=@id;";


            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = sqlStatement,
                CommandType = CommandType.Text,
            };
            sqlCommand.Parameters.Add(new SqlParameter("@id", studentPreviousSchool.ID));
            sqlCommand.Parameters.Add(new SqlParameter("@studentId", studentPreviousSchool.StudentId));
            sqlCommand.Parameters.Add(new SqlParameter("@previousSchoolId", studentPreviousSchool.PreviousSchoolId));
            sqlCommand.Parameters.Add(new SqlParameter("@note", studentPreviousSchool.Note == null ? DBNull.Value : studentPreviousSchool.Note));

            int result = BaseDataManager.ExecuteNonQuery(sqlCommand);
            return result;
        }
        public static int DeleteStudentPreviousSchool(StudentPreviousSchool studentPreviousSchool)
        {
            if (studentPreviousSchool == null) return 0;

            string sqlStatement = "DELETE FROM [dbo].[StudentPreviousSchool] WHERE ID=@id;";


            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = sqlStatement,
                CommandType = CommandType.Text,
            };
            sqlCommand.Parameters.Add(new SqlParameter("@id", studentPreviousSchool.ID));

            int result = BaseDataManager.ExecuteNonQuery(sqlCommand);
            return result;
        }

        #endregion
    }
}
