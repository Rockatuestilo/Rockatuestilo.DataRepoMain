using System;
using System.Linq;
using NUnit.Framework;
using Rockatuestilo.DataRepoMain.Tests.DbInit;
using UoWRepo.Persistence.UnitiesOfWork;
using UoWRepo.Core.EFDomain;

namespace Rockatuestilo.DataRepoMain.Tests.Units.CRUDS.EF;

public class GalleriesCruds
{
    private IUnitOfWorkEf _unitOfWorkEf;

    [SetUp]
    public void Setup()
    {
        var value = new ContextGenerator().CreateInMysql();
        _unitOfWorkEf = new UnityOfWorkEf(value);
    }
    
    [Test]
    public void Test1_add1()
    {

        var valueForTest =
            "{\"GalleryOwner\":0,\"GalleryName\":\"20240119_myhome_greatetest\",\"GalleryPath\":\"20240119_myhome_greatetest\",\"CreatedById\":0,\"UpdatedById\":0,\"CategoryLevel\":0,\"PublishType\":0,\"Id\":0,\"CreatedDate\":\"2024-01-19T16:08:48.425284+01:00\",\"UpdatedDate\":\"2024-01-19T16:08:48.425362+01:00\"}";
        
        var gallery = Newtonsoft.Json.JsonConvert.DeserializeObject<Galleries>(valueForTest);
        
        
        
        _unitOfWorkEf.Galleries.AddWithIdentity(gallery);
        _unitOfWorkEf.Complete();
        


        var result = _unitOfWorkEf.Galleries.GetAll().ToList();

     

        Assert.AreEqual(result.Count, 1);

        //IHashTags hashTags = result[0];
    }

}