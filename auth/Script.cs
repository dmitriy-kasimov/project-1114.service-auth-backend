using AltV.Net;
using AltV.Net.Elements.Entities;
using auth.infrastructure.business;

namespace auth;

public class Script : IScript
{
    private readonly UserService _userService = new();
    
    [ScriptEvent(ScriptEventType.PlayerConnect)]
    public void OnPlayerConnect(IPlayer player, string reason)
    {
        player.Emit("s:c/start");
    }
    
    [ScriptEvent(ScriptEventType.PlayerDisconnect)]
    public async void OnPlayerDisconnect(IPlayer player, string reason)
    {
        if (!player.GetData<Guid>("Id", out var value)) return;
        await _userService.DeAuth(value);
        player.ClearData();
    }

    [ClientEvent("c:s/auth")]
    public async void AuthHandler(IPlayer player, string login, string password)
    {
        try
        {
            var user = await _userService.Auth(login, password);
            player.SetData("Id", user.Id);
            player.Emit("s:c/auth|succeed");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            player.Emit("s:c/auth|rejected", e.Message);
        }
    }
    
    [ClientEvent("c:s/reg")]
    public async void RegHandler(IPlayer player, string login, string password)
    {
        try
        {
            var user = await _userService.Reg(login, password);
            player.SetData("Id", user.Id);
            player.Emit("s:c/reg|succeed");
        }
        catch (Exception e)
        {
            Console.WriteLine(e.Message);
            player.Emit("s:c/reg|rejected", e.Message);
        }
    }
}