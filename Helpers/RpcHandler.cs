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
    private Timer timer;
    private readonly PresenceObject Data;

    public RpcHandler()
    {
        var assets = AvaloniaLocator.Current.GetService<IAssetLoader>();
        var instance = new TomlParser(new StreamReader(assets.Open(new Uri("avares://UncannyRPC/Assets/default_config.toml"))));
        Data = instance.Data;
        Client = new(Data.AppId.ToString());
        Initializer();
    }

    private void Initializer()
    {
        timer = new Timer(Data.UpdateInterval);
        
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
        var cpu = Math.Round(allIdle.NextValue(), 2);
        return cpu;
    }

    private double GetCurrentRamPercent()
    {
        var allMem = new PerformanceCounter("Memory", "Available MBytes");
        double ram = Convert.ToDouble(allMem.NextValue());
        ram = Math.Round(ram, Data.RamCurrentRound);
        return ram;
    }

    private void GetImage()
    {
        var cpu = GetCPUPercent();
        if (Data.ImageSource == "default")
        {
            if (cpu is < 16.6 and >= 0.0)
            {
                Data.ImageSource = "https://i.imgur.com/QCAIyQ5.png";
            } else if (cpu is < 33.33 and >= 16.7)
            {
                Data.ImageSource = "https://i.imgur.com/EbQWujK.png";
            } else if (cpu is < 49.8 and >= 33.4)
            {
                Data.ImageSource = "https://i.imgur.com/IVftRn3.png";
            } else if (cpu is < 66.4 and >= 50)
            {
                Data.ImageSource = "https://i.imgur.com/KtAEWlH.png";
            } else if (cpu is < 83 and >= 66.5)
            {
                Data.ImageSource = "https://i.imgur.com/sPgNRAv.png";
            } else if (cpu is <= 100 and >= 84)
            {
                Data.ImageSource = "https://i.imgur.com/b6sBuI1.png";
            }
            else
            {
                Data.ImageSource = "https://i.imgur.com/zFs1M60.png";
            }
        }
    }

    private void SetPresence()
    {
        GetImage();
        Client.SetPresence(new RichPresence()
        {
            Details = $"{Data.CpuTitle} {Data.CpuSeperator} {GetCPUPercent()}%",
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
            },
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