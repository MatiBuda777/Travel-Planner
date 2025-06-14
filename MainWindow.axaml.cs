using System.Collections.Generic;
using System.Linq;
using Avalonia.Controls;
using Avalonia.Interactivity;

namespace Travel_Planner;

public partial class MainWindow : Window
{
    private readonly List<string> _countries =
    [
        "Afganistan", "Albania", "Algieria", "Andora", "Angola", "Antigua i Barbuda", "Arabia Saudyjska", "Argentyna",
        "Armenia", "Australia", "Austria", "Azerbejdżan", "Bahamy", "Bahrajn", "Bangladesz", "Barbados", "Belgia",
        "Belize", "Benin", "Bhutan", "Białoruś", "Boliwia", "Bośnia i Hercegowina", "Botswana", "Brazylia", "Brunei",
        "Bułgaria", "Burkina Faso", "Burundi", "Chile", "Chiny", "Cypr", "Czarnogóra", "Czechy", "Dania",
        "Demokratyczna Republika Konga", "Dominika", "Dominikana", "Dżibuti", "Egipt", "Ekwador", "Erytrea", "Estonia",
        "Eswatini", "Etiopia", "Fidżi", "Filipiny", "Finlandia", "Francja", "Gabon", "Gambia", "Ghana", "Grecja",
        "Grenada", "Gruzja", "Guatemala", "Gwinea", "Gwinea Bissau", "Gwinea Równikowa", "Haiti", "Hiszpania",
        "Holandia", "Honduras", "Indie", "Indonezja", "Irak", "Iran", "Irlandia", "Islandia", "Izrael", "Jamajka",
        "Japonia", "Jemen", "Jordania", "Kambodża", "Kamerun", "Kanada", "Katar", "Kazachstan", "Kenia", "Kirgistan",
        "Kiribati", "Kolumbia", "Komory", "Kongo", "Korea Południowa", "Korea Północna", "Kosowo", "Kostaryka", "Kuba",
        "Kuwejt", "Laos", "Lesotho", "Liban", "Liberia", "Libia", "Liechtenstein", "Litwa", "Luksemburg", "Łotwa",
        "Madagaskar", "Malawi", "Malediwy", "Malezja", "Mali", "Malta", "Maroko", "Mauritius", "Mauretania", "Meksyk",
        "Mołdawia", "Monako", "Mongolia", "Mozambik", "Mjanma", "Namibia", "Nauru", "Nepal", "Niemcy", "Niger",
        "Nigeria", "Norwegia", "Nowa Zelandia", "Oman", "Pakistan", "Panama", "Papua-Nowa Gwinea", "Paragwaj", "Peru",
        "Polska", "Portugalia", "Republika Południowej Afryki", "Republika Środkowoafrykańska", "Rosja", "Rumunia",
        "Rwanda", "Saint Kitts i Nevis", "Saint Lucia", "Saint Vincent i Grenadyny", "Salwador", "Samoa", "San Marino",
        "Senegal", "Serbia", "Seszele", "Sierra Leone", "Singapur", "Słowacja", "Słowenia", "Somalia", "Sri Lanka",
        "Sudan", "Sudan Południowy", "Surinam", "Syria", "Tadżykistan", "Tajlandia", "Tanzania", "Timor Wschodni",
        "Togo", "Tonga", "Trynidad i Tobago", "Tunezja", "Turcja", "Turkmenistan", "Tuvalu", "Uganda", "Ukraina",
        "Urugwaj", "USA", "Uzbekistan", "Vanuatu", "Watykan", "Wenezuela", "Węgry", "Wielka Brytania", "Wietnam",
        "Wybrzeże Kości Słoniowej", "Wyspy Marshalla", "Wyspy Salomona", "Zambia", "Zimbabwe"
    ];
    
    public MainWindow()
    {
        InitializeComponent();

        CountriesComboBox.ItemsSource = _countries;
    }

    private void SummaryButton_OnClick(object? sender, RoutedEventArgs e)
    {
        if (NameTextBox.Text == null || SurnameTextBox == null) return;
        if (CountriesComboBox.SelectedItem == null) return;
        if (CitiesListBox.SelectedItem == null) return;
        
        var nameSurname = $"{NameTextBox.Text} {SurnameTextBox.Text}";
        var country = CountriesComboBox?.SelectedItem?.ToString() ?? "Nie wybrano państwa";
        var city = CitiesListBox?.SelectedItem?.ToString() ?? "Nie wybrano miasta";
        
        var selectedAttractions = new List<string>
        {
            MuseumCheckBox.IsChecked == true ? "Muzea" : null,
            NationalParksCheckBox.IsChecked == true ? "Parki Narodowe" : null,
            MonumentsCheckBox.IsChecked == true ? "Zabytki" : null,
            RestaurantsCheckBox.IsChecked == true ? "Restauracje" : null,
            ArtGalleriesCheckBox.IsChecked == true ? "Galerie Sztuki" : null,
            FestivalsAndConcertsCheckBox.IsChecked == true ? "Festiwale i Koncerty" : null,
        }.Where(x => x != null).ToList();
        if (selectedAttractions.Count == 0) selectedAttractions.Add("Brak");
        var attractions = string.Join(", ", selectedAttractions);
        
        var transport = AirplaneRadioButton.IsChecked == true ? "Samolot" :
            BusRadioButton.IsChecked == true ? "Autobus" :
            CarRadioButton.IsChecked == true ? "Samochód" :
            ShipRadioButton.IsChecked == true ? "Statek" :
            TrainRadioButton.IsChecked == true ? "Pociąg" : "Brak";

        var summaryWindow = new SummaryWindow(nameSurname, country, city, attractions, transport);
        summaryWindow.ShowDialog(this);
    }

    private void AddCityButton_OnClick(object? sender, RoutedEventArgs e)
    {
        var cityName = AddCityTextBox.Text;
        if (string.IsNullOrEmpty(cityName)) return;
        CitiesListBox.Items.Add(cityName);
    }

    private void CitiesListBox_OnSelectionChanged(object? sender, SelectionChangedEventArgs e)
    {
        var selectedItem = CitiesListBox.SelectedItem as Label;
    }
}