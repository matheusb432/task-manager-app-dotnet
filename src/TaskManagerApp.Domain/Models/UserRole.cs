using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManagerApp.Domain.Models
{
    public sealed class UserRole : Entity
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
        public User? User { get; set; }
        public Role? Role { get; set; }
    }
}
