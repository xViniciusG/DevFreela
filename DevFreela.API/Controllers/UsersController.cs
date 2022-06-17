using DevFreela.API.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevFreela.API.Controllers
{
    [ApiController]
    [Route("api/Users")]
    public class UsersController : ControllerBase 
    {

        public UsersController(ExampleClass exampleClass)
        {

        }
        // api/users/1
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            return Ok();
        }
        //api/users/post
        [HttpPost]
        public IActionResult Post([FromBody]CreateUsersModel createUsers)
        {
            return CreatedAtAction(nameof(GetById), new { id = 1 }, createUsers);
        }
        // api/project/1/login
        [HttpPut("{id}/login")]
        public IActionResult Login(int id, [FromBody] LoginModel loginModel)
        {
            return NoContent();
        }


    }
}
