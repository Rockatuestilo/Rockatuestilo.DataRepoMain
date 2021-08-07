using System;

namespace UoWRepo.Core.EFDomain
{
    public interface ITEntity
    {
         int Id { get; set; }
         DateTime UpdatedDate { get; set; }
    }
}
