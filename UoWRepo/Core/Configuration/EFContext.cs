using System;
using Microsoft.EntityFrameworkCore;
using UoWRepo.Core.EFDomain;

namespace UoWRepo.Core.Configuration
{
    public class EFContext: DbContext, ICommonContext
    {
        private readonly string connectionString;

        public EFContext(DbContextOptions<EFContext> options)
            : base(options)
        { }

        public EFContext(string connectionString)
        {
            this.connectionString = connectionString;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            try
            {
                if (string.IsNullOrEmpty(connectionString))
                {
                    return;
                }
                
                optionsBuilder.UseMySql(connectionString,
                    new MariaDbServerVersion(new Version(10, 5, 8)) 
                    );
            }
            catch (TypeLoadException exception)
            {
                var gh = exception.Message;

            }
        }
        
        public DbSet<ArticlesViewForUI> ArticlesViewForUI { get; set; }

        public DbSet<NewsEtty> NewsEtty { get;set; }

        public DbSet<Galleries> Galleries { get; set; }

        public DbSet<Users> Users { get; set; }

        public DbSet<Categories> Categories { get; set; }

        public DbSet<HashTags> HashTags { get; set; }

        public DbSet<HashTagsNews> HashtagsNews { get; set; }

        public DbSet<SharingSocialNetworkLinqDB> SharingSocialNetwork { get; set; }

        public DbSet<SharedObjectLinqDB> SharedObject { get; set; }

        public DbSet<NewsPublicationType> NewsPublicationType { get; set; }
        
        public DbSet<PendingRegistration> PendingRegistration { get; set; }
        
        public DbSet<RoleModels> Roles { get; set; }
        public DbSet<UsersToRoles> UsersToRoles { get; set; }

    }
}
