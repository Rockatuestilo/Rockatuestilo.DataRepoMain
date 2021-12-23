using NUnit.Framework;
using Rockatuestilo.DataRepoMain.Tests.DbInit;
using UoWRepo.Persistence.UnitiesOfWork;

namespace Rockatuestilo.DataRepoMain.Tests.CRUDS.EF;

public class HashTagsCrudsEf
{
    [SetUp]
    public void Setup()
    {
        var value = new ContextGenerator().CreateInMemory();
        _unitOfWorkEf = new UnityOfWorkEf(value);
    }

    private IUnitOfWorkEf _unitOfWorkEf;
}