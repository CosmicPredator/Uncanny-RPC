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

    private long GetTotalRam()
    {
        var gcMemoryInfo = GC.GetGCMemoryInfo();
        var installedMemory = gcMemoryInfo.TotalAvailableMemoryBytes;
        var physicalMemory = (double)installedMemory / 1048576.0;
        return (long)physicalMemory;
    }

    private float GetCurrentRam()
    {
        var ram = new PerformanceCounter(
            "Memory", 
            "Available MBytes",
            true
        );

        return GetTotalRam() - ram.NextValue();
    }

    private string GetImage(float cpu)
    {
        if (Data.ImageSource == "default")
        {
            if (cpu is < 16.6f and >= 0.0f)
            {
                return "https://i.imgur.com/QCAIyQ5.png";
            }

            if (cpu is < 33.33f and >= 16.6f)
            {
                return "https://i.imgur.com/EbQWujK.png";
            }

            if (cpu is < 49.8f and >= 33.33f)
            {
                return "https://i.imgur.com/IVftRn3.png";
            }

            if (cpu is < 66.4f and >= 49.8f)
            {
                return "https://i.imgur.com/KtAEWlH.png";
            }

            if (cpu is < 83f and >= 66.4f)
            {
                return "https://i.imgur.com/sPgNRAv.png";
            }

            if (cpu is <= 100f and >= 83f)
            {
                return "https://i.imgur.com/b6sBuI1.png";
            }
            
            if (cpu > 100f)
            {
                return "https://i.imgur.com/b6sBuI1.png";
            }
        }
        return "https://i.imgur.com/zFs1M60.png";
    }

    private void SetPresence()
    {
        var allIdle = new PerformanceCounter(
            "Processor Information", 
            "% Processor Utility", 
            "_Total"
        );
        
        allIdle.NextValue();

        Client.SetPresence(new RichPresence()
        {
            Details = string.Format(
                "{0} {1} {2}%",
                Data.CpuTitle,
                Data.CpuSeperator,
                (allIdle.NextValue() < 0 || allIdle.NextValue() > 100)
                    ?100:
                    Math.Round(allIdle.NextValue(), Data.CpuCurrentRound)
            ),
            State = string.Format(
                "{0} {1} {2}/{3}GB",
                Data.RamTitle,
                Data.RamSeperator,
                Math.Round(GetCurrentRam()/1024.0, Data.RamCurrentRound),
                Math.Round(GetTotalRam()/1024.0, Data.RamTotalRound)),
            Assets = new Assets()
            {
                LargeImageKey = Data.ImageSource == "default" ? 
                    GetImage(allIdle.NextValue()):
                    Data.ImageSource,
                LargeImageText = "UncannyRPC"
            },
        });
    }

    public void RunPresence()
    {
        timer.Elapsed += (sender, args) =>
        {
            Client.Invoke();
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