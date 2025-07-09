using auth.domain.core;
using auth.infrastructure.data.UserRepository.Entities;

namespace auth.infrastructure.data.UserRepository.Mappers;

public static class UserMapper
{
    public static User ToDomain(UserEntity userEntity)
    {
        return new User()
        {
            Id = userEntity.Id,
            Login = userEntity.Login,
            PassHash = userEntity.PassHash,
        };
    }
    
    public static UserEntity ToModel(User user)
    {
        return new UserEntity()
        {
            Id = user.Id,
            Login = user.Login,
            PassHash = user.PassHash,
        };
    }
}