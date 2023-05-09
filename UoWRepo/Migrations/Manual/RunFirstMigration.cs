using System;
using MySql.Data.MySqlClient;
using UoWRepo.Core.Configuration;

namespace UoWRepo.Migrations.Manual;

public class RunFirstMigration
{
    private Linq2DbContext _context;

    public RunFirstMigration(Linq2DbContext context)
    {
        _context = context;
        RunStupidMigration();
        
    }
    
    private void RunMysqlDirectly(string connectionString, string script)
    {
        
        using (MySqlConnection connection = new MySqlConnection(connectionString))
        {
            connection.Open();
    
            MySqlCommand command = new MySqlCommand(script, connection);
            command.ExecuteNonQuery();
    
            connection.Close();
        }
    }
    
    
    private void RunStupidMigration()
        {
            try
            {
                var rawSQLGetDatabase = @"SELECT DATABASE() as db";
                var dataBase = _context.ExecuteRaw<object>(rawSQLGetDatabase);
                // get version 
                var rawSQLGetVersion = @"
USE " + dataBase + @";
SELECT 
Version
FROM VersionInfo
ORDER BY Version Desc
Limit 1;";
                var version = _context.ExecuteRaw<int>(rawSQLGetVersion);

                if (version > 0)
                {
                    return;
                }
               
                var rawSqlDoesTableExists = @"SELECT COUNT(*) FROM information_schema.tables WHERE table_schema = '" + dataBase + @"' AND table_name = 'Users';";
                var table = _context.ExecuteRaw<int>(rawSqlDoesTableExists);

                if (table > 0)
                {
                    // sql to see is Users have lines
                    var rawSqlDoesTableHaveLines = @"SELECT COUNT(*) FROM Users;";
                    var lines = _context.ExecuteRaw<int>(rawSqlDoesTableHaveLines);
                    if (lines == 0)
                    {
                        // delete Users table
                        var rawSQLDelete = @"DROP TABLE Users;";
                        _context.ExecuteRaw<object>(rawSQLDelete);
                        // change table name
                        var rawSQLRename = @"ALTER TABLE tb_users RENAME TO Users;";
                        _context.ExecuteRaw<object>(rawSQLRename);
                    }
                    
                }
                else
                {
                    // change table name
                    var rawSQLRename = @"ALTER TABLE tb_users RENAME TO Users;";
                    _context.ExecuteRaw<object>(rawSQLRename);
                }
                
                
                
                // change column names
                
                
                var rawSQL_01 = @"
USE " + dataBase + @";
          ALTER TABLE `Users` 

CHANGE COLUMN `UserUpdatedDate` `UserUpdatedDate` TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP 

;
                ";

                var rawSQL = @"
USE " + dataBase + @";
          ALTER TABLE `Users` 
CHANGE COLUMN `userID` `Id` INT NOT NULL AUTO_INCREMENT ,
CHANGE COLUMN `UserName` `Name` VARCHAR(60) CHARACTER SET 'utf8mb4' NOT NULL ,
CHANGE COLUMN `UserLastName` `LastName` VARCHAR(60) CHARACTER SET 'utf8mb4' NOT NULL ,
CHANGE COLUMN `UserLoginName` `LoginName` VARCHAR(60) CHARACTER SET 'utf8mb4' NOT NULL ,
CHANGE COLUMN `UserCreatedDate` `CreatedDate` TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP ,
CHANGE COLUMN `UserUpdatedDate` `UpdatedDate` TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP ,
CHANGE COLUMN `UserPassword` `Password` VARCHAR(250) CHARACTER SET 'utf8mb4' NOT NULL ,
CHANGE COLUMN `UserLastLogin` `LastLogin` DATETIME NOT NULL ,
CHANGE COLUMN `createdBy` `CreatedBy` INT NOT NULL ,
CHANGE COLUMN `updatedBy` `UpdatedBy` INT NOT NULL ,
CHANGE COLUMN `email` `Email` VARCHAR(255) NULL DEFAULT NULL ,
CHANGE COLUMN `verifiedaccount` `VerifiedAccount` BIT(1) NULL DEFAULT b'0' 
;
                ";
                RunMysqlDirectly(_context.ConnectionString, rawSQL_01);
                RunMysqlDirectly(_context.ConnectionString, rawSQL);
                
                // Create script to set version like this INSERT INTO `cmsbackup1004`.`VersionInfo`
                //(`Version`)
                //VALUES
                  //  (<{Version: }>);
                
                var rawSQLToAddColumns = @"
USE " + dataBase + @";
ALTER TABLE tb_role
CHANGE COLUMN `roleID` `Id` INT NOT NULL AUTO_INCREMENT ,
CHANGE COLUMN `roleName` `Name` VARCHAR(30) CHARACTER SET 'utf8mb4' NOT NULL ,
ADD COLUMN `Code` VARCHAR(255) NOT NULL,
ADD COLUMN `Description` VARCHAR(255) NOT NULL,
ADD COLUMN `Active` BIT NOT NULL DEFAULT b'0',
ADD COLUMN `CreatedDate` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
ADD COLUMN `UpdatedDate` DATETIME NOT NULL DEFAULT CURRENT_TIMESTAMP,
ADD UNIQUE INDEX `roleName_UNIQUE` (`Name` ASC) VISIBLE,
ADD UNIQUE INDEX `RoleCode_UNIQUE` (`Code` ASC) VISIBLE;
";
                RunMysqlDirectly(_context.ConnectionString, rawSQLToAddColumns);
                
                // change name of tb_role to Roles
                var rawSQLRenameRole = @"
USE " + dataBase + @";
ALTER TABLE tb_role RENAME TO Roles;";
                RunMysqlDirectly(_context.ConnectionString, rawSQLRenameRole);
                
                
                var rawSQLVersion = @"

USE " + dataBase + @";
          insert into VersionInfo (Version) values ("+1+");";
                RunMysqlDirectly(_context.ConnectionString, rawSQLVersion);

            }
            catch (Exception e)
            {
                
            }


   
        }
}