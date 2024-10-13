using NUnit.Framework;
using Rockatuestilo.DataRepoMain.Tests.DbInit;
using UoWRepo.Persistence.UnitiesOfWork;

namespace Rockatuestilo.DataRepoMain.Tests;

public class Tests
{
    private IUnitOfWorkEf unitOfWorkEf;

    [SetUp]
    public void Setup()
    {
        var value = new ContextGenerator().CreateInMemory();

        unitOfWorkEf = new UnityOfWorkEf(value);
    }

    [Test]
    public void Test1_CreateUnity()
    {
        Assert.That(unitOfWorkEf, Is.Not.Null);
    }
}