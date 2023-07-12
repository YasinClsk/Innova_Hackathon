using ProjectTemplate.Application.RequestParameters;
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
        Task<TransactionType?> GetByIdAsync(int Id, Pagination pagination);
        Task CreateAsync(TransactionType transactionType);
        Task<bool> AnyAsync(TransactionType transactionType);
        Task<bool> AnyAsync(int Id);
        void Update(TransactionType transactionType);
        Task Delete(int id);
    }
}
