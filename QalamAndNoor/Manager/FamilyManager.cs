using QalamAndNoor.DataManager;
using QalamAndNoor.Models;

namespace QalamAndNoor.Manager
{
    public abstract class FamilyManager
    {
        public static List<Family> GetFamilies()
        {
            return FamilyDataManager.GetFamilies().ToList();
        }
        public static int InsertFamily(Family family)
        {
          return  FamilyDataManager.InsertFamily(family);
        }
        public static int UpdateFamily(Family family) 
        {
            return FamilyDataManager.UpdateFamily(family);
        }
        public static int DeleteFamily(Family family)
        {
            return FamilyDataManager.DeleteFamily(family);
        }
        public static Family GetFamilyById(int id)
        {
            List<Family> families = GetFamilies();
            foreach (Family family in families)
            {
                if (family.ID==id)
                {
                    return family;
                }

            }
            return null;
        }

        public static List<Family> GetFamiliesByFatherId(int fatherId)
        {
            List<Family> families = GetFamilies();
            List<Family> result = new List<Family>();
            foreach (Family family in families)
            {
                if (family.FatherId==fatherId)
                {
                    result.Add(family);
                }
            }
            return result;
        }

        public static List<Family> GetFamiliesByFatherTieNumber(string fatherTieNumber)
        {
            List <Father> fathers= FatherManager.GetFathersByTieNumber(fatherTieNumber);
            List<Family> families = GetFamilies();
            List<Family> result = new List<Family>();
            foreach (var item in fathers)
            {
                result.Add(families.First((x) => x.FatherId == item.ID));
            }
            return result;
        }

        public static Family GetFamilyByStudentId(int studentId)
        {

            Student student = StudentManager.GetStudentById(studentId);

            return GetFamilyById(student.FamilyId);
        }
    }
}
