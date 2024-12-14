using Common.Domain;

namespace Shop.Domain.RoleAgg;

public class RolePermission:BaseEntity
{
    public long RoleId { get;internal set; }
    public Permission Permission { get; private set; }
}