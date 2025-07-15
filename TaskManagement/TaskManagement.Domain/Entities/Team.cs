using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Domain.Entities
{
    public class Team
    {
        public Guid Id { get; init; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<User> Members { get; set; }
    }
}
