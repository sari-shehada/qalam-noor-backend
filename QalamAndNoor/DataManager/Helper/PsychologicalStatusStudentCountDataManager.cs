using QalamAndNoor.Models;
using QalamAndNoor.Models.HelperModels;
using System.Data;
using System.Data.SqlClient;

namespace QalamAndNoor.DataManager.Helper
{
    public abstract class PsychologicalStatusStudentCountDataManager
    {
        #region Mappers
        private static PsychologicalStatusStudentCount PsychologicalStatusStudentCountMapper(IDataReader dataReader)
        {
            PsychologicalStatusStudentCount tempPsychologicalStatusStudentCount = new PsychologicalStatusStudentCount()
            {
                StudentsCount = Convert.ToInt32(dataReader["CountStudent"].ToString()),
                PsychologicalStatusName = dataReader["Name"].ToString(),
            };
            return tempPsychologicalStatusStudentCount;
        }
        #endregion
        public static List<PsychologicalStatusStudentCount> GetPsychologicalStatusStudentCount()
        {
            //SQL Statement
            string sqlStatement = "select PsychologicalStatus.Name as Name,count(Student.ID) as CountStudent from Student,PsychologicalStatus,PsychologicalStatusMedicalRecord,MedicalRecord\r\nwhere PsychologicalStatus.ID=PsychologicalStatusMedicalRecord.PsychologicalStatusId and PsychologicalStatusMedicalRecord.MedicalRecordId=MedicalRecord.StudentId and MedicalRecord.StudentId=Student.ID\r\ngroup By(PsychologicalStatus.Name)";
            //Preparing SQL Command
            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = sqlStatement,
                CommandType = CommandType.Text,
            };
            //Execute Query
            List<PsychologicalStatusStudentCount> result = BaseDataManager.GetSPItems<PsychologicalStatusStudentCount>(sqlCommand, PsychologicalStatusStudentCountMapper);
            return result;
        }
    }
}
