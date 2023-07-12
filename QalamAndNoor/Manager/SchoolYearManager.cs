using QalamAndNoor.DataManager;
using QalamAndNoor.Models;
using QalamAndNoor.Models.HelperModels.DbHelper;
using QalamAndNoor.Shared;

namespace QalamAndNoor.Manager
{
    public abstract class SchoolYearManager
    {
        public static List<SchoolYear> GetSchoolYears()
        {

            return SchoolYearDataManager.GetSchoolYears().ToList();
        }

        public static object InsertSchoolYear(SchoolYear schoolYear)
        {
            schoolYear.PreviousSchoolYearId = GetPreviousSchoolYearID();
            return SchoolYearDataManager.InsertSchoolYear(schoolYear);
        }

        public static int UpdateSchoolYear(SchoolYear schoolYear)
        {
            return SchoolYearDataManager.UpdateSchoolYear(schoolYear);
        }

        public static int DeleteSchoolYear(SchoolYear schoolYear)
        {
            return SchoolYearDataManager.DeleteSchoolYear(schoolYear);
        }

        public static SchoolYear? GetSchoolYearById(int id)
        {
            List<SchoolYear> schoolYears = GetSchoolYears();
            foreach (SchoolYear schoolYear in schoolYears)
            {
                if (schoolYear.ID == id)
                {
                    return schoolYear;
                }
            }
            return null;
        }

        private static SchoolYear? GetSchoolByPreviousSchoolYearById(int? previousSchoolYearId)
        {
            List<SchoolYear> schoolYears = GetSchoolYears();
            foreach (SchoolYear schoolYear in schoolYears)
            {
                if (schoolYear.PreviousSchoolYearId == previousSchoolYearId)
                {
                    return schoolYear;
                }
            }
            return null;
        }

        public static int? GetPreviousSchoolYearID(int? id = null)
        {
            try
            {
                SchoolYear? result = GetSchoolByPreviousSchoolYearById(id);
                if (result == null)
                {
                    return id!.Value;
                }
                return GetPreviousSchoolYearID(result!.ID);
            }
            catch
            {
                return null;
            }
        }

        private static int GetMaxSchoolYearID()
        {
            try
            {
                List<SchoolYear> schoolYears = GetSchoolYears();
                return schoolYears.Max(x => x.ID);
            }
            catch (InvalidOperationException)
            {
                return -1;
            }
         

        }
        public static SchoolYear? GetCurrentSchoolYear()
        {
            SchoolYear? schoolYear = GetSchoolYearById(GetMaxSchoolYearID());
            if (schoolYear is null)
            {
                return null;
            }
            return schoolYear;
        }
        public static List<SchoolYear> GetSchoolYearsByStudentId(int studentId)
        {
            return SchoolYearDataManager.GetSchoolYearsByStudentId(studentId);
        }

        public static object FinshedCurrentScoolYear()
        {
            SchoolYear schoolYear = GetCurrentSchoolYear();
            int finshedSchoolyear = UpdateSchoolYear(new SchoolYear
            {
                ID = schoolYear.ID,
                Name = schoolYear.Name,
                PreviousSchoolYearId = schoolYear.PreviousSchoolYearId,
                IsFinished = true
            });
            if (finshedSchoolyear==0)
            {
                return new 
                
                { 
                    Message="تعذرت عملية انهاء العام الدراسي ",
                    Success = false
                };
            }
            List<YearRecord> yearRecords = YearRecordManager.GetYearRecordsinCurrentSchoolYear();
            
            foreach (var item in yearRecords)
            {
                FinalStudentScore finalStudentScore = FinalStudentScoreManager.GetFinalStudentScoreByStudentIdAndSchoolYearId(item.StudentId,schoolYear.ID);
                YearRecordManager.UpdateYearRecord(new YearRecord
                {
                    ID = item.ID,
                    StudentId = item.StudentId,
                    ClassId = item.ClassId,
                    ClassRoomSchoolYearId = item.ClassRoomSchoolYearId,
                    YearGrade = Convert.ToInt32(Math.Ceiling((finalStudentScore.TotalGrade))),
                    Status = finalStudentScore.DidPassYear == true ? StudentStatusEnum.Pass : StudentStatusEnum.Fail,
                });
                
            }
            return new
            {
                Message = $"تمت بنجاح عملية انهاء العام الدراسي ${schoolYear.Name}",
                Success = true
            };


        }

    }
}

