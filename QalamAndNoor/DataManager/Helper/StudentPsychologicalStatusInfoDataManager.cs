using System.Data;
using System.Data.SqlClient;
using QalamAndNoor.Models;
using QalamAndNoor.Models.HelperModels;
using QalamAndNoor.Shared;

namespace QalamAndNoor.DataManager.Helper
{
    public abstract class StudentPsychologicalStatusInfoDataManager
    {
        private static StudentPsychologicalStatusInfo StudentPsychologicalStatusInfoMapper(IDataReader dataReader)
        {
            StudentPsychologicalStatusInfo tempStudentPsychologicalStatusInfo = new StudentPsychologicalStatusInfo()
            {
                PsychologicalStatusMedicalRecordId = Convert.ToInt32(dataReader["ID"].ToString()),
                PsychologicalStatusName = dataReader["Name"].ToString(),
                StatusLevel = (LevelEnum)Convert.ToInt32(dataReader["StatusLevel"].ToString()),

            };
            return tempStudentPsychologicalStatusInfo;
        }
        public static List<StudentPsychologicalStatusInfo> GetStudentStudentPsychologicalStatusInfoByStudentId(int studentId)
        {
            string sqlStatement = $"select PsychologicalStatus.Name as Name,PsychologicalStatusMedicalRecord.StatusLevel as StatusLevel,PsychologicalStatusMedicalRecord.ID as ID from PsychologicalStatus,PsychologicalStatusMedicalRecord where PsychologicalStatus.ID=PsychologicalStatusMedicalRecord.PsychologicalStatusId and PsychologicalStatusMedicalRecord.MedicalRecordId={studentId}";
            //Preparing SQL Command
            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = sqlStatement,
                CommandType = CommandType.Text,
            };
            //Execute Query
            List<StudentPsychologicalStatusInfo> result = BaseDataManager.GetSPItems(sqlCommand, StudentPsychologicalStatusInfoMapper);
            return result;
        }
    }

}
