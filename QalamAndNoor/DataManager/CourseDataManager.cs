using QalamAndNoor.Models;
using System.Data;
using System.Data.SqlClient;

namespace QalamAndNoor.DataManager
{
    public abstract class CourseDataManager
    {
        #region Mappers
        private static Course CourseMapper(IDataReader dataReader)
        {
            Course tempCourse = new Course()
            {
                ID = Convert.ToInt32(dataReader["ID"].ToString()),
                Name = dataReader["Name"].ToString(),
                TotalGrade = Convert.ToDouble(dataReader["TotalGrade"].ToString()),
                TeacherId = Convert.ToInt32(dataReader["TeacherId"].ToString()),
                IsEnriching = Convert.ToBoolean(dataReader["IsEnriching"].ToString()),
                ClassId = Convert.ToInt32(dataReader["ClassId"].ToString()),
            };
            return tempCourse;
        }
        #endregion
        #region PublicMethods
        public static List<Course> GetCourses()
        {
            //SQL Statement
            string sqlStatement = "SELECT * FROM  [dbo].[Course]";
            //Preparing SQL Command
            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = sqlStatement,
                CommandType = CommandType.Text,
            };
            //Execute Query
            List<Course> result = BaseDataManager.GetSPItems<Course>(sqlCommand, CourseMapper);
            return result;
        }
        public static int InsertCourse(Course course)
        {
            if (course == null) return 0;

            string sqlStatement = "INSERT INTO  [dbo].[Course] (Name,TotalGrade,TeacherId,IsEnriching,ClassId) " +
                                  "VALUES (@name,@totalGrade,@teacherId,@isEnriching,@classId)";


            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = sqlStatement,
                CommandType = CommandType.Text,
            };
            sqlCommand.Parameters.Add(new SqlParameter("@name", course.Name));
            sqlCommand.Parameters.Add(new SqlParameter("@totalGrade", course.TotalGrade));
            sqlCommand.Parameters.Add(new SqlParameter("@teacherId", course.TeacherId));
            sqlCommand.Parameters.Add(new SqlParameter("@isEnriching", course.IsEnriching ?"1": "0"));
            sqlCommand.Parameters.Add(new SqlParameter("@classId", course.ClassId));

            int result = BaseDataManager.ExecuteNonQuery(sqlCommand);
            if (result == 1)
            {
                List<Course> courses = GetCourses();
                return courses.Max(x => x.ID);

            }
            return 0;
        }
        public static int UpdateCourse(Course course)
        {
            if (course == null) return 0;

            string sqlStatement = "UPDATE  [dbo].[Course] SET " +
                                  "Name=@name,TotalGrade=@totalGrade,TeacherId=@teacherId," +
                                  "IsEnriching=@isEnriching,ClassId=@classIs " +
                                  "WHERE ID=@id;";

            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = sqlStatement,
                CommandType = CommandType.Text,
            };
            sqlCommand.Parameters.Add(new SqlParameter("@id", course.ID));
            sqlCommand.Parameters.Add(new SqlParameter("@name", course.Name));
            sqlCommand.Parameters.Add(new SqlParameter("@totalGrade", course.TotalGrade));
            sqlCommand.Parameters.Add(new SqlParameter("@teacherId", course.TeacherId));
            sqlCommand.Parameters.Add(new SqlParameter("@isEnriching", course.IsEnriching ? "1" : "0"));
            sqlCommand.Parameters.Add(new SqlParameter("@classId", course.ClassId));

            int result = BaseDataManager.ExecuteNonQuery(sqlCommand);
            return result;
        }
        public static int DeleteCourse(Course course)
        {
            if (course == null) return 0;

            string sqlStatement = "DELETE FROM [dbo].[Course] WHERE ID=@id;";

            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = sqlStatement,
                CommandType = CommandType.Text,
            };
            sqlCommand.Parameters.Add(new SqlParameter("@id", course.ID));

            int result = BaseDataManager.ExecuteNonQuery(sqlCommand);
            return result;
        }
        #endregion
    }
}
