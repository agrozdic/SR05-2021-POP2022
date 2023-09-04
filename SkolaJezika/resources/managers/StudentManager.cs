using SkolaJezika.resources.models;
using SkolaJezika.utilities.exceptions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkolaJezika.resources.managers
{
    class StudentManager
    {
        private static StudentManager instance;
        private ObservableCollection<Student> allStudents = new ObservableCollection<Student>();


        public ObservableCollection<Student> AllStudents { get => allStudents; set => allStudents = value; }

        private StudentManager() { }

        public static StudentManager GetInstance()
        {
            if (instance == null) instance = new StudentManager();
            return instance;
        }

        public Student GetStudentByIdentityNumber(string number)
        {
            Student student = allStudents.ToList().Find(x => x.PersonalIdentityNumber == number);

            if (student == null)
            {
                throw new UserNotFoundException("Student ne postoji.");
            }

            return student;

        }
    }
}
