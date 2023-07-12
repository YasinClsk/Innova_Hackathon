using ProjectTemplate.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTemplate.Application.Abstractions.Repositories
{
    public interface ITransactionRepository 
    {
        Task<Transaction?> GetByIdAsync(int Id, bool tracking = true);
        Task CreateAsync(Transaction transactionType);
    }
}
