using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Domain.Entities;

namespace TaskManagement.Application.Interfaces
{
    // If you need user-specific methods beyond generic CRUD, define them here.
    // For now, we'll just inherit from the generic one.
    public interface IUserRepository:IGenericRepository<User>
    {
        Task<User> GetByEmailAsync(string email);
    }
}
