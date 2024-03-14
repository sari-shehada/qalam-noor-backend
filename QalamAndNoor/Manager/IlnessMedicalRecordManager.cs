using QalamAndNoor.DataManager;
using QalamAndNoor.Models;

namespace QalamAndNoor.Manager
{
    public abstract class IlnessMedicalRecordManager
    {
        public static List<IlnessMedicalRecord> GetIlnessMedicalRecords()
        {
            return IlnessMedicalRecordDataManager.GetIlnessMedicalRecords().ToList();
        } 
        public static int InsertIlnessMedicalRecords(IlnessMedicalRecord ilnessMedicalRecord)
        {
            return IlnessMedicalRecordDataManager.InsertIlnessMedicalRecord(ilnessMedicalRecord);
        }
        public static int UpdateIlnessMedicalRecord(IlnessMedicalRecord ilnessRecord)
        {
            return IlnessMedicalRecordDataManager.UpdateIlnessMedicalRecord(ilnessRecord);
        }
        public static int DeleteIlnessMedicalRecord(IlnessMedicalRecord ilnessRecord)
        {
            return IlnessMedicalRecordDataManager.DeleteIlnessMedicalRecord(ilnessRecord);
        }
        public static IlnessMedicalRecord GetIlnessMedicalRecordById(int id)
        {
            List<IlnessMedicalRecord> ilnessMedicalRecords = GetIlnessMedicalRecords();
            foreach (IlnessMedicalRecord ilnessMedicalRecord in ilnessMedicalRecords)
            {
                if (ilnessMedicalRecord.ID==id)
                {
                    return ilnessMedicalRecord;
                }
            }
            return null;
        }
    }
}
