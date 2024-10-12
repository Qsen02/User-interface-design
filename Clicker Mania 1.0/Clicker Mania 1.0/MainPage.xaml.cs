using System;
using System.IO;
using System.Text;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

namespace Clicker_Mania_1._0
{
    public sealed partial class MainPage : Page
    {
        // Counter
        private int counter = 0;

        // Constructor
        public MainPage()
        {
            this.InitializeComponent();
            Read();
        }

        // Button Click Event Handler
        private void ClickHandler(object sender, RoutedEventArgs e)
        {
            counter = counter + 1;
            this.Clicks.Text = counter.ToString();
            Save(Clicks.Text);
        }

        // Save to File
        private async void Save(string content)
        {
            try
            {
                StorageFolder storage = ApplicationData.Current.LocalFolder;
                byte[] bytes = Encoding.UTF8.GetBytes(content.ToCharArray());
                var file = await storage.CreateFileAsync("clicker.txt", CreationCollisionOption.ReplaceExisting);
                using (var stream = await file.OpenStreamForWriteAsync())
                {
                    stream.Write(bytes, 0, bytes.Length);
                }
            }
            catch(Exception err)
            {
                ContentDialog modal = new ContentDialog
                {
                    Title = "Error",
                    Content = err.Message,
                    CloseButtonText="OK"
                };
                await modal.ShowAsync();
            }
        }

        // Read from File
        private async void Read()
        {
            try
            {
                StorageFolder storage = ApplicationData.Current.LocalFolder;
                StorageFile file = await storage.GetFileAsync("clicker.txt");
                if (file == null)
                {
                    file = await storage.CreateFileAsync("clicker.txt");
                }
                else
                {
                    Stream stream = await file.OpenStreamForReadAsync();
                    StreamReader reader = new StreamReader(stream);
                    Clicks.Text = reader.ReadToEnd();
                    if (Clicks.Text == "")
                    {
                        Clicks.Text = "0";
                        counter = 0;
                    }
                    else counter = int.Parse(Clicks.Text);
                }
            }
            catch(Exception err)
            {
                ContentDialog modal = new ContentDialog
                {
                    Title = "Error",
                    Content = err.Message,
                    CloseButtonText = "OK"
                };
                await modal.ShowAsync();
            }
        }
    }
}