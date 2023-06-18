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
            List<ClassRoom> alreadyOpenClassrooms=new List<ClassRoom>();
            foreach (var classroomSchoolYear in classRoomSchoolYears)
            {
                foreach (ClassRoom classroom in classroomsInClass)
                {
                    if(classroom.ID!= classroomSchoolYear.ClassRoomId)
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
    }
}