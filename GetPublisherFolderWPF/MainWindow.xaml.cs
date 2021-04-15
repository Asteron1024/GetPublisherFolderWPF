using System;
using System.IO;
using System.Text;
using System.Windows;
using Windows.Storage;

namespace GetPublisherFolderWPF
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;
        }

        private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            var folder = Windows.Storage.ApplicationData.Current.GetPublisherCacheFolder("SomeFolder");
            var file = await folder.CreateFileAsync("SomeFile", CreationCollisionOption.OpenIfExists);

            using var fileStream = await file.OpenStreamForWriteAsync();
            var buffer = Encoding.UTF8.GetBytes("SomeContent");
            await fileStream.WriteAsync(buffer, 0, buffer.Length);
        }
    }
}
