using ProjectTemplate.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTemplate.Application.Abstractions.Repositories
{
    public interface IUserRepository
    {
        IQueryable<User> Get(Expression<Func<User, bool>> expression, bool tracking = true);
        Task<User?> GetByIdAsync(int Id, bool tracking = true);
        Task CreateAsync(User user);
        Task CreateAsync(List<User> users);
    }
}
