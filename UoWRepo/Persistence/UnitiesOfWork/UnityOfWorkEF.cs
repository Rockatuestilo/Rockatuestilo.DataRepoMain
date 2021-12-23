using UoWRepo.Core.BaseDomain;
using UoWRepo.Core.Configuration;
//using UoWRepo.Core.Domain;
using UoWRepo.Core.EFDomain;
using UoWRepo.Core.Repositories;
using UoWRepo.Persistence.Repositories;
//using UoWRepo.Persistence.Repositories;
using UoWRepo.Persistence.RepositoriesEf;

namespace UoWRepo.Persistence.UnitiesOfWork
{
    public class UnityOfWorkEf: IUnitOfWorkEf
    {
        
        private EFContext _context;

        public UnityOfWorkEf(EFContext context)
        {
            
            _context = context;
            
            _context = context;

            //Users = new RepositoryEf<Users>(_context);
            Users = new MemoryRepositoryEF<Users>(_context, new RepositoryEf<Users>(_context));
            News = new RepositoryEf<NewsEtty>(_context);
            HashTags = new RepositoryEf<HashTags>(_context);

            ArticlesViewForUI = new RepositoryEf<ArticlesViewForUI>(_context);
            
            Categories = new RepositoryEf<Categories>(_context);
            
            HashTagsNews = new RepositoryEf<HashTagsNews>(_context);
            
            //PublicationType = new RepositoryEf<NewsPublicationType>(_context);
            PublicationType = new MemoryRepositoryEF<NewsPublicationType>(_context, new RepositoryEf<NewsPublicationType>(_context));
            
            Galleries = new RepositoryEf<Galleries>(_context);
            
            
            Galleries = new RepositoryEf<Galleries>(_context);
            Galleries = new RepositoryEf<Galleries>(_context);
            
           // PendingRegistration = new MemoryRepository<PendingRegistration>(_context, new Repository<PendingRegistration>(_context));

        }

        public IRepository<ArticlesViewForUI> ArticlesViewForUI { get; }
        public IRepository<Categories> Categories { get; }
        public IRepository<HashTags> HashTags { get; }
        public IRepository<HashTagsNews> HashTagsNews { get; }
        public IRepository<NewsPublicationType> PublicationType { get; }
        public IRepository<Galleries> Galleries { get; }
        public IRepository<Users> Users { get; }
        public IRepository<NewsEtty> News { get; }
        
        public IRepositorySharedObject SharedObject { get; }
        public IRepositorySharingSocialNetwork SharingSocialNetwork { get; }
        public int Complete()
        {
            return _context.SaveChanges();
        }
        
        public void Dispose()
        {
            throw new System.NotImplementedException();
        }
    }
}