using System;
using System.Collections.Generic;

namespace Rockatuestilo.DataRepoMain.Tests.TestData.Users;

public class TestDataUsers1
{
    public List<UoWRepo.Core.EFDomain.Users> GetDataEf()
    {
        //var result = JsonConvert.DeserializeObject<List<UoWRepo.Core.EFDomain.Users>>(DataJsonV2());
        //return result;
        return UsersTwo();
    }

    public List<UoWRepo.Core.LinqDomain.Users> GetDataLinq2Db()
    {
        //return JsonConvert.DeserializeObject<List<UoWRepo.Core.Domain.Users>>(DataJson());
        return UsersOne();
    }


    public string DataJson()
    {
        return
            @"[{""Id"":1,""Username"":""Edward"",""Userlastname"":""Flores"",""Userloginname"":""scherenhaenden"",""Usercreateddate"":""2014-03-10T23:00:00"",""UpdatedDate"":""2014-03-10T23:00:00"",""Userpassword"":""4C44660A07E8F52FBDA8D8C3C2860C54760DEF21"",""Userlastlogin"":""2021-08-09T20:41:42"",""Userrolelevel"":7,""CreatedBy"":0,""UpdatedBy"":0,""Email"":""scherenhaenden@hotmail.com"",""VerifiedAccount"":true},{""Id"":11,""Username"":""test"",""Userlastname"":""test"",""Userloginname"":""test"",""Usercreateddate"":""2014-09-12T21:31:59"",""UpdatedDate"":""2014-09-12T21:31:59"",""Userpassword"":""A94A8FE5CCB19BA61C4C0873D391E987982FBBD3"",""Userlastlogin"":""2015-09-07T10:51:56"",""Userrolelevel"":0,""CreatedBy"":0,""UpdatedBy"":0,""Email"":null,""VerifiedAccount"":false},{""Id"":12,""Username"":""Henry"",""Userlastname"":""Alvarez"",""Userloginname"":""hanso"",""Usercreateddate"":""2014-09-12T21:31:59"",""UpdatedDate"":""2014-09-12T21:31:59"",""Userpassword"":""6361F9EFF0CF3E1A11933F64024ECE400E4DC6A7"",""Userlastlogin"":""2015-09-07T10:51:56"",""Userrolelevel"":3,""CreatedBy"":0,""UpdatedBy"":0,""Email"":null,""VerifiedAccount"":false}]";
    }

    public List<UoWRepo.Core.LinqDomain.Users> UsersOne()
    {
        var users = new List<UoWRepo.Core.LinqDomain.Users>
        {
            new()
            {
                Id = 1,
                Name = "Edward",
                LastName = "Flores",
                LoginName = "scherenhaenden",
                CreatedDate = DateTime.Parse("2014-03-10T23:00:00"),
                UpdatedDate = DateTime.Parse("2014-03-10T23:00:00"),
                Password = "4C44660A07E8F52FBDA8D8C3C2860C54760DEF21",
                LastLogin = DateTime.Parse("2021-08-09T20:41:42"),
                UserRoleLevel = 7,
                CreatedBy = 0,
                UpdatedBy = 0,
                Email = "scherenhaenden@hotmail.com",
                VerifiedAccount = true
            },
            new()
            {
                Id = 11,
                Name = "test",
                LastName = "test",
                LoginName = "test",
                CreatedDate = DateTime.Parse("2014-09-12T21:31:59"),
                UpdatedDate = DateTime.Parse("2014-09-12T21:31:59"),
                Password = "A94A8FE5CCB19BA61C4C0873D391E987982FBBD3",
                LastLogin = DateTime.Parse("2015-09-07T10:51:56"),
                UserRoleLevel = 0,
                CreatedBy = 0,
                UpdatedBy = 0,
                Email = null,
                VerifiedAccount = false
            },
            new()
            {
                Id = 12,
                Name = "Henry",
                LastName = "Alvarez",
                LoginName = "hanso",
                CreatedDate = DateTime.Parse("2014-09-12T21:31:59"),
                UpdatedDate = DateTime.Parse("2014-09-12T21:31:59"),
                Password = "6361F9EFF0CF3E1A11933F64024ECE400E4DC6A7",
                LastLogin = DateTime.Parse("2015-09-07T10:51:56"),
                UserRoleLevel = 3,
                CreatedBy = 0,
                UpdatedBy = 0,
                Email = null,
                VerifiedAccount = false
            }
        };
        return users;
    }

    public List<UoWRepo.Core.EFDomain.Users> UsersTwo()
    {
        var users = new List<UoWRepo.Core.EFDomain.Users>
        {
            new()
            {
                Id = 1,
                Name = "Edward",
                LastName = "Flores",
                LoginName = "scherenhaenden",
                CreatedDate = DateTime.Parse("2014-03-10T23:00:00"),
                UpdatedDate = DateTime.Parse("2014-03-10T23:00:00"),
                Password = "4C44660A07E8F52FBDA8D8C3C2860C54760DEF21",
                LastLogin = DateTime.Parse("2021-08-09T20:41:42"),
                UserRoleLevel = 7,
                CreatedBy = 0,
                UpdatedBy = 0,
                Email = "scherenhaenden@hotmail.com",
                VerifiedAccount = true,
                Guid = Guid.NewGuid()
            },
            new()
            {
                Id = 11,
                Name = "test",
                LastName = "test",
                LoginName = "test",
                CreatedDate = DateTime.Parse("2014-09-12T21:31:59"),
                UpdatedDate = DateTime.Parse("2014-09-12T21:31:59"),
                Password = "A94A8FE5CCB19BA61C4C0873D391E987982FBBD3",
                LastLogin = DateTime.Parse("2015-09-07T10:51:56"),
                UserRoleLevel = 0,
                CreatedBy = 0,
                UpdatedBy = 0,
                Email = "testemail1@email.com",
                VerifiedAccount = false,
                Guid = Guid.NewGuid()
            },
            new()
            {
                Id = 12,
                Name = "Henry",
                LastName = "Alvarez",
                LoginName = "hanso",
                CreatedDate = DateTime.Parse("2014-09-12T21:31:59"),
                UpdatedDate = DateTime.Parse("2014-09-12T21:31:59"),
                Password = "6361F9EFF0CF3E1A11933F64024ECE400E4DC6A7",
                LastLogin = DateTime.Parse("2015-09-07T10:51:56"),
                UserRoleLevel = 3,
                CreatedBy = 0,
                UpdatedBy = 0,
                Email = "testemail2@email.com",
                VerifiedAccount = false,
                Guid = Guid.NewGuid()
            }
        };

        return users;
    }

    public string DataJsonV2()
    {
        return
            @"[{""Id"":1,""Username"":""Edward"",""Userlastname"":""Flores"",""Userloginname"":""scherenhaenden"",""Usercreateddate"":""2014-03-10T23:00:00"",""UpdatedDate"":""2014-03-10T23:00:00"",""Userpassword"":""4C44660A07E8F52FBDA8D8C3C2860C54760DEF21"",""Userlastlogin"":""2021-08-09T20:41:42"",""Userrolelevel"":7,""CreatedBy"":0,""UpdatedBy"":0,""Email"":""scherenhaenden@hotmail.com"",""VerifiedAccount"":true},{""Id"":11,""Username"":""test"",""Userlastname"":""test"",""Userloginname"":""test"",""Usercreateddate"":""2014-09-12T21:31:59"",""UpdatedDate"":""2014-09-12T21:31:59"",""Userpassword"":""A94A8FE5CCB19BA61C4C0873D391E987982FBBD3"",""Userlastlogin"":""2015-09-07T10:51:56"",""Userrolelevel"":0,""CreatedBy"":0,""UpdatedBy"":0,""Email"":""test1@mail.com"",""VerifiedAccount"":false},{""Id"":12,""Username"":""Henry"",""Userlastname"":""Alvarez"",""Userloginname"":""hanso"",""Usercreateddate"":""2014-09-12T21:31:59"",""UpdatedDate"":""2014-09-12T21:31:59"",""Userpassword"":""6361F9EFF0CF3E1A11933F64024ECE400E4DC6A7"",""Userlastlogin"":""2015-09-07T10:51:56"",""Userrolelevel"":3,""CreatedBy"":0,""UpdatedBy"":0,""Email"":""test2@mail.com"",""VerifiedAccount"":false}]";
    }
}