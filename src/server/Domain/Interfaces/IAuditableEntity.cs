
namespace Domain.Interfaces;

internal interface IAuditableEntity
{
    public DateTime Created { get; set; }
    public DateTime? LastModified { get; set; }
}
