using auth.domain.core;

namespace auth.services.interfaces;

public interface IUserService
{
    public Task<User> Auth(string login, string password);
    public Task DeAuth(Guid id);
    
    public Task<User> Reg(string login, string password);
}