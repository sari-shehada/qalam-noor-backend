using QalamAndNoor.Models;
using QalamAndNoor.Models.HelperModels;
using System.Data;
using System.Data.SqlClient;

namespace QalamAndNoor.DataManager.Helper
{
    public abstract class StudentInfoDataManager
    {
        private static StudentInfo StudentInfoMapper(IDataReader dataReader)
        {
            StudentInfo tempStudentInfo = new StudentInfo()
            {
                StudentId = Convert.ToInt32(dataReader["StudentId"].ToString()),
                SchoolYear = dataReader["SchoolYear"].ToString(),
                Semester = dataReader["Semester"].ToString(),
                Class = dataReader["CLass"].ToString(),
                ClassId = Convert.ToInt32(dataReader["ClassId"].ToString()),
                ClassRoom = dataReader["ClassRoom"].ToString(),
            };
            return tempStudentInfo;
        }
        public static List<StudentInfo> GetStudentInfo()
        {
            //SQL Statement
            string sqlStatement = "SELECT * FROM  [dbo].[StudentInfo]";
            //Preparing SQL Command
            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = sqlStatement,
                CommandType = CommandType.Text,
            };
            //Execute Quer
            List<StudentInfo> result = BaseDataManager.GetSPItems<StudentInfo>(sqlCommand, StudentInfoMapper);
            return result;
        }
    }
}
