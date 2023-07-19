using LinqToDB.Mapping;
using UoWRepo.Core.BaseDomain;

namespace UoWRepo.Core.Domain;

[Table(Name = "Roles")]
public class RoleModels : Linq2DbEntity, ITEntity
{
    [Column(Name = "Name")] [NotNull] public string Name { get; set; } = null!;

    [Column(Name = "Code")] [NotNull] public string Code { get; set; }

    [Column(Name = "Description")]
    [NotNull]
    public string Description { get; set; }

    [Column(Name = "Active")] [NotNull] public bool Active { get; set; }
}