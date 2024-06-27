using Avalonia.Controls;
using Avalonia.Markup.Xaml;

namespace calculator.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }
    private void InitializeComponent()
    {
        AvaloniaXamlLoader.Load(this);
    }
}