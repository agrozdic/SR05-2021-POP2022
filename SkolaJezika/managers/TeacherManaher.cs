using SR05-2021-POP2022.models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SR05-2021-POP2022.managers
{
    class TeacherManager { 
        private static TeacherManager instance;
        private ObservableCollection<Teacher> allTeachers = new ObservableCollection<Teacher>();

        public ObservableCollection<Teacher> AllTeachers { get => allTeachers; set => allTeachers = value; }

        private TeacherManager() { }

        public static TeacherManager GetInstance()
        {
            if (instance == null) instance = new TeacherManager();
            return instance;
        }

        public Teacher GetTeacherByJMBG(string jmbg)
        {
            try
            {
                Teacher teacher = allTeachers.ToList().Find(x => x.jmbg == jmbg);
                return teacher;
            }
            catch(NullReferenceException ex) 
            {
                throw new Exception(ex.Message);
            }
        }

        public List<Teacher> GetTeachersBasedBySchoolID(int schoolID)
        {
            List<Teacher> list = new List<Teacher>();
            
            return list;
        }
    }
}
