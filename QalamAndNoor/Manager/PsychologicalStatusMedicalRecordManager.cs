using QalamAndNoor.DataManager;
using QalamAndNoor.Models;

namespace QalamAndNoor.Manager
{
    public abstract class PsychologicalStatusMedicalRecordManager
    {
        public static List<PsychologicalStatusMedicalRecord> GetPsychologicalStatusMedicalRecords()
        {
            return PsychologicalStausMedicalRecordDataManager.GetPsychologicalStatusMedicalRecords().ToList();
        }
        public static int InsertPsychologicalStatusMedicalRecord(PsychologicalStatusMedicalRecord record)
        {
            return PsychologicalStausMedicalRecordDataManager.InsertPsychologicalStatusMedicalRecord(record);
        }
        public static int UpdatePsychologicalStatusMedicalRecord(PsychologicalStatusMedicalRecord record)
        {
            return PsychologicalStausMedicalRecordDataManager.UpdatePsychologicalStatusMedicalRecord(record);
        }
        public static int DeletePsychologicalStatusMedicalRecord(PsychologicalStatusMedicalRecord record)
        {
            return PsychologicalStausMedicalRecordDataManager.DeletePsychologicalStatusMedicalRecord(record);
        }
        public static PsychologicalStatusMedicalRecord GetPsychologicalStatusMedicalRecordById(int id)
        {
            List<PsychologicalStatusMedicalRecord> psychologicalStatusMedicalRecords = GetPsychologicalStatusMedicalRecords();
            foreach (PsychologicalStatusMedicalRecord record in psychologicalStatusMedicalRecords)
            {
                if (record.ID==id)
                {
                    return record;
                }
            }
            return null;
        }

        public static List<PsychologicalStatusMedicalRecord>GetPsychologicalStatusMedicalRecordsByMedicalRecordId(int medicalId)
        {
            List<PsychologicalStatusMedicalRecord> psychologicalStatusMedicalRecords = GetPsychologicalStatusMedicalRecords();
            List<PsychologicalStatusMedicalRecord> result = new List<PsychologicalStatusMedicalRecord>();
            foreach (PsychologicalStatusMedicalRecord psychologicalStatusMedicalRecord in psychologicalStatusMedicalRecords)
            {
                if (psychologicalStatusMedicalRecord.MedicalRecordId==medicalId)
                {
                    result.Add(psychologicalStatusMedicalRecord);
                }
            }
            return result;
        }
  
    public static List<PsychologicalStatusMedicalRecord>GetPsychologicalStatusMedicalRecordsByPsychologicalStatusId(int psychologicalStatusId)
        {
            List<PsychologicalStatusMedicalRecord> psychologicalStatusMedicalRecords = GetPsychologicalStatusMedicalRecords();
            List<PsychologicalStatusMedicalRecord> result = new List<PsychologicalStatusMedicalRecord>();
            foreach (PsychologicalStatusMedicalRecord item in psychologicalStatusMedicalRecords)
            {
                if (item.PsychologicalStatusId==psychologicalStatusId)
                {
                    result.Add(item);
                }
            }
            return result;
        }
    }
}

