using SkolaJezika.resources.managers;
using SkolaJezika.resources.models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkolaJezika.utilities.file_related_utilities
{
    class FileSchoolFormatter
    {

        public static School CreateSchoolFromFile(string[] splittedLine)
        {
            School school = new School();
            school.Id = int.Parse(splittedLine[0]);
            school.Name = splittedLine[1];
            school.Address = AddressManager.GetInstance().GetAddressById(int.Parse(splittedLine[2]));
            school.AllLanguages = LanguageManager.GetInstance().GetLanguagesBasedById(FileLanguageFormatter.SplitLanguagesFromFile(splittedLine[3])).ToList();
            school.Active = bool.Parse(splittedLine[4]);
            return school;
        }
        public static string CreateStringFormatForFileStorage(School school)
        {
            return String.Format("{0}|{1}|{2}|{3}|{4}", school.Id, school.Name, school.Address.Id, FileLanguageFormatter.CreateStringRepresentationOfLanguageIDs(school.AllLanguages), school.Active);
        }




    }
}
