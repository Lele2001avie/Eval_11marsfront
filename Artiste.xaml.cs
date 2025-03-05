using Eval_11_mars.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Eval_11_mars_Front
{
    ///<summary>
    /// Logique d'interaction pour Window1.xaml
    /// </summary>
    public partial class Artiste : Window
    {
        private readonly HttpClient _httpClient = new HttpClient { BaseAddress = new Uri("https://localhost:7270") } ;
        
        public Artiste()
        {
            InitializeComponent();
            Color_rectangle();
            ArtisteTable_SelectionChanged(this,null);
        }
        private void Color_rectangle()
        {
            LinearGradientBrush gradientBrush = new LinearGradientBrush();
            gradientBrush.StartPoint = new Point(0, 0);
            gradientBrush.EndPoint = new Point(1, 1);
            gradientBrush.GradientStops.Add(new GradientStop(Colors.BlueViolet, 0.0));
            gradientBrush.GradientStops.Add(new GradientStop(Colors.Purple, 1.0));

            // Appliquer le dégradé au bouton
            rectangle_3.Background = gradientBrush;
        }
        private async void ArtisteTable_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            // Charger les données dans le DataGrid
            try
            {
                var tableData = await _httpClient.GetFromJsonAsync<List<ArtisteinfoDTO>>("https://localhost:7270/api/MusiqueDatacontrol/GetArtisteinfo");
                ArtisteTable_1.ItemsSource = tableData;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Erreur lors du chargement des données : {ex.Message}");
            }

            // Logique à exécuter lorsque la sélection change dans le DataGrid
            var selectedArtiste = ArtisteTable_1.SelectedItem as ArtisteinfoDTO;
            if (selectedArtiste != null)
            {
                MessageBox.Show($"Artiste sélectionné : {selectedArtiste.Nom}");
            }
        }





    }

}
