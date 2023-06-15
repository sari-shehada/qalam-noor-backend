using System.Diagnostics;
using QalamAndNoor.Models;
using QalamAndNoor.Models.HelperModels;

namespace QalamAndNoor.Manager
{
    public abstract class StudentYearRecordsManager
    {

        public static List<StudentYearRecords> GetStudentYearRecordsByStudentId(int studentId)
        {
            List<YearRecord> yearRecords = YearRecordManager.GetYearRecordsByStudentId(studentId);
            List<StudentYearRecords> studentYearRecords = new List<StudentYearRecords>();
            foreach (var item in yearRecords)
            {
                if (item.ClassRoomSchoolYearId != null)
                {

                    ClassRoomSchoolYear classRoomSchoolYear =
                       ClassRoomSchoolYearManager.GetClassRoomSchoolYearById(item.ClassRoomSchoolYearId!.Value)!;

                    studentYearRecords.Add(new StudentYearRecords()
                    {
                        SchoolYear = SchoolYearManager.GetSchoolYearById(classRoomSchoolYear.SchoolYearId)!,
                        Semesters = SemesterManager.GetSemestersBySchoolYearId(classRoomSchoolYear.SchoolYearId),
                        Class = ClassManager.GetClassById(item.ClassId),
                        ClassRoom = ClassRoomManager.GetClassRoomById(classRoomSchoolYear.ClassRoomId),
                        YearRecord = YearRecordManager.GetYearRecordById(item.ID)
                    });
                }
            }
            return studentYearRecords;
        }
    }
}
