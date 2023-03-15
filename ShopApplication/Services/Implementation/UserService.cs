using ShopApplication.Models;
using ShopApplication.Repository.Interfaces;
using ShopApplication.Services.Interfaces;

namespace ShopApplication.Services.Implementation
{
    public class UserService : AbstractService, IUserService
    {
        private readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository) : base(userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<IEnumerable<User>> GetItemsAsync(int startPosition, int count)
        {
            return await _userRepository.GetItemsAsync(startPosition, count);
        }

        public async Task<User?> GetUserById(string id)
        {
            return await _userRepository.GetUserById(id);
        }

        public async Task<int> ItemsTotal()
        {
            return await _userRepository.CountAsync();
        }
    }
}
