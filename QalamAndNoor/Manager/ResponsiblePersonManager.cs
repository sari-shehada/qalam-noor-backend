using QalamAndNoor.DataManager;
using QalamAndNoor.Models;

namespace QalamAndNoor.Manager
{
    public class ResponsiblePersonManager
    {
        public static List<ResponsiblePerson> GetResponsiblePersons()
        {
            return ResponsiblePersonDataManager.GetResponsiblePersons().ToList();
        }
        public static int InsertResponsiblePerson(ResponsiblePerson person)
        {
            return ResponsiblePersonDataManager.InsertResponsiblePerson(person);
        }
        public static int UpdateResponsiblePerson(ResponsiblePerson person)
        {
            return ResponsiblePersonDataManager.UpdateResponsiblePerson(person);
        }
        public static int DeleteResponsiblePerson(ResponsiblePerson person)
        {
            return ResponsiblePersonDataManager.DeleteResponsiblePerson(person);
        }
        public static ResponsiblePerson? GetResponsiblePersonById(int id)
        {
            List<ResponsiblePerson> responsibles = GetResponsiblePersons();
            foreach (ResponsiblePerson person in responsibles)
            {
                if (person.ID==id)
                {
                    return person;
                }
            }
            return null;
        }

        public static ResponsiblePerson? GetResponsiblePersonByStudentId(int studentId)
        {
            Family family=FamilyManager.GetFamilyByStudentId(studentId);
            if (family.ResponsiblePersonId is null)
            {
                return null;
            }
            return GetResponsiblePersonById(family.ResponsiblePersonId.Value);
        }
    }
}
