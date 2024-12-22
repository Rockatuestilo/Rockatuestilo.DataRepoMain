using System;
using System.Linq;
using NUnit.Framework;
using Rockatuestilo.DataRepoMain.Tests.DbInit;
using UoWRepo.Persistence.UnitiesOfWork;

namespace Rockatuestilo.DataRepoMain.Tests.Units.CRUDS.EF.ByOperations;

public class SubjectsMediaTestsEf
{
    private IUnitOfWorkEf _unitOfWorkEf;

    [OneTimeSetUp]
    public void Setup()
    {
        var testFileName = "test_SubjectsMediaTestsEf.db";
        
        //delete file is exists
        if (System.IO.File.Exists(testFileName))
        {
            System.IO.File.Delete(testFileName);
        }
        
        //var context = new ContextGenerator().CreateInSqlite(testFileName);
        var context = new ContextGenerator().CreateInMysql();
        _unitOfWorkEf = new UnityOfWorkEf(context);
    }

  

    [Test]
    public void Test_AddSubject()
    {
        var subject = new Subjects
        {
            Guid = Guid.NewGuid(),
            Name = "Test Subject",
            Type = "Artist",
            Description = "A test subject description."
        };

        _unitOfWorkEf.Subjects.Add(subject);
        _unitOfWorkEf.Complete();

        var result = _unitOfWorkEf.Subjects.GetAll().ToList();

        Assert.That(result.Count, Is.EqualTo(1));
        Assert.That(result[0].Name, Is.EqualTo("Test Subject"));
    }

    [Test]
    public void Test_AddMedia()
    {
        var media = new Media
        {
            Guid = Guid.NewGuid(),
            FilePath = "/path/to/file.jpg",
            MediaType = "Image",
            CreatedDate = DateTime.UtcNow
        };

        _unitOfWorkEf.Media.Add(media);
        _unitOfWorkEf.Complete();

        var result = _unitOfWorkEf.Media.GetAll().ToList();

        Assert.That(result.Count, Is.GreaterThanOrEqualTo(1));
        Assert.That(result[0].FilePath, Is.EqualTo("/path/to/file.jpg"));
    }

    [Test]
    public void Test_AddSubjectMedia()
    {
        var subject = new Subjects
        {
            Guid = Guid.NewGuid(),
            Name = "Test Subject",
            Type = "Person",
            Description = "Description"
        };
        var media = new Media
        {
            Guid = Guid.NewGuid(),
            FilePath = "/path/to/file.jpg",
            MediaType = "Image"
        };

        _unitOfWorkEf.Subjects.Add(subject);
        _unitOfWorkEf.Media.Add(media);
        _unitOfWorkEf.Complete();

        var subjectMedia = new SubjectMedia
        {
            Guid = Guid.NewGuid(),
            SubjectGuid = subject.Guid,
            MediaGuid = media.Guid,
            IsFeatured = true
        };

        _unitOfWorkEf.SubjectMedia.Add(subjectMedia);
        _unitOfWorkEf.Complete();

        var result = _unitOfWorkEf.SubjectMedia.GetAll().ToList();

        Assert.That(result.Count, Is.EqualTo(1));
        Assert.That(result[0].IsFeatured, Is.True);
    }

    [Test]
    public void Test_AddContentMedia()
    {
        var media = new Media
        {
            Guid = Guid.NewGuid(),
            FilePath = "/path/to/file.jpg",
            MediaType = "Image"
        };

        var contentGuid = Guid.NewGuid();

        _unitOfWorkEf.Media.Add(media);
        _unitOfWorkEf.Complete();

        var contentMedia = new ContentMedia
        {
            Guid = Guid.NewGuid(),
            ContentGuid = contentGuid,
            MediaGuid = media.Guid,
            Role = "Featured"
        };

        _unitOfWorkEf.ContentMedia.Add(contentMedia);
        _unitOfWorkEf.Complete();

        var result = _unitOfWorkEf.ContentMedia.GetAll().ToList();

        Assert.That(result.Count, Is.EqualTo(1));
        Assert.That(result[0].Role, Is.EqualTo("Featured"));
    }
    
    [OneTimeTearDown]
    public void TearDown()
    {
        var allSubjects = _unitOfWorkEf.Subjects.GetAll().ToList();
        var allMedia = _unitOfWorkEf.Media.GetAll().ToList();
        var allSubjectMedia = _unitOfWorkEf.SubjectMedia.GetAll().ToList();
        var allContentMedia = _unitOfWorkEf.ContentMedia.GetAll().ToList();

        if (allSubjects.Count > 0)
            _unitOfWorkEf.Subjects.RemoveRange(allSubjects);

        if (allMedia.Count > 0)
            _unitOfWorkEf.Media.RemoveRange(allMedia);

        if (allSubjectMedia.Count > 0)
            _unitOfWorkEf.SubjectMedia.RemoveRange(allSubjectMedia);

        if (allContentMedia.Count > 0)
            _unitOfWorkEf.ContentMedia.RemoveRange(allContentMedia);

        _unitOfWorkEf.Complete();
        _unitOfWorkEf = null;
    }
}