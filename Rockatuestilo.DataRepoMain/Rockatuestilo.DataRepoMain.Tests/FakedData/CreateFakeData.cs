using System.Collections.Generic;
using Bogus;
using UoWRepo.Core.Domain;

namespace Rockatuestilo.DataRepoMain.Tests.FakedData;

public class CreateFakeData
{
    public List<UoWRepo.Core.EFDomain.Users> DoByNumberEf(int howMany = 1000)
    {
        var users = DoByNumber(howMany);
        // convert using json
        var json = Newtonsoft.Json.JsonConvert.SerializeObject(users);
        var usersEf = Newtonsoft.Json.JsonConvert.DeserializeObject<List<UoWRepo.Core.EFDomain.Users>>(json);
        return usersEf;
    }


    public List<Users> DoByNumber(int howMany = 1000)
    {
        
        List<Users> users = new List<Users>();
        
        // create 1000 users
        for (int i = 0; i < howMany; i++)
        {
            var user = new Faker<Users>()
                .RuleFor(a => a.Email, f => f.Person.Email)
                .RuleFor(a => a.Name, f => f.Person.FirstName)
                .RuleFor(a => a.LastName, f => f.Person.LastName)
                .RuleFor(a => a.LoginName, f => f.Person.UserName)
                .RuleFor(a => a.CreatedDate, f => f.Date.Past())
                .RuleFor(a => a.UpdatedDate, f => f.Date.Past())
                .RuleFor(a => a.Password, f => f.Internet.Password())
                .RuleFor(a => a.LastLogin, f => f.Date.Past())
                .RuleFor(a => a.UserRoleLevel, f => 1 )
                //.RuleFor(a => a.CreatedBy, f => f.Random.Number(1, 100))
                //.RuleFor(a => a.UpdatedBy, f => f.Random.Number(1, 100))
                .RuleFor(a => a.VerifiedAccount, f => false)
                .Generate();
            
            users.Add(user);
        }

        return users;
    }
}