using System.Diagnostics;
using System.IO;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using AvaloniaEdit;
using AvaloniaEdit.TextMate;
using TextMateSharp.Grammars;
using Tommy;

namespace UncannyRPC.Views;

public partial class TomlEditor : Window
{
    public TomlEditor()
    {
        InitializeComponent();
    }

    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
        InitEditor();
        //LoadTomlToEditor("../Config/Configuration.toml");
    }

    private void InitEditor()
    {
        var _textEditor = this.FindControl<TextEditor>("Editor");

        var _registryOptions = new RegistryOptions(ThemeName.DarkPlus);

        var _textMateInstallation = _textEditor.InstallTextMate(_registryOptions);

        _textMateInstallation.SetGrammar(
            _registryOptions.GetScopeByLanguageId(_registryOptions.GetLanguageByExtension(".cs").Id));
    }

    private void LoadTomlToEditor(string filepath)
    {
        using StreamReader reader = File.OpenText(filepath);
        Debug.WriteLine(reader.ReadToEnd());
    }
}