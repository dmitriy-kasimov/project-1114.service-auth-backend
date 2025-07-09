namespace auth.domain.core;

public class User
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public string PassHash { get; set; }
}