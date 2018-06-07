using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CourseProject.Models
{
    public class StoresViewModel
    {

        public int ID { get; set; }
        public string Name { get; set; }
        public int CityID { get; set; }
        public City StoreCity { get; set; }

        public StoresViewModel(Store store)
        {
            ID = store.ID;
            Name = store.Name;
            CityID = store.City;
            StoreCity = store.StoreCity;

        }

    }

    public class StoreViewModel
    {

        public int ID { get; set; }
        public string Name { get; set; }
        public int CityID { get; set; }
        public City StoreCity { get; set; }
        public List<StoresViewModel> storeList;

        public StoreViewModel()
        {
            storeList = new List<StoresViewModel>();
        }

        public StoreViewModel(Store store)
        {
            ID = store.ID;
            Name = store.Name;
            CityID = store.City;
            StoreCity = store.StoreCity;
        }


        public StoreViewModel(List<Store> stores)
            : this()
        {
            foreach (Store store in stores)
            {
                StoresViewModel storeViewModel = new StoresViewModel(store);
                storeList.Add(storeViewModel);
            }
        }

    }
}