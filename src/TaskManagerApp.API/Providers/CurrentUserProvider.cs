using System.Security.Claims;
using TaskManagerApp.Application.Common.Interfaces;

namespace TaskManagerApp.API.Services
{
    public class CurrentUserProvider : ICurrentUserProvider
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public CurrentUserProvider(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public int UserId => GetHttpContextUserId();
        public bool IsAdmin => GetHttpContextIsAdmin();

        public bool IsUserOrAdmin(int userId)
        {
            return IsAdmin || UserId == userId;
        }

        private int GetHttpContextUserId()
        {
            return int.Parse(
                _httpContextAccessor.HttpContext?.User?.FindFirst("UserId")?.Value ?? "-1"
            );
        }

        private bool GetHttpContextIsAdmin()
        {
            var identity = _httpContextAccessor.HttpContext?.User?.Identity as ClaimsIdentity;
            if (identity == null)
                return false;
            IEnumerable<Claim> claims = identity.Claims;
            var adminClaim = claims.FirstOrDefault(
                x => x.Type == identity.RoleClaimType && x.Value == "ADMIN"
            );

            return adminClaim != null;
        }
    }
}
