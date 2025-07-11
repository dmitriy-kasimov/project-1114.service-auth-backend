namespace auth.services.interfaces;

public interface IUserService
{
    public Task Auth(string login, string password);
    
    public Task Reg(string login, string password);
}