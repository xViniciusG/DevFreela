using DevFreela.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Infraestructure.Persistence
{
    public class DevFreelaDbContext
    {
        public DevFreelaDbContext()
        {
            Projects = new List<Project>
            {
                 new Project("Meu Projeto ASPNET CORE","Minha Descricao do Projeto 1",1,1,10000),
                 new Project("Meu Projeto ASPNET CORE","Minha Descricao do Projeto 2",1,1,20000),
                 new Project("Meu Projeto ASPNET CORE","Minha Descricao do Projeto 3",1,1,30000)
            };

            Users = new List<User>
            {
                new User("Vinicius Gomes", "vinicius.gomes@dorconsultoria.com.br", new DateTime(1998, 1, 1)),
                new User("Caique Dias", "caique.dias@dorconsultoria.com.br", new DateTime(1995, 1, 1)),
                new User("Cleber Costa", "cleber.costa@dorconsultoria.com.br", new DateTime(1998, 1, 1))
            };

            Skills = new List<Skill>
            {

                new Skill(".Net Core"),
                new Skill("C#"),
                new Skill("SQL")
            };

        }
        public List<Project> Projects { get;  set; }
        public List<User> Users { get;  set; }
        public List<Skill> Skills { get;  set; }
        public List<ProjectComment> ProjectComments { get;  set; }
    }
}
