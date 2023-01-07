using System;
using System.Diagnostics;
using System.IO;
using System.Timers;
using Avalonia;
using Avalonia.Platform;
using DiscordRPC;
using DiscordRPC.Logging;

namespace UncannyRPC.Helpers;

public class RpcHandler
{
    private readonly DiscordRpcClient Client;
    private readonly Timer timer = new (1000);
    private readonly PresenceObject Data;

    public RpcHandler(long token)
    {
        var assets = AvaloniaLocator.Current.GetService<IAssetLoader>();
        var instance = new TomlParser(new StreamReader(assets.Open(new Uri("avares://UncannyRPC/Assets/default_config.toml"))));
        Data = instance.Data;
        Client = new(token.ToString());
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

    private double GetCPUPercent()
    {
        var allIdle = new PerformanceCounter(
            "Processor", 
            "% Idle Time", 
            "_Total"
        );
        double cpu = Convert.ToDouble(100 - allIdle.NextValue());
        cpu = Math.Round(cpu, Data.CpuCurrentRound);
        return cpu;
    }

    private double GetCurrentRamPercent()
    {
        var allMem = new PerformanceCounter("Memory", "Available MBytes");
        double ram = Convert.ToDouble(allMem.NextValue());
        ram = Math.Round(ram, Data.RamCurrentRound);
        return ram;
    }

    private void SetPresence()
    {
        Client.SetPresence(new RichPresence()
        {
            Details = string.Format(
                "{0} {1} {2}",
                Data.CpuTitle, Data.CpuSeperator, GetCPUPercent()),
            State = string.Format(
                "{0} {1} {2}/{3}GB",
                Data.RamTitle,
                Data.RamSeperator,
                GetCurrentRamPercent(),
                8.0),
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
    }
}