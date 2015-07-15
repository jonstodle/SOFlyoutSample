using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=234238

namespace SOFlyoutSample
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();

            //this.NavigationCacheMode = NavigationCacheMode.Required;
        }

        /// <summary>
        /// Invoked when this page is about to be displayed in a Frame.
        /// </summary>
        /// <param name="e">Event data that describes how this page was reached.
        /// This parameter is typically used to configure the page.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
			var listSource = new List<SampeClass>();
			for (int i = 0; i < 10; i++)
			{
				listSource.Add(new SampeClass
				{
					Prop1 = string.Format("Prop1, iteration #{0}", (i + 1).ToString()),
					Prop2 = string.Format("Prop2, iteration #{0}", (i + 1).ToString()),
					Prop3 = string.Format("Prop3, iteration #{0}", (i + 1).ToString())
				});
			}
			MainLvw.ItemsSource = listSource;
        }

		private void MainLvw_SelectionChanged(object sender, SelectionChangedEventArgs e)
		{
			var sndr = (ListView)sender;
			var item = (SampeClass)sndr.SelectedItem;
			RootGrd.DataContext = item;
			FlyoutBase.ShowAttachedFlyout(RootGrd);
		}

		private void Button_Click(object sender, RoutedEventArgs e)
		{
			MainFlt.Hide();
		}
	}

	public class SampeClass
	{
		public string Prop1 { get; set; }
		public string Prop2 { get; set; }
		public string Prop3 { get; set; }
	}
}
