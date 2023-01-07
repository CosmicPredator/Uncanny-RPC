using System;
using System.IO;
using Avalonia;
using Avalonia.Platform;
using Tommy;

namespace UncannyRPC.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
    private TomlTable Table;
    public MainWindowViewModel()
    {
        Table = LoadTomlFile();
    }
    
    

    private TomlTable LoadTomlFile()
    {
        var assets = AvaloniaLocator.Current.GetService<IAssetLoader>();
        var file = new StreamReader(assets.Open(new Uri("avares://UncannyRPC/Assets/default_config.toml")));
        var table = TOML.Parse(file);
        return table;
    }
}