using QalamAndNoor.DataManager;
using QalamAndNoor.Models;
using QalamAndNoor.Models.HelperModels;

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
        public static List<ClassRoomSchoolYear> GetClassRoomSchoolYearsByClassRoomId(int classRoomId)
        {
            List<ClassRoomSchoolYear> classRoomSchoolYears = GetClassRoomSchoolYears();
            List<ClassRoomSchoolYear> result = new List<ClassRoomSchoolYear>();
            foreach (ClassRoomSchoolYear item in classRoomSchoolYears)
            {
                if (item.ClassRoomId == classRoomId)
                {
                    result.Add(item);
                }
            }
            return result;
        }

        public static List<ClassRoomSchoolYear> GetClassRoomSchoolYearsInCurrentSchoolYear()
        {
            List<ClassRoomSchoolYear> classRoomSchoolYears = GetClassRoomSchoolYears();
            List<ClassRoomSchoolYear> result = new List<ClassRoomSchoolYear>();
            foreach (ClassRoomSchoolYear classRoomSchoolYear in classRoomSchoolYears)
            {
                if (classRoomSchoolYear.SchoolYearId == SchoolYearManager.GetCurrentSchoolYear().ID)
                {
                    result.Add(classRoomSchoolYear);
                }
            }
            return result;
        }

        public static List<ItemOr> OpenCLassRoomsInSchoolYear(List<int> ClassRoomIds)
        {
            List<ItemOr> itemOrs = new List<ItemOr>();
            foreach (var item in ClassRoomIds)
            {
                int CurrentSchoolYear = SchoolYearManager.GetCurrentSchoolYear().ID;
                var result = InsertClassRoomSchoolYear(new ClassRoomSchoolYear()
                {
                    ClassRoomId = item,
                    SchoolYearId = CurrentSchoolYear
                });
                if (result != 0)
                {
                    itemOrs.Add(new ItemOr()
                    {
                        Item = GetClassRoomSchoolYearById(result),
                        Success = true
                    }
                    );
                }
                else
                {
                    itemOrs.Add(new ItemOr()
                    {
                        Item = null,
                        Success = false
                    }
                       );
                }

            }
            return itemOrs;
        }

        public static ClassRoomSchoolYear GetClassRoomSchoolYearByClassRoomIdAndSchoolYearId(int classRoomId, int schoolYearId)
        {
            List<ClassRoomSchoolYear> classRoomSchoolYears = GetClassRoomSchoolYears();
            List<ClassRoomSchoolYear> result = new List<ClassRoomSchoolYear>();
            foreach (ClassRoomSchoolYear item in classRoomSchoolYears)
            {
                if (item.SchoolYearId==schoolYearId&&item.ClassRoomId==classRoomId)
                {
                    return item;
                }
            }
            return null;
           
        }
    }
}
