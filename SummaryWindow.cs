using System.IO;
using System.Net;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace Travel_Planner;

public partial class SummaryWindow : Window
{
    public SummaryWindow(string nameSurname, string country, string city, string attractions, string transport)
    {
        InitializeComponent();
        
        SummaryNameTextBlock.Text = nameSurname;
        SummaryCountryTextBlock.Text = country;
        SummaryCitiesTextBlock.Text = city;
        SummaryAttractionsTextBlock.Text = attractions;
        SummaryTransportTextBlock.Text = transport;
    }

    private void SaveToFileButton_onClick(object? sender, RoutedEventArgs e)
    {
        string path = "travel-planer.txt";
        string content = $"Imię i nazwisko: {SummaryNameTextBlock.Text}\n" +
                         $"Kraj: {SummaryCountryTextBlock.Text}\n" +
                         $"Miasto: {SummaryCitiesTextBlock.Text}\n" +
                         $"Atrakcje: {SummaryAttractionsTextBlock.Text}\n" +
                         $"Transport: {SummaryTransportTextBlock.Text}\n\n";

        if (File.Exists(path))
        {
            File.AppendAllText(path, content);
        }
        else
        {
            File.WriteAllText(path, content);
        }
    }
}