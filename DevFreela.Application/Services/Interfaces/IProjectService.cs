﻿using DevFreela.Application.InputModels;
using DevFreela.Application.ViewsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Services.Interfaces
{
    public interface IProjectService
    {
        List<ProjectViewModels> GetAll(string query);
        ProjectDetailsViewModel GetById(int id);
        void Update(UpdateProjectInputModel inputModel);
        void Delete(int id);
       
        void Start(int id);
        void Finish(int id);

    }
}
