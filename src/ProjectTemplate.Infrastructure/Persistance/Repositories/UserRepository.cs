using Microsoft.EntityFrameworkCore;
using ProjectTemplate.Application.Abstractions.Repositories;
using ProjectTemplate.Application.DTO_s;
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

        public async Task Delete(int id)
        {
            var user = await Table.FirstOrDefaultAsync(x => x.Id == id);
            Table.Remove(user!);
        }

        public IQueryable<User> Get(Expression<Func<User, bool>> expression, bool tracking = true)
        {
            var query = Table.Where(expression);

            if(!tracking)
                query = query.AsNoTracking();

            return  _dbContext.Users
                .Where(expression);
        }

        public async Task<List<User>> GetAllAsync()
        {
            return await Table.ToListAsync();
        }

        public async Task<User?> GetByIdAsync(int id)
        {
            var user = await Table.Include(x => x.TransactionTypes)
                .ThenInclude(x => x.Transactions.OrderByDescending(x => x.TransactionDate).Take(5))
                .FirstOrDefaultAsync(x => x.Id == id);

            return user;
        }

        public async Task<User?> GetByMailAsync(string mail)
        {
            var user = await Table
                .FirstOrDefaultAsync(x => x.Email == mail);

            return user;
        }

        public void Update(User user)
        {
            Table.Update(user);
        }

        public async Task<List<UserCharges>> UserCharges(int id)
        {
            var userCharges = await _dbContext.TransactionTypes
                .Include(x => x.Transactions)
                .Where(x => x.UserId == id)
                .Select(x => new UserCharges
                {
                    Id = x.Id,
                    Cost = x.Transactions.Sum(x => x.Cost),
                    Title = x.Title
                }).ToListAsync();

            userCharges.Add(new UserCharges
            {
                Id = 0,
                Cost = userCharges.Sum(x => x.Cost),
                Title = "Total"
            }); 

            return userCharges;
        }

        public async Task<decimal> UserChargesBetweenDates(int id, DateOnly StartDate, DateOnly EndDate)
        {
            var transactionTypes = await _dbContext.TransactionTypes
                .Include(x => x.Transactions
                .Where(x => DateOnly.FromDateTime(x.TransactionDate) >= StartDate && DateOnly.FromDateTime(x.TransactionDate) <= EndDate))
                .Where(x => x.UserId == id)
                .ToListAsync();

            decimal cost = 0;
            foreach (var transactionType in transactionTypes)
            {
                cost += transactionType.Transactions.Sum(x => x.Cost);
            }

            return cost;
        }
    }
}
