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

namespace OstManSysMVVM.View
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ResidentView : Page
    {
        public ResidentView()
        {
            this.InitializeComponent();
            MyFrame1.Navigate(typeof(ResidentApartmentDetails));
        }

        private void ButtonClick_OnClick(object sender, RoutedEventArgs e)
        {
            MyFrame1.Navigate(typeof(ResidentApartmentDetails));
        }

        private void Button11_OnClick(object sender, RoutedEventArgs e)
        {
            MyFrame1.Navigate(typeof(ResidentDownpipesDetails));
        }
    }
}
