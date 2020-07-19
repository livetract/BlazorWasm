using JwtAuth.Dtos;

namespace JwtAuth.Services
{
    public interface IGeneralService
    {
        string BuildToken(JwtDto model);
        string EncryptPassword(string password);
    }
}