using System.ComponentModel.DataAnnotations.Schema;

namespace TaskManagerApp.Domain.Models
{
    public sealed class Role : Entity
    {
        public Role()
        {
            UserRoles = new();
        }

        public string Name { get; set; } = string.Empty;

        public List<UserRole> UserRoles { get; set; }
    }
}
