using LinqToDB;
using LinqToDB;
using LinqToDB.DataProvider;
using UoWRepo.Core.Domain;

namespace UoWRepo.Core.Configuration;

public interface INews
{
    
}

public interface IITableSet<ToutTableBase>
{
    
}

public interface IBaseContext<IITableSet>
{
    public IITableSet<INews> tb_news { get; set; }
}


/*public class SimpleContext: LinqToDB.Data.DataConnection, IBaseContext<ITable<out >>
{
    

}*/


