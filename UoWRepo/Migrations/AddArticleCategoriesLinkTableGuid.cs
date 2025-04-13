using FluentMigrator;

namespace UoWRepo.Migrations;

[Migration(20250413200002, "Add ArticleCategories Linking Table using GUIDs")] // New timestamp or descriptive name
public class AddArticleCategoriesLinkTableGuid : Migration
{
    public override void Up()
    {
        Create.Table("ArticleCategories")
            // Use AsFixedLengthString(36) to match the current CHAR(36).
            // Or AsGuid() if you know your FM/MySQL provider maps it to CHAR(36).
            .WithColumn("ArticleGuid").AsFixedLengthString(36).NotNullable()
            .ForeignKey("fk_articlecategories_article_guid", "Articles", "Guid") // FK to Articles.Guid
            .PrimaryKey("pk_articlecategories_guid") // Part of the composite PK

            .WithColumn("CategoryGuid").AsFixedLengthString(36).NotNullable()
            .ForeignKey("fk_articlecategories_category_guid", "Categories", "Guid") // FK to Categories.Guid
            .PrimaryKey("pk_articlecategories_guid"); // Part of the composite PK

        // Create indexes on the FK columns
        Create.Index("idx_articlecategories_articleguid").OnTable("ArticleCategories").OnColumn("ArticleGuid");
        Create.Index("idx_articlecategories_categoryguid").OnTable("ArticleCategories").OnColumn("CategoryGuid");


        // --- Data Migration (OPTIONAL - RECOMMENDED TO DO SEPARATELY) ---
        // This SQL is more complex because it requires looking up the corresponding GUIDs.
        // Test it carefully in a development environment!
        /*
            Execute.Sql(@"
                INSERT INTO ArticleCategories (ArticleGuid, CategoryGuid)
                SELECT a.Guid, c.Guid
                FROM Articles a
                JOIN Categories c ON a.CategoryId = c.news_categoriesID
                WHERE a.CategoryId IS NOT NULL
                -- Optional: Add ON DUPLICATE KEY UPDATE ArticleGuid=ArticleGuid to avoid errors if executed multiple times,
                -- although the composite PK should already prevent exact duplicates.
                -- Or add a NOT EXISTS check:
                -- AND NOT EXISTS (
                --    SELECT 1 FROM ArticleCategories ac
                --    WHERE ac.ArticleGuid = a.Guid AND ac.CategoryGuid = c.Guid
                -- );
            ");
            */
    }

    public override void Down()
    {
        Delete.Table("ArticleCategories");
        // Note: It's not necessary to explicitly delete indexes/FKs here if they were defined
        // with the FluentMigrator syntax when creating the table, as Delete.Table handles them.
    }
}