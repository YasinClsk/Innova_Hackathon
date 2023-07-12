using Microsoft.EntityFrameworkCore;
using ProjectTemplate.Application.Abstractions.Repositories;
using ProjectTemplate.Domain.Entities;
using ProjectTemplate.Infrastructure.Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTemplate.Infrastructure.Persistance.Repositories
{
    public class TransactionRepository : ITransactionRepository
    {
        private readonly ApplicationDbContext _context;

        public TransactionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        private DbSet<Transaction> Table => _context.Transactions;

        public async Task<bool> AnyAsync(Transaction transaction)
        {
            return await AnyAsync(transaction.Id);
        }

        public async Task<bool> AnyAsync(int Id)
        {
            return await Table.AnyAsync(x => x.Id == Id);
        }

        public async Task CreateAsync(Transaction transactionType)
        {
            await Table.AddAsync(transactionType);
        }

        public async Task Delete(int Id)
        {
            var transaction = await Table.FirstOrDefaultAsync(x => x.Id == Id);
            
            if(transaction is null) 
                throw new ArgumentNullException(nameof(transaction));

            Table.Remove(transaction);
        }

        public async Task<Transaction?> GetByIdAsync(int Id, bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();

            return await Table.FindAsync(Id);
        }

        public void Update(Transaction transactionType)
        {
            Table.Update(transactionType);
        }
    }
}
