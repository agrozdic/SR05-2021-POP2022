using SkolaJezika.models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkolaJezika.models
{
    public class Classes : INotifyPropertyChanged
    {
        private int id;
        private Teacher teacher;
        private DateTime reservedDate;
        private string startingTime;
        private int classLength;
        private EClassesStatus status;
        private Student student;
        private bool active;

        public Classes()
        {

        }

        public Classes(int id, Teacher teacher, DateTime reservedDate, string startingTime, int classLength, EClassesStatus status, Student student, bool active)
        {
            this.id = id;
            this.teacher = teacher;
            this.reservedDate = reservedDate;
            this.startingTime = startingTime;
            this.classLength = classLength;
            this.status = status;
            this.student = student;
            this.active = active;
        }

        public int Id { get => id; set { id = value; OnPropertyChanged("id"); } }

        public Teacher Teacher { get => teacher; set { teacher = value; OnPropertyChanged("teacher"); } }

        public DateTime ReservedDate { get => reservedDate; set { reservedDate = value; OnPropertyChanged("reservedDate"); } }

        public string StartingTime { get => startingTime; set { startingTime = value; OnPropertyChanged("startingTime"); } }

        public int ClassesLength { get => classLength; set { classLength = value; OnPropertyChanged("classLength"); } }

        public EClassesStatus Status { get => status; set { status = value; OnPropertyChanged("status"); }}

        public Student Student { get => student; set { student = value; OnPropertyChanged("student"); } }
        
        public bool Active { get => active; set { active = value; OnPropertyChanged("active"); } }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(String name)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(name));
            }
        }
        public override string ToString()
        {
            return $"Classes {id}, Teacher {teacher.Jmbg}, Student {student?.Jmbg}";
        }
    }
}
