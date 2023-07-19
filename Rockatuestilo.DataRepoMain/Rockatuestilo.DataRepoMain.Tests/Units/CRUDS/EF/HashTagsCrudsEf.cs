using System;
using System.Linq;
using NUnit.Framework;
using Rockatuestilo.DataRepoMain.Tests.DbInit;
using UoWRepo.Core.EFDomain;
using UoWRepo.Persistence.UnitiesOfWork;

namespace Rockatuestilo.DataRepoMain.Tests.Units.CRUDS.EF;

public class HashTagsCrudsEf
{
    private IUnitOfWorkEf _unitOfWorkEf;

    [SetUp]
    public void Setup()
    {
        var value = new ContextGenerator().CreateInMemory();
        _unitOfWorkEf = new UnityOfWorkEf(value);
    }


    [Test]
    public void Test1_add1()
    {
        var value = new HashTags();
        value.Allowed = 1;
        value.CreatedDate = DateTime.Now;
        value.HashtagWord = "zorro";
        value.UpdatedDate = DateTime.Now;
        value.CreatedById = 0;
        value.UpdatedById = 0;


        var result = _unitOfWorkEf.HashTags.GetAll().ToList();

        if (result.Count == 0)
        {
            //var users = new TestDataUsers1().GetDataEf();

            _unitOfWorkEf.HashTags.Add(value);
            _unitOfWorkEf.Complete();
        }

        result = _unitOfWorkEf.HashTags.GetAll().ToList();

        Assert.AreEqual(result.Count, 1);

        //IHashTags hashTags = result[0];
    }
}