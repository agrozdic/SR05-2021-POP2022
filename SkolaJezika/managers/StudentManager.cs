using SR05-2021-POP2022.models;
using SR05-2021-POP2022.exceptions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SR05-2021-POP2022.managers
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

        public Student GetStudentByJMBG(string jmbg)
        {
            Student student = allStudents.ToList().Find(x => x.jmbg == jmbg);

            if (student == null)
            {
                throw new UserNotFoundException("Student nije pronadjen.");
            }

            return student;

        }
    }
}
