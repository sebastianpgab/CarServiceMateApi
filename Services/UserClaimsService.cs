using CarServiceMate.Exceptions;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CarServiceMate.Services
{
    public class UserClaimsService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;
        public UserClaimsService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public ClaimsPrincipal User => _httpContextAccessor.HttpContext.User;
        public int companyId => GetCompanyId(User);

        public int GetCompanyId(ClaimsPrincipal user)
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
