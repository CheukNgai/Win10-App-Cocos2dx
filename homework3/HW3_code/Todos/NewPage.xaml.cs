using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;
using Windows.UI.Popups;
using Windows.Storage.Pickers;
using Windows.UI.Xaml.Media.Imaging;


// “空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=234238 上提供

namespace Todos
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class NewPage : Page
    {
        public NewPage()
        {
            this.InitializeComponent();
        }

        private ViewModels.TodoItemViewModel ViewModel;

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            Frame rootFrame = Window.Current.Content as Frame;

            if (rootFrame.CanGoBack)
            {
                // Show UI in title bar if opted-in and in-app backstack is not empty.
                SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility =
                    AppViewBackButtonVisibility.Visible;
            }
            else
            {
                // Remove the UI from the title bar if in-app back stack is empty.
                SystemNavigationManager.GetForCurrentView().AppViewBackButtonVisibility =
                    AppViewBackButtonVisibility.Collapsed;
            }


            ViewModel = ((ViewModels.TodoItemViewModel)e.Parameter);
            if (ViewModel.SelectedItem == null)
            {
                createButton.Visibility = Visibility.Visible;
                updateButton.Visibility = Visibility.Collapsed;
                DeleteBarButton.Visibility = Visibility.Collapsed;
                //var i = new MessageDialog("Welcome!").ShowAsync();
            }
            else
            {
                createButton.Visibility = Visibility.Collapsed;
                updateButton.Visibility = Visibility.Visible;
                DeleteBarButton.Visibility = Visibility.Visible;
                Title.Text = ViewModel.SelectedItem.title;
                Description.Text = ViewModel.SelectedItem.description;
                Date.Date = ViewModel.SelectedItem.date;
                // ...
            }
        }

        private void CreateButton_Clicked(object sender, RoutedEventArgs e)
        {
            string ErrorInformation = "";
            if (Title.Text == "")
            {
                ErrorInformation += "未正确填写标题\n";
            }
            if (Description.Text == "")
            {
                ErrorInformation += "未正确填写详情\n";
            }
            DateTimeOffset temp = Date.Date;
            DateTimeOffset now = DateTimeOffset.Now;
            if (DateTimeOffset.Compare(temp, now) <= 0)
            {
                ErrorInformation += "截止日期必须超过今天\n";
            }
            if (ErrorInformation != "")
            {
                ErrorInformation = "错误如下：\n" + ErrorInformation;
                var i = new MessageDialog(ErrorInformation).ShowAsync();
            }
            else {
                ViewModel.AddTodoItem(Title.Text, Description.Text, Date.Date, Cover.Source);
                Frame.Navigate(typeof(MainPage), ViewModel);
            }
        }
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Title.Text = "";
            Description.Text = "";
            Date.Date = DateTimeOffset.Now;
            Cover.Source = new BitmapImage(new Uri("ms-appx:///Assets/background.jpg"));
        }
        private async void Upload_Click(object sender, RoutedEventArgs e)
        {
            // Set up the file picker.
            Windows.Storage.Pickers.FileOpenPicker openPicker =
                new Windows.Storage.Pickers.FileOpenPicker();
            openPicker.SuggestedStartLocation =
                Windows.Storage.Pickers.PickerLocationId.PicturesLibrary;
            openPicker.ViewMode =
                Windows.Storage.Pickers.PickerViewMode.Thumbnail;

            // Filter to include a sample subset of file types.
            openPicker.FileTypeFilter.Clear();
            openPicker.FileTypeFilter.Add(".bmp");
            openPicker.FileTypeFilter.Add(".png");
            openPicker.FileTypeFilter.Add(".jpeg");
            openPicker.FileTypeFilter.Add(".jpg");

            // Open the file picker.
            Windows.Storage.StorageFile file =
                await openPicker.PickSingleFileAsync();

            // 'file' is null if user cancels the file picker.
            if (file != null)
            {
                // Open a stream for the selected file.
                // The 'using' block ensures the stream is disposed
                // after the image is loaded.
                using (Windows.Storage.Streams.IRandomAccessStream fileStream =
                    await file.OpenAsync(Windows.Storage.FileAccessMode.Read))
                {
                    // Set the image source to the selected bitmap.
                    Windows.UI.Xaml.Media.Imaging.BitmapImage bitmapImage =
                        new Windows.UI.Xaml.Media.Imaging.BitmapImage();
                    bitmapImage.SetSource(fileStream);
                    Cover.Source = bitmapImage;
                }
            }

        }
        private void DeleteButton_Clicked(object sender, RoutedEventArgs e)
        {
            if (ViewModel.SelectedItem != null)
            {
                ViewModel.RemoveTodoItem();
                Frame.Navigate(typeof(MainPage), ViewModel);
            }

        }
        private void UpdateButton_Clicked(object sender, RoutedEventArgs e)
        {
            if (ViewModel.SelectedItem != null)
            {
                string ErrorInformation = "";
                if (Title.Text == "")
                {
                    ErrorInformation += "未正确填写标题\n";
                }
                if (Description.Text == "")
                {
                    ErrorInformation += "未正确填写详情\n";
                }
                DateTimeOffset temp = Date.Date;
                DateTimeOffset now = DateTimeOffset.Now;
                if (DateTimeOffset.Compare(temp, now) <= 0)
                {
                    ErrorInformation += "截止日期必须超过今天\n";
                }
                if (ErrorInformation != "")
                {
                    ErrorInformation = "错误如下：\n" + ErrorInformation;
                    var i = new MessageDialog(ErrorInformation).ShowAsync();
                }
                else {

                    ViewModel.UpdateTodoItem(Title.Text, Description.Text, Date.Date, Cover.Source);
                    Frame.Navigate(typeof(MainPage), ViewModel);
                }
            }
        }
    }
}
