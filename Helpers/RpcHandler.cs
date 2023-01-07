using System;
using System.Threading.Tasks;
using System.Timers;
using DiscordRPC;
using DiscordRPC.Logging;

namespace UncannyRPC.Helpers;

public class RpcHandler
{
    private readonly long token;
    private readonly DiscordRpcClient Client;
    private readonly Timer timer = new (1000);

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

    private void SetPresence(
        )
    {
        Client.SetPresence(new RichPresence()
        {
            Details = string.Format(
                "{0} {1} {2}",
                cpuTitle, cpuSeperator, cpuCurrent),
            State = string.Format(
                "{0} {1} {2}/{3}GB",
                ramTitle,
                ramSeperator,
                ramCurrent,
                ramTotal),
            Assets = new Assets()
            {
                LargeImageKey = imageSource,
                LargeImageText = "UncannyRPC"
            }
        });
    }

    public async Task RunPresence()
    {
        timer.Elapsed += (sender, args) =>
        {
            
        };
    }
}

public class PresenceObject
{
    public string cpuTitle { get; set; }
    public string ramTitle { get; set; }
    public string imageSource { get; set; }
    public string cpuSeperator { get; set; }
    public string ramSeperator { get; set; }
    public string cpuCurrent { get; set; }
    public string ramCurrent { get; set; }
    public string ramTotal { get; set; }
}