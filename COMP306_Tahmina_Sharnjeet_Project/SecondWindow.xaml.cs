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
using System.Windows.Shapes;

namespace COMP306_Tahmina_Sharnjeet_Project
{
    /// <summary>
    /// Interaction logic for SecondWindow.xaml
    /// </summary>
    public partial class SecondWindow : Window
    {
        public SecondWindow()
        {
            InitializeComponent();
        }

        private void websiteButton_Click(object sender, RoutedEventArgs e)
        {
            // Launch browser to facebook...
            System.Diagnostics.Process.Start("https://www.expedia.ca/Hotel-Search?adults=2&d1=2020-11-29&d2=2020-11-30&destination=Las%20Vegas%20%28and%20vicinity%29%2C%20Nevada%2C%20United%20States%20of%20America&endDate=2020-11-30&latLong=36.114666%2C-115.172872&regionId=178276&rooms=1&semdtl=&sort=RECOMMENDED&startDate=2020-11-29&theme=&useRewards=false&userIntent");
        }
    }
}
