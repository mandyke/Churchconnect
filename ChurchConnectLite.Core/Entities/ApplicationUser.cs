using Microsoft.AspNetCore.Identity;

namespace ChurchConnectLite.Core.Entities
{
    public class ApplicationUser: IdentityUser
    {
        public string ChurchName { get; set; }

        public Church Churches { get; set; }
    }
}
