using QalamAndNoor.Models;
using System.Data.SqlClient;
using System.Data;

namespace QalamAndNoor.DataManager
{
    public abstract class VccineDataManager
    {
        #region Mappers
        private static Vaccine VaccineMapper(IDataReader dataReader)
        {
            Vaccine tempVaccine = new Vaccine()
            {
                ID = Convert.ToInt32(dataReader["ID"].ToString()),
                Name = dataReader["Name"].ToString(),
            };
            return tempVaccine;
        }
        #endregion
        // #region Public Methods
        #region PublicMethods
        public static List<Vaccine> GetVaccines()
        {
            //SQL Statement
            string sqlStatement = "SELECT * FROM  [dbo].[Vaccine]";
            //Preparing SQL Command
            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = sqlStatement,
                CommandType = CommandType.Text,
            };
            //Execute Query
            List<Vaccine> result = BaseDataManager.GetSPItems<Vaccine>(sqlCommand, VaccineMapper);
            return result;
        }
        public static int InsertVaccine(Vaccine vaccine)
        {
            if (vaccine == null) return 0;

            string sqlStatement = "INSERT INTO  [dbo].[Vaccine] (Name) " +
                                  "VALUES (@name)";


            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = sqlStatement,
                CommandType = CommandType.Text,
            };
            sqlCommand.Parameters.Add(new SqlParameter("@name", vaccine.Name));

            int result = BaseDataManager.ExecuteNonQuery(sqlCommand);
            if (result == 1)
            {
                List<Vaccine> vaccines = GetVaccines();
                return vaccines.Max(x => x.ID);

            }
            return 0;
        }
        public static int UpdateVaccine(Vaccine vaccine)
        {
            if (vaccine == null) return 0;

            string sqlStatement = "UPDATE  [dbo].[Vaccine] SET " +
                                  "Name=@name " +
                                  "WHERE ID=@id;";

            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = sqlStatement,
                CommandType = CommandType.Text,
            };
            sqlCommand.Parameters.Add(new SqlParameter("@id", vaccine.ID));
            sqlCommand.Parameters.Add(new SqlParameter("@name", vaccine.Name));

            int result = BaseDataManager.ExecuteNonQuery(sqlCommand);
            return result;
        }
        public static int DeleteVaccine(Vaccine vaccine)
        {
            if (vaccine == null) return 0;

            string sqlStatement = "DELETE FROM [dbo].[Vaccine] WHERE ID=@id;";

            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = sqlStatement,
                CommandType = CommandType.Text,
            };
            sqlCommand.Parameters.Add(new SqlParameter("@id", vaccine.ID));

            int result = BaseDataManager.ExecuteNonQuery(sqlCommand);
            return result;
        }


        #endregion
    }
}
