using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;
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
    private IAssetLoader Assets;
    private StreamReader TomlStreamReader;
    private StreamWriter TomlStreamWriter;
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
        _textEditor.Document = new TextDocument()
        {
            Text = File.ReadAllText("Config/default_config.toml", Encoding.UTF8)
        };
    }

    private async void SaveButton_OnClick(object? sender, RoutedEventArgs e)
    {
        await File.WriteAllTextAsync("Config/default_config.toml", _textEditor.Text);
        Close();
    }

    private void CloseButton_OnClick(object? sender, RoutedEventArgs e)
    {
        Close();
    }
}