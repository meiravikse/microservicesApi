using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace UserApi.Model
{
    class City
    {
        public int cid { get; set; }
        public string name { get; set; }
    }
    public class UserRepository
    {
        private static List<User> users = new List<User> {
             new User {UID=111, Name="Micro", Salary=3450, CityId=4000},
             new User {UID=222, Name="Service", Salary=2000, CityId=5000},
             new User {UID=333, Name="System", Salary=7500, CityId=4000},
        };

        private readonly IHttpClientFactory _clientFactory;

        public UserRepository(IHttpClientFactory clientFactory)
        {
            _clientFactory = clientFactory;
        }


        public IEnumerable<User> GetAll()
        {
            return users;
        }

        public async Task<UserAdv> GetById(int id)
        {
            var user=users.FirstOrDefault(u => u.UID == id);
            var userDetails = new UserAdv
            {
                UID = user.UID,
                Name = user.Name,
                Salary = user.Salary,
                CityId = user.CityId
            };
            var request = new HttpRequestMessage(HttpMethod.Get,
                $"http://ApiGateway/city/{user.CityId}");

            var client = _clientFactory.CreateClient();

            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                using var responseStream = await response.Content.ReadAsStreamAsync();
                var city = await JsonSerializer.DeserializeAsync<City>(responseStream);
                userDetails.CityName = city.name;
            }
            else
            {
                
            }

            return userDetails;
        }

        public void Add(User user) {
            users.Add(user);
        }

        public void Delete(int id)
        {
            var user= users.FirstOrDefault(u => u.UID == id);
            if (user != null)
                users.Remove(user);
        }
    }
}
