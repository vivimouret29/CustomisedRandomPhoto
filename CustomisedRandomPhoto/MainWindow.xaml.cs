using System.Collections.ObjectModel;
using System.Net;
using System.Threading;
using System.Windows;
using Microsoft.Win32;

using CustomisedRandomPhoto.ViewBinding;

namespace CustomisedRandomPhoto
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml.cs
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly string webRequest =
            "https://source.unsplash.com/random";

        private readonly ObservableCollection<BindingMainWindows> Images =
            new ObservableCollection<BindingMainWindows> { };

        public MainWindow()
        {
            InitializeComponent();
            WindowStartupLocation =
                WindowStartupLocation.CenterScreen;

            this.DisplayListImage();

            ListImageUri.ItemsSource = this.Images;
        }

        /// <summary>
        /// Calls each time the url link
        /// </summary>
        private string LoadOneNewImage()
        {
            HttpWebRequest request = WebRequest.Create(webRequest) as HttpWebRequest;
            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                return (string)response.ResponseUri.AbsoluteUri;
            }
        }

        /// <summary>
        /// Logical interaction of a loop for a list
        /// </summary>
        private void DisplayListImage()
        {
            for (int i = 0; i < 10; i++)
            {
                Images.Add(item: new BindingMainWindows() { ImageUri = this.LoadOneNewImage() });
                Thread.Sleep(1000);
            }
        }

        /// <summary>
        /// Interaction to download an image from local
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FindLocalImage(object sender, RoutedEventArgs e)
        {
            OpenFileDialog openFileDialog =
                new OpenFileDialog
                {
                    Title = "Select a picture",
                    Filter = "All supported graphics|*.jpg;*.jpeg;*.png|" +
              "JPEG (*.jpg;*.jpeg)|*.jpg;*.jpeg|" +
              "Portable Network Graphic (*.png)|*.png"
                };

            if ((bool)openFileDialog.ShowDialog())
            {
                this.Images.Insert(0, item: new BindingMainWindows() { ImageUri = openFileDialog.FileName });
            }
        }
    }
}
