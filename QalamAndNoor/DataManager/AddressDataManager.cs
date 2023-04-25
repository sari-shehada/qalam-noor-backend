using QalamAndNoor.Models;
using System.Data;
using System.Data.SqlClient;

namespace QalamAndNoor.DataManager
{
    public abstract class AddressDataManager
    {
        #region AddressMapper
        private static Address AddressMapper(IDataReader dataReader)
        {
            Address tempAddress = new Address()
            {
                ID = Convert.ToInt32(dataReader["ID"].ToString()),
                Name = dataReader["Name"].ToString(),
                AreaId = Convert.ToInt32(dataReader["AreaId"].ToString()),
                Details = dataReader["Details"].ToString(),
            };
            return tempAddress;
        }
        #endregion
        #region PublicMethods
        public static List<Address> GetAddresses()
        {
            //SQL Statement
            string sqlStatement = "SELECT * FROM  [dbo].[Address]";
            //Preparing SQL Command
            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = sqlStatement,
                CommandType = CommandType.Text,
            };
            //Execute Query
            List<Address> result = BaseDataManager.GetSPItems<Address>(sqlCommand, AddressMapper);
            return result;
        }

        public static int InsertAddress(Address address)
        {
            if (address == null) return 0;

            string sqlStatement = "INSERT INTO  [dbo].[Address] (Name,AreaId,Details) " +
                                  "VALUES (@name,@areaId,@details)";


            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = sqlStatement,
                CommandType = CommandType.Text,
            };
            sqlCommand.Parameters.Add(new SqlParameter("@name", address.Name));
            sqlCommand.Parameters.Add(new SqlParameter("@areaId", address.AreaId));
            sqlCommand.Parameters.Add(new SqlParameter("@details", address.Details));

            int result = BaseDataManager.ExecuteNonQuery(sqlCommand);
            if (result == 1)
            {
                List<Address> addresses = GetAddresses();
                return addresses.Max(x => x.ID);

            }
            return 0;
        }

        public static int UpdateAddress(Address address)
        {

            if (address == null) return 0;
            //SQL Statement
            string sqlStatement = "UPDATE  [dbo].[Address] SET " +
                                  "Name=@name,AreaId=@areaId,Details=@details " +
                                  "WHERE ID=@id;";

            //Preparing SQL Command
            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = sqlStatement,
                CommandType = CommandType.Text,
            };
            sqlCommand.Parameters.Add(new SqlParameter("@id", address.ID));
            sqlCommand.Parameters.Add(new SqlParameter("@name", address.Name));
            sqlCommand.Parameters.Add(new SqlParameter("@areaId", address.AreaId));
            sqlCommand.Parameters.Add(new SqlParameter("@details", address.Details));

            //Execute Query
            int result = BaseDataManager.ExecuteNonQuery(sqlCommand);
            return result;
        }
        public static int DeleteAddress(Address address)
        {
            if (address == null) return 0;
            //SQL Statement
            string sqlStatement = "DELETE FROM [dbo].[Address] WHERE ID=@id;";

            //Preparing SQL Command
            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = sqlStatement,
                CommandType = CommandType.Text,
            };


            sqlCommand.Parameters.Add(new SqlParameter("@id", address.ID));
            int result = BaseDataManager.ExecuteNonQuery(sqlCommand);
            return result;
        }

        #endregion
    }
}
