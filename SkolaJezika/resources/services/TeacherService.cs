using SkolaJezika.resources.dao;
using SkolaJezika.resources.managers;
using SkolaJezika.utilities.exceptions;
using SkolaJezika.resources.enums;
using SkolaJezika.resources.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Collections.ObjectModel;

namespace SkolaJezika.resources.services
{
    class TeacherService
    {
        TeacherRepository repository;
        AddressService addressService;
        SessionService sessionService;
        public TeacherService()
        {
            repository = new TeacherRepository();
            addressService = new AddressService();
            sessionService = new SessionService();
        }

        public void InitializeService()
        {
            FillManager();
            Console.WriteLine("Teacher Service - Initialized");

        }

        private void FillManager()
        {
            repository.Read();
        }

        public void InitializeTeacherSessions()
        {
            Console.WriteLine("SESSIONS ARRAY LENGTH -> ", sessionService.GetAllSessions().Count());
            sessionService.GetAllSessions().ToList().ForEach(session => {
                Teacher teacher = session?.Teacher;
                if (teacher != null)
                {
                    teacher.Sessions.Add(session);
                }
            });
        }

        public ObservableCollection<Teacher> GetTeachersBasedBySchoolID(int schoolID)
        {
            ObservableCollection<Teacher> list = new ObservableCollection<Teacher>(TeacherManager.GetInstance().AllTeachers.ToList().FindAll(teacher => teacher.WorkingSchool.Id == schoolID));
            return list;
        }

        public ObservableCollection<Teacher> GetAllTeachers()
        {
            return new ObservableCollection<Teacher>(TeacherManager.GetInstance().AllTeachers.Where(x => x.Active));
        }
        public Teacher FindByPersonalIDAndPassword(string personalID, string password)
        {
            Teacher a = (Teacher)TeacherManager.GetInstance().AllTeachers.ToList().Find(teacher => teacher.PersonalIdentityNumber == personalID && teacher.Password == password);
            return a;
        }
        public void CreateTeacher(string firstName, string lastName, string personalIdentityNumber, string email, string password, EUserType userType, EGender genderType, string streetName, int streetNumber, string cityName, string country, bool active, string schoolName, List<Language> languages)
        {
            try
            {
                Address enteredAddress = addressService.GetAddressByStreetNameNumberAndCity(streetName, streetNumber, cityName);

                if (enteredAddress == null)
                {
                    addressService.CreateAddress(streetName, streetNumber, cityName, country);
                    enteredAddress = addressService.GetAddressByStreetNameNumberAndCity(streetName, streetNumber, cityName);
                }
    
                repository.Create(firstName, lastName, personalIdentityNumber, email, password, EUserType.Teacher, genderType, enteredAddress, active = true, SchoolManager.GetInstance().GetSchoolByName(schoolName), languages, new List<Session>());
            }
            catch (AddressNotFoundException exception)
            {
                Console.WriteLine(exception.Message);
            }
            catch(SchoolNotFoundException exception)
            {
                Console.WriteLine(exception.Message);
            }
            catch(LanguageNotFoundException exception)
            {
                Console.WriteLine(exception.Message);
            }
            catch(SessionNotFoundException exception)
            {
                Console.Write(exception);
            }
        }

        public void UpdateTeacher(string firstName, string lastName, string personalIdentityNumber, string email, string password, EUserType userType, EGender genderType, string streetName, int streetNumber, string cityName, string country, bool active, string schoolName, List<Language> languages)
        {

            Address enteredAddress = addressService.GetAddressByStreetNameNumberAndCity(streetName, streetNumber, cityName);

            if (enteredAddress == null)
            {
                addressService.CreateAddress(streetName, streetNumber, cityName, country);
                enteredAddress = addressService.GetAddressByStreetNameNumberAndCity(streetName, streetNumber, cityName);
            }
            School workingSchool = SchoolManager.GetInstance().GetSchoolByName(schoolName);
            List<Session> sessions = TeacherManager.GetInstance().GetTeacherByIdentityNumber(personalIdentityNumber).Sessions;
            repository.Update(firstName, lastName, personalIdentityNumber, email, password, userType, genderType, enteredAddress, active, workingSchool, languages, sessions);
        }

        public void DeleteTeacher(string identityNumber)
        {
            repository.Delete(identityNumber);
        }
    }
}
