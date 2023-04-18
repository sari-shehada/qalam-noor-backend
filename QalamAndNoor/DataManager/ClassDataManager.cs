using QalamAndNoor.Models;
using System.Data.SqlClient;
using System.Data;

namespace QalamAndNoor.DataManager
{
    public abstract class ClassDataManager
    {
        #region Mappers
        private static Class ClassMapper(IDataReader dataReader)
        {
            Class tempClass = new Class()
            {
                ID = Convert.ToInt32(dataReader["ID"].ToString()),
                Name = dataReader["Name"].ToString(),
            };
            return tempClass;
        }
        #endregion

        #region PublicMetheds
        public static List<Class> GetClasses()
        {
            //SQL Statement
            string sqlStatement = "SELECT * FROM  [dbo].[Class]";
            //Preparing SQL Command
            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = sqlStatement,
                CommandType = CommandType.Text,
            };
            //Execute Query
            List<Class> result = BaseDataManager.GetSPItems<Class>(sqlCommand, ClassMapper);
            return result;
        }

        public static int InsertClass(Class cls)
        {
            if (cls == null) return 0;

            string sqlStatement = "INSERT INTO  [dbo].[Class] (Name) " +
                                  "VALUES (@name)";


            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = sqlStatement,
                CommandType = CommandType.Text,
            };
            sqlCommand.Parameters.Add(new SqlParameter("@name", cls.Name));

            int result = BaseDataManager.ExecuteNonQuery(sqlCommand);
            if (result == 1)
            {
                List<Class> classes = GetClasses();
                return classes.Max(x => x.ID);

            }
            return 0;
        }
        public static int UpdateClass(Class cls)
        {
            if (cls == null) return 0;

            string sqlStatement = "UPDATE  [dbo].[Class] SET " +
                                  "Name=@name " +
                                  "WHERE ID=@id;";


            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = sqlStatement,
                CommandType = CommandType.Text,
            };

            sqlCommand.Parameters.Add(new SqlParameter("@id", cls.ID));
            sqlCommand.Parameters.Add(new SqlParameter("@name", cls.Name));

            int result = BaseDataManager.ExecuteNonQuery(sqlCommand);
            return result;
        }
        public static int DeleteClass(Class cls)
        {
            if (cls == null) return 0;

            string sqlStatement = "DELETE FROM [dbo].[Class] WHERE ID=@id;";

            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = sqlStatement,
                CommandType = CommandType.Text,
            };

            sqlCommand.Parameters.Add(new SqlParameter("@id", cls.ID));

            int result = BaseDataManager.ExecuteNonQuery(sqlCommand);
            return result;
        }



        #endregion
    }
}
