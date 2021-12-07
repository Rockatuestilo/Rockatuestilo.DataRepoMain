using System;

namespace UoWRepo.Core.Domain
{
    [Obsolete]
    public interface ITEntity
    {
         int Id { get; set; }
         DateTime UpdatedDate { get; set; }
    }
}
