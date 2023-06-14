using QalamAndNoor.DataManager;
using QalamAndNoor.Models;

namespace QalamAndNoor.Manager
{
    public abstract class SemesterYearRecordManager
    {
        public static SemesterYearRecord GetSemesterYearById(int id)
        {
            return SemesterYearRecordDataManager.GetSemesterYearRecords().First((e)=>e.ID == id)!;
        }
        public static List<SemesterYearRecord> GetSemesterYearRecords()
        {
            return SemesterYearRecordDataManager.GetSemesterYearRecords();
        }
        public static int InsertSemsterYearRecord(SemesterYearRecord semesterYearRecord)
        {
            return SemesterYearRecordDataManager.InsertSemesterYearRecord(semesterYearRecord);
        }
        public static int UpdateSemesterYearRecord(SemesterYearRecord semesterYearRecord)
        {
            return SemesterYearRecordDataManager.UpdateSemesterYearRecord(semesterYearRecord);
        }
        public static int DeleteSemesterYearRecord(SemesterYearRecord semesterYearRecord)
        {
            return SemesterYearRecordDataManager.DeleteSemesterYearRecord(semesterYearRecord);
        }
    }
}
