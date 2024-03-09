using WushuIdentity.Models;

namespace WushuIdentity.Repository.Interfaces
{
    public interface IRefreshTokenRepository
    {
        Task CreateRefreshToken(RefreshToken refreshToken);
        Task<RefreshToken> GetRefreshToken(TokenRequest tokenRequest);

        Task UpdateRefreshToken(RefreshToken refreshToken);
    }
}
