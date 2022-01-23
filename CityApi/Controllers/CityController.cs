using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CityApi.Model;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CityApi.Controllers
{
    [Route("[controller]")]
    public class CityController : Controller
    {
        private CityRepository repository = new CityRepository();

        [HttpGet]
        public IEnumerable<City> Get()
        {
            return repository.GetAll();
        }

        [HttpGet("{id}")]
        public City Get(int id)
        {
            return repository.GetById(id);
        }
    }
}
