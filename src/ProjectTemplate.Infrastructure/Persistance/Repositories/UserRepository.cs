using Microsoft.EntityFrameworkCore;
using ProjectTemplate.Application.Abstractions.Repositories;
using ProjectTemplate.Domain.Entities;
using ProjectTemplate.Infrastructure.Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTemplate.Infrastructure.Persistance.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _dbContext;


        public UserRepository(ApplicationDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        private DbSet<User> Table => _dbContext.Users;

        public async Task<bool> AnyAsync(User user)
        {
            return await AnyAsync(user.Id);
        }

        public async Task<bool> AnyAsync(int Id)
        {
            return await Table.AnyAsync(x => x.Id == Id);
        }

        public async Task CreateAsync(User user)
        {
            await Table.AddAsync(user);
        }

        public async Task CreateAsync(List<User> users)
        {
            await Table.AddRangeAsync(users);
        }

        public IQueryable<User> Get(Expression<Func<User, bool>> expression, bool tracking = true)
        {
            var query = Table.Where(expression);

            if(!tracking)
                query = query.AsNoTracking();

            return  _dbContext.Users
                .Where(expression);
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            var user = await Table.Include(x => x.TransactionTypes)
                .ThenInclude(x => x.Transactions)
                .FirstOrDefaultAsync(x => x.Id == id);

            return user;
        }

        public async Task<User?> GetUserTransactions(int id)
        {
            var user = await Table.Include(x => x.TransactionTypes)
                .ThenInclude(x => x.Transactions)
                .FirstOrDefaultAsync(x => x.Id == id);

            return user;
        }
    }
}
