using System.Collections.Generic;
using UoWRepo.Core.EFDomain;

namespace Rockatuestilo.DataRepoMain.Tests.TestData.Roles;

public class TestDataRoles1
{
    public List<RoleModels> GetRolesStaticEf()
    {
        var result = GetRolesStatic();

        return result.ConvertAll(x => new RoleModels
        {
            Active = x.Active,
            Name = x.Name,
            Code = x.Code,
            Description = x.Description
        });
    }


    public List<UoWRepo.Core.LinqDomain.RoleModels> GetRolesStatic()
    {
        // Admin role has full access to the system
        var adminRole = new UoWRepo.Core.LinqDomain.RoleModels
        {
            Active = true,
            Name = "Administrator",
            Code = "Admin",
            Description = "This role has full access to the system."
        };

// Editor role can create, edit, and publish articles
        var editorRole = new UoWRepo.Core.LinqDomain.RoleModels
        {
            Active = true,
            Name = "Editor",
            Code = "Editor",
            Description = "This role can create, edit, and publish articles."
        };

// Writer role can create and edit their own articles, but not publish them
        var writerRole = new UoWRepo.Core.LinqDomain.RoleModels
        {
            Active = true,
            Name = "Writer",
            Code = "Writer",
            Description = "This role can create and edit their own articles, but not publish them."
        };

// Reviewer role can review articles and send them back to writers for revision
        var reviewerRole = new UoWRepo.Core.LinqDomain.RoleModels
        {
            Active = true,
            Name = "Reviewer",
            Code = "Reviewer",
            Description = "This role can review articles and send them back to writers for revision."
        };

// Reader role can only read published articles
        var readerRole = new UoWRepo.Core.LinqDomain.RoleModels
        {
            Active = true,
            Name = "Reader",
            Code = "Reader",
            Description = "This role can only read published articles."
        };

        return new List<UoWRepo.Core.LinqDomain.RoleModels> { adminRole, editorRole, writerRole, reviewerRole, readerRole };
    }
}