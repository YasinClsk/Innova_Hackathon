using Microsoft.EntityFrameworkCore;
using ProjectTemplate.Application.Abstractions.Repositories;
using ProjectTemplate.Application.RequestParameters;
using ProjectTemplate.Domain.Entities;
using ProjectTemplate.Infrastructure.Persistance.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTemplate.Infrastructure.Persistance.Repositories
{
    public class TransactionTypeRepository : ITransactionTypeRepository
    {
        private readonly ApplicationDbContext _context;

        public TransactionTypeRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        private DbSet<TransactionType> Table => _context.TransactionTypes;

        public async Task<bool> AnyAsync(TransactionType transactionType)
        {
            return await AnyAsync(transactionType.Id);
        }

        public async Task<bool> AnyAsync(int Id)
        {
            return await Table.AnyAsync(x => x.Id == Id);
        }

        public async Task CreateAsync(TransactionType transactionType)
        {
            await Table.AddAsync(transactionType);
        }

        public async Task<TransactionType?> GetByIdAsync(int Id, Pagination pagination)
        {
            var transactionType = await Table
                .Include(x => x.Transactions.OrderByDescending(x => x.TransactionDate)
                .Skip((pagination.Page - 1) * pagination.Size)
                .Take(pagination.Size))
                .FirstOrDefaultAsync(x => x.Id == Id);


            return transactionType;

        }
    }
}
