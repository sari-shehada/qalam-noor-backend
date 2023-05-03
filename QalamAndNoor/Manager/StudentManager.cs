
using System;
using System.Collections.Generic;
using QalamAndNoor.DataManager;
using QalamAndNoor.Models;
using QalamAndNoor.Models.HelperModels;

namespace QalamAndNoor.Manager
{
    public abstract class StudentManager
    {
        public static List<Student> GetStudents()
        {
            return StudentDataManager.GetStudents().ToList();
        }
        public static int InsertStudent(Student student)
        {
            return StudentDataManager.InsertStudent(student);
        }
        public static int UpdateStudent(Student student)
        {
            return StudentDataManager.UpdateStudent(student);
        }
        public static int DeleteStudent(Student student)
        {
            return StudentDataManager.DeleteStudent(student);
        }
        public static Student GetStudentById(int id)
        {
            List<Student> students = GetStudents();
            foreach (Student student in students)
            {
                if (student.ID == id)
                {
                    return student;
                }

            }
            return null;
        }

        public static List<Student> GetStudentByName(string name)
        {
            List<Student> students = GetStudents();
            List<Student> result = new List<Student>();
            foreach (Student item in students)
            {
                if (item.FirstName.ToLower().Trim().Contains(name.ToLower().Trim()))
                {
                    result.Add(item);
                }
            }
            return result;
        }
        public static List<Student> GetStudentsByIsMale()
        {
            List<Student> students = GetStudents();
            List<Student> result = new List<Student>();
            foreach (Student item in students)
            {
                if (item.IsMale == true)
                {
                    result.Add(item);
                }
            }
            return result;
        }
        public static List<Student> GetStudentsByIsFemale()
        {
            List<Student> students = GetStudents();
            List<Student> result = new List<Student>();
            foreach (Student item in students)
            {
                if (item.IsMale == false)
                {
                    result.Add(item);
                }
            }
            return result;
        }

        public static List<Student> GetStudentsByFamilyId(int familyId)
        {
            List<Student> students = GetStudents();
            List<Student> result = new List<Student>();
            foreach (Student item in students)
            {
                if (item.FamilyId == familyId)
                {
                    result.Add(item);
                }
            }
            return result;
        }

        public static List<Student> GetStudentsByAddressId(int addressId)
        {
            List<Student> students = GetStudents();
            List<Student> result = new List<Student>();
            foreach (Student item in students)
            {
                if (item.AddressId == addressId)
                {
                    result.Add(item);
                }
            }
            return result;
        }
        public static object RegisterStudent(StudentRegistrationModel obj)
        {
            //TODO: Later Added ErrorCodes Into ENUM
            #region Family
            ItemOr familyAdditionResult;
            //New Family Addition
            if (obj.Family.ID == -1)
            {
                familyAdditionResult = _addNewFamily(mother: obj.Mother,
                     father: obj.Father,
                     responsiblePerson: obj.ResponsiblePerson);

                if (!familyAdditionResult.Success)
                {
                    return new
                    {
                        Success = false,
                        Message = "فشل تسجيل عائلة جديدة",
                    };
                }

                obj.Family = (familyAdditionResult.Item as Family)!;
            }

            //Existing Family
            obj.Student.FamilyId = obj.Family.ID;
            #endregion

            #region Student
            int studentId = InsertStudent(obj.Student);
            if (studentId == 0)
            {
                return new
                {
                    Success = false,
                    Message = "فشل تسجيل معلومات الطالب الشخصية",
                };
            }
            obj.Student.ID = studentId;
            #endregion

            #region MedicalInfo
            _bulkInsertMedicalInfo(studentId: obj.Student.ID,
                                    medicalRecord: obj.MedicalRecord,
                                    takenVaccines: obj.TakenVaccines,
                                    illnesses: obj.Illnesses);

            if (obj.StudentPreviousSchool != null)
            {
                obj.StudentPreviousSchool.StudentId = obj.Student.ID;
                StudentPreviousSchoolManager.InsertStudentPreviousSchool(obj.StudentPreviousSchool);
            }
            YearRecordManager.InsertYearRecord(yearRecord: new YearRecord()
            {
                ID = -1,
                StudentId = obj.Student.ID,
                ClassId = obj.EnrolledClass.ID,
                DidPass = false,
                ClassRoomSchoolYearId = -1,
            });
            #endregion

            return new
            {
                Success = true,
                Message = "تم تسجيل طالب جديد بنجاح",
            };
        }

        public static List<Student> GetStudentsBySchoolYearIdAndClassId(int schoolYearId, int classId)
        {
            List<YearRecord> yearRecords = YearRecordManager.GetYearRecordsBySchoolYearIdAndClassId(schoolYearId, classId);
            List<Student> students = GetStudents();
            List<Student> result = new List<Student>();
            foreach (var item in yearRecords)
            {
                result.Add(students.First((x) => x.ID == item.StudentId));
            }
            return result;
        }

        public static List<Student> GetStudentsBySchoolYearId(int schoolYearId)
        {
            List<YearRecord> yearRecords = YearRecordManager.GetYearRecordsBySchoolyearId(schoolYearId);
            List<Student> students = GetStudents();
            List<Student> result = new List<Student>();
            foreach (var item in yearRecords)
            {
                result.Add(students.First((x) => x.ID == item.StudentId));
            }
            return result;
        }











        #region Private Helper Methods
        private static ItemOr _addNewFamily(
            Mother mother, Father father,
            ResponsiblePerson? responsiblePerson)
        {

            int fatherID = FatherManager.InsertFather(father);
            int motherID = MotherManager.InsertMother(mother);
            int? responsiblePersonId = null;
            if (responsiblePerson != null)
            {
                responsiblePersonId = ResponsiblePersonManager.InsertResponsiblePerson(responsiblePerson);
            }
            var dummyUsernameAndPassword = _getDummyUsernameAndPassword();
            var family = new Family()
            {
                ID = -1,
                FatherId = fatherID,
                MotherId = motherID,
                ResponsiblePersonId = responsiblePersonId,
                UserName = dummyUsernameAndPassword[0],
                Password = dummyUsernameAndPassword[1],
            };

            var familyId = FamilyManager.InsertFamily(family);

            family.ID = familyId;
            return new ItemOr()
            {
                Item = family,
                Success = fatherID != 0 && motherID != 0 && familyId != 0 &&
                          (responsiblePersonId == null || responsiblePersonId != 0)
            };
        }

        private static ItemOr _bulkInsertMedicalInfo(int studentId, MedicalRecord medicalRecord, List<Ilness> illnesses, List<TokenVaccine> takenVaccines)
        {
            medicalRecord.StudentId = studentId;
            MedicalRecordManager.InsertMedicalRecord(medicalRecord);
            foreach (Ilness illness in illnesses)
            {
                IlnessMedicalRecordManager.InsertIlnessMedicalRecords(new IlnessMedicalRecord()
                {
                    ID = -1,
                    IlnessId = illness.ID,
                    MedicalRecordId = medicalRecord.StudentId,
                });
            }
            foreach (TokenVaccine takenVaccine in takenVaccines)
            {
                takenVaccine.MedicalRecordId = medicalRecord.StudentId;
                TokenVaccineManager.InsertTokenVaccine(takenVaccine);
            }

            return new ItemOr
            {
                Item = medicalRecord,
                Success = true
            };
        }

        static string[] _getDummyUsernameAndPassword() => new string[]
        {
            "Family-"+Guid.NewGuid().ToString().Substring(0,4),
            "Password"+new Random().NextInt64(1000000,9999999),
        };
        #endregion

    }
}
