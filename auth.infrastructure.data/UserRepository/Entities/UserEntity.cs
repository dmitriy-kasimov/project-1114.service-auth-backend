namespace auth.infrastructure.data.UserRepository.Entities;

public class UserEntity
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string PassHash { get; set; }
}