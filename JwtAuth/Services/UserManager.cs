using System;
using System.Threading.Tasks;
using AutoMapper;
using JwtAuth.Dtos;
using JwtAuth.Entities;
using JwtAuth.Repositories;
using Microsoft.Extensions.Logging;

namespace JwtAuth.Services
{
    public class UserManager : IUserManager
    {
        private readonly IUserRepository _userRepository;
        private readonly IGeneralService _generalService;
        private readonly IMapper _mapper;
        private readonly ILogger<UserManager> _logger;

        public UserManager(IUserRepository userRepository,
            IGeneralService generalService,
            IMapper mapper, ILogger<UserManager> logger)
        {
            _userRepository = userRepository;
            _generalService = generalService;
            _mapper = mapper;
            _logger = logger;
        }
        
        public async Task<bool> CreatUserAsync(RegisterDto model)
        {
            if (await IsExists(model.UserName))
            {
                _logger.LogWarning($"用户名：{model.UserName} 已存在。");
                return false;
            }
            var pwd = _generalService.EncryptPassword(model.Password);
            var user = new IdentityUser {UserName = model.UserName, Id = Guid.NewGuid(), Password = pwd, Email = model.Email, CustomTag = model.CustomTag, RegTime = DateTime.Now};
            return await _userRepository.AddAsync(user);
        }

        public async Task<IdentityUser> FindByNameAsync(string name)
        {
            var user = await _userRepository.GetByNameAsync(name);
            //var model = _mapper.Map<UserDto>(user);
            return user;
        }

        public async Task<IdentityUser> FindByIdAsync(string id)
        {
            var user = await _userRepository.GetByNameAsync(id);
            //var model = _mapper.Map<UserDto>(user);
            return user;
        }

        public Task<bool> IsExists(string name)
        {
            return _userRepository.FindByNameAsync(name);
        }
    }
}