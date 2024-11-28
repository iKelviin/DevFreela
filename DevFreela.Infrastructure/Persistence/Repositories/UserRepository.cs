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
    public class UserRepository : IUserRepository
    {
        private readonly DevFreelaDbContext _context;
        public UserRepository(DevFreelaDbContext context)
        {
            _context = context;
        }
        public Task<int> Add(User user)
        {
            throw new NotImplementedException();
        }

        public async Task<User?> GetById(int id)
        {
            var user = await _context.Users
                     .Include(u => u.Skills)
                     .ThenInclude(u => u.Skill)
                     .SingleOrDefaultAsync(u => u.Id == id);

            return user;
        }
    }
}
