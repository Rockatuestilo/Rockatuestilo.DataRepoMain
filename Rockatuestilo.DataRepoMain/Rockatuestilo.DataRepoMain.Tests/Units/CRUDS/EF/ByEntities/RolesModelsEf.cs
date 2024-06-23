using System.Linq;
using NUnit.Framework;
using Rockatuestilo.DataRepoMain.Tests.DbInit;
using Rockatuestilo.DataRepoMain.Tests.TestData.Roles;
using UoWRepo.Persistence.UnitiesOfWork;

namespace Rockatuestilo.DataRepoMain.Tests.Units.CRUDS.EF.ByEntities;

public class RolesModelsEf
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
        var roleModelsList = new TestDataRoles1().GetRolesStaticEf();

        _unitOfWorkEf.Roles.AddRange(roleModelsList);
        _unitOfWorkEf.Complete();

        var result = _unitOfWorkEf.Roles.GetAll().ToList();
        Assert.Greater(result.Count, 0);
    }
}