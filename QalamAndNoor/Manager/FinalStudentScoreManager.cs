using QalamAndNoor.DataManager.Helper;
using QalamAndNoor.Models;
using QalamAndNoor.Models.HelperModels.DbHelper;

namespace QalamAndNoor.Manager
{
    public class FinalStudentScoreManager
    {
        public static FinalStudentScore GetFinalStudentScoreByStudentIdInCurrentSchoolYear(int studentId)
        {
            int schoolYearId = SchoolYearManager.GetCurrentSchoolYear().ID;
            List<TotalStudentMark> totalStudentMarks = TotalStudentMarkDataManager.
                GetTotalStudentMarksByStudentIdAndSchoolYearId(schoolYearId, studentId);


            Class schoolClass = ClassManager.GetClassByCoureseId(totalStudentMarks.First().CourseId);
            bool didPass = true;
            int numberOfFailedCourses = 0;
            foreach (TotalStudentMark mark in totalStudentMarks)
            {
                if(mark.DidPass==false)
                {
                    if(mark.RequiredToPass==true)
                    {
                        didPass= false;
                        break;
                    }
                    numberOfFailedCourses++;
                    if(numberOfFailedCourses==schoolClass.YearDropCourseCount)

                    {
                        didPass= false;
                        break;
                    }
                }
            }
            return new FinalStudentScore
            {
                TotalStudentMarks = totalStudentMarks,
                TotalGrade = totalStudentMarks.Sum(x => x.AverageGrade),
                DidPassYear = didPass
            };


        }
    }
}
