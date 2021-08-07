using FluentMigrator;

namespace UoWRepo.Migrations
{
    [Migration(1,"AddUIViewArticles")]
    public class AddUIViewArticles: Migration
    {
        public AddUIViewArticles()
        {
           // base.ConnectionString = connectionString;
        }

        public override void Down()
        {
            //new MigrationContext()

        }

        public override void Up()
        {
            Create.Table("ArticlesViewForUI")
            .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
            .WithColumn("ArticleId").AsInt32().Unique().NotNullable().Unique()
            .WithColumn("UIString").AsString(90000).Nullable()
            .WithColumn("CreatedByID").AsInt32().NotNullable()
            .WithColumn("UpdatedById").AsInt32().NotNullable()
            .WithColumn("CreatedDate").AsDateTime2().NotNullable()
            .WithColumn("UpdatedDate").AsDateTime2().NotNullable()
            .WithColumn("LastUpdateOfArticle").AsDateTime2().NotNullable();
        }
    }
}
