using SkolaJezika.resources.managers;
using SkolaJezika.utilities.file_related_utilities.file_formatters;
using SkolaJezika.resources.enums;
using SkolaJezika.resources.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkolaJezika.utilities.file_related_utilities
{
    class FileStudentFormatter
    {

        public static Student CreateStudentFromFile(string[] splittedLine)
        {
            Student student = new Student();
            student.PersonalIdentityNumber = splittedLine[0];
            student.FirstName = splittedLine[1];
            student.LastName = splittedLine[2];
            student.Email = splittedLine[3];
            student.Password = splittedLine[4];
            student.UserType = (EUserType)int.Parse(splittedLine[5]);
            student.Gender = (EGender)int.Parse(splittedLine[6]);
            student.Address = AddressManager.GetInstance().GetAddressById(int.Parse(splittedLine[7]));
            student.ReservedSessions = new List<Session>();
            student.Active = bool.Parse(splittedLine[9]);
            return student;
        }

        public static string CreateStringFormatForFile(Student student)
        {
            return String.Format("{0}|{1}|{2}|{3}|{4}|{5}|{6}|{7}|{8}|{9}", student.PersonalIdentityNumber, student.FirstName, student.LastName, student.Email, student.Password, (int)student.UserType, (int)student.Gender, student.Address.Id, FileSessionFormatter.CreateStringRepresentationOfSessionIDs(student.ReservedSessions), student.Active);
        }

        public static void InitializeSessionsToStudent(string[] splittedLine, string studentID)
        {

        }
    }
}
