using auth.domain.core;

namespace auth.interfaces.core;

public interface IUserRepository
{
    public Task<bool> Auth(string login, string passHash);
    public Task DeAuth(Guid id);
    public Task<bool> IsAuth(string login);
    
    public Task Reg(string login, string passHash);
    public Task<bool> IsReg(string login);
}