using QalamAndNoor.Models;
using System.Data;
using System.Data.SqlClient;

namespace QalamAndNoor.DataManager
{
    public abstract class TokenVaccineDataManager
    {
        #region Mappers
        private static TokenVaccine TokenVaccineMapper(IDataReader dataReader)
        {
            TokenVaccine tempTokenVaccine = new TokenVaccine()
            {
                ID = Convert.ToInt32(dataReader["ID"].ToString()),
                VaccineId = Convert.ToInt32(dataReader["VaccineId"].ToString()),
                MedicalRecordId = Convert.ToInt32(dataReader["MedicalRecordId"].ToString()),
                ShotDate =Convert.ToDateTime( dataReader["ShotDate"].ToString()),
                Note = dataReader["Note"].ToString().Trim() == string.Empty ? null : dataReader["Note"].ToString(),

            };
            return tempTokenVaccine;
        }
        #endregion

        #region PublicMethods
        public static List<TokenVaccine> GetTokenVaccines()
        {
            //SQL Statement
            string sqlStatement = "SELECT * FROM  [dbo].[TokenVaccine]";
            //Preparing SQL Command
            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = sqlStatement,
                CommandType = CommandType.Text,
            };
            //Execute Query
            List<TokenVaccine> result = BaseDataManager.GetSPItems<TokenVaccine>(sqlCommand, TokenVaccineMapper);
            return result;
        }

        public static int InsertTokenVaccine(TokenVaccine tokenVaccine)
        {
            if (tokenVaccine == null) return 0;

            string sqlStatement = "INSERT INTO  [dbo].[TokenVaccine] (VaccineId,MedicalRecordId,ShotDate,Note) " +
                                  "VALUES (@vaccineId,@medicalRecordId,@shotDate,@note)";


            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = sqlStatement,
                CommandType = CommandType.Text,
            };
            sqlCommand.Parameters.Add(new SqlParameter("@vaccineId", tokenVaccine.VaccineId));
            sqlCommand.Parameters.Add(new SqlParameter("@medicalRecordId", tokenVaccine.MedicalRecordId));
            sqlCommand.Parameters.Add(new SqlParameter("@shotDate", tokenVaccine.ShotDate));
            sqlCommand.Parameters.Add(new SqlParameter("@note", tokenVaccine.Note == null ? DBNull.Value : tokenVaccine.Note));

            int result = BaseDataManager.ExecuteNonQuery(sqlCommand);
            if (result == 1)
            {
                List<TokenVaccine> tokenVaccines = GetTokenVaccines();

                return tokenVaccines.Max(x => x.ID);

            }
            return 0;
        }

        public static int UpdateTokenVaccine(TokenVaccine tokenVaccine)
        {
            if (tokenVaccine == null) return 0;

            string sqlStatement = "UPDATE  [dbo].[TokenVaccine] SET " +
                                  "VaccineId=@vaccineId,MedicalRecordId=@medicalRecordId," +
                                  "ShotDate=@shotDate,Note=@note " +
                                  "WHERE ID=@id;";

            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = sqlStatement,
                CommandType = CommandType.Text,
            };
            sqlCommand.Parameters.Add(new SqlParameter("@id", tokenVaccine.ID));
            sqlCommand.Parameters.Add(new SqlParameter("@vaccineId", tokenVaccine.VaccineId));
            sqlCommand.Parameters.Add(new SqlParameter("@medicalRecordId", tokenVaccine.MedicalRecordId));
            sqlCommand.Parameters.Add(new SqlParameter("@shotDate", tokenVaccine.ShotDate));
            sqlCommand.Parameters.Add(new SqlParameter("@note", tokenVaccine.Note == null ? DBNull.Value : tokenVaccine.Note));

            int result = BaseDataManager.ExecuteNonQuery(sqlCommand);
            return result;
        }

        public static int DeleteTokenVaccine(TokenVaccine tokenVaccine)
        {
            if (tokenVaccine == null) return 0;

            string sqlStatement = "DELETE FROM [dbo].[TokenVaccine] WHERE ID=@id;";

            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = sqlStatement,
                CommandType = CommandType.Text,
            };
            sqlCommand.Parameters.Add(new SqlParameter("@id", tokenVaccine.ID));

            int result = BaseDataManager.ExecuteNonQuery(sqlCommand);
            return result;
        }

        #endregion
    }
}
