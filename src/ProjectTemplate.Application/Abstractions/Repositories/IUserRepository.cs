using ProjectTemplate.Application.DTO_s;
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
        Task<User?> GetByIdAsync(int id);

        Task<List<UserCharges>> UserCharges(int id);

        Task CreateAsync(User user);
        Task CreateAsync(List<User> users);
        Task<bool> AnyAsync(User user);
        Task<bool> AnyAsync(int Id);
    }
}
