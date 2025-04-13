using UoWRepo.Core.BaseDomain;
using UoWRepo.Core.EFDomain;
// Adjust namespace based on your project structure

namespace UoWRepo.Tests.Units.Core.BaseDomain
{
    [TestFixture]
    public class HashTagsTests
    {
        public IHashTags GetHashTagVersion1()
        {
            return new HashTags
            {
                Id = 1,
                HashtagWord = "test",
                Allowed = 1,
                CreatedById = 100,
                UpdatedById = 101,
                CreatedDate = new DateTime(2024, 3, 24),
                UpdatedDate = new DateTime(2024, 3, 24)
            };
        }
        
        public IHashTags GetHashTagVersion2()
        {
            return new HashTags
            {
                Id = 1,
                HashtagWord = "test",
                Allowed = 1,
                CreatedById = 100,
                UpdatedById = 101,
                CreatedDate = new DateTime(2024, 3, 24),
                UpdatedDate = new DateTime(2024, 3, 24)
            };
        }
        
        
        [Test]
        public void CanCreateAndRetrieveHashTag()
        {
            
            
            
            // Arrange
            var hashTag = GetHashTagVersion1();
  

            // Act and Assert
            Assert.That(hashTag.Id, Is.EqualTo(1));
            Assert.That(hashTag.HashtagWord, Is.EqualTo("test"));
            Assert.That(hashTag.Allowed, Is.EqualTo(1));
            Assert.That(hashTag.CreatedById, Is.EqualTo(100));
            Assert.That(hashTag.UpdatedById, Is.EqualTo(101));
            Assert.That(hashTag.CreatedDate, Is.EqualTo(new DateTime(2024, 3, 24)));
            Assert.That(hashTag.UpdatedDate, Is.EqualTo(new DateTime(2024, 3, 24)));
            
             hashTag = GetHashTagVersion2();
            
            // Act and Assert
            Assert.That(hashTag.Id, Is.EqualTo(1));
            Assert.That(hashTag.HashtagWord, Is.EqualTo("test"));
            Assert.That(hashTag.Allowed, Is.EqualTo(1));
            Assert.That(hashTag.CreatedById, Is.EqualTo(100));
            Assert.That(hashTag.UpdatedById, Is.EqualTo(101));
            Assert.That(hashTag.CreatedDate, Is.EqualTo(new DateTime(2024, 3, 24)));
            Assert.That(hashTag.UpdatedDate, Is.EqualTo(new DateTime(2024, 3, 24)));
        }

        [Test]
        public void CheckPropertiesEquality()
        {
            
             DomainCommonTests domainCommonTests = new DomainCommonTests();
            
            // Arrange
            var hashTagV1 = GetHashTagVersion1();
            var hashTagV2 = GetHashTagVersion2();
            
            domainCommonTests.CheckPropertiesEquality(hashTagV1, hashTagV2);
        }
    }
}