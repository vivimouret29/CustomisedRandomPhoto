using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Net;
using System.Windows;

using CustomisedRandomPhoto.ViewBinding;

namespace CustomisedRandomPhoto
{
    /// <summary>
    /// Logique d'interaction pour MainWindow.xaml.cs
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly string webRequest = "https://source.unsplash.com/random";

        //private readonly BindingMainWindows bindingMainWindows =
        //    new BindingMainWindows();

        public ObservableCollection<string> Images =
            new ObservableCollection<string> { };

        public MainWindow()
        {
            InitializeComponent();

            this.DisplayListImage();

            //this.DataContext = bindingMainWindows;
            observableCollection.ItemsSource = Images;
        }

        /// <summary>
        /// Calls each time the url link
        /// </summary>
        /// <returns></returns>
        private string LoadOneNewImage()
        {
            //response.ResponseUri.AbsoluteUri

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
            ObservableCollection<string> imageValue =
                new ObservableCollection<string> { };

            for (int i = 0; i < 10; i++)
            {
                //Images.Add(new ListImages() { Uri = this.LoadOneNewImage() } );
                Images.Add(this.LoadOneNewImage());
            }

            observableCollection.ItemsSource = Images;
            //bindingMainWindows.ImageUri = imageValue;
        }

    }
    public class ListImages
    {
        public string Uri
        {
            get;
            set;
        }
    }
}
