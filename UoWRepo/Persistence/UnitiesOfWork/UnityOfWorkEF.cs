using System.ComponentModel.Design.Serialization;
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
            Users = InitObjects<Users>();
            News = InitObjects<NewsEtty>();
            HashTags = InitObjects<HashTags>();
            ArticlesViewForUI = InitObjects<ArticlesViewForUI>();
            Categories = InitObjects<Categories>();
            HashTagsNews = InitObjects<HashTagsNews>();
            
            PublicationType = InitObjects<NewsPublicationType>();
            Galleries = InitObjects<Galleries>();

        }

        private  MemoryRepositoryEF<T> InitObjects<T>()  where T : BaseTEntity
        {
            return new MemoryRepositoryEF<T>(_context, new RepositoryEf<T>(_context));
        }

        public IMemoryRepository<ArticlesViewForUI> ArticlesViewForUI { get; }
        public IMemoryRepository<Categories> Categories { get; }
        public IMemoryRepository<HashTags> HashTags { get; }
        public IMemoryRepository<HashTagsNews> HashTagsNews { get; }
        public IMemoryRepository<NewsPublicationType> PublicationType { get; }
        public IMemoryRepository<Galleries> Galleries { get; }
        public IMemoryRepository<Users> Users { get; }
        public IMemoryRepository<NewsEtty> News { get; }
        
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