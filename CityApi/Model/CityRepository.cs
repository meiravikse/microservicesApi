using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CityApi.Model
{
    public class CityRepository
    {
        private List<City> cities = new List<City>
        {
            new City {CID=3000, Name="Jerusalem"},
            new City {CID=4000, Name="Haifa"},
            new City {CID=5000, Name="Tel aviv"},
        };

        public IEnumerable<City> GetAll()
        {
            return cities;
        }

        public City GetById(int id)
        {
            var city = cities.FirstOrDefault(c => c.CID == id);
            return city;
        }
    }
}
