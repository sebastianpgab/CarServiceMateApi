using CarServiceMate.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CarServiceMate.Services
{
    public static class UserClaimsService
    {
        public static int GetCompanyId(ClaimsPrincipal user)
        {
            var companyIdClaim = user.FindFirst(c => c.Type == "CompanyId")?.Value;

            if (companyIdClaim == null || !int.TryParse(companyIdClaim, out var companyId))
            {
                throw new ForbidException();
            }
            return companyId;
        }
    }
}
