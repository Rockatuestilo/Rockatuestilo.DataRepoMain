using System;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using Rockatuestilo.DataRepoMain.Tests.DbInit;
using Rockatuestilo.DataRepoMain.Tests.FakedData;
using Rockatuestilo.DataRepoMain.Tests.TestData.Roles;
using UoWRepo.Core.EFDomain;
using UoWRepo.Persistence.UnitiesOfWork;

namespace Rockatuestilo.DataRepoMain.Tests.Units.CRUDS.EF;

public class UsersToRoleEf
{
    private IUnitOfWorkEf _unitOfWorkEf;

    [SetUp]
    public void Setup()
    {
        var value = new ContextGenerator().CreateInMemory();

        //value.Database.Migrate();

        _unitOfWorkEf = new UnityOfWorkEf(value);
    }


    [Test]
    public void Test1_AddRole()
    {
        var roleModelsList = new TestDataRoles1().GetRolesStaticEf();

        //get all roles first
        var rolesExisting = _unitOfWorkEf.Roles.GetAll().ToList();

        // get a list of the roles that are in roleModelsList but not in rolesExisting
        var rolesToBeAdded = roleModelsList.Where(x => rolesExisting.All(y => y.Code != x.Code)).ToList();

        // add roles
        _unitOfWorkEf.Roles.AddRange(rolesToBeAdded);
        _unitOfWorkEf.Complete();

        // get roles
        var roles = _unitOfWorkEf.Roles.GetAll().ToList();

        var createFakeData = new CreateFakeData();
        var bugusUsers = createFakeData.DoByNumberEf(20);

        // add users
        _unitOfWorkEf.Users.AddRange(bugusUsers);
        _unitOfWorkEf.Complete();

        // get users
        var users = _unitOfWorkEf.Users.GetAll().ToList();

        // divide list of users by number of roles
        var usersPerRole = users.Count / roles.Count;

        var listOfLists = SplitList(users, usersPerRole);

        var allRolesToBeAdded = new List<UsersToRoles>();

        var i = 0;

        foreach (var list in listOfLists)
        {
            foreach (var user in list)
            {
                var role = roles[i];

                allRolesToBeAdded.Add(new UsersToRoles
                {
                    User = user.Id,
                    RoleGuid = roles[i].Id
                });
            }

            i++;
            if (i == roles.Count)
                i = 0;
        }

        _unitOfWorkEf.UsersToRoles.AddRange(allRolesToBeAdded);
        _unitOfWorkEf.Complete();

        var usersToRolesList = _unitOfWorkEf.UsersToRoles.GetAll().ToList();
        Assert.GreaterOrEqual(usersToRolesList.Count, users.Count);

        // get roles unique rolesguids
        var uniqueRolesGuids = usersToRolesList.Select(x => x.RoleGuid).Distinct().ToList();
        Assert.AreEqual(uniqueRolesGuids.Count, roles.Count);

        // get random user
        var randomUser = users[new Random().Next(0, users.Count)];

        // get roles of random user
        var rolesOfRandomUser = usersToRolesList.Where(x => x.User == randomUser.Id).ToList();
        Assert.GreaterOrEqual(rolesOfRandomUser.Count, 1);

        // get random usersToRoles
        var randomUsersToRoles = rolesOfRandomUser[new Random().Next(0, rolesOfRandomUser.Count)];


        //verify that randomUsersToRoles has roles and existent user
        Assert.IsNotNull(randomUsersToRoles.RoleGuid);
        Assert.IsNotNull(randomUsersToRoles.User);

        var userToBeTest = users.SingleOrDefault(x => x.Id == randomUsersToRoles.User);
        Assert.IsNotNull(userToBeTest);
    }

    [Test]
    public void User_Get_ReturnsExpectedValue()
    {
        // Arrange
        var expected = 123;
        var usersToRoles = new UsersToRoles { User = expected };

        // Act
        var actual = usersToRoles.User;

        // Assert
        Assert.AreEqual(expected, actual);
    }

    [Test]
    public void RoleGuid_Get_ReturnsExpectedValue()
    {
        // Arrange
        var expected = 456;
        var usersToRoles = new UsersToRoles { RoleGuid = expected };

        // Act
        var actual = usersToRoles.RoleGuid;

        // Assert
        Assert.AreEqual(expected, actual);
    }

    public List<List<T>> SplitList<T>(List<T> list, int n)
    {
        var result = new List<List<T>>();
        for (var i = 0; i < list.Count; i += n) result.Add(list.GetRange(i, Math.Min(n, list.Count - i)));
        return result;
    }
}