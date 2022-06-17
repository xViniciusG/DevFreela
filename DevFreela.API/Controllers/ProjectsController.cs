using DevFreela.API.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevFreela.API.Controllers
{
    [ApiController]
    [Route("api/projects")]

    public class ProjectsController : ControllerBase

    {
        private readonly OpeningTimeOption _option;
        public  ProjectsController(IOptions<OpeningTimeOption> option, ExampleClass exampleClass)
        {
            exampleClass.Name = "Update na ProjectsController";
            _option = option.Value;
        }

        // api/projects?query=NetCore
        [HttpGet]
        public IActionResult Get(string query)
        {
            return Ok();
            //Buscar todos projetos ou Filtrar 
        }

        // api/projects/599
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            //return NotFound();
            return Ok();
            // Busca o projeto
        }
       
        [HttpPost]
        public IActionResult Post([FromBody] CreateProjectModel createProject)
        {
            if(createProject.Title.Length > 50)
            {
            return BadRequest();
            }
            //Cadastrar o Projeto
            return CreatedAtAction(nameof(GetById), new { id = createProject.Id}, createProject);
        }
        // api/projects/2
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody]UpdateProjectModel updateProject)
        {
            if (updateProject.Description.Length > 200)
            {
                return BadRequest();
            }
            //Atualiza o Projeto
            return NoContent();
        }
        // api/projects/3 
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            //Buscar, se não exibir retorna notfound

            //Deleta o Projeto
            return NoContent();
        }
        //api/projects/1/comments
        [HttpPost("{id}/comments")]
        public IActionResult PostComments(int id,[FromBody] CreateCommentModel createComment)
        {
            return NoContent();
        }
        //api/project/1/start
        [HttpPut("{id}/start")]
        public IActionResult Start(int id)
        {
            return NoContent();
        }
        // api/project/1/finish
        [HttpPut("{id}/finish")]
        public IActionResult Finish(int id)
        {
            return NoContent();
                
        }
       
    }
}



