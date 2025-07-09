using auth.interfaces.core;

namespace auth.infrastructure.data.UserRepository;

public class UserRepository : IUserRepository
{
    private readonly UserDbContext _dbContext = new();
    
    public Task Auth(string name, string password)
    {
        throw new NotImplementedException();
    }

    public Task<bool> IsAuth(string name)
    {
        throw new NotImplementedException();
    }

    public Task Register(string name, string password)
    {
        throw new NotImplementedException();
    }

    public Task<bool> IsRegister(string name)
    {
        throw new NotImplementedException();
    }
}