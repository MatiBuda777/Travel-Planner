using Avalonia.Controls;

namespace Travel_Planner;

public partial class SummaryWindow : Window
{
    public string NameSurname { get; set; }
    public string Country { get; set; }
    public string City { get; set; }
    public string Attractions { get; set; }
    public string Transport { get; set; }
    
    
    public SummaryWindow()
    {
        InitializeComponent();
        
        SummaryNameTextBlock.Text = NameSurname;
        SummaryCountryTextBlock.Text = Country;
        SummaryCitiesTextBlock.Text = City;
        SummaryAttractionsTextBlock.Text = Attractions;
        SummaryTransportTextBlock.Text = Transport;
    }
}