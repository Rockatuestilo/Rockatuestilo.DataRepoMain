using NUnit.Framework;
using Rockatuestilo.DataRepoMain.Tests.DbInit;
using UoWRepo.Persistence.UnitiesOfWork;

namespace Rockatuestilo.DataRepoMain.Tests.CRUDS.EF;

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
        /*var roleModelsList = new TestDataRoles1().GetFirstExample();
            
        _unitOfWorkEf.Roles.Add(roleModelsList[0]);

        var result = _unitOfWork.Users.GetAll().ToList();
        Assert.AreEqual(result.Count, 1);*/
    }

}