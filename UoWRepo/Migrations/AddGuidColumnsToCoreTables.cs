using FluentMigrator;

namespace UoWRepo.Migrations;

[Migration(20250413180001, "Add Nullable Guid Columns to Users and Roles")] // Usa un timestamp real
    public class AddGuidColumnsToCoreTables : Migration
    {
        public override void Up()
        {
            // Añadir columna guid a Users (nullable inicialmente)
            // Nota: AsGuid() puede mapear a CHAR(36). Si necesitas BINARY(16) estrictamente,
            // podrías necesitar .AsCustom("BINARY(16)") dependiendo del proveedor FM de MySQL.
            // Revisa la documentación de FluentMigrator.Extensions.MySql
            if (Schema.Table("Users").Exists() && !Schema.Table("Users").Column("guid").Exists())
            {
                Alter.Table("Users").AddColumn("guid").AsGuid().Nullable().Unique("uq_users_guid_temp");
                    // .AsCustom("BINARY(16)").Nullable().Unique("uq_users_guid_temp"); // Alternativa
            }

            // Añadir columna guid a Roles (nullable inicialmente)
            if (Schema.Table("Roles").Exists() && !Schema.Table("Roles").Column("guid").Exists())
            {
                 Alter.Table("Roles").AddColumn("guid").AsGuid().Nullable().Unique("uq_roles_guid_temp");
                    // .AsCustom("BINARY(16)").Nullable().Unique("uq_roles_guid_temp"); // Alternativa
            }

             // Opcional: Añadir GUID temporal a Articles si ayuda a la migración
             /*
             if (Schema.Table("Articles").Exists() && !Schema.Table("Articles").Column("guid_legacy").Exists())
             {
                 Alter.Table("Articles").AddColumn("guid_legacy").AsGuid().Nullable().Unique("uq_articles_guid_legacy_temp");
             }
             */
        }

        public override void Down()
        {
             // Eliminar las columnas añadidas en Up()
             if (Schema.Table("Users").Column("guid").Exists())
             {
                Delete.Column("guid").FromTable("Users");
             }
             if (Schema.Table("Roles").Column("guid").Exists())
             {
                 Delete.Column("guid").FromTable("Roles");
             }
             /*
             if (Schema.Table("Articles").Column("guid_legacy").Exists())
             {
                 Delete.Column("guid_legacy").FromTable("Articles");
             }
             */
        }
    }