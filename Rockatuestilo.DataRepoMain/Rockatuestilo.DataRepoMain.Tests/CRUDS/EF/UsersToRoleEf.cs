using System.Linq;
using NUnit.Framework;
using Rockatuestilo.DataRepoMain.Tests.DbInit;
using UoWRepo.Core.EFDomain;
using UoWRepo.Persistence.UnitiesOfWork;

namespace Rockatuestilo.DataRepoMain.Tests.CRUDS.EF;

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
    public void Test1_add1()
    {
        var value =new UsersToRoles();

        value.User = 1;
        value.RoleGuid = 1;

        _unitOfWorkEf.UsersToRoles.Add(value);

        var result = _unitOfWorkEf.Users.GetAll().ToList();
        Assert.AreEqual(result.Count, 1);
    }
}