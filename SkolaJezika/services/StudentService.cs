using SkolaJezika.managers;
using SkolaJezika.dao;
using SkolaJezika.enums;
using SkolaJezika.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows;

namespace SkolaJezika.services
{
    class StudentService
    {
        private StudentRepository repository;
        private AddressService addressService;
        private SessionService sessionService;
        public StudentService()
        {
            repository = new StudentRepository();
            sessionService = new SessionService();
            addressService = new AddressService();
        }

        public void InitializeService()
        {
            FillManager();
            Console.WriteLine("Student Service -> Service initialized");
        }

        private void FillManager()
        {
            repository.Read();
        }
        
        public Student FindByID(string id)
        {
            return StudentManager.GetInstance().GetStudentByJMBG(id);
        }
        public Student FindByJMBGIDAndPassword(string jmbg, string password)
        {
            Student a = (Student)StudentManager.GetInstance().AllStudents.ToList().Find(student => student.Jmbg == jmbg && student.Password == password);
            return a;
        }

        public Student FindBySessionID(int id)
        {
            Student foundStudent = null;
            foreach(Student student in StudentManager.GetInstance().AllStudents)
            {
               foreach(Session session in student.ReservedSessions)
                {
                    if (session.Id == id) foundStudent = student;
                }
            }
            return foundStudent;
        }

        public void InitializeStudentSession()
        {
            sessionService.GetAllSessions().ToList().ForEach(session => {
                Student student = session.Student;
                if (student != null)
                {
                    student.ReservedSessions.Add(session);
                }
            });
        }

        public ObservableCollection<Student> GetAllStudents()
        {
            return new ObservableCollection<Student>(StudentManager.GetInstance().AllStudents.Where(x => x.Active));
        }

        public void CreateStudent(string firstName, string lastName, string jmbg, string email, string password, EUserType userType, EGender genderType, string streetName, int streetNumber, string cityName, string country)
        {
            Address enteredAddress = addressService.GetAddressByStreetNameNumberAndCity(streetName, streetNumber, cityName);

            if (enteredAddress == null)
            {
                addressService.CreateAddress(streetName, streetNumber, cityName, country);
                enteredAddress = addressService.GetAddressByStreetNameNumberAndCity(streetName, streetNumber, cityName);
            }
            repository.Create(firstName, lastName, jmbg, email, password, userType, genderType, true, enteredAddress, new List<Session>());
        }

        public void UpdateStudent(string firstName, string lastName, string jmbg, string email, string password, EUserType userType, EGender genderType, string streetName, int streetNumber, string cityName, string country)
        {
            Address enteredAddress = addressService.GetAddressByStreetNameNumberAndCity(streetName, streetNumber, cityName);

            if (enteredAddress == null)
            {
                addressService.CreateAddress(streetName, streetNumber, cityName, country);
                enteredAddress = addressService.GetAddressByStreetNameNumberAndCity(streetName, streetNumber, cityName);
            }
            repository.Update(firstName, lastName, jmbg, email, password, userType, genderType, true, enteredAddress, FindByID(jmbg).ReservedSessions);
        }

        public void DeleteStudent(string jmbg)
        {
            repository.Delete(jmbg);
        }

    }
}
