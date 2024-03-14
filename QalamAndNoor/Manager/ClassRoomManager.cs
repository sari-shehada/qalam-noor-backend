using QalamAndNoor.DataManager;
using QalamAndNoor.Models;

namespace QalamAndNoor.Manager
{
    public abstract class ClassRoomManager
    {
        public static List<ClassRoom> GetClassRooms()
        {
            return ClassRoomDataManager.GetClasseRooms().ToList();
        }
        public static int InsertClassRoom(ClassRoom classRoom)
        {
            return ClassRoomDataManager.InsertClassRoom(classRoom);
        }
        public static int UpdateClassRoom(ClassRoom classRoom)
        {
            return ClassRoomDataManager.UpdateClassRoom(classRoom);
        }
        public static int DeleteClassRoom(ClassRoom classRoom)
        {
            return ClassRoomDataManager.DeleteClassRoom(classRoom);
        }
        public static ClassRoom? GetClassRoomById(int id)
        {
            List<ClassRoom> classRooms = GetClassRooms();
            foreach (ClassRoom classRoom in classRooms)
            {
                if (classRoom.ID == id)
                {
                    return classRoom;
                }
            }
            return null;
        }
        public static List<ClassRoom> GetClassRoomsByName(string name)
        {
            List<ClassRoom> classRooms = GetClassRooms();
            List<ClassRoom> result = new List<ClassRoom>();
            foreach (ClassRoom item in classRooms)
            {
                if (item.Name.ToLower().Trim().Contains(name.ToLower().Trim()))
                {
                    result.Add(item);
                }
            }
            return result;
        }
        public static List<ClassRoom> GetClassRoomsByClassId(int classId)
        {
            List<ClassRoom> classRooms = GetClassRooms();
            List<ClassRoom> result = new List<ClassRoom>();
            foreach (ClassRoom item in classRooms)
            {
                if (item.ClassId == classId)
                {
                    result.Add(item);
                }
            }
            return result;
        }
        public static List<ClassRoom> GetAvailableClassRoomsByClassId(int classId)
        {
            List<ClassRoomSchoolYear> classRoomSchoolYears = ClassRoomSchoolYearManager.
                GetClassRoomSchoolYearsBySchoolYearId(SchoolYearManager.GetCurrentSchoolYear().ID);
            List<ClassRoom> classroomsInClass = GetClassRoomsByClassId(classId);
            List<ClassRoom> alreadyOpenClassrooms = new List<ClassRoom>();
            foreach (var classroomSchoolYear in classRoomSchoolYears)
            {
                foreach (ClassRoom classroom in classroomsInClass)
                {
                    if (classroom.ID != classroomSchoolYear.ClassRoomId)
                    {
                        continue;
                    }
                    alreadyOpenClassrooms.Add(classroom);
                }

            }
            List<ClassRoom> readyToOpenClassrooms = classroomsInClass.Where((e) => !alreadyOpenClassrooms.Contains(e)).ToList();
            return readyToOpenClassrooms;
        }
        public static List<ClassRoom> GetAlreadyOpenClassRoomsByClassId(int classId)
        {
            List<ClassRoomSchoolYear> classRoomSchoolYears = ClassRoomSchoolYearManager.
                GetClassRoomSchoolYearsBySchoolYearId(SchoolYearManager.GetCurrentSchoolYear().ID);
            List<ClassRoom> classroomsInClass = GetClassRoomsByClassId(classId);
            List<ClassRoom> alreadyOpenClassrooms = new List<ClassRoom>();
            foreach (var classroomSchoolYear in classRoomSchoolYears)
            {
                foreach (ClassRoom classroom in classroomsInClass)
                {
                    if (classroom.ID != classroomSchoolYear.ClassRoomId)
                    {
                        continue;
                    }
                    alreadyOpenClassrooms.Add(classroom);
                }

            }
            return alreadyOpenClassrooms;
        }
        public static ClassRoom? GetCurrentClassRoomInCurrentSchoolYearByStudentId(int studentId)
        {
            YearRecord? yearRecord = YearRecordManager.GetYearRecordsinCurrentSchoolYearByStudentId(studentId);
            if (yearRecord is null)
            {
                return null;
            }
            ClassRoomSchoolYear? classRoomSchoolYear = ClassRoomSchoolYearManager.GetClassRoomSchoolYearById(yearRecord.ClassRoomSchoolYearId!.Value);
            if (classRoomSchoolYear is null)
            {
                return null;
            }
            return GetClassRoomById(classRoomSchoolYear.ClassRoomId);
        }

        public static List<ClassRoom> GetClassRoomsInCurrentSchoolYear()
        {
            int schoolYearId = SchoolYearManager.GetCurrentSchoolYear().ID;
            List<ClassRoomSchoolYear> classRoomSchoolYears = ClassRoomSchoolYearManager.GetClassRoomSchoolYearsBySchoolYearId(schoolYearId);
            List<ClassRoom> classRooms = GetClassRooms();
            List<ClassRoom> result = new List<ClassRoom>();
            foreach (var item in classRoomSchoolYears)
            {
                result.Add(classRooms.First((x) => x.ID == item.ClassRoomId));
            }
            return result;
        }

        public static int GetClassRoomsCountInCurrentSchoolYear()
        {
          return  GetClassRoomsInCurrentSchoolYear().Count;
        }
        public static List<ClassRoom> GetClassRoomsBySchoolYearId(int schoolYearId)
        {
            List<ClassRoomSchoolYear> classRoomSchoolYears = ClassRoomSchoolYearManager.GetClassRoomSchoolYearsBySchoolYearId(schoolYearId);
            List<ClassRoom> classRooms = GetClassRooms();
            List<ClassRoom> result = new List<ClassRoom>();
            foreach (var item in classRoomSchoolYears)
            {
                result.Add(classRooms.First((x) => x.ID == item.ClassRoomId));
            }
            return result;
        }
    }
}