using System.Net.Http;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Eval_11_mars_Front
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ApplyGradientToRectangle();
            changecolor(Tablespage1);
        }
        private void ApplyGradientToRectangle()
        {
            // Créer un dégradé linéaire
            LinearGradientBrush gradientBrush = new LinearGradientBrush();
            gradientBrush.StartPoint = new Point(0, 0);
            gradientBrush.EndPoint = new Point(1, 1);
            gradientBrush.GradientStops.Add(new GradientStop(Colors.BlueViolet, 0.0));
            gradientBrush.GradientStops.Add(new GradientStop(Colors.Purple, 1.0));

            // Appliquer le dégradé au bouton
            rectangle.Fill = gradientBrush;
            Tablespage1.Background = gradientBrush;
            Musique.Background = gradientBrush;
           


        }

        private void changecolor(Button button)
        {
            // Créer un dégradé linéaire
            LinearGradientBrush gradientBrush = new LinearGradientBrush();
            gradientBrush.StartPoint = new Point(0, 0);
            gradientBrush.EndPoint = new Point(1, 1);
            gradientBrush.GradientStops.Add(new GradientStop(Colors.BlueViolet, 0.0));
            gradientBrush.GradientStops.Add(new GradientStop(Colors.Purple, 1.0));

            // Appliquer le dégradé au bouton
            button.Background = gradientBrush;


        }
        private void Tablespage1_Click(object sender, RoutedEventArgs e)
        {
            Artiste table = new Artiste();
            table.Show();
            changecolor(Tablespage1);
        }

        private void Musique_Click(object sender, RoutedEventArgs e)
        {
            MusiqueTable musique = new MusiqueTable();
            musique.Show();
            changecolor(Musique);
        }

    }
}