using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using Avalonia.Media.Imaging;
using Avalonia.Platform;
using System;

namespace LoanCalculator.Views;

public partial class CardCardsView : UserControl
{
    public CardCardsView()
    {
        InitializeComponent();
    }
    public string CardTitle
    {
        get => carName.Text;
        set => carName.Text = value;
    }

    public string CardPrice
    {
        get => price.Text;
        set => price.Text = value;
    }

    public string CardImageSource
    {
        get => carImage.Source?.ToString();
        set
        {
            var uri = new Uri(value);
            var assets = AssetLoader.Open(uri);
            carImage.Source = new Bitmap(assets);
        }

    }
}