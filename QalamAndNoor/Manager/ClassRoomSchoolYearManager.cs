using QalamAndNoor.DataManager;
using QalamAndNoor.Models;

namespace QalamAndNoor.Manager
{
    public abstract class ClassRoomSchoolYearManager
    {
        public static List<ClassRoomSchoolYear> GetClassRoomSchoolYears()
        {
            return ClassRoomSchoolYearDataManager.GetClassRoomSchoolYears().ToList();
        }
        public static int InsertClassRoomSchoolYear(ClassRoomSchoolYear cls)
        {
            return ClassRoomSchoolYearDataManager.InsertClassRoomSchoolYear(cls);
        }
        public static int UpdateClassRoomSchoolYear(ClassRoomSchoolYear cls)
        {
            return ClassRoomSchoolYearDataManager.UpdateClassRoomSchoolYear(cls);
        }
        public static int DeleteClassRoomSchoolYear(ClassRoomSchoolYear cls)
        {
            return ClassRoomSchoolYearDataManager.DeleteClassRoomSchoolYear(cls);
        }
        public static ClassRoomSchoolYear GetClassRoomSchoolYearById(int id)
        {
            List<ClassRoomSchoolYear> classRoomSchoolYears = GetClassRoomSchoolYears();
            foreach (ClassRoomSchoolYear cls in classRoomSchoolYears)
            {
                if (cls.ID == id)
                {
                    return cls;
                }
            }
            return null;
        }
        public static List<ClassRoomSchoolYear> GetClassRoomSchoolYearsBySchoolYearId(int schoolYearId)
        {
            List<ClassRoomSchoolYear> classRoomSchoolYears = GetClassRoomSchoolYears();
            List<ClassRoomSchoolYear> result = new List<ClassRoomSchoolYear>();
            foreach (ClassRoomSchoolYear classRoomSchoolYear in classRoomSchoolYears)
            {
                if (classRoomSchoolYear.SchoolYearId == schoolYearId)
                {
                    result.Add(classRoomSchoolYear);
                }
            }
            return result;
        }
        public static List<ClassRoomSchoolYear>GetClassRoomSchoolYearsByClassRoomId(int classRoomId)
        {
            List<ClassRoomSchoolYear> classRoomSchoolYears = GetClassRoomSchoolYears();
            List<ClassRoomSchoolYear> result = new List<ClassRoomSchoolYear>();
            foreach (ClassRoomSchoolYear item in classRoomSchoolYears)
            {
                if (item.ClassRoomId==classRoomId)
                {
                    result.Add(item);
                }
            }
            return result;
        }
    }
}
