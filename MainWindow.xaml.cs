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

namespace S3WPF1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
      

        private void calculateButton_Click(object sender, RoutedEventArgs e)
        {
            double r, h, V = 0, P = 0; ;

            try 
            {
                r = Convert.ToDouble(promienBox.Text);
                h = Convert.ToDouble(heightBox.Text);

                if (r < 0 || h < 0)
                {
                    MessageBox.Show("Zla wartosc. Podaj wartosc dodatnia.");
                }

                if (chkObjetosc.IsChecked == true)
                {
                    switch(cbxRodzajBryly.SelectedIndex)
                    {
                        case 0:
                            V = Math.PI * Math.Pow(r, 2) * h;
                            break;
                        case 1:
                            V = (Math.PI * Math.Pow(r, 2) * h) * (1.0 / 3.0);
                            break;
                        case 2:
                            V = 4.0 / 3.0 * Math.PI * Math.Pow(r, 3);
                            break;

                    }
                }

                if (chkPole.IsChecked == true)
                {
                    switch (cbxRodzajBryly.SelectedIndex)
                    {
                        case 0:
                            P = 2.0 * Math.PI * Math.Pow(r, 2) + (2.0 * Math.PI * r * h);
                            break;
                        case 1:
                            P = (2.0 * Math.PI * Math.Pow(r, 2) + (2.0 * Math.PI * r * h))/(1.0/3.0);
                            break;
                        case 2:
                            P = 4.0 / 3.0 * Math.PI * Math.Pow(r, 3);
                            break;

                    }
                }


                //lblWynik.Content = V.ToString("F2");

                lblObjetosc.Content = $"Objetosc dla bryly: {cbxRodzajBryly.SelectionBoxItem} wynosi: {V:F2} m^3";
                lblPole.Content = $"Objetosc dla bryly: {cbxRodzajBryly.SelectionBoxItem} wynosi: {V:F2} m^3";
            } catch { MessageBox.Show("Zly format"); }
            

            
        }

        private void cbxRodzajBryly_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cbxRodzajBryly.SelectedIndex == 2)
            {
                heightBox.Visibility = Visibility.Hidden;
            }
            else
                heightBox.Visibility = Visibility.Visible;
               
        }

        private void exitBox_Click(object sender, RoutedEventArgs e)
        {
            if (MessageBox.Show("Czy na pewno?", "Pytanie", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                this.Close();
            }
        }
    }
}
