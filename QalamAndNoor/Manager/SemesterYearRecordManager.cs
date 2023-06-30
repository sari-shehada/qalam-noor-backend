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
        public static SemesterYearRecord? GetSemesterYearRecordByYearRecordIdInCurrentSemester(int yearRecordId)
        {
            int currentSemesterId = SemesterManager.GetCurrentSemesterInCurrentSchoolYear().ID;
            List<SemesterYearRecord> semesterYearRecords = GetSemesterYearRecords();
            foreach (SemesterYearRecord item in semesterYearRecords)
            {
                if (item.YearRecordId==yearRecordId&&item.SemesterId==currentSemesterId)
                {
                    return item;
                }

            }
            return null;
        }
        public static List<SemesterYearRecord> GetSemesterYearRecordsBySemesterId(int semesterId)
        {
            List<SemesterYearRecord> semesterYearRecords = GetSemesterYearRecords();
            List<SemesterYearRecord> result = new List<SemesterYearRecord>();
            foreach (SemesterYearRecord item in semesterYearRecords)
            {
                if ( item.SemesterId == semesterId)
                {
                    result.Add(item);
                }

            }
            return result;
        }
        public static SemesterYearRecord? GetSemesterYearRecordByYearRecordIdAndSemesterId(int yearRecordId,int semesterID)
        {
            List<SemesterYearRecord> semesterYearRecords = GetSemesterYearRecords();
            foreach (SemesterYearRecord item in semesterYearRecords)
            {
                if (item.YearRecordId == yearRecordId && item.SemesterId == semesterID)
                {
                    return item;
                }

            }
            return null;
        }

    }
}
