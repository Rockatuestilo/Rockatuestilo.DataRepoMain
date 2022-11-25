using System;

namespace UoWRepo.Core.DomainDefinition;

public interface IBaseTEntity
{
    int Id { get; set; }
    DateTime UpdatedDate { get; set; }
}