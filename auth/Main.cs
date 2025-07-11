using AltV.Net;
using AltV.Net.Elements.Entities;
using auth.infrastructure.business;

namespace auth;

public class Main : Resource
{
    public override void OnStart()
    {
        Console.WriteLine("Main.OnStart");
    }

    public override void OnStop()
    {
        
    }
}