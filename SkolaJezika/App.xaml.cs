using SkolaJezika.resources.services;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace SkolaJezika
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            AddressService addressService = new AddressService();
            addressService.InitializeService();
            LanguageService languageService = new LanguageService();
            languageService.InitializeService();
            SchoolService schoolService = new SchoolService();
            schoolService.InitializeService();
            TeacherService teacherService = new TeacherService();
            teacherService.InitializeService();
            StudentService studentService = new StudentService();
            studentService.InitializeService();
            AdminService adminService = new AdminService();
            adminService.InitializeService();
            SessionService sessionService = new SessionService();
            sessionService.InitializeService();
            teacherService.InitializeTeacherSessions();
            studentService.InitializeStudentSession();
        }
    }
}
