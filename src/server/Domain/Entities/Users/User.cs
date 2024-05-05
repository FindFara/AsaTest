using Domain.Common;
using Domain.Interfaces;

namespace Domain.Entities.Users;
public class User : BaseEntity<byte> , IAuditableEntity
{
    public string? FirstName { get; set; } 
    public string? LastName { get; set; }
    public int Age { get; set; }
    public DateTime Created { get; set; }
    public DateTime? LastModified { get; set; }
}
