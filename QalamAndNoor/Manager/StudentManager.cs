
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using QalamAndNoor.DataManager;
using QalamAndNoor.DataManager.Helper;
using QalamAndNoor.Models;
using QalamAndNoor.Models.HelperModels;
using QalamAndNoor.Models.HelperModels.DbHelper;
using QalamAndNoor.Shared;

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
        public static Student? GetStudentById(int id)
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
                Status = 0,
                ClassRoomSchoolYearId = -1,
            });
            #endregion

            return new
            {
                Success = true,
                Message = "تم تسجيل طالب جديد بنجاح",
            };
        }
        public static List<Student> GetStudentsWhoDontHavePsychologicalStatus()
        {
            return StudentDataManager.GetStudentsWhoDontHavePsychologicalStatus();
        }
        public static List<Student> GetIsActiveStudent()
        {
            List<Student> students = GetStudents();
            List<Student> result = new List<Student>();
            foreach (Student student in students)
            {
                if (student.IsActive == true)
                {
                    result.Add(student);
                }
            }
            return result;
        }
        public static List<Student> GetStudentsByPsychologicalStatusId(int psychologicalStatusId)
        {
            List<MedicalRecord> medicalRecords = MedicalRecordManager.GetMedicalRecordsByPsychologicalStatusId(psychologicalStatusId);
            List<Student> students = GetIsActiveStudent();
            List<Student> result = new List<Student>();
            foreach (var item in medicalRecords)
            {
                result.Add(students.First((x) => x.ID == item.StudentId));
            }
            return result;
        }
        public static List<Student> GetSuccessfulStudentsByClassId(int classId)
        {
            List<StudentIdYearRecord> studentIdYearRecords = StudentIdYearRecordDataManager.GetSuccessfulStudentIdsByClassId(classId);
            List<Student> students = GetIsActiveStudent();
            List<Student> result = new List<Student>();
            foreach (var item in studentIdYearRecords)
            {
                result.Add(students.First((x) => x.ID == item.StudentId));
            }
            return result;
        }
        public static List<Student> GetFailingStudentsByClassId(int classId)
        {
            List<StudentIdYearRecord> studentIdYearRecords = StudentIdYearRecordDataManager.GetFailingStudentIdsByClassId(classId);
            List<Student> students = GetIsActiveStudent();
            List<Student> result = new List<Student>();
            foreach (var item in studentIdYearRecords)
            {
                result.Add(students.First((x) => x.ID == item.StudentId));
            }
            return result;
        }
        public static List<NewStudentSchoolYear> GetNewStudentsByClassId(int classId)
        {
            List<YearRecord> yearRecords = YearRecordManager.GetNewYearRecordsBYClassID(classId);
            List<Student> students = GetIsActiveStudent();
            List<NewStudentSchoolYear> result = new List<NewStudentSchoolYear>();
            foreach (var item in yearRecords)
            {
                result.Add(new NewStudentSchoolYear()
                {
                    YearRecord = item,
                    Student = students.First((x) => x.ID == item.StudentId)
                });
            }
            return result;
        }
        public static List<Student> GetStudentsInCurrentSchoolYear()


        {
            List<YearRecord> yearRecords = YearRecordManager.GetYearRecordsinCurrentSchoolYear();
            List<Student> students = GetStudents();
            List<Student> result = new List<Student>();
            foreach (var item in yearRecords)
            {
                result.Add(students.First((x) => x.ID == item.StudentId));
            }
            return result;
        }
        public static List<Student> GetActiceStudentsInSchoolYearByClassRoomId(int classRoomId)
        {
            int schoolYearId = SchoolYearManager.GetCurrentSchoolYear().ID;
            List<YearRecord> yearRecords = YearRecordManager.
                GetYearRecordsByClassRoomIdAndSchoolYearId(classRoomId, schoolYearId);
            List<Student> students = GetIsActiveStudent();
            List<Student> result = new List<Student>();
            foreach (var item in yearRecords)
            {
                result.Add(students.First((x) => x.ID == item.StudentId));
            }
            return result;
        }
        public static object RegistrationNewStudentInSchoolYear(NewStudentRegistrationInSchoolYear newStudentRegistrationInSchoolYear)
        {
            int currentSchoolYearId = SchoolYearManager.GetCurrentSchoolYear().ID;
            List<YearRecord> yearRecords = new List<YearRecord>();
            List<int> semesterIds = new List<int>();
            try
            {
                ClassRoomSchoolYear classRoomSchoolYear = ClassRoomSchoolYearManager.GetClassRoomSchoolYearByClassRoomIdAndSchoolYearId(newStudentRegistrationInSchoolYear.ClassRoomId, currentSchoolYearId);
                if (classRoomSchoolYear == null)
                {
                    return new
                    {
                        message = "هذه الشعبة غير متاحة في هذا العام الدراسي",
                        success = false,
                    };
                }
                foreach (var item in newStudentRegistrationInSchoolYear.YearRecordId)
                {
                    YearRecordManager.UpdateYearRecord(new YearRecord()
                    {
                        ID = item,
                        ClassRoomSchoolYearId = classRoomSchoolYear.ID,
                        ClassId = YearRecordManager.GetYearRecordById(item).ClassId,
                        StudentId = YearRecordManager.GetYearRecordById(item).StudentId,
                        Status = StudentStatusEnum.NotDefined

                    });
                    yearRecords.Add(YearRecordManager.GetYearRecordById(item));
                    semesterIds.Add(SemesterYearRecordManager.InsertSemsterYearRecord(new SemesterYearRecord()
                    {
                        ID = -1,
                        SemesterId = newStudentRegistrationInSchoolYear.SemesterId,
                        YearRecordId = item
                    })
                    );



                }
                return new
                {
                    message = "تمت عملية تسجيل الطلاب بنجاح",
                    success = true,
                };
            }
            catch (Exception)
            {
                RollBackOnRegistrationNewStudentInSchoolYear(semesterIds, yearRecords);
                return new
                {
                    message = "فشلت عملية تسجيل الطلاب ",
                    success = false,
                };
            }
        }
        public static object RegistrationOldStudentInSchoolYear(OldStudentRegistration oldStudentRegistration)
        {
            List<int> semesterYearRecordIds = new List<int>();
            List<int> yearRecordIds = new List<int>();
            try
            {
                int currentSchoolYearId = SchoolYearManager.GetCurrentSchoolYear().ID;

                ClassRoomSchoolYear classRoomSchoolYear = ClassRoomSchoolYearManager.GetClassRoomSchoolYearByClassRoomIdAndSchoolYearId(oldStudentRegistration.ClassRoomId, currentSchoolYearId);
                if (classRoomSchoolYear == null)
                {
                    return new
                    {
                        message = "هذه الشعبة غير متاحة في هذا العام الدراسي",
                        success = false,
                    };
                }

                foreach (var item in oldStudentRegistration.StudentIds)
                {
                    int yearRecordId = YearRecordManager.InsertYearRecord(new YearRecord
                    {

                        ClassId = oldStudentRegistration.ClassId,
                        ClassRoomSchoolYearId = classRoomSchoolYear.ID,
                        StudentId = item,
                        Status = StudentStatusEnum.NotDefined
                    });
                    int semesterYearRecordId = SemesterYearRecordManager.InsertSemsterYearRecord(new SemesterYearRecord
                    {
                        YearRecordId = yearRecordId,
                        SemesterId = oldStudentRegistration.SemesterId
                    });
                    yearRecordIds.Add(yearRecordId);
                    semesterYearRecordIds.Add(semesterYearRecordId);
                }

                return new
                {
                    message = "تمت عملية تسجيل الطلاب بنجاح",
                    success = true,
                };
            }
            catch (Exception)
            {

                RollBackOnRegistrationOldStudentInSchoolYear(semesterYearRecordIds, yearRecordIds);
                return new
                {
                    message = "فشلت عملية تسجيل الطلاب ",
                    success = false,
                };
            }


        }
        private static bool RollBackOnRegistrationNewStudentInSchoolYear
            (List<int> semsterYearRecordIds, List<YearRecord> yearRecords)
        {

            try
            {
                if (semsterYearRecordIds.Count == 0 && yearRecords.Count == 0) return true;
                foreach (int item in semsterYearRecordIds)
                {
                    SemesterYearRecordManager.DeleteSemesterYearRecord
                        (SemesterYearRecordManager.GetSemesterYearById(item));
                }
                foreach (YearRecord item in yearRecords)
                {
                    item.ClassRoomSchoolYearId = null;
                    item.Status = StudentStatusEnum.New;
                    YearRecordManager.UpdateYearRecord(item);
                }
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return false;
            }

        }
        private static bool RollBackOnRegistrationOldStudentInSchoolYear
          (List<int> semsterYearRecordIds, List<int> yearRecordIds)
        {

            try
            {
                if (semsterYearRecordIds.Count == 0 && yearRecordIds.Count == 0) return true;
                foreach (int item in semsterYearRecordIds)
                {
                    SemesterYearRecordManager.DeleteSemesterYearRecord
                        (SemesterYearRecordManager.GetSemesterYearById(item));
                }
                foreach (int item in yearRecordIds)
                {
                    YearRecordManager.DeleteYearRecord(YearRecordManager.GetYearRecordById(item));
                }
                return true;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return false;
            }

        }
        public static List<StudentExamMark> GetStudentExamMarks(int courseId, int examId, int classRoomId)
        {

            List<StudentExamMark> result = new List<StudentExamMark>();
            int schoolYearId = SchoolYearManager.GetCurrentSchoolYear().ID;
            List<YearRecord> yearRecords = YearRecordManager.
                GetYearRecordsByClassRoomIdAndSchoolYearId(classRoomId, schoolYearId);
            foreach (var item in yearRecords)
            {
                result.Add(new StudentExamMark
                {
                    Student = GetStudentById(item.StudentId),
                    YearRecord = item,
                    SemesterExam = SemesterExamManager.GetSemesterExamByExamIdAndCourseIdAndSemesterYearRecordId
                    (examId, SemesterYearRecordManager.GetSemesterYearRecordByYearRecordIdInCurrentSemester(item.ID).ID, courseId),
                    Father = FatherManager.GetFatherByStudentId(item.StudentId)
                }
                );
            }
            return result;
        }
        public static object InsertStudentsMark(StudentExamMarkInsertion studentExamMarkInsertion)
        {
            ItemOr itemOr = new ItemOr();
            Debug.WriteLine(studentExamMarkInsertion.StudentMark);
            foreach (int item in studentExamMarkInsertion.StudentMark.Keys)
            {
                int res = SemesterExamManager.InsertSemesterExam(new SemesterExam
                {
                    ID = -1,
                    CourseId = studentExamMarkInsertion.CourseId,
                    ExamId = studentExamMarkInsertion.ExamId,
                    SemesterYearecordId = SemesterYearRecordManager.GetSemesterYearRecordByYearRecordIdInCurrentSemester(item).ID,
                    ObtainedGrade = studentExamMarkInsertion.StudentMark[item]
                });
                if (res == 0)
                {
                    return new
                    {
                        Message = "فشلت عملية ادخال العلامات",
                        Success = false
                    };
                }
            }
            return new
            {
                Message = "تمت عملية ادخال العلامات بنجاح",
                Success = true
            };


        }
        public static StudentProfileDto? GetStudentProfileByStudentId(int studentId)
        {
            Student? student = GetStudentById(studentId);
            if (student is null)
            {
                return null;
            }
            
            List<Student> sibling = GetStudentsByFamilyId(student.FamilyId);
            sibling = sibling.Where(x => x.ID != student.ID).ToList();
            StudentProfileDto studentProfile = new StudentProfileDto
            {
                Student = GetStudentById(student.ID),
                Father = FatherManager.GetFatherByStudentId(student.ID),
                Mother = MotherManager.GetMotherByStudentId(student.ID),
                ResponsiblePerson = ResponsiblePersonManager.GetResponsiblePersonByStudentId(student.ID),
                Address = AddressManager.GetAddressByStudentId(student.ID),
                Area = AreaManager.GetAreaByStudentId(student.ID),
                City = CityManager.GetCityByStudentId(student.ID),
                Sibling =sibling,
                PreviousSchools = PreviousSchoolManager.GetPreviousSchoolsByStudentId(student.ID),
                Vaccines = StudentTakenVaccineDataManager.GetStudentTakenVaccinesByStudentId(student.ID),
                Illnesses = StudentIllnessesDataManager.GetStudentIllnessesByStudentId(student.ID),
                PsychologicalStatuses = StudentPsychologicalStatusInfoDataManager.GetStudentStudentPsychologicalStatusInfoByStudentId(student.ID),
                StudentSchoolYears = SchoolYearManager.GetSchoolYearsByStudentId(student.ID),
                CurrentClass=ClassManager.GetCurrentClassInCurrentSchoolYearByStudentId(student.ID),
                CurrentClaasRoom=ClassRoomManager.GetCurrentClassRoomInCurrentSchoolYearByStudentId(student.ID)
            };
            return studentProfile;

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










