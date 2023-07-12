using ProjectTemplate.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTemplate.Application.Abstractions.Repositories
{
    public interface ITransactionTypeRepository
    {
        Task<TransactionType?> GetByIdAsync(int Id, bool tracking = true);
        Task CreateAsync(TransactionType transactionType);
    }
}
