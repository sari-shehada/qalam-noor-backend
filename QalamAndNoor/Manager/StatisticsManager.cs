namespace QalamAndNoor.Manager
{
    public abstract class StatisticsManager
    {
        public static Dictionary<string, int> GetStatistics()
        {
            Dictionary<string, int> statistics = new Dictionary<string, int>();
            #region City statistics
            statistics.Add("CityCount", CityManager.GetCities().Count);
            statistics.Add("AreasCount", AreaManager.GetAreas().Count);
            statistics.Add("AddresesCount", AddressManager.GetAddresses().Count);
            #endregion
            #region Classes statistics
            statistics.Add("ClassesCount", ClassManager.GetClasses().Count);
            statistics.Add("ClassesRoomCount", ClassRoomManager.GetClassRooms().Count);
            statistics.Add("CoursesCount", CourseManager.GetCourses().Count);
            #endregion
            #region Student statistics
            statistics.Add("StudnetCount", StudentManager.GetStudents().Count);
            statistics.Add("MaleStudent", StudentManager.GetStudentsByIsMale().Count);
            statistics.Add("FemaleStudent", StudentManager.GetStudentsByIsFemale().Count);
            #endregion
            #region Medical statistics
            statistics.Add("VaccineCount", VaccineManager.GetVaccines().Count);
            statistics.Add("IlnessesCount", IlnessManager.GetIlnesses().Count);
            statistics.Add("PsychologicalStatusesCount", PsychologicalStatusManager.GetPsychologicalStatuses().Count);
            #endregion

            return statistics;
        }
        
    }

}
