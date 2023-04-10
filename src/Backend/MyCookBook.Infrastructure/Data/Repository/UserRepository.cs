using Microsoft.EntityFrameworkCore;
using MyCookBook.Domain.Entities;
using MyCookBook.Domain.Repository;
using MyCookBook.Infrastructure.Context;

namespace MyCookBook.Infrastructure.Data.Repository
{
    public class UserRepository : IUserReadOnlyRepository, IUserWriteOnlyRepository
    {
        private readonly MyCookBookContext _context;

        public UserRepository(MyCookBookContext context)
        {
            _context = context;
        }

        public async Task Add(User user)
        {
            await _context.Users.AddAsync(user);
        }

        public async Task<bool> IsUserEmailExists(string email)
        {
            return await _context.Users.AnyAsync(e => e.Email.Equals(email));
        }
    }
}
