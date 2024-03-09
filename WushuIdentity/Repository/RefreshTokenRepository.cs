using Microsoft.EntityFrameworkCore;
using WushuIdentity.Data;
using WushuIdentity.Models;
using WushuIdentity.Repository.Interfaces;

namespace WushuIdentity.Repository
{
    public class RefreshTokenRepository:IRefreshTokenRepository
    {
        private readonly DataContext _dataContext;

        public RefreshTokenRepository(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public async Task CreateRefreshToken(RefreshToken refreshToken)
        {
            await _dataContext.RefreshTokens.AddAsync(refreshToken);
            await _dataContext.SaveChangesAsync();
        }

        public async Task<RefreshToken> GetRefreshToken(TokenRequest tokenRequest)
        {
            var refreshToken =
                await _dataContext.RefreshTokens.FirstOrDefaultAsync(elem => elem.Token == tokenRequest.RefreshToken);

            return refreshToken;

        }

        public async Task UpdateRefreshToken(RefreshToken refreshToken)
        {
            var token = await _dataContext.RefreshTokens.FirstOrDefaultAsync(elem => elem.Id == refreshToken.Id);
            token.IsUsed = refreshToken.IsUsed;
            await _dataContext.SaveChangesAsync();
        }
    }
}
