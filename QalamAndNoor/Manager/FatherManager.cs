using QalamAndNoor.DataManager;
using QalamAndNoor.Models;

namespace QalamAndNoor.Manager
{
    public abstract class FatherManager
    {
        public static List<Father> GetFathers()
        {
            return FatherDataManager.GetFathers().ToList();
        }
        public static int InsertFather(Father father)
        {
            return FatherDataManager.InsertFather(father);
        }
        public static int UpdateFather(Father father)
        {
            return FatherDataManager.UpdateFather(father);
        }
        public static int DeleteFather(Father father)
        {
            return FatherDataManager.DeleteFather(father);
        }
        public static Father GetFatherById(int id)
        {
            List<Father> fathers = GetFathers();
            foreach (Father father in fathers)
            {
                if (father.ID == id)
                {
                    return father;
                }
            }
            return null;
        }

        public static List<Father> GetFathersByTieNumber(string tieNumber)
        {
            List<Father> fathers = GetFathers();
            List<Father> result = new List<Father>();
            foreach (Father father in fathers)
            {
                if (father.TieNumber == tieNumber)
                {
                    result.Add(father);
                }
            }
            return result;
        }
        public static Father GetFatherByStudentId(int studentId)
        {
            Family family = FamilyManager.GetFamilyByStudentId(studentId);
            return GetFatherById(family.FatherId);
        }
    }
}
