using QalamAndNoor.Models;
using System.Data.SqlClient;
using System.Data;

namespace QalamAndNoor.DataManager
{
    public abstract class IlnessDataManager
    {
        #region Mappers
        private static Ilness IlnessMapper(IDataReader dataReader)
        {
            Ilness tempIlness = new Ilness()
            {
                ID = Convert.ToInt32(dataReader["ID"].ToString()),
                Name = dataReader["Name"].ToString(),
            };
            return tempIlness;
        }
        #endregion
        // #region Public Methods
        #region PublicMethods
        public static List<Ilness> GetIlnesses()
        {
            //SQL Statement
            string sqlStatement = "SELECT * FROM  [dbo].[Ilness]";
            //Preparing SQL Command
            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = sqlStatement,
                CommandType = CommandType.Text,
            };
            //Execute Query
            List<Ilness> result = BaseDataManager.GetSPItems<Ilness>(sqlCommand, IlnessMapper);
            return result;
        }
        public static int InsertIlness(Ilness ilness)
        {
            if (ilness == null) return 0;

            string sqlStatement = "INSERT INTO  [dbo].[Ilness] (Name) " +
                                  "VALUES (@name)";


            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = sqlStatement,
                CommandType = CommandType.Text,
            };
            sqlCommand.Parameters.Add(new SqlParameter("@name", ilness.Name));

            int result = BaseDataManager.ExecuteNonQuery(sqlCommand);
            if (result == 1)
            {
                List<Ilness> ilnesses = GetIlnesses();
                return ilnesses.Max(x => x.ID);

            }
            return 0;
        }
        public static int UpdateIlness(Ilness ilness)
        {
            if (ilness == null) return 0;

            string sqlStatement = "UPDATE  [dbo].[Ilness] SET " +
                                  "Name=@name " +
                                  "WHERE ID=@id;";

            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = sqlStatement,
                CommandType = CommandType.Text,
            };
            sqlCommand.Parameters.Add(new SqlParameter("@id", ilness.ID));
            sqlCommand.Parameters.Add(new SqlParameter("@name", ilness.Name));

            int result = BaseDataManager.ExecuteNonQuery(sqlCommand);
            return result;
        }
        public static int DeleteIlness(Ilness ilness)
        {
            if (ilness == null) return 0;

            string sqlStatement = "DELETE FROM [dbo].[Ilness] WHERE ID=@id;";

            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = sqlStatement,
                CommandType = CommandType.Text,
            };
            sqlCommand.Parameters.Add(new SqlParameter("@id", ilness.ID));

            int result = BaseDataManager.ExecuteNonQuery(sqlCommand);
            return result;
        }


        #endregion
    }
}
