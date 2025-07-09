namespace auth.infrastructure.data.UserRepository.Entities;

public class UserEntity
{
    public Guid Id { get; set; }
    public string Login { get; set; }
    public string PassHash { get; set; }
    
    public bool IsAuth { get; set; }
}