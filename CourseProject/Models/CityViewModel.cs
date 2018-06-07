using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CourseProject.Models
{
    public class CitiesViewModel
    {

        public int ID { get; set; }
        public string Name { get; set; }

        public CitiesViewModel(City city)
        {
            ID = city.ID;
            Name = city.Name;
        }

    }

    public class CityViewModel
    {

        public int ID { get; set; }
        public string Name { get; set; }
        public List<CitiesViewModel> citiesList;

        public CityViewModel()
        {
            citiesList = new List<CitiesViewModel>();
        }

        public CityViewModel(City city)
        {
            ID = city.ID;
            Name = city.Name;
        }


        public CityViewModel(List<City> cities)
            : this()
        {
            foreach (City city in cities)
            {
                CitiesViewModel cityViewModel = new CitiesViewModel(city);
                citiesList.Add(cityViewModel);
            }
        }

    }
}