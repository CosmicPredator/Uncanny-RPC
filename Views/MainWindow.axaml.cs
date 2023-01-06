using System;
using System.ComponentModel;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace UncannyRPC.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    protected override void OnClosing(CancelEventArgs e)
    {
        e.Cancel = true;
        ShowInTaskbar = false;
        Hide();
        base.OnClosing(e);
    }

    private async void Button_OnClick(object? sender, RoutedEventArgs e)
    {
        var dialog = new TomlEditor();
        await dialog.ShowDialog(this);
    }

    private void ToggleButton_OnChecked(object? sender, RoutedEventArgs e)
    {
        
    }
}