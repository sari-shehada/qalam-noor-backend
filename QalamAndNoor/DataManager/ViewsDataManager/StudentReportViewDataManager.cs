using QalamAndNoor.Models;
using QalamAndNoor.Models.HelperModels.DbHelper;
using QalamAndNoor.Shared;
using System.Data;
using System.Data.SqlClient;

namespace QalamAndNoor.DataManager.ViewsDataManager
{
    public abstract class StudentReportViewDataManager
    {
        private static StudentReport StudentReportMapper(IDataReader dataReader)
        {
            StudentReport tempStudentReport = new StudentReport()
            {
                ClassId = Convert.ToInt32(dataReader["ClassId"].ToString()),
                ClassName = dataReader["ClassName"].ToString(),
                ClassRoomId = Convert.ToInt32(dataReader["ClassRoomId"].ToString()),
                ClassRoomName = dataReader["ClassRoomName"].ToString(),
                ExamId = Convert.ToInt32(dataReader["ExamId"].ToString()),
                ExamType= (ExamTypeEnum)Convert.ToInt32(dataReader["ExamType"].ToString()),
                CourseId = Convert.ToInt32(dataReader["CourseId"].ToString()),
                CourseName = dataReader["CourseName"].ToString(),
                ActualCount = Convert.ToInt32(dataReader["ActualCount"].ToString()),
                ExpectedCount = Convert.ToInt32(dataReader["ExpectedCount"].ToString())
            };
            return tempStudentReport;
        }
        public static List<StudentReport> GetStudentReports()
        {
            //SQL Statement
            string sqlStatement = "SELECT * FROM  [dbo].[ExamReportView]";
            //Preparing SQL Command
            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = sqlStatement,
                CommandType = CommandType.Text,
            };
            //Execute Query
            List<StudentReport> result = BaseDataManager.GetSPItems<StudentReport>(sqlCommand, StudentReportMapper);
            return result;
        }
    }
}
