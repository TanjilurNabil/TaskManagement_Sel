using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Domain.Entities
{
    public class User
    {
        public Guid Id { get; init; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public UserRole Role { get; set; }
    }
    public enum UserRole
    {
        Admin,
        Manager,
        Employee
    }
}
