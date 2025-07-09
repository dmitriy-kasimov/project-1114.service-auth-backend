using auth.domain.core;
using auth.infrastructure.data.UserRepository.Mappers;
using auth.interfaces.core;
using Microsoft.EntityFrameworkCore;

namespace auth.infrastructure.data.UserRepository;

public class UserRepository : IUserRepository
{
    private readonly UserDbContext _dbContext = new();

    public async Task<bool> Auth(string login, string passHash)
    {
        var user = await _dbContext.Users
            .FirstOrDefaultAsync(c => c.Login == login);

        if (user?.PassHash != passHash) return false;
        
        user.IsAuth = true;
        await _dbContext.SaveChangesAsync();
        
        return true;

    }

    public async Task DeAuth(Guid id)
    {
        var user = await _dbContext.Users
            .FirstOrDefaultAsync(c => c.Id == id);
        
        user!.IsAuth = false;
        await _dbContext.SaveChangesAsync();
    }

    public async Task<bool> IsAuth(string login)
    {
        var user = await _dbContext.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.Login == login);

        return user is { IsAuth: true };
    }

    public async Task Register(User user)
    {
        await _dbContext.AddAsync(UserMapper.ToModel(user));
        await _dbContext.SaveChangesAsync();
    }

    public async Task<bool> IsRegister(string login)
    {
        var result = await _dbContext.Users
            .AsNoTracking()
            .FirstOrDefaultAsync(c => c.Login == login);
        
        return result != null;
    }
}