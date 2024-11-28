using DevFreela.Core.Entities;
using DevFreela.Core.Repositories;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DevFreela.Infrastructure.Persistence.Repositories
{
    public class SkillRepository : ISkillRepository
    {
        private readonly DevFreelaDbContext _context;
        public SkillRepository(DevFreelaDbContext context)
        {
            _context = context;
        }
        public async Task<int> Add(Skill skill)
        {
            _context.Skills.Add(skill);
            await _context.SaveChangesAsync();
            return skill.Id;
        }

        public async Task<List<int>> AddUserSkill(List<UserSkill> userSkills)
        {
            _context.UserSkills.AddRange(userSkills);
            await _context.SaveChangesAsync();
            return userSkills.Select(s=> s.Id).ToList();
        }

        public async Task<List<Skill>> GetAll()
        {
            var skills = await _context.Skills.ToListAsync();
            return skills;
        }

    }
}
