using AltV.Net;
using AltV.Net.Elements.Entities;
using auth.infrastructure.business;

namespace auth;

public class Script : IScript
{
    private readonly UserService _userService = new();
    
    [ScriptEvent(ScriptEventType.PlayerConnect)]
    public async void OnPlayerConnect(IPlayer player, string reason)
    {
        var newUser = await _userService.Reg(player.Name, reason);

        player.SetData("Id", newUser.Id);

        if (player.GetData<Guid>("Id", out var value))
        {
            Console.WriteLine($"User reged and his id: {value}");
        }
    }
}