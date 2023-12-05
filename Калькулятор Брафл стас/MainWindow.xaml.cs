using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Калькулятор_Брафл_стас
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        bool isboyGender = true;
        public double BMI;
        Border borderGender = new Border();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            GenderMan.BorderThickness = new Thickness(5, 5, 5, 5);
            GenderWomen.BorderThickness = new Thickness(0, 0, 0, 0);
            isboyGender = true;
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
        }

        private void brawlheigth_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            brawlheigth.Text = "";
        }

        private void brawlheigth_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!Char.IsDigit(e.Text, 0) && e.Text != " ")
            {
                e.Handled = true;
            }

        }

        private void brawlheigth_Copy_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            brawlMass.Text = "";
        }

        private void brawlheigth_Copy_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {

            if (!Char.IsDigit(e.Text, 0) && e.Text != " ")
            {
                e.Handled = true;
            }
        }

        private void MediaElement_MediaEnded(object sender, RoutedEventArgs e)
        {
            mediaFon.Position = TimeSpan.Zero;
            mediaFon.Play();
        }

        private void sumButton_MouseDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                double heigth = Convert.ToDouble(brawlheigth.Text) / 100;
                double mass = Convert.ToDouble(brawlMass.Text);
                BMI = mass / Math.Pow(heigth, 2);
                BMI = Math.Round(BMI, 2);
                sliderBMI.Value = BMI;
                textBMI.Text = $"Ваш BMI = {BMI}";
            }
            catch { textError.Text = "Введите значения!"; }
            if (BMI < 18.5)
            {
                textBrawl.Text = "Недостаточный вес";
                if (isboyGender == true)
                {
                    BitmapImage bi3 = new BitmapImage();
                    bi3.BeginInit();
                    bi3.UriSource = new Uri("М худой.png", UriKind.Relative);
                    bi3.EndInit();
                    imageBMI.Source = bi3;
                }
                else
                {
                    BitmapImage bi3 = new BitmapImage();
                    bi3.BeginInit();
                    bi3.UriSource = new Uri("Ж худой.png", UriKind.Relative);
                    bi3.EndInit();
                    imageBMI.Source = bi3;
                }
            }
            else if (BMI >= 18.5 && BMI < 24.9)
            {
                textBrawl.Text = "Здоровый вес";
                if (isboyGender == true)
                {
                    BitmapImage bi3 = new BitmapImage();
                    bi3.BeginInit();
                    bi3.UriSource = new Uri("М здоровый.png", UriKind.Relative);
                    bi3.EndInit();
                    imageBMI.Source = bi3;
                }
                else
                {
                    BitmapImage bi3 = new BitmapImage();
                    bi3.BeginInit();
                    bi3.UriSource = new Uri("Ж здоровый.png", UriKind.Relative);
                    bi3.EndInit();
                    imageBMI.Source = bi3;
                }
            }
            else if (BMI >= 25 && BMI < 29.9)
            {
                textBrawl.Text = "Избыточный вес";
                if (isboyGender == true)
                {
                    BitmapImage bi3 = new BitmapImage();
                    bi3.BeginInit();
                    bi3.UriSource = new Uri("м избытоный.png", UriKind.Relative);
                    bi3.EndInit();
                    imageBMI.Source = bi3;
                }
                else
                {
                    BitmapImage bi3 = new BitmapImage();
                    bi3.BeginInit();
                    bi3.UriSource = new Uri("ж пухлый.png", UriKind.Relative);
                    bi3.EndInit();
                    imageBMI.Source = bi3;
                }
            }
            else
            {
                textBrawl.Text = "Ожирение";
                if (isboyGender == true)
                {
                    BitmapImage bi3 = new BitmapImage();
                    bi3.BeginInit();
                    bi3.UriSource = new Uri("М жирный.png", UriKind.Relative);
                    bi3.EndInit();
                    imageBMI.Source = bi3;
                }
                else
                {
                    BitmapImage bi3 = new BitmapImage();
                    bi3.BeginInit();
                    bi3.UriSource = new Uri("Ж жирный.png", UriKind.Relative);
                    bi3.EndInit();
                    imageBMI.Source = bi3;
                }
            }
        }

        private void GenderWomen_Click(object sender, RoutedEventArgs e)
        {
            GenderWomen.BorderThickness = new Thickness(5, 5, 5, 5);
            GenderMan.BorderThickness = new Thickness(0, 0, 0, 0);
            isboyGender = false;
        }
    }
}
