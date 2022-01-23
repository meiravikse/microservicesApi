using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace UserApi.Model
{
    public class User
    {
        public int UID { get; set; }
        public string Name { get; set; }
        public int Salary { get; set; }
        public int CityId { get; set; }
    }
}
