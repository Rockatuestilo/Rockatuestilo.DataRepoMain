using Microsoft.EntityFrameworkCore;
using UoWRepo.Core.EFDomain;
using UoWRepo.Tests.Helpers.Db;

namespace UoWRepo.Tests.Units.Test
{
    public class MediaRepositoryTests : InMemoryTestBase
    {
        protected override void SeedData()
        {
            // Pre-carga un Author
            var author = new Authors {
                Guid = Guid.NewGuid(),
                FullName = "Autor Test",
                Presentation = "Desc",
                CreatedDate = DateTime.UtcNow
            };
            Context.Authors.Add(author);
            Context.SaveChanges();
        }

        [Test]
        public void Can_Add_And_Retrieve_Media()
        {
            // Arrange
            var media = new Media {
                Guid = Guid.NewGuid(),
                FilePath = "/ruta.png",
                MediaType = "Image",
                CreatedDate = DateTime.UtcNow
            };

            // Act
            Context.Media.Add(media);
            Context.SaveChanges();

            // Assert
            var stored = Context.Media.Single(m => m.Guid == media.Guid);
            Assert.That(stored.FilePath, Is.EqualTo(media.FilePath));
        }

        [Test]
        public void Can_Link_Media_To_Author()
        {
            // Arrange
            var author = Context.Authors.Single();
            var media = new Media {
                Guid = Guid.NewGuid(),
                FilePath = "/img.jpg",
                MediaType = "Image",
                AuthorGuid = author.Guid,
                CreatedDate = DateTime.UtcNow
            };

            // Act
            Context.Media.Add(media);
            Context.SaveChanges();

            // Assert
            var linked = Context.Media
                .Where(m => m.AuthorGuid == author.Guid)
                //.Include(m => m.Author)     // <-- Carga explícita de la navegación
                .ToList();

            Assert.That(linked, Has.Exactly(1).Items);
            //Assert.That(linked[0].Author.FullName, Is.EqualTo(author.FullName));
        }
    }
}
