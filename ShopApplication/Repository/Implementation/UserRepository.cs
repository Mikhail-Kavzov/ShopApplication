using Microsoft.EntityFrameworkCore;
using ShopApplication.Context;
using ShopApplication.Models;
using ShopApplication.Repository.Interfaces;
using System.Runtime.CompilerServices;

namespace ShopApplication.Repository.Implementation
{
    public class UserRepository : AbstractRepository, IUserRepository
    {
        public UserRepository(ApplicationContext context) : base(context)
        {
        }

        public async Task<int> CountAsync()
        {
            return await _context.Users.CountAsync();
        }

        public void Create(User item)
        {
            _context.Users.Add(item);
        }

        public void Delete(User item)
        {
            _context.Users.Remove(item);
        }

        public async Task<IEnumerable<User>> GetItemsAsync(int startPosition, int count)
        {
            return await _context.Users.Skip(startPosition).Take(count).ToListAsync();
        }

        public async Task<User?> GetUserById(string id)
        {
            return await _context.Users.FirstOrDefaultAsync(u => u.Id == id);
        }

        public void Update(User item)
        {
            _context.Users.Update(item);
        }
    }
}
