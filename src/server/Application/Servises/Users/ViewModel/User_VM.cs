
namespace Application.Servises.Users.ViewModel;
public class User_VM
{
    public byte Id { get; set; }
    public string? FirstName { get; set; } = default;
    public string? LastName { get; set; } = default;
    public int Age { get; set; }
    public DateTime Created { get; set; }
    public DateTime? LastModified { get; set; }
}
