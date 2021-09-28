using System;
using FluentMigrator;

namespace UoWRepo.Migrations
{
    [Migration(3,"DeleteUnneededStuff")]
    public class DeleteUnneededStuff: Migration
    {
        public DeleteUnneededStuff()
        {
           // base.ConnectionString = connectionString;
        }

        public override void Down()
        {
            //new MigrationContext()

        }

        public override void Up()
        {
            
            
         
            
            TryDelete("Banners");
            TryDelete("Div_configuration");
            TryDelete("divofpage");
            TryDelete("divOrder");
            TryDelete("ObjectOfpages");
            TryDelete("ObjectTypes");
            TryDelete("page");
            TryDelete("page_configuration");
            TryDelete("tempDivtable");
            TryDelete("TextItems");
            TryDelete("VersionInfo");
            TryDelete("Widgets");
            TryDelete("tableuptodate");
        }

        public void TryDelete(string nameOfTable)
        {
            try
            {
                if (Schema.Table(nameOfTable).Exists())
                {
                    Delete.Table(nameOfTable);
                }
            }
            catch (Exception e)
            {
            }
        }
    }
}
