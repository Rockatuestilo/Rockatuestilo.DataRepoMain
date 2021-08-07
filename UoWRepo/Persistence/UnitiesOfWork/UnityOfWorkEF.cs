using UoWRepo.Core.Configuration;
//using UoWRepo.Core.Domain;
using UoWRepo.Core.EFDomain;
using UoWRepo.Core.Repositories;
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
            //News = new RepositoryNews(_context);
            //Galleries = new RepositoryGalleries(_context);
            //Users = new RepositoryUsers(_context);
            /*SharedObject = new RepositorySharedObject(_context);
            SharingSocialNetwork = new RepositorySharingSocialNetwork(_context);

            //ArticlesViewForUI = new Repository<ArticlesViewForUI>(_context);
            //Categories = new RepositoryCategories(_context);
            //Categories = new RepositoryCategories(_context);


            News = new MemoryRepositoryNews(_context, new RepositoryNews(_context));


            PublicationType = new MemoryRepository<NewsPublicationType>(_context, new Repository<NewsPublicationType>(_context));
            HashTags = new MemoryRepository<HashTags>(_context, new Repository<HashTags>(_context));
            HashTagsNews = new MemoryRepository<HashTagsNews>(_context, new Repository<HashTagsNews>(_context));
            Categories = new MemoryRepository<Categories>(_context, new Repository<Categories>(_context));
            ArticlesViewForUI = new MemoryRepository<ArticlesViewForUI>(_context, new Repository<ArticlesViewForUI>(_context));

            Galleries = new MemoryRepository<Galleries>(_context, new Repository<Galleries>(_context));*/
            //Users = new MemoryRepository<Users>(_context, new Repository<Users>(_context));
            
            Users = new RepositoryEf<Users>(_context);
            News = new RepositoryEf<NewsEtty>(_context);
            HashTags = new RepositoryEf<HashTags>(_context);
            
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
            throw new System.NotImplementedException();
        }
        
        public void Dispose()
        {
            throw new System.NotImplementedException();
        }
    }
}