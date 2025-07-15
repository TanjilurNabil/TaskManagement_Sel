using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Domain.Entities;

namespace TaskManagement.Application.Features.Users.Commands.CreateUser
{
    public class CreateUserCommand:IRequest<Guid>
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public UserRole Role { get; set; }
        public string Password { get; set; }
    }
}
