using Microsoft.EntityFrameworkCore;
using PRM392_API.Models;
using PRM392_API.Repositories.Interface;

namespace PRM392_API.Repositories.Implementation
{
    public class FCMTokenRepository : IFCMTokenRepository
    {
        private readonly PRM392Context _context;

        public FCMTokenRepository(PRM392Context context)
        {
            _context = context;
        }

        public async Task AddOrUpdateTokenAsync(FCMToken fCMToken)
        {
            var existingToken = _context.FCMTokens
                .FirstOrDefault(t => t.UserId == fCMToken.UserId);
            if (existingToken != null)
            {
                existingToken.Token = fCMToken.Token;
                _context.FCMTokens.Update(existingToken);
            }
            else
            _context.FCMTokens.Add(fCMToken);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<FCMToken>> GetTokensByUserIdAsync(int[] userIds)
        {
            return await _context.FCMTokens
                .Where(t => userIds.Contains(t.UserId))
                .ToListAsync();
        }
    }
}
