﻿using DevFreela.API.Models;
using DevFreela.Application.Commands.CreateComment;
using DevFreela.Application.Commands.CreateProject;
using DevFreela.Application.Commands.DeleteProject;
using DevFreela.Application.Commands.FinishProject;
using DevFreela.Application.Commands.StartProject;
using DevFreela.Application.Commands.UpdateProject;
using DevFreela.Application.InputModels;
using DevFreela.Application.Queries.GetAllProjects;
using DevFreela.Application.Queries.GetProjectById;
using DevFreela.Application.Services.Interfaces;
using MediatR;
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
        private readonly IMediator _mediator;
        public  ProjectsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        // api/projects?query=NetCore
        [HttpGet]
        public async Task<IActionResult> Get(string query)
        {
            var proj = new GetAllProjectsQuery(query);   
            var projects = await _mediator.Send(proj);

            return Ok(projects);    
        }

        // api/projects/599
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var query = new GetProjectByIdQuery(id);
            var project = await _mediator.Send(query);
            if(project == null)
            {
                return NotFound();
            }
            return Ok(project);
            // Busca o projeto
        }
       
        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateProjectCommand command)
        {
            if(command.Title.Length > 50)
            {
            return BadRequest();
            }

            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetById), new { id = id}, command);
        }
        
        // api/projects/2
        [HttpPut("{id}")]
        public async Task <IActionResult> Put(int id, [FromBody]UpdateProjectCommand command)
        {
            if (command.Description.Length > 200)
            {
                return BadRequest();
            }
            await _mediator.Send(command); 
            return NoContent();
        }
        
        // api/projects/3 
        [HttpDelete("{id}")]
        public async Task <IActionResult> Delete(int id)
        {
            var command = new DeleteProjectCommand(id);
            await _mediator.Send(command); 
            //Deleta o Projeto
            return NoContent();
        }

        //api/projects/1/comments
        [HttpPost("{id}/comments")]
        public async Task <IActionResult> PostComments(int id,[FromBody] CreateCommentCommand command )
        {
            await _mediator.Send(command);
            return NoContent();
        }

        //api/project/1/start
        [HttpPut("{id}/start")]
        public async Task <IActionResult> Start(int id)
        {
            var command = new StartProjectCommand(id);
            await _mediator.Send(command);
            return NoContent();
        }
        // api/project/1/finish
        [HttpPut("{id}/finish")]
        public async Task<IActionResult> Finish(int id)
        {
            var command = new FinishProjectCommand(id);
            await _mediator.Send(command);
            return NoContent();
        }
       
    }
}



