using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Application.Features.Users.Queries.GetUserById
{
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, UserDto>
    {
        public async Task<UserDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            // In a real scenario, you'd fetch the user from the database.
            // var user = await _userRepository.GetByIdAsync(request.Id);

            // For now, let's simulate a user.
            if (request.Id == Guid.Empty) // Simple check for demonstration
            {
                return null; // Or throw an exception for not found
            }

            var simulatedUser = new UserDto
            {
                Id = request.Id,
                FullName = "Simulated User Name",
                Email = "simulated@example.com",
                Role = "Employee"
            };

            Console.WriteLine($"Simulated user retrieved: {simulatedUser.FullName}"); // Temporary for demonstration

            return await Task.FromResult(simulatedUser);
        }
    }
}
