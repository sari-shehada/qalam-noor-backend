using QalamAndNoor.Models;
using System.Data;
using System.Data.SqlClient;

namespace QalamAndNoor.DataManager
{
    public abstract class ClassRoomDataManager
    {
        #region Mappers
        private static ClassRoom ClassRoomMapper(IDataReader dataReader)
        {
            ClassRoom tempClassRoom = new ClassRoom()
            {
                ID = Convert.ToInt32(dataReader["ID"].ToString()),
                Name = dataReader["Name"].ToString(),
                MaxCapacity = Convert.ToInt32(dataReader["MaxCapacity"].ToString()),
                ClassId = Convert.ToInt32(dataReader["ClassId"].ToString()),
            };
            return tempClassRoom;
        }
        #endregion
        #region PublicMetheds

        public static List<ClassRoom> GetClasseRooms()
        {
            //SQL Statement
            string sqlStatement = "SELECT * FROM  [dbo].[ClassRoom]";
            //Preparing SQL Command
            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = sqlStatement,
                CommandType = CommandType.Text,
            };
            //Execute Query
            List<ClassRoom> result = BaseDataManager.GetSPItems<ClassRoom>(sqlCommand, ClassRoomMapper);
            return result;
        }
        public static int InsertClassRoom(ClassRoom classRoom)
        {
            if (classRoom == null) return 0;

            string sqlStatement = "INSERT INTO  [dbo].[ClassRoom] (Name,MaxCapacity,ClassId) " +
                                  "VALUES (@name,@maxCapacity,@classId)";


            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = sqlStatement,
                CommandType = CommandType.Text,
            };
            sqlCommand.Parameters.Add(new SqlParameter("@name", classRoom.Name));
            sqlCommand.Parameters.Add(new SqlParameter("@maxCapacity", classRoom.MaxCapacity));
            sqlCommand.Parameters.Add(new SqlParameter("@classId", classRoom.ClassId));


            int result = BaseDataManager.ExecuteNonQuery(sqlCommand);
            if (result == 1)
            {
                List<ClassRoom> classRooms = GetClasseRooms();
                return classRooms.Max(x => x.ID);

            }
            return 0;
        }
        public static int UpdateClassRoom(ClassRoom classRoom)
        {
            if (classRoom == null) return 0;

            string sqlStatement = "UPDATE  [dbo].[ClassRoom] SET " +
                                  "Name=@name,MaxCapacity=@maxCapacity,ClassId=@classId " +
                                  "WHERE ID=@id;";


            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = sqlStatement,
                CommandType = CommandType.Text,
            };
            sqlCommand.Parameters.Add(new SqlParameter("@id", classRoom.ID));
            sqlCommand.Parameters.Add(new SqlParameter("@name", classRoom.Name));
            sqlCommand.Parameters.Add(new SqlParameter("@maxCapacity", classRoom.MaxCapacity));
            sqlCommand.Parameters.Add(new SqlParameter("@classId", classRoom.ClassId));


            int result = BaseDataManager.ExecuteNonQuery(sqlCommand);
            return result;
        }
        public static int DeleteClassRoom(ClassRoom classRoom)
        {
            if (classRoom == null) return 0;

            string sqlStatement = "DELETE FROM [dbo].[ClassRoom] WHERE ID=@id;";

            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = sqlStatement,
                CommandType = CommandType.Text,
            };

            sqlCommand.Parameters.Add(new SqlParameter("@id", classRoom.ID));

            int result = BaseDataManager.ExecuteNonQuery(sqlCommand);
            return result;
        }

        #endregion
    }
}
