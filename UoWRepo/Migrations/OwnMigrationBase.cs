using System;
using FluentMigrator;

namespace UoWRepo.Migrations
{
    public class OwnMigrationBase: MigrationBase
    {
        public OwnMigrationBase()
        {
            ConnectionString = "";
        }

        public override void Down()
        {
            throw new NotImplementedException();
        }

        public override void Up()
        {
            throw new NotImplementedException();
        }
    }
}
