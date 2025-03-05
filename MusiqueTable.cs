using System.Collections.Generic;
using System.Net.Http;
using System.Windows.Controls;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using Eval_11_mars.Entities;

namespace Eval_11_mars_Front
{
    /// <summary>
    /// Logique d'interaction pour Window1.xaml
    /// </summary>
    public partial class MusiqueTable : Window
    {
        private readonly HttpClient _httpClient = new HttpClient { BaseAddress = new Uri("https://localhost:7270") };

        public MusiqueTable()
        {
            InitializeComponent();
            Color_rectangle();
            MusiqueTable_SelectionChanged(this,null);

        }
        private void Color_rectangle()
        {
            LinearGradientBrush gradientBrush = new LinearGradientBrush();
            gradientBrush.StartPoint = new Point(0, 0);
            gradientBrush.EndPoint = new Point(1, 1);
            gradientBrush.GradientStops.Add(new GradientStop(Colors.BlueViolet, 0.0));
            gradientBrush.GradientStops.Add(new GradientStop(Colors.Purple, 1.0));

            // Appliquer le dégradé au bouton
            rectangle_2.Background = gradientBrush;
        }


        private async void MusiqueTable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Charger les données dans le DataGrid
            try
            {
                var tableData = await _httpClient.GetFromJsonAsync<List<Musique>>("https://localhost:7270/api/MusiqueDatacontrol/GetMusique");
                MusiqueTable_1.ItemsSource = tableData;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement des données : {ex.Message}");
            }

            // Logique à exécuter lorsque la sélection change dans le DataGrid
            var selectedArtiste = MusiqueTable_1.SelectedItem as MusiqueDTO;
            if (selectedArtiste != null)
            {
                MessageBox.Show($"Artiste sélectionné : {selectedArtiste.IdArtiste}");
            }
        }






        //private async void Tablespage1_Click(object sender, RoutedEventArgs e)
        //{
        //    using (HttpClient client = new HttpClient())
        //    {
        //        var response = await client.GetAsync("https://localhost:7270/api/MusiqueDatacontrol/GetMusique");
        //        response.EnsureSuccessStatusCode();
        //        if (response.IsSuccessStatusCode)
        //        {
        //            test.Content = await response.Content.ReadAsStringAsync();
        //        }
        //        else
        //        {
        //            MessageBox.Show("Erreur de connexion");
        //        }
        //    }
        //}

        //private async void Tablespage3_Click(object sender, RoutedEventArgs e)
        //{
        //    string idArtiste = IdMusiquetextbox.Text;
        //    using (HttpClient client = new HttpClient())
        //    {
        //        var response = await client.GetAsync($"https://localhost:7270/api/MusiqueDatacontrol/GetMusiquebyid?idArtiste={idArtiste}");
        //        response.EnsureSuccessStatusCode();
        //        if (response.IsSuccessStatusCode)
        //        {
        //            IdMusique.Content = await response.Content.ReadAsStringAsync();
        //        }
        //        else
        //        {
        //            MessageBox.Show("Erreur de connexion");
        //        }
        //    }
        //}

        //private async void Tablespage4_Click(object sender, RoutedEventArgs e)
        //{
        //    string idArtiste = IdArtistetextbox.Text;
        //    using (HttpClient client = new HttpClient())
        //    {
        //        var response = await client.GetAsync($"https://localhost:7270/api/MusiqueDatacontrol/GetArtisteinfobyid?idArtiste={idArtiste}");
        //        response.EnsureSuccessStatusCode();
        //        if (response.IsSuccessStatusCode)
        //        {
        //            IdArtisteinfo.Content = await response.Content.ReadAsStringAsync();
        //        }
        //        else
        //        {
        //            MessageBox.Show("Erreur de connexion");
        //        }
        //    }
        //}
    }
}
