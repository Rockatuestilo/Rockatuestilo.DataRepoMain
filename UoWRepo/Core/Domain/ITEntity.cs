using System;

namespace UoWRepo.Core.Domain
{
    public interface ITEntity
    {
         int Id { get; set; }
         DateTime UpdatedDate { get; set; }
    }
}
