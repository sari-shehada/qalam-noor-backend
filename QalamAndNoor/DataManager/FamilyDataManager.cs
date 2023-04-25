using QalamAndNoor.Models;
using QalamAndNoor.Shared;
using System.Data;
using System.Data.SqlClient;

namespace QalamAndNoor.DataManager
{
    public abstract class FamilyDataManager
    {
        #region Mappers
        private static Family FamilyMapper(IDataReader dataReader)
        {
            Family tempFamily = new Family()
            {
                ID = Convert.ToInt32(dataReader["ID"].ToString()),
                UserName = dataReader["UserName"].ToString(),
                Password = dataReader["Password"].ToString(),
                FatherId = Convert.ToInt32(dataReader["FatherId"].ToString()),
                MotherId = Convert.ToInt32(dataReader["MotherId"].ToString()),
                ResponsiblePersonId = dataReader["ResponsiblePersonId"].ToString().Trim() == string.Empty ? null : Convert.ToInt32(dataReader["ResponsiblePersonId"].ToString()),
            };
            return tempFamily;
        }
        #endregion
        #region PublicMethods
        public static List<Family> GetFamilies()
        {
            //SQL Statement
            string sqlStatement = "SELECT * FROM  [dbo].[Family]";
            //Preparing SQL Command
            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = sqlStatement,
                CommandType = CommandType.Text,
            };
            //Execute Query
            List<Family> result = BaseDataManager.GetSPItems<Family>(sqlCommand, FamilyMapper);
            return result;
        }
        public static int InsertFamily(Family family)
        {
            if (family == null) return 0;

            string sqlStatement = "INSERT INTO  [dbo].[Family] (UserName,Password,FatherId,MotherId,ResponsiblePersonId) " +
                                  "VALUES (@userName,@password,@fatherId,@motherId,@responsiblePersonId)";


            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = sqlStatement,
                CommandType = CommandType.Text,
            };
            sqlCommand.Parameters.Add(new SqlParameter("@userName", family.UserName));
            sqlCommand.Parameters.Add(new SqlParameter("@password", family.Password));
            sqlCommand.Parameters.Add(new SqlParameter("@fatherId", family.FatherId));
            sqlCommand.Parameters.Add(new SqlParameter("@motherId", family.MotherId));
            sqlCommand.Parameters.Add(new SqlParameter("@responsiblePersonId", family.ResponsiblePersonId == null ? DBNull.Value :family.ResponsiblePersonId));

            int result = BaseDataManager.ExecuteNonQuery(sqlCommand);
            if (result == 1)
            {
                List<Family> families = GetFamilies();
                return families.Max(x => x.ID);

            }
            return 0;
        }
        public static int UpdateFamily(Family family)
        {
            if (family == null) return 0;

            string sqlStatement = "UPDATE  [dbo].[Family] SET " +
                                  "UserName=@userName,Password=@password,FatherId=@fatherId," +
                                  "MotherId=@motherId,ResponsiblePersonId=@responsiblePersonId " +
                                  "WHERE ID=@id;";

            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = sqlStatement,
                CommandType = CommandType.Text,
            };
            sqlCommand.Parameters.Add(new SqlParameter("@id", family.ID));
            sqlCommand.Parameters.Add(new SqlParameter("@userName", family.UserName));
            sqlCommand.Parameters.Add(new SqlParameter("@password", family.Password));
            sqlCommand.Parameters.Add(new SqlParameter("@fatherId", family.FatherId));
            sqlCommand.Parameters.Add(new SqlParameter("@motherId", family.MotherId));
            sqlCommand.Parameters.Add(new SqlParameter("@responsiblePersonId", family.ResponsiblePersonId == null ? DBNull.Value : family.ResponsiblePersonId));

            int result = BaseDataManager.ExecuteNonQuery(sqlCommand);
            return result;
        }
        public static int DeleteFamily(Family family)
        {
            if (family == null) return 0;

            string sqlStatement = "DELETE FROM [dbo].[Family] WHERE ID=@id;";

            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = sqlStatement,
                CommandType = CommandType.Text,
            };
            sqlCommand.Parameters.Add(new SqlParameter("@id", family.ID));

            int result = BaseDataManager.ExecuteNonQuery(sqlCommand);
            return result;
        }
        #endregion
    }
}
