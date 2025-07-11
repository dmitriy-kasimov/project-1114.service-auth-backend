namespace auth.domain.core;

public class User(Guid id, string login, string passHash)
{
    public Guid Id { get; } = id;
    public string Login { get; } = login;
    public string PassHash { get; } = passHash;
}