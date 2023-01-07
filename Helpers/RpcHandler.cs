using System;
using System.Timers;
using DiscordRPC;
using DiscordRPC.Logging;

namespace UncannyRPC.Helpers;

public class RpcHandler
{
    private readonly long token;
    private readonly DiscordRpcClient Client;
    private readonly Timer timer = new (1000);
    private readonly PresenceObject Data;

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

    private void SetPresence()
    {
        Client.SetPresence(new RichPresence()
        {
            Details = string.Format(
                "{0} {1} {2}",
                Data.CpuTitle, Data.CpuSeperator, Data.CpuCurrent),
            State = string.Format(
                "{0} {1} {2}/{3}GB",
                Data.RamTitle,
                Data.RamSeperator,
                Data.RamCurrent,
                Data.RamTotal),
            Assets = new Assets()
            {
                LargeImageKey = Data.ImageSource,
                LargeImageText = "UncannyRPC"
            }
        });
    }

    public void RunPresence()
    {
        timer.Elapsed += (sender, args) =>
        {
            SetPresence();
        };
        timer.Start();
    }

    public void StopPresence()
    {
        timer.Stop();
        Client.ClearPresence();
        Client.Dispose();
    }
}

public class PresenceObject
{
    public string CpuTitle { get; set; }
    public string RamTitle { get; set; }
    public string ImageSource { get; set; }
    public string CpuSeperator { get; set; }
    public string RamSeperator { get; set; }
    public string CpuCurrent { get; set; }
    public string RamCurrent { get; set; }
    public string RamTotal { get; set; }
}