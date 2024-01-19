using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Newtonsoft.Json;
using UoWRepo.Core.BaseDomain;
using UoWRepo.Core.Configuration;
using UoWRepo.Core.Domain;
using UoWRepo.Core.EFDomain;
using UoWRepo.Core.Repositories;
using UoWRepo.Persistence.Repositories;
using UoWRepo.Persistence.UnitiesOfWork;
using ITEntity = UoWRepo.Core.BaseDomain.ITEntity;

namespace UoWRepo.Api;




public class UnitOfWorkMultiOrm
{
    private readonly Linq2DbContext _context;
    IUnitOfWorkLinq _unitOfWorkLinq;
    IUnitOfWorkEf _unitOfWorkEf;
    
    public UnitOfWorkMultiOrm(Linq2DbContext context)
    {
        _context = context;
        _unitOfWorkLinq = new UnityOfWorkLinq(context);
    }
    
    public UnitOfWorkMultiOrm(IUnitOfWorkLinq IUnitOfWorkLinq)
    {
        _unitOfWorkLinq = IUnitOfWorkLinq;
    }
    
    public UnitOfWorkMultiOrm(EFContext context)
    {
        _unitOfWorkEf = new UnityOfWorkEf(context);
    }


    public IRepository<UsersModelApi> Users 
    {
        get
        {
            if (_unitOfWorkLinq != null)
            {
                // to json and back
                var usersJson = Newtonsoft.Json.JsonConvert.SerializeObject(_unitOfWorkLinq.Users);
                var usersJson2 = Newtonsoft.Json.JsonConvert.DeserializeObject<Repository<UsersModelApi>>(usersJson);
                usersJson2._context = _context;
                
                
                return usersJson2;
            }
            else
            {
                return (dynamic) _unitOfWorkEf.Users;
                
            }

        }
    }
}
public abstract class BaseModel
{
    public virtual int Id { get; set; }
    public virtual DateTime CreatedDate { get; set; }
    public virtual DateTime UpdatedDate { get; set; }
}


public class UsersModelApi: BaseTEntity, ITEntity
{
    public string Name { get; set; }
    public string LastName { get; set; }
    public string LoginName { get; set; }
    public string Password { get; set; }
    public DateTime LastLogin { get; set; }
    public int UserRoleLevel { get; set; }
    public int CreatedBy { get; set; }
    public int UpdatedBy { get; set; }
    public string? Email { get; set; }
    public bool VerifiedAccount { get; set; }
    public int Id { get; set; }
}