using FluentMigrator;
using FluentMigrator.SqlServer; // May be needed for specific methods like Identity() depending on provider nuances

namespace UoWRepo.Migrations // Adjust your namespace if needed
{
    [Migration(20200101000001, "Create Initial Schema Based on Existing Database V1.0")] // Use an appropriate base timestamp/version
    public class CreateInitialSchema_CurrentState : Migration
    {
        public override void Up()
        {
            // Check if the main Users table already exists. If so, assume this baseline migration
            // has already run or the schema was created manually before introducing migrations.
            // FluentMigrator's VersionInfo table is the standard way to track applied migrations,
            // this check adds an extra layer of safety for the initial run.
            if (Schema.Table("Users").Exists())
            {
                // Optional: Log that the schema is presumed to exist.
                // Console.WriteLine("Table 'Users' already exists. Skipping initial schema creation migration.");
                return;
            }

            // --- Section: Users and Roles ---

            // Create Users table (Based on renamed tb_users and current Users entity)
            Create.Table("Users")
                .WithColumn("Id").AsInt32().NotNullable().PrimaryKey("pk_users").Identity()
                .WithColumn("Name").AsString(60).NotNullable() // Formerly UserName
                .WithColumn("LastName").AsString(60).NotNullable() // Formerly UserLastName
                .WithColumn("LoginName").AsString(60).NotNullable().Unique("uq_users_loginname") // Formerly UserLoginName
                .WithColumn("CreatedDate").AsDateTime().NotNullable().WithDefault(SystemMethods.CurrentDateTime) // Use AsDateTime for standard DATETIME/TIMESTAMP
                .WithColumn("UpdatedDate").AsDateTime().NotNullable().WithDefault(SystemMethods.CurrentDateTime) // ON UPDATE needs Raw SQL/trigger if DB-level update is required
                .WithColumn("Password").AsString(1500).NotNullable() // Formerly UserPassword
                .WithColumn("LastLogin").AsDateTime().NotNullable() // Formerly UserLastLogin
                .WithColumn("UserRoleLevel").AsInt32().NotNullable() // Current role assignment mechanism
                .WithColumn("CreatedBy").AsInt32().NotNullable()
                .WithColumn("UpdatedBy").AsInt32().NotNullable()
                .WithColumn("Email").AsString(255).Nullable().Unique("uq_users_email")
                .WithColumn("VerifiedAccount").AsBoolean().NotNullable().WithDefaultValue(false)
                .WithColumn("Guid").AsFixedLengthString(36).NotNullable().Unique("uq_users_guid"); // Existing CHAR(36) Guid column
            // Additional Indexes from original schema
            Create.Index("idx_email").OnTable("Users").OnColumn("Email");
            Create.Index("idx_loginname").OnTable("Users").OnColumn("LoginName"); // May be redundant with UNIQUE constraint depending on DB

            // Create Roles table
            Create.Table("Roles")
                .WithColumn("Id").AsInt32().NotNullable().PrimaryKey("pk_roles").Identity()
                .WithColumn("Name").AsString(30).NotNullable().Unique("uq_roles_name")
                .WithColumn("Code").AsString(255).NotNullable().Unique("uq_roles_code")
                .WithColumn("Description").AsString(255).NotNullable()
                .WithColumn("Active").AsBoolean().NotNullable().WithDefaultValue(false)
                .WithColumn("CreatedDate").AsDateTime().NotNullable().WithDefault(SystemMethods.CurrentDateTime)
                .WithColumn("UpdatedDate").AsDateTime().NotNullable().WithDefault(SystemMethods.CurrentDateTime); // ON UPDATE?

            // Create UsersToRoles linking table (assuming it exists based on UoW)
             Create.Table("UsersToRoles") // No 'if exists' needed here as the whole migration runs only once if Users doesn't exist
                 .WithColumn("Id").AsInt32().NotNullable().PrimaryKey("pk_userstoroles").Identity() // Added standard PK
                 .WithColumn("User").AsInt32().NotNullable().ForeignKey("fk_userstoroles_user", "Users", "Id").Indexed() // FK to Users.Id (INT)
                 .WithColumn("RoleGuid").AsInt32().NotNullable().ForeignKey("fk_userstoroles_role", "Roles", "Id").Indexed(); // FK to Roles.Id (INT), despite name

            // --- Section: Content Structure (Categories, Articles, etc.) ---

             // Create categorylevels table
             Create.Table("categorylevels")
                 .WithColumn("category_level_id").AsInt32().NotNullable().PrimaryKey("pk_categorylevels").Identity()
                 .WithColumn("category_level").AsInt32().NotNullable()
                 .WithColumn("categoryname").AsString(100).NotNullable().Unique("uq_catlevels_name")
                 .WithColumn("CreatedByID").AsInt32().NotNullable() //.ForeignKey("fk_catlevels_createdby", "Users", "Id")
                 .WithColumn("UpdatedByID").AsInt32().NotNullable() //.ForeignKey("fk_catlevels_updatedby", "Users", "Id")
                 .WithColumn("CreatedDate").AsDateTime().NotNullable()
                 .WithColumn("updatedDate").AsDateTime().NotNullable();

            // Create Categories table (Based on news_categories)
            Create.Table("Categories") // Assuming renamed
                .WithColumn("news_categoriesID").AsInt32().NotNullable().PrimaryKey("pk_categories") // Assuming this INT ID is the PK
                .WithColumn("categoryOwner").AsInt32().NotNullable().ForeignKey("fk_categories_owner", "Users", "Id") // FK to Users.Id
                .WithColumn("news_categoryName").AsString(255).Nullable()
                .WithColumn("levelCategory").AsInt32().Nullable().ForeignKey("fk_categories_level", "categorylevels", "category_level_id") // FK to categorylevels
                .WithColumn("CreatedByID").AsInt32().Nullable().ForeignKey("fk_categories_createdby", "Users", "Id")
                .WithColumn("UpdatedByID").AsInt32().Nullable().ForeignKey("fk_categories_updatedby", "Users", "Id")
                .WithColumn("CreatedDate").AsDateTime().Nullable()
                .WithColumn("updatedDate").AsDateTime().Nullable()
                .WithColumn("Guid").AsFixedLengthString(36).NotNullable(); // DEFAULT (uuid()) needs Raw SQL if required DB-side

            // Create NewsPublicationType table
             Create.Table("NewsPublicationType")
                 .WithColumn("NewsPublicationTypeID").AsInt32().NotNullable().PrimaryKey("pk_newspublicationtype").Identity()
                 .WithColumn("TypeOfPublication").AsString(255).NotNullable()
                 .WithColumn("LevelUser").AsInt32().Nullable() // FK to Roles.Id? Or just a level number?
                 .WithColumn("CreatedByID").AsInt32().Nullable().ForeignKey("fk_newspubtype_createdby", "Users", "Id")
                 .WithColumn("UpdatedByID").AsInt32().Nullable().ForeignKey("fk_newspubtype_updatedby", "Users", "Id")
                 .WithColumn("CreatedDate").AsDateTime().Nullable()
                 .WithColumn("updatedDate").AsDateTime().Nullable();

            // Create galleries table
            Create.Table("galleries")
                 .WithColumn("galleryID").AsInt32().NotNullable().PrimaryKey("pk_galleries").Identity()
                 .WithColumn("galleryOwner").AsInt32().NotNullable().ForeignKey("fk_galleries_owner", "Users", "Id")
                 .WithColumn("galleryName").AsString(255).Nullable().Unique("uq_galleries_name")
                 .WithColumn("galleryPath").AsString(255).NotNullable()
                 .WithColumn("CreatedByID").AsInt32().Nullable().ForeignKey("fk_galleries_createdby", "Users", "Id")
                 .WithColumn("UpdatedByID").AsInt32().Nullable().ForeignKey("fk_galleries_updatedby", "Users", "Id")
                 .WithColumn("CreatedDate").AsDateTime().Nullable()
                 .WithColumn("updatedDate").AsDateTime().Nullable()
                 .WithColumn("categorylevel").AsInt32().Nullable().ForeignKey("fk_galleries_catlevel", "categorylevels", "category_level_id") // FK to categorylevels
                 .WithColumn("publishtype").AsInt32().Nullable().ForeignKey("fk_galleries_pubtype", "NewsPublicationType", "NewsPublicationTypeID"); // FK to NewsPublicationType

             // Create Articles table (Primary content table)
             Create.Table("Articles")
                 .WithColumn("Id").AsInt32().NotNullable().PrimaryKey("pk_articles").Identity()
                 .WithColumn("Owner").AsInt32().NotNullable().ForeignKey("fk_articles_owner", "Users", "Id").Indexed() // Added Index
                 .WithColumn("Title").AsString(2000).Nullable()
                 .WithColumn("Content").AsCustom("LONGTEXT").Nullable() // Represents LONGTEXT or similar large text types
                 .WithColumn("CreatedDate").AsDateTime().NotNullable()
                 .WithColumn("LastUpdateDate").AsDateTime().NotNullable() // ON UPDATE CURRENT_TIMESTAMP needs Raw SQL/trigger
                 .WithColumn("Permission").AsInt32().Nullable()
                 .WithColumn("ChangedById").AsInt32().Nullable().ForeignKey("fk_articles_changedby", "Users", "Id").Indexed() // Added Index
                 .WithColumn("CategoryId").AsInt32().Nullable().ForeignKey("fk_articles_category", "Categories", "news_categoriesID").Indexed() // Added Index
                 .WithColumn("PublicationType").AsInt32().Nullable().WithDefaultValue(0).ForeignKey("fk_articles_pubtype", "NewsPublicationType", "NewsPublicationTypeID").Indexed() // Added Index
                 .WithColumn("GalleryId").AsInt32().Nullable().ForeignKey("fk_articles_gallery", "galleries", "galleryID").Indexed() // Added Index
                 .WithColumn("Presentation").AsCustom("LONGTEXT").Nullable() // Represents LONGTEXT
                 .WithColumn("PublicationDate").AsDateTime().NotNullable().WithDefault(SystemMethods.CurrentDateTime) // TIMESTAMP DEFAULT CURRENT_TIMESTAMP
                 .WithColumn("TitleForUrl").AsString(500).Nullable() // Consider adding UNIQUE constraint if needed
                 .WithColumn("HashtagsArticleId").AsInt32().Nullable() // Ambiguous FK - likely to HashtagsNews.Id? Needs clarification.
                 .WithColumn("ArticleVersion").AsInt32().Nullable()
                 .WithColumn("OwnerUsersGuid").AsFixedLengthString(36).NotNullable().ForeignKey("fk_articles_owner_guid", "Users", "Guid").Indexed() // FK to Users.Guid
                 .WithColumn("Guid").AsFixedLengthString(36).NotNullable().Unique("uq_articles_guid"); // DEFAULT (uuid()) needs Raw SQL/trigger
             // Indexes (some added via FKs above)
             //Create.Index("idx_category_id").OnTable("Articles").OnColumn("CategoryId"); // Already indexed by FK helper
             Create.Index("idx_publicationdate").OnTable("Articles").OnColumn("PublicationDate");

            // Create Hashtags table
            Create.Table("Hashtags")
                .WithColumn("Id").AsInt32().NotNullable().PrimaryKey("pk_hashtags").Identity()
                .WithColumn("HashtagWord").AsString(255).NotNullable()
                .WithColumn("Allowed").AsByte().NotNullable() // tinyint
                .WithColumn("CreatedByID").AsInt32().Nullable().ForeignKey("fk_hashtags_createdby", "Users", "Id")
                .WithColumn("UpdatedByID").AsInt32().Nullable().ForeignKey("fk_hashtags_updatedby", "Users", "Id")
                .WithColumn("CreatedDate").AsDateTime().Nullable()
                .WithColumn("updatedDate").AsDateTime().Nullable();
            Create.Index("idx_hashtagword").OnTable("Hashtags").OnColumn("HashtagWord");

            // Create HashtagsNews linking table
            Create.Table("HashtagsNews")
                .WithColumn("Id").AsInt32().NotNullable().PrimaryKey("pk_hashtagsnews").Identity()
                .WithColumn("NewsID").AsInt32().Nullable().ForeignKey("fk_htnews_article", "Articles", "Id").Indexed() // Added Index
                .WithColumn("HashtagID").AsInt32().Nullable().ForeignKey("fk_htnews_hashtag", "Hashtags", "Id").Indexed() // Added Index
                .WithColumn("CreatedByID").AsInt32().Nullable().ForeignKey("fk_htnews_createdby", "Users", "Id")
                .WithColumn("UpdatedByID").AsInt32().Nullable().ForeignKey("fk_htnews_updatedby", "Users", "Id")
                .WithColumn("CreatedDate").AsDateTime().Nullable()
                .WithColumn("updatedDate").AsDateTime().Nullable();
            // Indexes idx_hashtag_id and idx_news_id created above via FK helper

             // Create ArticlesViewForUI table
             Create.Table("ArticlesViewForUI")
                 .WithColumn("Id").AsInt32().NotNullable().PrimaryKey("pk_articlesviewforui").Identity()
                 .WithColumn("ArticleId").AsInt32().NotNullable().Unique("uq_articlesview_articleid").ForeignKey("fk_articlesview_article", "Articles", "Id")
                 .WithColumn("UIString").AsCustom("LONGTEXT").Nullable() // Represents TEXT
                 .WithColumn("CreatedByID").AsInt32().NotNullable().ForeignKey("fk_articlesview_createdby", "Users", "Id")
                 .WithColumn("UpdatedById").AsInt32().NotNullable().ForeignKey("fk_articlesview_updatedby", "Users", "Id")
                 .WithColumn("CreatedDate").AsDateTime().NotNullable()
                 .WithColumn("UpdatedDate").AsDateTime().NotNullable()
                 .WithColumn("LastUpdateOfArticle").AsDateTime().NotNullable();

            // --- Section: GUID-based Entities (Subjects, Media, etc.) ---

            // Create Subjects table
            Create.Table("Subjects")
                .WithColumn("Guid").AsFixedLengthString(36).NotNullable().PrimaryKey("pk_subjects") // CHAR(36)
                .WithColumn("Name").AsString(255).NotNullable()
                .WithColumn("Type").AsString(50).NotNullable() // ENUM stored as string
                .WithColumn("Description").AsCustom("LONGTEXT").Nullable() // TEXT
                .WithColumn("CreatedDate").AsDateTime().Nullable().WithDefault(SystemMethods.CurrentDateTime) // TIMESTAMP
                .WithColumn("UpdatedDate").AsDateTime().Nullable().WithDefault(SystemMethods.CurrentDateTime); // ON UPDATE?

            // Create Media table
            Create.Table("Media")
                .WithColumn("Guid").AsFixedLengthString(36).NotNullable().PrimaryKey("pk_media") // CHAR(36)
                .WithColumn("FilePath").AsString(500).NotNullable()
                .WithColumn("MediaType").AsString(50).NotNullable() // ENUM stored as string
                .WithColumn("Author").AsString(255).Nullable()
                .WithColumn("License").AsString(255).Nullable()
                .WithColumn("CreatedDate").AsDateTime().Nullable().WithDefault(SystemMethods.CurrentDateTime) // TIMESTAMP
                .WithColumn("UpdatedDate").AsDateTime().Nullable().WithDefault(SystemMethods.CurrentDateTime); // ON UPDATE?

             // Create SubjectMedia linking table
             Create.Table("SubjectMedia")
                 .WithColumn("Guid").AsFixedLengthString(36).NotNullable().PrimaryKey("pk_subjectmedia")
                 .WithColumn("SubjectGuid").AsFixedLengthString(36).NotNullable().ForeignKey("fk_subjectmedia_subject", "Subjects", "Guid").Indexed()
                 .WithColumn("MediaGuid").AsFixedLengthString(36).NotNullable().ForeignKey("fk_subjectmedia_media", "Media", "Guid").Indexed()
                 .WithColumn("IsFeatured").AsBoolean().Nullable().WithDefaultValue(false) // tinyint(1)
                 .WithColumn("CreatedDate").AsDateTime().Nullable().WithDefault(SystemMethods.CurrentDateTime) // TIMESTAMP
                 .WithColumn("UpdatedDate").AsDateTime().Nullable().WithDefault(SystemMethods.CurrentDateTime); // ON UPDATE?

             // Create SubjectRelationships table
             Create.Table("SubjectRelationships")
                 .WithColumn("Guid").AsFixedLengthString(36).NotNullable().PrimaryKey("pk_subjectrelationships")
                 .WithColumn("FromSubjectGuid").AsFixedLengthString(36).NotNullable().ForeignKey("fk_subjectrel_from", "Subjects", "Guid").Indexed()
                 .WithColumn("ToSubjectGuid").AsFixedLengthString(36).NotNullable().ForeignKey("fk_subjectrel_to", "Subjects", "Guid").Indexed()
                 .WithColumn("RelationshipType").AsString(50).NotNullable() // ENUM stored as string
                 .WithColumn("CreatedDate").AsDateTime().Nullable().WithDefault(SystemMethods.CurrentDateTime) // TIMESTAMP
                 .WithColumn("UpdatedDate").AsDateTime().Nullable().WithDefault(SystemMethods.CurrentDateTime); // ON UPDATE?

            // Create Types table (Used by Associations)
            Create.Table("Types")
                .WithColumn("Guid").AsFixedLengthString(36).NotNullable().PrimaryKey("pk_types") // CHAR(36)
                .WithColumn("TypeName").AsString(255).NotNullable()
                .WithColumn("CreatedDate").AsDateTime().NotNullable().WithDefault(SystemMethods.CurrentDateTime) // DEFAULT CURRENT_TIMESTAMP
                .WithColumn("UpdatedDate").AsDateTime().NotNullable().WithDefault(SystemMethods.CurrentDateTime); // ON UPDATE?
            Create.Index("idx_guid").OnTable("Types").OnColumn("Guid"); // Explicit index from original DDL

             // Create Associations table
             Create.Table("Associations")
                 .WithColumn("Guid").AsFixedLengthString(36).NotNullable().PrimaryKey("pk_associations") // CHAR(36)
                 .WithColumn("Id").AsInt32().NotNullable() // Role unclear if PK is Guid
                 .WithColumn("CreatedDate").AsDateTime().NotNullable().WithDefault(SystemMethods.CurrentDateTime) // DEFAULT CURRENT_TIMESTAMP
                 .WithColumn("UpdatedDate").AsDateTime().NotNullable().WithDefault(SystemMethods.CurrentDateTime) // ON UPDATE?
                 .WithColumn("CreatedById").AsInt32().NotNullable().ForeignKey("fk_assoc_createdby", "Users", "Id")
                 .WithColumn("UpdatedById").AsInt32().NotNullable().ForeignKey("fk_assoc_updatedby", "Users", "Id")
                 .WithColumn("AssociatedTypeGuid").AsFixedLengthString(36).NotNullable().ForeignKey("fk_assoc_asstype", "Types", "Guid")
                 .WithColumn("ObjectTypeGuid").AsFixedLengthString(36).NotNullable().ForeignKey("fk_assoc_objtype", "Types", "Guid")
                 .WithColumn("ObjectGuid").AsFixedLengthString(36).NotNullable() // Polymorphic reference via Guid
                 .WithColumn("AssociatedGuid").AsFixedLengthString(36).NotNullable(); // Polymorphic reference via Guid

            // --- Section: Utility and Other Tables ---

            // Create CMSLog table
             Create.Table("CMSLog")
                 .WithColumn("Id").AsInt32().NotNullable().PrimaryKey("pk_cmslog") // Assuming no Identity based on original DDL snippet
                 .WithColumn("Date").AsDateTime().NotNullable()
                 .WithColumn("Thread").AsString(255).NotNullable()
                 .WithColumn("Level").AsString(50).NotNullable()
                 .WithColumn("Logger").AsString(255).NotNullable()
                 .WithColumn("Message").AsString(4000).NotNullable()
                 .WithColumn("Exception").AsString(2000).Nullable();

             // DO NOT Create VersionInfo - FluentMigrator manages this table itself.
             /*
             Create.Table("VersionInfo")
                 .WithColumn("Version").AsInt64().NotNullable().PrimaryKey();
             */

             // Create pendingRegistration table
             Create.Table("pendingRegistration")
                 .WithColumn("pendingID").AsInt32().NotNullable().PrimaryKey("pk_pendingregistration").Identity()
                 .WithColumn("userIDTableKey").AsInt32().NotNullable().Unique("uq_pending_userid") // Potentially FK to Users.Id later?
                 .WithColumn("UserName").AsString(60).NotNullable()
                 .WithColumn("UserLastName").AsString(60).NotNullable()
                 .WithColumn("UserLoginName").AsString(60).NotNullable()
                 .WithColumn("UserCreatedDate").AsDateTime().NotNullable().WithDefault(SystemMethods.CurrentDateTime) // TIMESTAMP DEFAULT CURRENT_TIMESTAMP
                 .WithColumn("UserUpdatedDate").AsDateTime().NotNullable() // Default '0000...' needs Raw SQL or handling in app
                 .WithColumn("email").AsString(255).NotNullable()
                 .WithColumn("id1").AsString(300).Nullable()
                 .WithColumn("id2").AsString(300).Nullable()
                 .WithColumn("id3").AsString(300).Nullable()
                 .WithColumn("id4").AsString(300).Nullable()
                 .WithColumn("emailMD5").AsString(300).NotNullable()
                 .WithColumn("UserLoginNameMD5").AsString(300).NotNullable();

             // Backup tables (_backup) are intentionally not created by this migration.

             // --- Add Foreign Keys that were commented out or might have cross-table dependencies ---
             // (Adding them here ensures the referenced tables exist first)
             // Example: If FKs in Categories/Galleries/etc pointed to Users.Id
             // Note: Many FKs were already created inline above using the .ForeignKey() syntax
             // Add any missing ones here if needed, for example:
             // Create.ForeignKey("fk_categories_owner").FromTable("Categories").ForeignColumn("categoryOwner").ToTable("Users").PrimaryColumn("Id");
             // Create.ForeignKey("fk_galleries_owner").FromTable("galleries").ForeignColumn("galleryOwner").ToTable("Users").PrimaryColumn("Id");
             // ... etc ... check your original DDL for all constraints.
        }

        public override void Down()
        {
            // Delete tables in reverse order of creation / dependency
            /*Delete.Table("pendingRegistration");
            Delete.Table("CMSLog");
            Delete.Table("Associations");
            // Delete FKs before deleting referenced tables if not handled by cascading or implicit FM behavior
            // Delete.ForeignKey("fk_assoc_asstype").OnTable("Associations"); // Example
            // Delete.ForeignKey("fk_assoc_objtype").OnTable("Associations"); // Example
            Delete.Table("Types"); // Types referenced by Associations
            Delete.Table("SubjectRelationships");
            Delete.Table("SubjectMedia");
            Delete.Table("Media");
            Delete.Table("Subjects");
            Delete.Table("ArticlesViewForUI");
            Delete.Table("HashtagsNews");
            Delete.Table("Hashtags");
            Delete.Table("Articles"); // Depends on Users, Categories, Galleries, NewsPubType
            Delete.Table("galleries"); // Depends on Users, CatLevels, NewsPubType
            Delete.Table("NewsPublicationType");
            Delete.Table("categorylevels"); // Depends on Users
            Delete.Table("Categories"); // Depends on Users
            Delete.Table("UsersToRoles"); // Depends on Users, Roles
            Delete.Table("Roles");
            Delete.Table("Users");*/

            // Do not delete VersionInfo table.
        }
    }
}