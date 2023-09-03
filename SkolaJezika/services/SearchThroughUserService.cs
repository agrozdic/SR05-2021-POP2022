using SkolaJezika.models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkolaJezika.services
{
    class SearchThroughUserService
    {
        
        private StudentService studentService;
        private ObservableCollection<Student> students;
        
        public SearchUserService()
        {
            studentService = new StudentService();
            students = new ObservableCollection<Student>();
        }

        public ObservableCollection<Student> SearchStudents()
        {
            students = studentService.GetAllStudents();
            return students;
        }

        public ObservableCollection<Student> SearchStudentsByFirstName(string firstName)
        {
            students = new ObservableCollection<Student>(students.Where(student => student.FirstName.ToLower().Contains(firstName.ToLower())));
            return students;
        }

        public ObservableCollection<Student> SearchStudentsByLastName(string lastName)
        {
            students = new ObservableCollection<Student>(students.Where(student => student.LastName.ToLower().Contains(lastName.ToLower())));
            return students;
        }

        public ObservableCollection<Student> SearchStudentsByMail(string mail)
        {
            students = new ObservableCollection<Student>(students.Where(student => student.Email.ToLower().Contains(mail)));
            return students;
        }
    }
}
