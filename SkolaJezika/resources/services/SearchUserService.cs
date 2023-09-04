using SkolaJezika.resources.models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkolaJezika.resources.services
{
    class SearchUserService
    {
        private TeacherService teacherService;
        private StudentService studentService;
        private ObservableCollection<Student> students;
        private ObservableCollection<Teacher> teachers;
        public SearchUserService()
        {
            teacherService = new TeacherService();
            studentService = new StudentService();
            students = new ObservableCollection<Student>();
            teachers = new ObservableCollection<Teacher>();
        }

        public ObservableCollection<Student> SearchStudents()
        {
            students = studentService.GetAllStudents();
            return students;
        }

        public ObservableCollection<Teacher> SearchTeachers()
        {
            teachers = teacherService.GetAllTeachers();
            return teachers;
        }

        public ObservableCollection<Teacher> SearchTeachersByFirstName(string firstName)
        {
            teachers = new ObservableCollection<Teacher>(teachers.Where(teacher => teacher.FirstName.ToLower().Contains(firstName.ToLower())));
            return teachers;
        }

        public ObservableCollection<Student> SearchStudentsByFirstName(string firstName)
        {
            students = new ObservableCollection<Student>(students.Where(student => student.FirstName.ToLower().Contains(firstName.ToLower())));
            return students;
        }

        public ObservableCollection<Teacher> SearchTeachersByLastName(string lastName)
        {
            teachers = new ObservableCollection<Teacher>(teachers.Where(teacher => teacher.LastName.ToLower().Contains(lastName.ToLower())));
            return teachers;
        }

        public ObservableCollection<Student> SearchStudentsByLastName(string lastName)
        {
            students = new ObservableCollection<Student>(students.Where(student => student.LastName.ToLower().Contains(lastName.ToLower())));
            return students;
        }

        public ObservableCollection<Teacher> SearchTeachersByMail(string mail)
        {
            teachers = new ObservableCollection<Teacher>(teachers.Where(teacher => teacher.Email.ToLower().Contains(mail.ToLower())));
            return teachers;
        }

        public ObservableCollection<Student> SearchStudentsByMail(string mail)
        {
            students = new ObservableCollection<Student>(students.Where(student => student.Email.ToLower().Contains(mail)));
            return students;
        }
    }
}
