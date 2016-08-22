using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

//“空白页”项模板在 http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409 上有介绍

namespace Todos
{
    /// <summary>
    /// 可用于自身或导航至 Frame 内部的空白页。
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            this.ViewModel = new ViewModels.TodoItemViewModel();
        }

        ViewModels.TodoItemViewModel ViewModel { get; set; }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter.GetType() == typeof(ViewModels.TodoItemViewModel))
            {
                this.ViewModel = (ViewModels.TodoItemViewModel)(e.Parameter);
            }
        }

        private void TodoItem_ItemClicked(object sender, ItemClickEventArgs e)
        {
            ViewModel.SelectedItem = (Models.TodoItem)(e.ClickedItem);
            Frame.Navigate(typeof(NewPage), ViewModel);
        }


        private void AddAppBarButton_Click(object sender, RoutedEventArgs e)
        {
            if (InlineToDoItemViewGrid.Visibility == Visibility.Visible)
            {
                return;
            }
            Frame.Navigate(typeof(NewPage), ViewModel);
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
                ViewModel.AddTodoItem(Title.Text, Description.Text, Date.Date, new BitmapImage(new Uri("ms-appx:///Assets/background.jpg")));
                Frame.Navigate(typeof(MainPage), ViewModel);
            }
        }
        private void Cancel_Click(object sender, RoutedEventArgs e)
        {
            Title.Text = "";
            Description.Text = "";
            Date.Date = DateTimeOffset.Now;
        }
    }
    public class DataConverter : IValueConverter {
        public object Convert(object value, Type targetType, object parameter, string language) {
            bool? ischecked = value as bool?;
            if (ischecked == null || ischecked == false)
            {
                return Visibility.Collapsed;
            }
            else {
                return Visibility.Visible;
            }

        }

        public object ConvertBack(object value, Type targetType, object parameter, string language) {
            throw new NotImplementedException();
        }
    }

}
