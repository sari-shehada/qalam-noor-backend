namespace QalamAndNoor.Models.HelperModels.DbHelper
{
    public class StudentProfileDto
    {
        public Student? Student { get; set; }
        public Father? Father { get; set; }
        public Mother? Mother { get; set; }
        public ResponsiblePerson? ResponsiblePerson { get; set; }
        public List<Student>? Sibling { get; set; }
        public List<PreviousSchool>? PreviousSchools { get; set; }
        public Address? Address { get; set; }
        public Area? Area { get; set; }
        public City? City { get; set; }
        public List<StudentIllnesses>? Illnesses { get; set; }
        public List<StudentPsychologicalStatusInfo>? PsychologicalStatuses { get; set; }
        public List<StudentTakenVaccine>? Vaccines { get; set; }
        public Class? CurrentClass { get; set; }
        public ClassRoom? CurrentClaasRoom { get; set; }
        public List<SchoolYear>? StudentSchoolYears { get; set; }


    }
}
