using QalamAndNoor.DataManager;
using QalamAndNoor.Models;

namespace QalamAndNoor.Manager
{
    public abstract class MedicalRecordManager
    {
        public static List<MedicalRecord> GetMedicalRecords()
        {
            return MedicalRecordDataManager.GetMedicalRecords().ToList();
        }
        public static int InsertMedicalRecord(MedicalRecord record)
        {
            return MedicalRecordDataManager.InsertMedicalRecord(record);
        }
        public static int UpdateMedicalRecord(MedicalRecord record)
        {
            return MedicalRecordDataManager.UpdateMedicalRecord(record);
        }
        public static int DeleteMedicalRecord(MedicalRecord record)
        {
            return MedicalRecordDataManager.DeleteMedicalRecord(record);
        }
        public static MedicalRecord GetMedicalRecordById(int id)
        {
            List<MedicalRecord> records = GetMedicalRecords();
            foreach (MedicalRecord record in records)
            {
                if (record.StudentId == id)
                {
                    return record;
                }
            }
            return null;
        }
    }
}
