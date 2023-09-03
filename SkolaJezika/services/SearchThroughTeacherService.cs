using SkolaJezika.models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkolaJezika.services
{
    class SearchThroughTeacherService
    {
        private TeacherService teacherService;
        private ObservableCollection<Teacher> teachers;

        public SearchTeacherService()
        {
            teacherService = new TeacherService();
            teachers = new ObservableCollection<Teacher>();
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

        public ObservableCollection<Teacher> SearchTeachersByLastName(string lastName)
        {
            teachers = new ObservableCollection<Teacher>(teachers.Where(teacher => teacher.LastName.ToLower().Contains(lastName.ToLower())));
            return teachers;
        }

        public ObservableCollection<Teacher> SearchTeachersByMail(string mail)
        {
            teachers = new ObservableCollection<Teacher>(teachers.Where(teacher => teacher.Email.ToLower().Contains(mail.ToLower())));
            return teachers;
        }

        public ObservableCollection<Teacher> SearchTeachersByLanguages(List<Language> languages)
        {
            ObservableCollection<Teacher> newListTemp = new ObservableCollection<Teacher>();
            
            teachers.ToList().ForEach(teacher =>
            {
                languages.ToList().ForEach(lang => { 
                    if (teacher.TeachingLanguages.Contains(lang))
                    {
                        newListTemp.Add(teacher);
                    }
                });
            });

            return new ObservableCollection<Teacher>(newListTemp.Distinct());
        }

        public ObservableCollection<Teacher> SearchTeachersByStreetName(string streetName)
        {
            teachers = new ObservableCollection<Teacher>(teachers.Where(teacher => teacher.Address.Street.ToLower().Contains(streetName.ToLower())));
            return teachers;
        }

        public ObservableCollection<Teacher> SearchTeachersByCity(string city)
        {
            teachers = new ObservableCollection<Teacher>(teachers.Where(teacher => teacher.Address.City.ToLower().Contains(city.ToLower())));
            return teachers;
        }
    }
}
