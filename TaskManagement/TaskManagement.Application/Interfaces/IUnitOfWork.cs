using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Application.Interfaces
{
    public interface IUnitOfWork:IDisposable
    {
        IUserRepository Users { get; }
        // Add other repositories here as needed:
        // ITeamRepository Teams { get; }
        // ITaskRepository Tasks { get; }
        Task<int> SaveChangesAsync();
    }
}
