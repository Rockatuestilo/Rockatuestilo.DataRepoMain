using System.Collections.Generic;
using UoWRepo.Core.Domain;

namespace Rockatuestilo.DataRepoMain.Tests.TestData.Roles;

public class TestDataRoles1
{
    public List<UoWRepo.Core.EFDomain.RoleModels> GetRolesStaticEf()
    {
        var result = GetRolesStatic();
        
        return result.ConvertAll(x => new UoWRepo.Core.EFDomain.RoleModels()
        {
            Active = x.Active,
            RoleName = x.RoleName,
            RoleCode = x.RoleCode,
            Description = x.Description
        });
        
    }
    
    
    public List<RoleModels> GetRolesStatic()
    {
        // Admin role has full access to the system
        RoleModels adminRole = new RoleModels()
        {
            Active = true,
            RoleName = "Administrator",
            RoleCode = "Admin",
            Description = "This role has full access to the system."
        };

// Editor role can create, edit, and publish articles
        RoleModels editorRole = new RoleModels()
        {
            Active = true,
            RoleName = "Editor",
            RoleCode = "Editor",
            Description = "This role can create, edit, and publish articles."
        };

// Writer role can create and edit their own articles, but not publish them
        RoleModels writerRole = new RoleModels()
        {
            Active = true,
            RoleName = "Writer",
            RoleCode = "Writer",
            Description = "This role can create and edit their own articles, but not publish them."
        };

// Reviewer role can review articles and send them back to writers for revision
        RoleModels reviewerRole = new RoleModels()
        {
            Active = true,
            RoleName = "Reviewer",
            RoleCode = "Reviewer",
            Description = "This role can review articles and send them back to writers for revision."
        };

// Reader role can only read published articles
        RoleModels readerRole = new RoleModels()
        {
            Active = true,
            RoleName = "Reader",
            RoleCode = "Reader",
            Description = "This role can only read published articles."
        };

        return new List<RoleModels>() { adminRole, editorRole, writerRole, reviewerRole, readerRole };
    }
}