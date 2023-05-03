using QalamAndNoor.Models;
using System.Data.SqlClient;
using System.Data;

namespace QalamAndNoor.DataManager
{
    public abstract class EmployeeDataManager
    {
        #region Mappers
        private static Employee EmployeeMapper(IDataReader dataReader)
        {
            Employee tempEmployee = new Employee()
            {
                ID = Convert.ToInt32(dataReader["ID"].ToString()),
                FirstName = dataReader["FirstName"].ToString(),
                LastName = dataReader["LastName"].ToString(),
                FatherName = dataReader["FatherName"].ToString(),
                MotherName = dataReader["MotherName"].ToString(),
                DateOfBirth = Convert.ToDateTime(dataReader["DateOfBirth"].ToString()),
                PlaceOfBirth = dataReader["PlaceOfBirth"].ToString(),
                StartDate = Convert.ToDateTime(dataReader["StartDate"].ToString()),
                NumberOfChildren = dataReader["NumberOfChildren"].ToString().Trim() == string.Empty ? null : Convert.ToInt32(dataReader["NumberOfChildren"].ToString()),
                AddressId = Convert.ToInt32(dataReader["AddressId"].ToString()),
                JobTitleId = Convert.ToInt32(dataReader["JoinDateId"].ToString()),
                IsMale = Convert.ToBoolean(dataReader["IsMale"].ToString()),
                UserName = dataReader["UserName"].ToString(),
                Password = dataReader["Password"].ToString(),
            };
            return tempEmployee;
        }
        #endregion

        #region PublicMethod

        public static List<Employee> GetEmployees()
        {
            //SQL Statement
            string sqlStatement = "SELECT * FROM  [dbo].[Employee]";
            //Preparing SQL Command
            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = sqlStatement,
                CommandType = CommandType.Text,
            };
            //Execute Query
            List<Employee> result = BaseDataManager.GetSPItems<Employee>(sqlCommand, EmployeeMapper);
            return result;
        }

        public static int InsertEmployee(Employee employee)
        {
            if (employee == null) return 0;

            string sqlStatement = "INSERT INTO  [dbo].[Employee](FirstName,LastName,FatherName,MotherName,DateOfBirth,PlaceOfBirth," +
                                  "StartDate,NumberOfChildren,AddressId,JoinDateId,IsMale,UserName,Password) " +
                                  "VALUES (@firstName,@lastName,@fatherName,@motherName,@dateOfBirth,@placeOfBirth,@startDate," +
                                  "@numberOfChildren,@addressId,@jobTitleId,@isMale,@userName,@password)";


            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = sqlStatement,
                CommandType = CommandType.Text,
            };
            sqlCommand.Parameters.Add(new SqlParameter("@firstName", employee.FirstName));
            sqlCommand.Parameters.Add(new SqlParameter("@lastName", employee.LastName));
            sqlCommand.Parameters.Add(new SqlParameter("@fatherName", employee.FatherName));
            sqlCommand.Parameters.Add(new SqlParameter("@motherName", employee.MotherName));
            sqlCommand.Parameters.Add(new SqlParameter("@dateOfBirth", employee.DateOfBirth));
            sqlCommand.Parameters.Add(new SqlParameter("@placeOfBirth", employee.PlaceOfBirth));
            sqlCommand.Parameters.Add(new SqlParameter("@startDate", employee.StartDate));
            sqlCommand.Parameters.Add(new SqlParameter("@numberOfChildren", employee.NumberOfChildren == null ? DBNull.Value :employee.NumberOfChildren));
            sqlCommand.Parameters.Add(new SqlParameter("@addressId", employee.AddressId));
            sqlCommand.Parameters.Add(new SqlParameter("@jobTitleId", employee.JobTitleId));
            sqlCommand.Parameters.Add(new SqlParameter("@isMale", employee.IsMale ? "1" : "0"));
            sqlCommand.Parameters.Add(new SqlParameter("@userName", employee.UserName));
            sqlCommand.Parameters.Add(new SqlParameter("@password", employee.Password));


            int result = BaseDataManager.ExecuteNonQuery(sqlCommand);
            if (result==1)

            {
                List<Employee> employees = GetEmployees();
                return employees.Max(x => x.ID);
            }
            return 0;
        }
        public static int UpdateEmployee(Employee employee)
        {
            if (employee == null) return 0;

            string sqlStatement = "UPDATE[dbo].[Employee] SET " +
                                  "FirstName=@firstName,LastName=@lastName,FatherName=@fatherName," +
                                  "MotherName=@motherName,DateOfBirth=@dateOfBirth,PlaceOfBirth=@placeOfBirth," +
                                  "StartDate=@startDate,NumberOfChildren=@numberOfChildren,AddressId=@addressId," +
                                  "JoinDateId=@jobTitleId,IsMale=@isMale,UserName=@userName,Password=@password " +
                                  "WHERE ID=@id;";


            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = sqlStatement,
                CommandType = CommandType.Text,
            };
            sqlCommand.Parameters.Add(new SqlParameter("@id", employee.ID));
            sqlCommand.Parameters.Add(new SqlParameter("@firstName", employee.FirstName));
            sqlCommand.Parameters.Add(new SqlParameter("@lastName", employee.LastName));
            sqlCommand.Parameters.Add(new SqlParameter("@fatherName", employee.FatherName));
            sqlCommand.Parameters.Add(new SqlParameter("@motherName", employee.MotherName));
            sqlCommand.Parameters.Add(new SqlParameter("@dateOfBirth", employee.DateOfBirth));
            sqlCommand.Parameters.Add(new SqlParameter("@placeOfBirth", employee.PlaceOfBirth));
            sqlCommand.Parameters.Add(new SqlParameter("@startDate", employee.StartDate));
            sqlCommand.Parameters.Add(new SqlParameter("@numberOfChildren", employee.NumberOfChildren == null ? DBNull.Value : employee.NumberOfChildren));
            sqlCommand.Parameters.Add(new SqlParameter("@addressId", employee.AddressId));
            sqlCommand.Parameters.Add(new SqlParameter("@jobTitleId", employee.JobTitleId));
            sqlCommand.Parameters.Add(new SqlParameter("@isMale", employee.IsMale ? "1" : "0"));
            sqlCommand.Parameters.Add(new SqlParameter("@userName", employee.UserName));
            sqlCommand.Parameters.Add(new SqlParameter("@password", employee.Password));


            int result = BaseDataManager.ExecuteNonQuery(sqlCommand);
            return result;
        }
        public static int DeleteEmployee(Employee employee)
        {
            if (employee == null) return 0;

            string sqlStatement = "DELETE FROM [dbo].[Employee] WHERE ID=@id;";


            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = sqlStatement,
                CommandType = CommandType.Text,
            };
            sqlCommand.Parameters.Add(new SqlParameter("@id", employee.ID));


            int result = BaseDataManager.ExecuteNonQuery(sqlCommand);
            return result;
        }


        #endregion
    }
}
