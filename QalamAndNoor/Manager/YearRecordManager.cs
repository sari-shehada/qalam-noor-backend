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
                if (yearRecord.ID == id)
                {
                    return yearRecord;
                }
            }
            return null;
        }
        public static List<YearRecord> GetYearRecordsByClassId(int classId)
        {
            List<YearRecord> yearRecords = GetYearRecords();
            List<YearRecord> result = new List<YearRecord>();
            foreach (YearRecord yearRecord in yearRecords)
            {
                if (yearRecord.ClassId == classId)
                {
                    result.Add(yearRecord);
                }
            }
            return result;
        }
        public static List<YearRecord> GetYearRecordsByClassRoomSchoolRearId(int classRoomSchoolYearId)
        {
            List<YearRecord> yearRecords = GetYearRecords();
            List<YearRecord> result = new List<YearRecord>();
            foreach (YearRecord yearRecord in yearRecords)
            {
                if (yearRecord.ClassRoomSchoolYearId == classRoomSchoolYearId)
                {
                    result.Add(yearRecord);
                }
            }
            return result;
        }
        public static List<YearRecord> GetYearRecordsBySchoolyearId(int schoolYearId)
        {
            List<ClassRoomSchoolYear> classRoomSchoolYears = ClassRoomSchoolYearManager.GetClassRoomSchoolYearsBySchoolYearId(schoolYearId);
            List<YearRecord> yearRecords = GetYearRecords();
            List<YearRecord> result = new List<YearRecord>();
            foreach (var item in classRoomSchoolYears)
            {
                result.Add(yearRecords.First((x) => x.ClassRoomSchoolYearId == item.ID));
            }
            return result;
        }
        public static List<YearRecord> GetYearRecordsBySchoolYearIdAndClassId(int schoolYearId, int classId)
        {
            List<YearRecord> yearRecords = GetYearRecordsBySchoolyearId(schoolYearId);
            List<YearRecord> result = new List<YearRecord>();
            foreach (YearRecord yearRecord in yearRecords)
            {
                if (yearRecord.ClassId == classId)
                {
                    result.Add(yearRecord);
                }
            }
            return result;
        }
        public static List<YearRecord> GetYearRecordsByStudentId(int studentId)
        {
            List<YearRecord> yearRecords = GetYearRecords();
            List<YearRecord> result = new List<YearRecord>();
            foreach (YearRecord yearRecord in yearRecords)
            {
                if (yearRecord.StudentId == studentId)
                {
                    result.Add(yearRecord);
                }
            }
            return result;
        }
        public static List<YearRecord> GetDidPassedYearRescord()
        {
            List<YearRecord> yearRecords = GetYearRecords();
            List<YearRecord> result = new List<YearRecord>();
            foreach (YearRecord yearRecord in yearRecords)
            {
                if (yearRecord.DidPass == true)
                {
                    result.Add(yearRecord);
                }
            }
            return result;
        }
        public static List<YearRecord> GetDidPassedYearRecordsByStudentId(int studentId)
        {
            List<YearRecord> yearRecords = GetDidPassedYearRescord();
            List<YearRecord> result = new List<YearRecord>();
            foreach (YearRecord yearRecord in yearRecords)
            {
                if (yearRecord.StudentId == studentId)
                {
                    result.Add(yearRecord);
                }
            }
            return result;
        }
    }
}
