using auth.domain.core;
using auth.infrastructure.data.UserRepository;
using auth.services.interfaces;

namespace auth.infrastructure.business;

public class UserService : IUserService
{
    private readonly UserRepository _userRepository = new ();

    public async Task<User> Auth(string login, string password)
    {
        if (! await _userRepository.IsReg(login)) throw new Exception("Учетная запись не зарегистрирована.");
        if (await _userRepository.IsAuth(login)) throw new Exception("Учетная запись активна на другом устройстве.");

        return await _userRepository.Auth(login, password);
    }

    public async Task DeAuth(Guid id)
    {
        await _userRepository.DeAuth(id);
    }


    public async Task<User> Reg(string login, string password)
    {
        if (await _userRepository.IsReg(login)) throw new Exception("Учетная запись уже зарегистрирована.");
        if (password.Length < 8) throw new Exception("Пароль должен быть длиной не менее 8 символов!");
        
        return await _userRepository.Reg(login, password);
    }
}