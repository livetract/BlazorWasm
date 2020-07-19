using System;
using System.Threading.Tasks;
using JwtAuth.Dtos;
using JwtAuth.Entities;

namespace JwtAuth.Services
{
    public interface ISignInManager
    {
        // 登录管理
        /*1. 用户登录，成功后还要发token
         * 
         */


        Task SignInAsync(Guid id);

        Task<string> SignInPasswordAsync(IdentityUser model, string password);
    }
}