using FluentMigrator;

namespace UoWRepo.Migrations
{
    [Migration(5,"AddNewColumnVersionOfNews")]
    public class AddNewColumnVersionOfNews: Migration
    {
        public AddNewColumnVersionOfNews()
        {
            //base.ConnectionString = connectionString;
        }

        public override void Down()
        {
            //new MigrationContext()

        }

        public override void Up()
        {
            var tableName = "tb_news";
            
            

            var table = Schema.Table(tableName);

            if (Schema.Table(tableName).Exists())
            {
                var column = table.Column("ArticleVersion");
                if (!column.Exists())
                {
                    Alter.Table(tableName).AddColumn("ArticleVersion").AsInt32().Nullable();
                }
            }
        }
    }
}
