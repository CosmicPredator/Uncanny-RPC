using System;
using System.Diagnostics;
using System.IO;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Platform;
using AvaloniaEdit;
using AvaloniaEdit.Document;
using AvaloniaEdit.TextMate;
using TextMateSharp.Grammars;
using Tommy;

namespace UncannyRPC.Views;

public partial class TomlEditor : Window
{
    private TextEditor? _textEditor;
    public TomlEditor()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
        _textEditor = this.FindControl<TextEditor>("Editor");
        InitEditor();
        LoadTomlToEditor();
    }

    private void InitEditor()
    {
        var _registryOptions = new RegistryOptions(ThemeName.TomorrowNightBlue);
        var _textMateInstallation = _textEditor.InstallTextMate(_registryOptions);
        _textMateInstallation.SetGrammar(
            _registryOptions.GetScopeByLanguageId(_registryOptions.GetLanguageByExtension(".cs").Id));
    }

    private void LoadTomlToEditor()
    {
        var assets = AvaloniaLocator.Current.GetService<IAssetLoader>();
        var fs = new StreamReader(assets.Open(new Uri("avares://UncannyRPC/Assets/default_config.toml")));
        _textEditor.Document = new TextDocument()
        {
            Text = fs.ReadToEnd()
        };
    }
}