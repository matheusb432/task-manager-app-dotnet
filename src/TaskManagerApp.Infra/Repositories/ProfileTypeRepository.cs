using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagerApp.Domain.Models;
using TaskManagerApp.Infra.Interfaces;

namespace TaskManagerApp.Infra.Repositories
{
    internal class ProfileTypeRepository : Repository<ProfileType>, IProfileTypeRepository
    {
        public ProfileTypeRepository(TaskManagerContext context) : base(context)
        {
        }
    }
}
