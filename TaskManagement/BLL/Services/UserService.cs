using DLL.Repositories;
using Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class UserService
    {
        private readonly UserRepository _userRepository;

        public UserService(UserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<OperationDetail> CreateAsync (User user)
        {
            return await _userRepository.CreatAsync(user);
        }
        public async Task<OperationDetail> UpdateAsync(User user)
        {
            return await _userRepository.UpdateAsync(user);
        }
        public async Task<OperationDetail> RemoveAsync(int userId)
        {
            return await _userRepository.RemoveAsync(userId);
        }
        public async Task<IReadOnlyCollection<User>> FindByConditionAsync(Expression<Func<User, bool>> expression)
        {
            return await _userRepository.FindByConditionAsync(expression);
        }
        public async Task<IReadOnlyCollection<User>> GetAllAsync()
        {
            return await _userRepository.GetAllAsync();
        }
    }
}
