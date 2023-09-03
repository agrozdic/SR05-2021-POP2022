using SkolaJezika.dao;
using SkolaJezika.managers;
using SkolaJezika.exceptions;
using SkolaJezika.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Collections.ObjectModel;

namespace SkolaJezika.services
{
    class TeacherService
    {
        TeacherRepository repository;
        AddressService addressService;
        ClassesService classService;
        public TeacherService()
        {
            repository = new TeacherRepository();
            addressService = new AddressService();
            classService = new ClassesService();
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

        public void InitializeTeacherClasses()
        {
            Console.WriteLine("SESSIONS ARRAY LENGTH -> ", classService.GetAllClasses().Count());
            classService.GetAllClasses().ToList().ForEach(classes => {
                Teacher teacher = classes?.Teacher;
                if (teacher != null)
                {
                    teacher.Classes.Add(classes);
                }
            });
        }

        public ObservableCollection<Teacher> GetTeachersBasedBySchoolID(int schoolID)
        {
            ObservableCollection<Teacher> list = new ObservableCollection<Teacher>(TeacherManager.GetInstance().AllTeachers.ToList().FindAll(teacher => teacher.School.Id == schoolID));
            return list;
        }

        public ObservableCollection<Teacher> GetAllTeachers()
        {
            return new ObservableCollection<Teacher>(TeacherManager.GetInstance().AllTeachers.Where(x => x.Active));
        }
        public Teacher FindByJMBGIDAndPassword(string jmbg, string password)
        {
            Teacher a = (Teacher)TeacherManager.GetInstance().AllTeachers.ToList().Find(teacher => teacher.Jmbg == jmbg && teacher.Password == password);
            return a;
        }
        public void CreateTeacher(string firstName, string lastName, string jmbg, string email, string password, EUserType userType, EGender genderType, string streetName, int streetNumber, string cityName, string country, bool active, string schoolName, List<Language> languages)
        {
            try
            {
                Address enteredAddress = addressService.GetAddressByStreetNameNumberAndCity(streetName, streetNumber, cityName);

                if (enteredAddress == null)
                {
                    addressService.CreateAddress(streetName, streetNumber, cityName, country);
                    enteredAddress = addressService.GetAddressByStreetNameNumberAndCity(streetName, streetNumber, cityName);
                }
    
                repository.Create(firstName, lastName, jmbg, email, password, EUserType.Teacher, genderType, enteredAddress, active = true, SchoolManager.GetInstance().GetSchoolByName(schoolName), languages, new List<Classes>());
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
            catch(ClassesNotFoundException exception)
            {
                Console.Write(exception);
            }
        }

        public void UpdateTeacher(string firstName, string lastName, string jmbg, string email, string password, EUserType userType, EGender genderType, string streetName, int streetNumber, string cityName, string country, bool active, string schoolName, List<Language> languages)
        {

            Address enteredAddress = addressService.GetAddressByStreetNameNumberAndCity(streetName, streetNumber, cityName);

            if (enteredAddress == null)
            {
                addressService.CreateAddress(streetName, streetNumber, cityName, country);
                enteredAddress = addressService.GetAddressByStreetNameNumberAndCity(streetName, streetNumber, cityName);
            }
            School workingSchool = SchoolManager.GetInstance().GetSchoolByName(schoolName);
            List<Classes> classs = TeacherManager.GetInstance().GetTeacherByJMBG(jmbg).Classes;
            repository.Update(firstName, lastName, jmbg, email, password, userType, genderType, enteredAddress, active, workingSchool, languages, classs);
        }

        public void DeleteTeacher(string identityNumber)
        {
            repository.Delete(identityNumber);
        }
    }
}
