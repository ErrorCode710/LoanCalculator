using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Markup.Xaml;
using System;
using System.Diagnostics;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace LoanCalculator.Views;

public partial class PurchaseWindow : Window
{
    public PurchaseWindow()
    {
        InitializeComponent();
    }

    private string _cardPrice;

    private int downPayment;
    private int paymentTerm;
    private int carPrice;


    private int downPaymentTotal;
    private int amountFinanced;
    private int monthlyPayment; 

    public string CardPrice
    {
        get => _cardPrice;
        set
        {
            _cardPrice = value;
            string numOnly = value.Substring(1).Replace(",", "");

            int number = int.Parse(numOnly);

            this.FindControl<TextBlock>("loanAmount").Text = value;
            this.FindControl<TextBlock>("SummaryCarPrice").Text = value;

            var slider = this.FindControl<Slider>("slider").Value = number;

            carPrice = number;


            
        }
    }
    private void LoanComputation(){
        downPaymentTotal = (carPrice * downPayment) / 100;
        amountFinanced = carPrice - downPaymentTotal;
        monthlyPayment = (amountFinanced / paymentTerm);

       
    }
    private void slider1_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
    {
        Debug.WriteLine(e.NewValue);

        downPayment = (int)e.NewValue;



    }
    private void slider2_ValueChanged(object sender, RangeBaseValueChangedEventArgs e)
    {
       paymentTerm = (int)e.NewValue;
        
        Debug.WriteLine(e.NewValue);
    }
    private void updateLoanSummary (object sender, Avalonia.Interactivity.RoutedEventArgs e)
    {
        LoanComputation();

        this.FindControl<TextBlock>("totalDownP").Text = "₱" + downPaymentTotal.ToString("N0");
        this.FindControl<TextBlock>("amountFinance").Text = "₱" + amountFinanced.ToString("N0");
        this.FindControl<TextBlock>("MonthlyAmortization").Text = "₱" + monthlyPayment.ToString("N0");

    }


}