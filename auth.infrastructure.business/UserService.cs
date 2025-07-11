using auth.domain.core;
using auth.infrastructure.data.UserRepository;
using auth.services.interfaces;

namespace auth.infrastructure.business;

public class UserService : IUserService
{
    private readonly UserRepository _userRepository = new ();
    
    public async Task<User> Auth(string login, string password) => await _userRepository.Auth(login, password);

    public async Task<User> Reg(string login, string password) => await _userRepository.Reg(login, BCrypt.Net.BCrypt.HashPassword(password));
}