using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Domain.Entities
{
    public class TaskCollection
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Status Status { get; set; }
        public Guid AssignedToUserId { get; set; }
        public Guid CreatedByUserId { get; set; }
        public Guid TeamId { get; set; }
        public DateTime DueDate { get; set; }
        public User AssignedToUser { get; set; }
        public User CreatedByUser { get; set; }
        public Team Team { get; set; }
    }
    public enum Status
    {
        Todo,
        InProgress,
        Done
    }
}
