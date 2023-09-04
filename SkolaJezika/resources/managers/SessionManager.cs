using SkolaJezika.utilities.exceptions;
using SkolaJezika.resources.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;

namespace SkolaJezika.resources.managers
{
    class SessionManager
    {
        private static SessionManager instance;
        private ObservableCollection<Session> allSessions
            = new ObservableCollection<Session>();
      
        public ObservableCollection<Session> AllSessions { get => allSessions; set => allSessions = value; }

        private SessionManager() { }

        public static SessionManager GetInstance()
        {
            if (instance == null) instance = new SessionManager();
            return instance;
        }

        public Session GetSessionById(int id)
        {

            Session foundClass = allSessions.ToList().Find(x => x.Id == id);
            if (foundClass == null)
            {
                throw new SessionNotFoundException("Cas ne postoji.");
            }
            return foundClass;
        }

        public ObservableCollection<Session> GetSessionsBasedByID(string[] splittedIndexes)
        {
            ObservableCollection<Session> sessions = new ObservableCollection<Session>();
            foreach(string splittedIndex in splittedIndexes)
            {
                if (splittedIndex != "-1") sessions.Add(GetSessionById(int.Parse(splittedIndex)));
            }
            return sessions;
        }

        public ObservableCollection<Session> GetSessionsBasedByID(int[] splittedIndexes)
        {
            ObservableCollection<Session> sessions = new ObservableCollection<Session>();
            foreach (int splittedIndex in splittedIndexes)
            {
                sessions.Add(GetSessionById(splittedIndex));
            }
            return sessions;
        }
    }
}
