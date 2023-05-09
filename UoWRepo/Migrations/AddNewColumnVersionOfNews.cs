using System;
using FluentMigrator;
using FluentMigrator.Builders.Create.Table;
using FluentMigrator.Infrastructure;
using LinqToDB.Tools;

namespace UoWRepo.Migrations
{
    
    public static class Ex
    {
        public static IFluentSyntax CreateTableIfNotExists(this MigrationBase self, string tableName, Func<ICreateTableWithColumnOrSchemaOrDescriptionSyntax, IFluentSyntax> constructTableFunction, string schemaName = "dbo")
        {
            if (!self.Schema.Schema(schemaName).Table(tableName).Exists())
            {
                return constructTableFunction(self.Create.Table(tableName));
            }
            else
            {
                return null;
            }       
        }
    }
    
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

            var ghh =Schema.Table(tableName);
            
            
            
            
            

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
