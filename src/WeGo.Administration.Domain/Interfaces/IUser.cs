using System.Collections.Generic;
using System.Security.Claims;

namespace WeGo.Administration.Domain.Interfaces
{
    public interface IUser
    {
        string Name { get; }

        IEnumerable<Claim> GetClaimsIdentity();

        bool IsAuthenticated();
    }
}