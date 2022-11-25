using System.Collections.Generic;
using UoWRepo.Core.Domain;

namespace Rockatuestilo.DataRepoMain.Tests.TestData.Roles;

public class TestDataRoles1
{
    public List<RoleModels> GetFirstExample()
    {
        RoleModels roleModels = new RoleModels()
        {
            Active = true,
            RoleName = "Max Level Administration",
            RoleCode = "Max.Level.Admin",
            Description = "This is the Max Level Of Administration"

        };
        
        RoleModels i = new RoleModels()
        {
            Active = true,
            RoleName = "Max Level Writer",
            RoleCode = "Max.Level.ItemsWriter",
            Description = "This is the Max Level OfAdministration"

        };

        return new List<RoleModels>() { roleModels, i };
    }
}