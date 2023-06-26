using BlazorAPI.Data;
using BlazorAPI.Entities;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlazorAPI.Repositories
{
    public class UserRepository :IUserRepository
    {
        private readonly BlazorDbContext _context;

        public UserRepository(BlazorDbContext context)
        {
            _context = context;
        }
        public async Task<List<User>> GetUserList()
        {
            return await _context.Users.ToListAsync();
        }
    }
}
