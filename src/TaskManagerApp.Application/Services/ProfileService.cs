using AutoMapper;
using TaskManagerApp.Application.Interfaces;
using TaskManagerApp.Application.ViewModels.Profile;
using TaskManagerApp.Domain.Models.Validators;
using TaskManagerApp.Infra.Interfaces;
using Profile = TaskManagerApp.Domain.Models.Profile;

namespace TaskManagerApp.Application.Services
{
    public class ProfileService : EntityService<
        Profile,
        ProfileViewModel, 
        ProfilePostViewModel, 
        ProfilePutViewModel, 
        ProfileValidator>, IProfileService
    {
        public ProfileService(IProfileRepository repo, IMapper mapper)
            : base(mapper, repo)
        {
        }
    }
}