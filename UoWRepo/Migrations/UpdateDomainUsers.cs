using FluentMigrator;

namespace UoWRepo.Migrations;

[Migration(6,"AddUIViewArticles")]
public class UpdateDomainUsers: Migration 
{
    public UpdateDomainUsers()
    {
        // base.ConnectionString = connectionString;
    }

    public override void Down()
    {
        //new MigrationContext()

    }

    public override void Up()
    {
        tb_users();

    }


    private void tb_users()
    {
        var tableName = "tb_users";
        var table = Schema.Table(tableName);
        if(Schema.Table(tableName).Exists())
        {
            var userIDColumn = table.Column("userID");
            if(userIDColumn.Exists())
            {
                Rename.Column("userID").OnTable(tableName).To("Id");
            }
            
            var UserNameColumn = table.Column("UserName");
            if(UserNameColumn.Exists())
            {
                Rename.Column("UserName").OnTable(tableName).To("Name");
            }
            
            var UserLastNameColumn = table.Column("UserLastName");
            if(UserLastNameColumn.Exists())
            {
                Rename.Column("UserLastName").OnTable(tableName).To("LastName");
            }
            
            var UserLoginNameColumn = table.Column("UserLoginName");
            if(UserLoginNameColumn.Exists())
            {
                Rename.Column("UserLoginName").OnTable(tableName).To("LoginName");
            }
            
            var createdDateColumn = table.Column("UserCreatedDate");
            if(createdDateColumn.Exists())
            {
                Rename.Column("UserCreatedDate").OnTable(tableName).To("CreatedDate");
            }
            var UpdatedDateColumn = table.Column("UserUpdatedDate");
            if(UpdatedDateColumn.Exists())
            {
                Rename.Column("UserUpdatedDate").OnTable(tableName).To("UpdatedDate");
            }
            
            var UserPassword = table.Column("UserPassword");
            if(UserPassword.Exists())
            {
                Rename.Column("UserPassword").OnTable(tableName).To("Password");
            }
            var UserLastLogin = table.Column("UserLastLogin");
            if(UserLastLogin.Exists())
            {
                Rename.Column("UserLastLogin").OnTable(tableName).To("LastLogin");
            }
            
            var createdBy = table.Column("createdBy");
            if(createdBy.Exists())
            {
                Rename.Column("createdBy").OnTable(tableName).To("CreatedBy");
            }
            
            var updatedBy = table.Column("updatedBy");
            if(updatedBy.Exists())
            {
                Rename.Column("updatedBy").OnTable(tableName).To("UpdatedBy");
            }
            
            var email = table.Column("email");
            if(email.Exists())
            {
                Rename.Column("email").OnTable(tableName).To("Email");
            }
            
            var verifiedaccount = table.Column("verifiedaccount");
            if(verifiedaccount.Exists())
            {
                Rename.Column("verifiedaccount").OnTable(tableName).To("VerifiedAccount");
            }
            
            Rename.Table(tableName).To("Users");

        }
    }
}