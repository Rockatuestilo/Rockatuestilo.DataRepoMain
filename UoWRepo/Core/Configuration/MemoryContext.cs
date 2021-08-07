namespace UoWRepo.Core.Configuration
{
    public class MemoryContext: Linq2DbContext
    {
        public MemoryContext(string connectionString) : base(connectionString)
        {

        }
    }
}
