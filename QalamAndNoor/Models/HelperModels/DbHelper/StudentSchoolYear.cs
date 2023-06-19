using System.Security.Principal;

namespace QalamAndNoor.Models.HelperModels.DbHelper
{
    public class StudentSchoolYear
    {
        public SchoolYear SchoolYear { get; set; }
        public Class Class { get; set; }
        public YearRecord YearRecord { get; set; }
        public Semester Semester { get; set; }
        public List<SemesterExam> SemesterExams { get; set; }
    }
}
