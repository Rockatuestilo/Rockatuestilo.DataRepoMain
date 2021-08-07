using FluentMigrator;

namespace UoWRepo.Migrations
{
    [Migration(2, "UpdateArticlesTable")]
    public class UpdateArticlesTable : Migration
    {
        public UpdateArticlesTable()
        {
            // base.ConnectionString = connectionString;
        }

        public override void Down()
        {
            //new MigrationContext()

        }

        public override void Up()
        {
            var statementCreate = @"
CREATE TABLE `Articles` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Title` varchar(2000) DEFAULT NULL,
  `Content` text CHARACTER SET utf8 COLLATE utf8_unicode_ci,
  `CreatedDate` datetime NOT NULL,
  `LastUpdateDate` datetime NOT NULL ON UPDATE CURRENT_TIMESTAMP,
  `Permission` int(11) DEFAULT NULL,
  `CreatedById` int(11) NOT NULL,
  `UpdatedById` int(11) DEFAULT NULL,
  `CategoryId` int(11) DEFAULT NULL,
  `PublicationTypeId` int(11) DEFAULT '0',
  `Presentation` varchar(2000) DEFAULT NULL,
  `PublicationDate` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `TitleForURL` varchar(500) CHARACTER SET utf8 DEFAULT NULL,
  `HashtagsNewsId` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  UNIQUE KEY `TitleForURL` (`titleforURL`)
) ENGINE=InnoDB AUTO_INCREMENT=675 DEFAULT CHARSET=latin1;
            ";

            Execute.Sql(statementCreate);
        }
    }
}
