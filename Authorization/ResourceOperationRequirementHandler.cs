using CarServiceMate.Entities;
using Microsoft.AspNetCore.Authorization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace CarServiceMate.Authorization
{
    public class ResourceOperationRequirementHandler : AuthorizationHandler<ResourceOperationRequirement, IEnumerable<Vehicle>>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, ResourceOperationRequirement requirement, IEnumerable<Vehicle> vehicles)
        {
            var companyIdClaim = context.User.FindFirst(c => c.Type == "CompanyId").Value;

            if (companyIdClaim == null || !int.TryParse(companyIdClaim, out var companyId))
            {
                return Task.CompletedTask;
            }
            var vehiclesBelongingToCompany = vehicles.Where(v => v.IdCompany == companyId);

            if (vehiclesBelongingToCompany.Any())
            {
                context.Succeed(requirement);
            }

            return Task.CompletedTask;
        }
    }
}
