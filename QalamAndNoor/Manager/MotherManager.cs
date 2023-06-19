using QalamAndNoor.DataManager;
using QalamAndNoor.Models;

namespace QalamAndNoor.Manager
{
    public abstract class MotherManager
    {
        public static List<Mother> GetMothers()
        {
            return MotherDataManager.GetMothers().ToList();
        }
        public static int InsertMother(Mother mother)
        {
            return MotherDataManager.InsertMother(mother);
        }
        public static int UpdateMother(Mother mother)
        {
            return MotherDataManager.UpdateMother(mother);
        }
        public static int DeleteMother(Mother mother)
        {
            return MotherDataManager.DeleteMother(mother);
        }
        public static Mother GetMotherById(int id)
        {
            List<Mother> mothers = GetMothers();
            foreach (Mother mother in mothers)
            {
                if (mother.ID==id)
                {
                    return mother;
                }
            }
            return null;
        }
        public static Mother GetMotherByStudentId(int studentId)
        {
            Family family = FamilyManager.GetFamilyByStudentId(studentId);
            return GetMotherById(family.MotherId);
        }
    }
}
