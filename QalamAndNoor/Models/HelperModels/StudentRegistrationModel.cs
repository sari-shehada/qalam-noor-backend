namespace QalamAndNoor.Models.HelperModels
{
    public class StudentRegistrationModel
    {
        public Student Student { get; set; }
        public Family Family { get; set; }
        public Father Father { get; set; }
        public Mother Mother { get; set; }
        public ResponsiblePerson? ResponsiblePerson { get; set; }
        public MedicalRecord MedicalRecord { get; set; }
        public List< Ilness> Illnesses { get; set; }
        public List <TokenVaccine> TakenVaccines { get; set; }
        public StudentPreviousSchool? StudentPreviousSchool { get; set; }
        public Class EnrolledClass { get; set; }
    }
}
