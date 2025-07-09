namespace auth.interfaces.core;

public interface IUserRepository
{
    public Task Auth(string name, string password);
    public Task<bool> IsAuth(string name);
    
    public Task Register(string name, string password);
    public Task<bool> IsRegister(string name);
}