namespace UoWRepo.Core.Configuration.CacheSystem
{
    public interface ICacheFactory
    {
        void ResetCache();

        void ResetEntity();

        void GetListOfEntities();
    }
}
