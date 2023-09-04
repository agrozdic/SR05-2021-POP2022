using SkolaJezika.resources.dao;
using SkolaJezika.resources.managers;
using SkolaJezika.resources.enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using SkolaJezika.resources.models;
using System.Windows;

namespace SkolaJezika.resources.services
{
    class SessionService
    {
        SessionRepository repository;

        public SessionService()
        {
            repository = new SessionRepository();
        }

        public void InitializeService()
        {
            FillModelManager();
            //Create(1, "1234567891011", DateTime.Now, "21:00", 30, EClassStatus.AVAILABLE, "123123");
            //Update(1, "1234567891011", DateTime.Now, "21:00", 30, EClassStatus.RESERVED, "123123");
            Console.WriteLine("Session Service -> Service initialized");
        }

        private void FillModelManager()
        {
            repository.Read();
        }

        public void MakeSessionAvailable(Session session)
        {
            session.Status = EClassStatus.AVAILABLE;
            session.Student.ReservedSessions.Remove(session);
            session.Student = null;
            repository.Update(session);
            repository.MakeSessionAvailable(session.Id);
        }
        public void MakeSessionReserved(Session session, Student student)
        {
            session.Student = student;
            session.Status = EClassStatus.RESERVED;
            session.Student.ReservedSessions.Add(session);
            repository.Update(session);
            repository.MakeSessionReserved(session.Id, student.PersonalIdentityNumber);
        }

        public ObservableCollection<Session> GetAllAvailableSessionByTeacherID(string id)
        {
            return new ObservableCollection<Session>(SessionManager.GetInstance().AllSessions.Where(session => session.Teacher.PersonalIdentityNumber == id && session.Status == EClassStatus.AVAILABLE));
        }

        public ObservableCollection<Session> GetAllReservedSessionsByStudentID(string id)
        {
            return new ObservableCollection<Session>(SessionManager.GetInstance().AllSessions.Where(session => session.Student?.PersonalIdentityNumber == id));
        }
        public ObservableCollection<Session> GetAllAvailableSessions()
        {
            return new ObservableCollection<Session>(SessionManager.GetInstance().AllSessions.Where(session => session.Active && session.Status == EClassStatus.AVAILABLE).ToList());
        }

        public ObservableCollection<Session> GetSessionsBasedByTeacherIDAndDate(string id, DateTime date)
        {
            return new ObservableCollection<Session>(SessionManager.GetInstance().AllSessions.Where(session => session.Teacher.PersonalIdentityNumber == id && session.ReservedDate.Date == date.Date));
        }
        public ObservableCollection<Session> GetSessionsBasedByTeacherID(string id)
        {
            return new ObservableCollection<Session>(SessionManager.GetInstance().AllSessions.Where(session => session.Teacher.PersonalIdentityNumber == id));
        }
        public ObservableCollection<Session> GetAllSessions()
        {
            return new ObservableCollection<Session>(SessionManager.GetInstance().AllSessions.Where(session => session.Active).ToList());
        }

        public void Create(Teacher teacher, DateTime reservedDate, string startingTime, int classLength, EClassStatus status, Student student = null)
        {
            repository.Create(teacher, reservedDate, startingTime, classLength, status, student);
        }

        public void Update(int id, Teacher teacher, DateTime reservedDate, string startingTime, int classLength, EClassStatus status, Student student = null)
        {
            repository.Update(id, teacher, reservedDate, startingTime, classLength, status, student);
        }

        public void Delete(int id)
        {
            repository.Delete(id);
        }
    }
}
