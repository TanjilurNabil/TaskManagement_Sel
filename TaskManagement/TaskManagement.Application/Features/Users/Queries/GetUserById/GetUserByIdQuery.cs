using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Application.Features.Users.Queries.GetUserById
{
    public class UserDto
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
    }
    public class GetUserByIdQuery:IRequest<UserDto>
    {
        public Guid Id { get; set; }
    }
}
