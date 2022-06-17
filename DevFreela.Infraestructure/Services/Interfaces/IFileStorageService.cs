using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Infraestructure.Services.Interfaces
{
    public interface IFileStorageService
    {
        void uploadFile(byte[] bytes, string fileName);
    }
}
