using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace YammerApi
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        ObservableCollection<Model> list;
        public MainPage()
        {
            this.InitializeComponent();
            list=new ObservableCollection<Model>();
            list.Add(new Model() { head = "FIRST", num = 1 });
            list.Add(new Model() { head = "SECOND", num = 2 });
            list.Add(new Model() { head = "THIRD", num = 3 });
            list.Add(new Model() { head = "FOURTH", num = 4 });

            ls.ItemsSource = list;

        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            int cou = list.Count+1;
            list.Insert(0, new Model() { head = cou.ToString(), num=cou});
            //ls.SelectedItem(list.Count)
            await Task.Delay(1000);
                ls.SelectedIndex = 0;
            //Get ItemContainer
            ListViewItem lvi = (ListViewItem)ls.ContainerFromIndex(0);
            DependencyObject dob = VisualTreeHelper.GetChild(lvi, 0);
            //Get DataContext StackPanel or Grid
            dob = VisualTreeHelper.GetChild(dob, 0);
            ////Get first TextBox in ListViewItem
            dob = VisualTreeHelper.GetChild(dob, 0);
            //SetFocus
            TextBox tbx = (dob as TextBox);
            await Windows.ApplicationModel.Core.CoreApplication.MainView.CoreWindow
                .Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Low,
            () => tbx.Focus(FocusState.Programmatic));
        }
    }
    class Model
    {
        public string head { get; set; }
        public int num { get; set; }
    }

}
