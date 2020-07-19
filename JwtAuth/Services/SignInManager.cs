using System;
using System.Threading.Tasks;
using AutoMapper;
using JwtAuth.Dtos;
using JwtAuth.Entities;

namespace JwtAuth.Services
{
    public class SignInManager : ISignInManager
    {
        private readonly IGeneralService _generalService;
        private readonly IMapper _mapper;
        private readonly IUserManager _userManager;

        public SignInManager(IGeneralService generalService, IMapper mapper, IUserManager userManager)
        {
            _generalService = generalService;
            _mapper = mapper;
            _userManager = userManager;
        }


        public Task SignInAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<string> SignInPasswordAsync(IdentityUser model, string password)
        {
            var jwtUser = _mapper.Map<JwtDto>(model);
            var token = await Task.Run(() => _generalService.BuildToken(jwtUser));
            return token;
        }
    }
}