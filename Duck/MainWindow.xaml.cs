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
using Newtonsoft.Json;
using RestSharp;

namespace Duck
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

        Image img = new Image();    

        private void Button_Click(object sender, RoutedEventArgs e)
        {

            string uri = "https://random-d.uk/api/v2/random";

            RestClient client = new RestClient(uri);
            RestRequest request = new RestRequest();
            var response = client.ExecuteAsync(request).Result.Content;

            DuckJson duck_json = JsonConvert.DeserializeObject<DuckJson>(response);

            stack.Children.Remove(img);

            img.Source = new BitmapImage(new Uri(duck_json.url));
            img.Height = 200;
            img.Width = 300;

            stack.Children.Add(img);


        }
    }

    class DuckJson
    {
        public string message { get; set; }
        public string url { get; set; }
    }
}
