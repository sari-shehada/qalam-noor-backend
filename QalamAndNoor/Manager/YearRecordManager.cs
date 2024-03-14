using QalamAndNoor.DataManager;
using QalamAndNoor.Models;
using QalamAndNoor.Shared;

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

        public static List<YearRecord> GetNewYearRecordNullClassRoomSchoolYearId()
        {
            List<YearRecord> yearRecords = GetYearRecords();
            List<YearRecord> result = new List<YearRecord>();
            foreach (YearRecord item in yearRecords)
            {
                if (item.ClassRoomSchoolYearId == null)
                {
                    result.Add(item);
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

        public static List<YearRecord> GetNewYearRecords()
        {
            Dictionary<int, YearRecord> uniqueStudents = new Dictionary<int, YearRecord>();
            List<YearRecord> yearRecords = GetNewYearRecordNullClassRoomSchoolYearId();

            foreach (YearRecord yearRecord in yearRecords)
            {
                if (uniqueStudents.ContainsKey(yearRecord.StudentId))
                {
                    uniqueStudents.Remove(yearRecord.StudentId);
                }
                else
                {
                    uniqueStudents.Add(yearRecord.StudentId, yearRecord);
                }
            }
            return uniqueStudents.Values.ToList();
        }
        public static List<YearRecord> GetNewYearRecordsBYClassID(int classID)
        {
            return GetNewYearRecords().Where((e) => e.ClassId == classID && e.ClassRoomSchoolYearId == null).ToList();
        }



        public static List<YearRecord> GetYearRecordsByClassRoomSchoolYearId(int id)
        {
            List<YearRecord> yearRecords = GetYearRecords();
            List<YearRecord> result = new List<YearRecord>();
            foreach (YearRecord item in yearRecords)
            {
                if (item.ClassRoomSchoolYearId == id)
                {
                    result.Add(item);
                }
            }
            return result;
        }
        public static List<YearRecord> GetYearRecordsByClassRoomIdAndSchoolYearId(int classRoomId, int schoolYearId)
        {
            ClassRoomSchoolYear classRoomSchoolYear = ClassRoomSchoolYearManager.
                GetClassRoomSchoolYearByClassRoomIdAndSchoolYearId(classRoomId, schoolYearId);
            if (classRoomSchoolYear == null)
            {
                return new List<YearRecord>();
            }
            List<YearRecord> yearRecords = GetYearRecords();
            List<YearRecord> result = new List<YearRecord>();
            foreach (YearRecord item in yearRecords)
            {
                if (item.ClassRoomSchoolYearId == classRoomSchoolYear.ID)
                {
                    result.Add(item);
                }
            }
            return result;
        }
        public static List<YearRecord> GetYearRecordsinCurrentSchoolYear()
        {
            int schoolYearId = SchoolYearManager.GetCurrentSchoolYear().ID;
            List<int> classRoomSchoolYearsIds = ClassRoomSchoolYearManager.
                GetClassRoomSchoolYearsBySchoolYearId(schoolYearId).Select((e) => e.ID).ToList();
            List<YearRecord> yearRecords = GetYearRecords();
            List<YearRecord> result = new List<YearRecord>();
            result = yearRecords.Where((e) => classRoomSchoolYearsIds.Contains(e.ClassRoomSchoolYearId ?? -1)).ToList();
            return result;
        }
        public static YearRecord? GetYearRecordsinCurrentSchoolYearByStudentId(int studentId)
        {
            List<YearRecord> yearRecords = GetYearRecordsinCurrentSchoolYear();
            foreach (YearRecord item in yearRecords)
            {
                if (item.StudentId == studentId)
                {
                    return item;
                }
            }
            return null;
        }

        public static List<YearRecord> GetYearRecordsBySemesterId(int semesterId)
        {
            List<SemesterYearRecord> semesterYearRecords = SemesterYearRecordManager.GetSemesterYearRecordsBySemesterId(semesterId);
            List<YearRecord> yearRecords = GetYearRecords();
            List<YearRecord> result = new List<YearRecord>();
            foreach (var item in semesterYearRecords)
            {
                result.Add(yearRecords.First((x) => x.ID == item.YearRecordId));
            }
            return result;
        }

        public static List<YearRecord> GetYearRecordsBySchoolYearId(int schoolYearId)
        {
            List<int> classRoomSchoolYearsIds = ClassRoomSchoolYearManager.
                GetClassRoomSchoolYearsBySchoolYearId(schoolYearId).Select((e) => e.ID).ToList();
            List<YearRecord> yearRecords = GetYearRecords();
            List<YearRecord> result = new List<YearRecord>();
            result = yearRecords.Where((e) => classRoomSchoolYearsIds.Contains(e.ClassRoomSchoolYearId ?? -1)).ToList();
            return result;
        }
        public static List<YearRecord> GetPassYearRecordsBySchoolYearId(int schoolYearId)
        {
            return GetYearRecordsBySchoolYearId(schoolYearId).Where(x => x.Status == StudentStatusEnum.Pass).ToList();
        }
        public static List<YearRecord> GetFailYearRecordsBySchoolYearId(int schoolYearId)
        {
            return GetYearRecordsBySchoolYearId(schoolYearId).Where(x => x.Status == StudentStatusEnum.Fail).ToList();
        }
        public static List<YearRecord> GetYearRecordsBySchoolYearIdAndClassId(int schoolYearId, int classId)
        {
            List<int> classRoomSchoolYearsIds = ClassRoomSchoolYearManager.
                GetClassRoomSchoolYearsBySchoolYearId(schoolYearId).Select((e) => e.ID).ToList();
            List<YearRecord> yearRecords = GetYearRecords();
            List<YearRecord> result = new List<YearRecord>();
            result = yearRecords.Where((e) => classRoomSchoolYearsIds.Contains(e.ClassRoomSchoolYearId ?? -1)&& e.ClassId==classId).ToList();
            return result;
        }

    }
}
