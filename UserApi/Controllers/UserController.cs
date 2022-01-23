using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using UserApi.Model;

namespace UserApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    
    public class UserController : ControllerBase
    {
        private readonly ILogger<UserController> _logger;
        private UserRepository repository = null;

        public UserController(ILogger<UserController> logger, UserRepository repository)
        {
            _logger = logger;
            this.repository = repository;
        }

        [HttpGet]
        [Authorize]
        public IEnumerable<User> Get()
        {
            return repository.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<User> Get(int id)
        {
            return await repository.GetById(id);
        }

        [HttpPost] 
        public void Post(User user)
        {
            repository.Add(user);
        }
    }
}
