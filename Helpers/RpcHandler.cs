using System;
using DiscordRPC;
using DiscordRPC.Logging;

namespace UncannyRPC.Helpers;

public class RpcHandler
{
    private readonly long token;
    private readonly DiscordRpcClient Client;

    public RpcHandler(long token)
    {
        Client = new(this.token.ToString());
        Initializer();
    }

    private void Initializer()
    {
        Client.Logger = new ConsoleLogger()
        {
            Level = LogLevel.Warning | LogLevel.Error | LogLevel.Info
        };

        Client.OnReady += (sender, args) =>
        {
            Console.WriteLine($"{args.User.Username} is ready...");
        };

        Client.Initialize();
    }
}