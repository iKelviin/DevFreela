using DevFreela.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Core.Repositories
{
    public interface ISkillRepository
    {
        Task<int> Add(Skill skill);
        Task<List<int>> AddUserSkill(List<UserSkill> userSkills);
        Task<List<Skill>> GetAll();
    
    }
}
