using QalamAndNoor.DataManager;
using QalamAndNoor.Models;

namespace QalamAndNoor.Manager
{
    public abstract class YearRecordManager
    {
        public static List<YearRecord> GetYearRecords()
        {
            return YearRecordDataManager.GetYearRecords().ToList();
        }
        public static int InsertYearRecord(YearRecord yearRecord)
        {
            return YearRecordDataManager.InsertYearRecord(yearRecord);
        }
        public static int UpdateYearRecord(YearRecord yearRecord)
        {
            return YearRecordDataManager.UpdateYearRecord(yearRecord);
        }
        public static int DeleteYearRecord(YearRecord yearRecord)
        {
            return YearRecordDataManager.DeleteYearRecord(yearRecord);
        }
        public static YearRecord GetYearRecordById(int id)
        {
            List<YearRecord> yearRecords = GetYearRecords();
            foreach (YearRecord yearRecord in yearRecords)
            {
                if (yearRecord.ID==id)
                {
                    return yearRecord;
                }
            }
            return null;
        }

    }
}
