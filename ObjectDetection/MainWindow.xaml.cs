using System.Windows;
using Alturos.Yolo;
using Microsoft.Win32;
using System.Windows.Media.Imaging;

namespace ObjectDetection
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var configurationDetector = new ConfigurationDetector();
            var config = configurationDetector.Detect();
            using (var yoloWrapper = new YoloWrapper(config))
            {
                var items = yoloWrapper.Detect("image.png");
            }
        }

        private void Button1_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.png;*.jpeg)|*.png;*.jpeg||";
            if (openFileDialog.ShowDialog() == true)
            {
                Image.Source = new BitmapImage(new System.Uri(openFileDialog.FileName));
            }
        }
    }
}
