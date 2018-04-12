using Parkeringssimulering;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Documents;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace frontEndSimulation
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class BlankPage1 : Page
    {
        public BlankPage1()
        {
            this.InitializeComponent();
            ApplicationView.PreferredLaunchViewSize = new Size(1280, 720);
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.PreferredLaunchViewSize;
            string contextString = main.Initialize(MainPage.parkeringsPlasserArray, MainPage.parkeringsPercentArray, MainPage.amountOfCars, MainPage.timeFrom, MainPage.timeTo, MainPage.simulationSpeed);
            TextBlock tb = FindName("context") as TextBlock;
            tb.Text = contextString;
            /*
            char[] seperator = new char[] { '$' };
            string[] contextArray = contextString.Split(seperator, StringSplitOptions.None);
            foreach (string s in contextArray)
            {
                tb.Text += s;
                tb.Text += "\r\n";
            }
            */
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            main.clearForReRun();
            this.Frame.Navigate(typeof(MainPage));
        }
    }
}
