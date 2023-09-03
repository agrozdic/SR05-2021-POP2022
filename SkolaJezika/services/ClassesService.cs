//using SkolaJezika.dao;
using SkolaJezika.managers;
using SkolaJezika.models;
using SkolaJezika.repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using System.Windows;

namespace SkolaJezika.services
{
    class ClassesService
    {
        ClassesRepository repository;

        public ClassesService()
        {
            repository = new ClassesRepository();
        }

        public void InitializeService()
        {
            FillModelManager();
            Console.WriteLine("Classes Service -> Service initialized");
        }

        private void FillModelManager()
        {
            //repository.Read();
        }

        public void MakeClassesAvailable(Classes classes)
        {
            classes.Status = EClassesStatus.AVAILABLE;
            classes.Student.ReservedClasses.Remove(classes);
            classes.Student = null;
            repository.Update(classes);
            repository.MakeClassesAvailable(classes.Id);
        }

        public void MakeClassesReserved(Classes classes, Student student)
        {
            classes.Student = student;
            classes.Status = EClassesStatus.RESERVED;
            classes.Student.ReservedClasses.Add(classes);
            repository.Update(classes);
            repository.MakeClassesReserved(classes.Id, student.Jmbg);
        }

        public ObservableCollection<Classes> GetAllAvailableClassesByTeacherID(string id)
        {
            return new ObservableCollection<Classes>(ClassesManager.GetInstance().AllClasses.Where(classes => classes.Teacher.Jmbg == id && classes.Status == EClassesStatus.AVAILABLE));
        }

        public ObservableCollection<Classes> GetAllReservedClassesByStudentID(string id)
        {
            return new ObservableCollection<Classes>(ClassesManager.GetInstance().AllClasses.Where(classes => classes.Student?.Jmbg == id));
        }
        public ObservableCollection<Classes> GetAllAvailableClasses()
        {
            return new ObservableCollection<Classes>(ClassesManager.GetInstance().AllClasses.Where(classes => classes.Active && classes.Status == EClassesStatus.AVAILABLE).ToList());
        }

        public ObservableCollection<Classes> GetClassesBasedByTeacherIDAndDate(string id, DateTime date)
        {
            return new ObservableCollection<Classes>(ClassesManager.GetInstance().AllClasses.Where(classes => classes.Teacher.Jmbg == id && classes.ReservedDate.Date == date.Date));
        }
        public ObservableCollection<Classes> GetClassesBasedByTeacherID(string id)
        {
            return new ObservableCollection<Classes>(ClassesManager.GetInstance().AllClasses.Where(classes => classes.Teacher.Jmbg == id));
        }
        public ObservableCollection<Classes> GetAllClasses()
        {
            return new ObservableCollection<Classes>(ClassesManager.GetInstance().AllClasses.Where(classes => classes.Active).ToList());
        }

        public void Create(Teacher teacher, DateTime reservedDate, string startingTime, int classesLength, EClassesStatus status, Student student = null)
        {
            repository.Create(teacher, reservedDate, startingTime, classesLength, status, student);
        }

        public void Update(int id, Teacher teacher, DateTime reservedDate, string startingTime, int classesLength, EClassesStatus status, Student student = null)
        {
            repository.Update(id, teacher, reservedDate, startingTime, classesLength, status, student);
        }

        public void Delete(int id)
        {
            repository.Delete(id);
        }
    }
}
