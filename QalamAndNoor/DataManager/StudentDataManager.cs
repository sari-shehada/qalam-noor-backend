using QalamAndNoor.Models;
using QalamAndNoor.Shared;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;

namespace QalamAndNoor.DataManager
{
    public abstract class StudentDataManager
    {
        #region Mappers
        private static Student StudentMapper(IDataReader dataReader)
        {

            Student tempStudent = new Student()
            {
                ID = Convert.ToInt32(dataReader["ID"].ToString()),
                FirstName = dataReader["FirstName"].ToString(),
                IsMale = Convert.ToBoolean(dataReader["IsMale"].ToString()),
                DateOfBirth = Convert.ToDateTime(dataReader["DateOfBirth"].ToString()),
                PlaceOfBirth = dataReader["PlaceOfBirth"].ToString(),
                Religion = (ReligionEnum)Convert.ToInt32(dataReader["Religion"].ToString()),
                IncidentNumber = dataReader["IncidentNumber"].ToString(),
                IncidentDate = dataReader["IncidentDate"].ToString(),
                PublicRecordId = Convert.ToInt32(dataReader["PublicRecordId"].ToString()),
                PhoneNumber = dataReader["PhoneNumber"].ToString(),
                WhatsappPhoneNumber = dataReader["WhatsappPhoneNumber"].ToString(),
                LandLine = dataReader["LandLine"].ToString(),
                JoinDate = Convert.ToDateTime(dataReader["JoinDate"].ToString()),
                LeaveDate = dataReader["LeaveDate"].ToString().Trim() == string.Empty ? null : Convert.ToDateTime(dataReader["LeaveDate"].ToString()),
                AddressId = Convert.ToInt32(dataReader["AddressId"].ToString()),
                FamilyId = Convert.ToInt32(dataReader["FamilyId"].ToString()),
                IsActive= dataReader["IsActive"].ToString().Trim() == string.Empty ? null : Convert.ToBoolean(dataReader["IsActive"].ToString()),
            };
            return tempStudent;
        }
        #endregion

        #region PublicMethods
        public static List<Student> GetStudents()
        {
            //SQL Statement
            string sqlStatement = "SELECT * FROM  [dbo].[Student]";
            //Preparing SQL Command
            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = sqlStatement,
                CommandType = CommandType.Text,
            };
            //Execute Query
            List<Student> result = BaseDataManager.GetSPItems<Student>(sqlCommand, StudentMapper);
            return result;
        }
        public static int InsertStudent(Student student)
        {
            if (student == null) return 0;
            Debug.WriteLine(student.LeaveDate == null);
            string sqlStatement = "INSERT INTO  [dbo].[Student] (FirstName,IsMale,DateOfBirth," +
                                  "PlaceOfBirth,Religion,IncidentNumber,IncidentDate," +
                                  "PublicRecordId,PhoneNumber,WhatsappPhoneNumber,LandLine," +
                                  "JoinDate,LeaveDate,AddressId,FamilyId,IsActive) " +
                                  "VALUES (@firstName,@isMale,@dateOfBirth," +
                                  "@placeOfBirth,@religion,@incidentNumber,@incidentDate," +
                                  "@publicRecordId,@phoneNumber,@whatsappPhoneNumber,@landLine," +
                                  "@joinDate,@leaveDate,@addressId,@familyId,@isActive)";


            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = sqlStatement,
                CommandType = CommandType.Text,
            };
            sqlCommand.Parameters.Add(new SqlParameter("@firstName", student.FirstName));
            sqlCommand.Parameters.Add(new SqlParameter("@isMale", student.IsMale ? "1" : "0"));
            sqlCommand.Parameters.Add(new SqlParameter("@dateOfBirth", student.DateOfBirth));
            sqlCommand.Parameters.Add(new SqlParameter("@placeOfBirth", student.PlaceOfBirth));
            sqlCommand.Parameters.Add(new SqlParameter("@religion", (int)student.Religion));
            sqlCommand.Parameters.Add(new SqlParameter("@incidentNumber", student.IncidentNumber));
            sqlCommand.Parameters.Add(new SqlParameter("@incidentDate", student.IncidentDate));
            sqlCommand.Parameters.Add(new SqlParameter("@publicRecordId", student.PublicRecordId));
            sqlCommand.Parameters.Add(new SqlParameter("@phoneNumber", student.PhoneNumber));
            sqlCommand.Parameters.Add(new SqlParameter("@whatsappPhoneNumber", student.WhatsappPhoneNumber));
            sqlCommand.Parameters.Add(new SqlParameter("@landLine", student.LandLine));
            sqlCommand.Parameters.Add(new SqlParameter("@joinDate", student.JoinDate));
            sqlCommand.Parameters.Add(new SqlParameter("@leaveDate", student.LeaveDate == null ? DBNull.Value : student.LeaveDate));
            sqlCommand.Parameters.Add(new SqlParameter("@addressId", student.AddressId));
            sqlCommand.Parameters.Add(new SqlParameter("@familyId", student.FamilyId));
            sqlCommand.Parameters.Add(new SqlParameter("@isActive", student.IsActive == null ? DBNull.Value : student.IsActive ));
            int result = BaseDataManager.ExecuteNonQuery(sqlCommand);
            if (result == 1)
            {
                List<Student> students = GetStudents();
                return students.Max(x => x.ID);

            }
            return 0;
        }
        public static int UpdateStudent(Student student)
        {
            if (student == null) return 0;

            string sqlStatement = "UPDATE  [dbo].[Student] SET " +
                                  "FirstName=@firstName,IsMale=@isMale,DateOfBirth=@dateOfBirth,PlaceOfBirth=@placeOfBirth," +
                                  "Religion=@religion,IncidentNumber=@incidentNumber,IncidentDate=@incidentDate," +
                                  "PublicRecordId=@publicRecordId,PhoneNumber=@phoneNumber,WhatsappPhoneNumber=@whatsappPhoneNumber,LandLine=@landLine," +
                                  "JoinDate=@joinDate,LeaveDate=@leaveDate,AddressId=@addressId," +
                                  "FamilyId=@familyId,IsActive=@isActive " +
                                  "WHERE ID=@id;";

            //                      "JoinDate,LeaveDate,AddressId,MedicalRecordId,FamilyId) " +


            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = sqlStatement,
                CommandType = CommandType.Text,
            };
            sqlCommand.Parameters.Add(new SqlParameter("@id", student.ID));
            sqlCommand.Parameters.Add(new SqlParameter("@firstName", student.FirstName));
            sqlCommand.Parameters.Add(new SqlParameter("@isMale", student.IsMale ? "1" : "0"));
            sqlCommand.Parameters.Add(new SqlParameter("@dateOfBirth", student.DateOfBirth));
            sqlCommand.Parameters.Add(new SqlParameter("@placeOfBirth", student.PlaceOfBirth));
            sqlCommand.Parameters.Add(new SqlParameter("@religion", (int)student.Religion));
            sqlCommand.Parameters.Add(new SqlParameter("@incidentNumber", student.IncidentNumber));
            sqlCommand.Parameters.Add(new SqlParameter("@incidentDate", student.IncidentDate));
            sqlCommand.Parameters.Add(new SqlParameter("@publicRecordId", student.PublicRecordId));
            sqlCommand.Parameters.Add(new SqlParameter("@phoneNumber", student.PhoneNumber));
            sqlCommand.Parameters.Add(new SqlParameter("@whatsappPhoneNumber", student.WhatsappPhoneNumber));
            sqlCommand.Parameters.Add(new SqlParameter("@landLine", student.LandLine));
            sqlCommand.Parameters.Add(new SqlParameter("@joinDate", student.JoinDate));
            sqlCommand.Parameters.Add(new SqlParameter("@leaveDate", student.LeaveDate == null ? DBNull.Value : student.LeaveDate));
            sqlCommand.Parameters.Add(new SqlParameter("@addressId", student.AddressId));
            sqlCommand.Parameters.Add(new SqlParameter("@familyId", student.FamilyId));
            sqlCommand.Parameters.Add(new SqlParameter("@isActive", student.IsActive == null ? DBNull.Value : student.IsActive));


            int result = BaseDataManager.ExecuteNonQuery(sqlCommand);
            return result;
        }
        public static int DeleteStudent(Student student)
        {
            if (student == null) return 0;

            string sqlStatement = "DELETE FROM [dbo].[Student] WHERE ID=@id;";



            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = sqlStatement,
                CommandType = CommandType.Text,
            };
            sqlCommand.Parameters.Add(new SqlParameter("@id", student.ID));

            int result = BaseDataManager.ExecuteNonQuery(sqlCommand);
            return result;
        }
        public static List<Student> GetStudentsWhoDontHavePsychologicalStatus()
        {
            //SQL Statement
            string sqlStatement =
                "SELECT *  from Student  where Student.IsActive=1 AND Student.ID not in (SELECT distinct(MedicalRecordId) from PsychologicalStatusMedicalRecord)";
            //Preparing SQL Command
            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = sqlStatement,
                CommandType = CommandType.Text,
            };
            //Execute Query
            List<Student> result = BaseDataManager.GetSPItems<Student>(sqlCommand, StudentMapper);
            return result;
            #endregion
        }

        public static int UpdateIsActiveStudent()
        {
          

            string sqlStatement = "UPDATE [dbo].[Student] SET IsActive=1 ;";



            SqlCommand sqlCommand = new SqlCommand()
            {
                CommandText = sqlStatement,
                CommandType = CommandType.Text,
            };

            int result = BaseDataManager.ExecuteNonQuery(sqlCommand);
            return result;
        }

    }
}
