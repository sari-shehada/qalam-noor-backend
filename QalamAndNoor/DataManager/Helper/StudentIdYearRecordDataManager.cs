using QalamAndNoor.Manager;
using QalamAndNoor.Models;
using QalamAndNoor.Models.HelperModels;
using System.Data;
using System.Data.SqlClient;

namespace QalamAndNoor.DataManager.Helper
{
    public abstract class StudentIdYearRecordDataManager
    {
        private static StudentIdYearRecord StudentIdYearRecordMapper(IDataReader dataReader)
        {
            StudentIdYearRecord tempStudentIdYearRecord = new StudentIdYearRecord()
            {
                StudentId = Convert.ToInt32(dataReader["StudentId"].ToString())
            };
            return tempStudentIdYearRecord;
        }
        public static List<StudentIdYearRecord> GetSuccessfulStudentIdsByClassId(int classId)
        {
            Class cls = ClassManager.GetClassById(classId)!;
            if (cls == null || cls.PreviousClassId == null)
            {
                return new List<StudentIdYearRecord>();
            }
            //SQL Statement
            string sqlStatement = $"select YearRecord.StudentId as StudentId  from YearRecord group by YearRecord.StudentId having max(YearRecord.ID) in (select YearRecord.ID from YearRecord where YearRecord.Status = 2 and YearRecord.ClassId = {cls.PreviousClassId})";
            //Preparing SQL Command
            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = sqlStatement,
                CommandType = CommandType.Text,
            };
            //Execute Query
            List<StudentIdYearRecord> result = BaseDataManager.GetSPItems<StudentIdYearRecord>(sqlCommand, StudentIdYearRecordMapper);
            return result;
        }
        public static List<StudentIdYearRecord> GetFailingStudentIdsByClassId(int classId)
        {
            //SQL Statement
            string sqlStatement = $"select YearRecord.StudentId from YearRecord group by YearRecord.StudentId having max(YearRecord.ID) in (select YearRecord.ID from YearRecord where YearRecord.Status = 1 and YearRecord.ClassId = {classId})";

            //Preparing SQL Command
            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = sqlStatement,
                CommandType = CommandType.Text,
            };
            //Execute Query
            List<StudentIdYearRecord> result = BaseDataManager.GetSPItems<StudentIdYearRecord>(sqlCommand, StudentIdYearRecordMapper);
            return result;
        }

    }
}
