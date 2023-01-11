namespace UncannyRPC.Views;

public partial class MainWindow : Window
{
    public RpcHandler Handler;
    public MainWindow()
    {
        Logger.TryGet(LogEventLevel.Fatal, LogArea.Control)?.Log(this, "Avalonia Infrastructure");
        Debug.WriteLine("System Diagnostics Debug");
        InitializeComponent();
        Handler = new RpcHandler();
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
        Handler.RunPresence();
    }

    private void ToggleButton_OnUnchecked(object? sender, RoutedEventArgs e)
    {
        Handler.StopPresence();
    }

    private void HyperlinkButton_OnClick(object? sender, RoutedEventArgs e)
    {
        Process.Start(new ProcessStartInfo { FileName = "https://github.com/CosmicPredator/Uncanny-RPC", UseShellExecute = true });
    }
}