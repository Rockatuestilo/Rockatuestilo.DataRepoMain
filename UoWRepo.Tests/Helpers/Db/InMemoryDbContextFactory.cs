using Microsoft.EntityFrameworkCore;
using UoWRepo.Core.Configuration;

namespace UoWRepo.Tests.Helpers.Db;

/// <summary>
    /// Factory para crear instancias de EFContext usando el proveedor InMemory de EF Core.
    /// Permite aislar cada test con su propia base de datos en memoria.
    /// </summary>
    public static class InMemoryDbContextFactory
    {
        /// <summary>
        /// Crea un EFContext configurado con una base de datos en memoria.
        /// </summary>
        /// <param name="dbName">
        /// Nombre único para la base de datos en memoria. 
        /// Usar un GUID o TestContext.CurrentContext.Test.ID para aislar tests.
        /// </param>
        public static EFContext Create(string dbName)
        {
            var options = new DbContextOptionsBuilder<EFContext>()
                .UseInMemoryDatabase(databaseName: dbName)
                .EnableSensitiveDataLogging()   // Opcional: para ver valores en excepciones
                .Options;

            // Si tu EFContext tiene un ctor que acepta opciones:
            return new EFContext(options);
        }
    }

    /// <summary>
    /// Test base que configura y destruye el contexto en cada test.
    /// Hereda de él tus clases de test para tener un DI mínimo.
    /// </summary>
    public abstract class InMemoryTestBase : IDisposable
    {
        protected readonly EFContext Context;
        private readonly string _dbName;

        protected InMemoryTestBase()
        {
            // Usa el ID del test para que cada prueba tenga su propia base:
            _dbName = TestContext.CurrentContext.Test.ID;
            Context = InMemoryDbContextFactory.Create(_dbName);

            // Opcional: dispara migraciones o seed inicial:
            // Context.Database.EnsureCreated();
            SeedData();
        }

        /// <summary>
        /// Si quieres precargar datos antes de cada test, sobreescribe este método.
        /// </summary>
        protected virtual void SeedData()
        {
            // Ejemplo:
            // Context.Authors.Add(new Authors { FullName = "Test", Presentation = "..." });
            // Context.SaveChanges();
        }

        public void Dispose()
        {
            // Limpia la base de datos tras el test
            Context.Database.EnsureDeleted();
            Context.Dispose();
        }
    }