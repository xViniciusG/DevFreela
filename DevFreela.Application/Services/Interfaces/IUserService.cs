﻿using DevFreela.Application.InputModels;
using DevFreela.Application.ViewsModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Application.Services.Interfaces
{
    public interface IUserService
    {
        int Create(CreateUserInputModel inputModel);
        UserViewModel GetUser(int id);
        
    }
}
