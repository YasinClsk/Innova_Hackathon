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
    public class TransactionTypeRepository : ITransactionTypeRepository
    {
        private readonly ApplicationDbContext _context;

        public TransactionTypeRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        private DbSet<TransactionType> Table => _context.TransactionTypes;

        public async Task CreateAsync(TransactionType transactionType)
        {
            await Table.AddAsync(transactionType);
        }

        public async Task<TransactionType?> GetByIdAsync(int Id, bool tracking = true)
        {
            var query = Table.AsQueryable();
            if (!tracking)
                query = query.AsNoTracking();

            return await Table.FindAsync(Id);
        }
    }
}
