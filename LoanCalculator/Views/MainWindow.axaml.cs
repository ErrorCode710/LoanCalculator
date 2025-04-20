using Avalonia.Controls;
using Avalonia.Interactivity;

namespace LoanCalculator.Views;

public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    public void Next(object source, RoutedEventArgs args)
    {
        slides.Next();
    }

    public void Previous(object source, RoutedEventArgs args)
    {
        slides.Previous();
    }
}