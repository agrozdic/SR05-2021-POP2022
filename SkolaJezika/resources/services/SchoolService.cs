using SkolaJezika.resources.dao;
using SkolaJezika.resources.managers;
using SkolaJezika.resources.models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace SkolaJezika.resources.services
{
    class SchoolService
    {

        private SchoolRepository repository;
        private AddressService addressService;
        public SchoolService()
        {
            repository = new SchoolRepository();
            addressService = new AddressService();
        }

        public void InitializeService()
        {
            FillModelManager();
            Console.WriteLine("School Service -> Initialized");
        }

        private void FillModelManager()
        {
            repository.Read();
        }

        public ObservableCollection<School> GetSchoolsByLanguagesAndCity(List<Language> languageList, string cityName)
        {
            ObservableCollection<School> returnableCollection = new ObservableCollection<School>();
            languageList.ForEach(language =>
            {
                GetAllSchools().ToList().ForEach(school =>
                {
                    if (school.AllLanguages.Contains(language) && school.Address.City == cityName)
                    {
                        returnableCollection.Add(school);
                    }
                });
            });
            return new ObservableCollection<School>(returnableCollection.Distinct());
        }

        public ObservableCollection<School> GetSchoolsByLanguages(List<Language> languageList)
        {
            ObservableCollection<School> returnableCollection = new ObservableCollection<School>();
            languageList.ForEach(language =>
            {
                GetAllSchools().ToList().ForEach(school =>
                {
                    if (school.AllLanguages.Contains(language))
                    {
                        returnableCollection.Add(school);
                    }
                });
            });
            return new ObservableCollection<School>(returnableCollection.Distinct());
        }

        public ObservableCollection<School> GetSchoolByCityName(string name)
        {
            return new ObservableCollection<School>(GetAllSchools().ToList().Where(school => school.Address.City == name));
        }

        public ObservableCollection<School> GetAllSchools()
        {
            return new ObservableCollection<School>(SchoolManager.GetInstance().AllSchools.ToList().Where(school => school.Active));
        }

        public void Create(string name, string streetName, int streetNumber, string city, string country, List<Language> languages)
        {
            Address enteredAddress = addressService.GetAddressByStreetNameNumberAndCity(streetName, streetNumber, city);

            if (enteredAddress == null)
            {
                addressService.CreateAddress(streetName, streetNumber, city, country);
                enteredAddress = addressService.GetAddressByStreetNameNumberAndCity(streetName, streetNumber, city);
            }
            repository.Create(name, enteredAddress, languages);
        }

        public void Update(int id, string name, string streetName, int streetNumber, string city, string country, List<Language> languages)
        {
            Address enteredAddress = addressService.GetAddressByStreetNameNumberAndCity(streetName, streetNumber, city);

            if (enteredAddress == null)
            {
                addressService.CreateAddress(streetName, streetNumber, city, country);
                enteredAddress = addressService.GetAddressByStreetNameNumberAndCity(streetName, streetNumber, city);
            }
            repository.Update(id, name, enteredAddress, languages);
        }

        public void Delete(int id)
        {
            repository.Delete(id);
        }
    }
}
