using DevFreela.API.Models;
using DevFreela.Application.InputModels;
using DevFreela.Application.Services.Interfaces;
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
        private readonly IUserService _userService;
        public UsersController(IUserService userService)
        {
            _userService = userService;
        }
        // api/users/1
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var user = _userService.GetUser(id);

            return Ok(user);
        }
        //api/users/post
        [HttpPost]
        public IActionResult Post([FromBody]CreateUserInputModel inputModel)
        {
            if(inputModel == null)
            {
                return BadRequest();
            }
            var id = _userService.Create(inputModel);
            return CreatedAtAction(nameof(GetById), new { id = id}, inputModel);
        }
        // api/project/1/login
        [HttpPut("{id}/login")]
        public IActionResult Login(int id, [FromBody] LoginModel loginModel)
        {
            if (loginModel == null)
            {
                return BadRequest();
            }

            return NoContent();
        }


    }
}
