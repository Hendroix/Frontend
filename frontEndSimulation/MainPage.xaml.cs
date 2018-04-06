using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text.RegularExpressions;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Core;
using Windows.UI.ViewManagement;
using Windows.UI;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace frontEndSimulation
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            ApplicationView.PreferredLaunchViewSize = new Size(1280, 720);
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.PreferredLaunchViewSize;

        }

        private void startButton_Click(object sender, RoutedEventArgs e)
        {
            TextBlock percentage = this.FindName("percentage") as TextBlock;
            string percentagecheck = percentage.Text.ToString();
            percentagecheck = percentagecheck.Remove(percentagecheck.Length -1);
            double tmp;
            if (double.TryParse(percentagecheck, out tmp) && tmp == 100)
            {
                Debug.WriteLine("Nå skal simuleringen starte");

            }
            else
            {
                percentage.Foreground = new SolidColorBrush(Colors.Red);
            }
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (!Regex.IsMatch(tb.Text, "^\\d*\\.?\\d*$"))
            {
                int pos = tb.SelectionStart - 1;
                if (pos < 0)
                {
                    pos = 0;
                }
                tb.Text = tb.Text.Remove(pos, 1);
                tb.SelectionStart = pos;
                updateMaxParkingSpots();
            }
            else if (tb.Text == "" && tb.SelectionLength < 1) 
            {
                tb.Text = "0";
                updateMaxParkingSpots();
            }
            else
            {
                updateMaxParkingSpots();
            }
        }

        private void TextBox_KeyDown(object sender, KeyRoutedEventArgs e)
        {
            double tmp;
            TextBox tb = (TextBox)sender;
            string text = tb.Text;
            if (double.TryParse(text, out tmp))
            {
                if (e.Key == Windows.System.VirtualKey.Up && tmp < 1000)
                {
                    tb.Text = (tmp + 1).ToString();
                    updateMaxParkingSpots();
                }
                if (e.Key == Windows.System.VirtualKey.Down && tmp >= 1)
                {
                    tb.Text = (tmp - 1).ToString();
                    updateMaxParkingSpots();
                }
            }
        }

        private void TextBox_TextChanged_1(object sender, TextChangedEventArgs e)
        {
            TextBox tb = (TextBox)sender;
            if (!Regex.IsMatch(tb.Text, "^\\d*\\.?\\d*$"))
            {
                int pos = tb.SelectionStart - 1;
                if (pos < 0)
                {
                    pos = 0;
                }
                tb.Text = tb.Text.Remove(pos, 1);
                tb.SelectionStart = pos;
                updateArrivingPercentage();
            }
            else if (tb.Text == "" && tb.SelectionLength < 1)
            {
                tb.Text = "0";
                updateArrivingPercentage();
            }
            else
            {
                updateArrivingPercentage();
            }
        }

        private void TextBox_KeyDown_1(object sender, KeyRoutedEventArgs e)
        {
            double tmp;
            TextBox tb = (TextBox)sender;
            string text = tb.Text;
            if (double.TryParse(text, out tmp))
            {
                if (e.Key == Windows.System.VirtualKey.Up && tmp < 100)
                {
                    tb.Text = (tmp + 1).ToString();
                    updateArrivingPercentage();
                }
                if (e.Key == Windows.System.VirtualKey.Down && tmp >= 1)
                {
                    tb.Text = (tmp - 1).ToString();
                    updateArrivingPercentage();
                }
            }
        }

        private void updateMaxParkingSpots()
        {
            double tmp = 0;
            TextBlock pMax = this.FindName("totalpplass") as TextBlock;
            TextBox p1 = this.FindName("pplass1") as TextBox;
            tmp += double.Parse(p1.Text);
            TextBox p2 = this.FindName("pplass2") as TextBox;
            tmp += double.Parse(p2.Text);
            TextBox p3 = this.FindName("pplass3") as TextBox;
            tmp += double.Parse(p3.Text);
            TextBox p4 = this.FindName("pplass4") as TextBox;
            tmp += double.Parse(p4.Text);
            TextBox p5 = this.FindName("pplass5") as TextBox;
            tmp += double.Parse(p5.Text);
            TextBox p6 = this.FindName("pplass6") as TextBox;
            tmp += double.Parse(p6.Text);
            TextBox p7 = this.FindName("pplass7") as TextBox;
            tmp += double.Parse(p7.Text);
            TextBox p8 = this.FindName("pplass8") as TextBox;
            tmp += double.Parse(p8.Text);
            TextBox p9 = this.FindName("pplass9") as TextBox;
            tmp += double.Parse(p9.Text);
            TextBox p10 = this.FindName("pplass10") as TextBox;
            tmp += double.Parse(p10.Text);
            TextBox p11 = this.FindName("pplass11") as TextBox;
            tmp += double.Parse(p11.Text);
            pMax.Text = tmp.ToString();
        }

        private void updateArrivingPercentage()
        {
            double tmp = 0;
            TextBlock percentage = this.FindName("percentage") as TextBlock;
            TextBox p1 = this.FindName("p1") as TextBox;
            tmp += double.Parse(p1.Text);
            checkIfStillOk(tmp, percentage);
            TextBox p2 = this.FindName("p2") as TextBox;
            tmp += double.Parse(p2.Text);
            checkIfStillOk(tmp, percentage);
            TextBox p3 = this.FindName("p3") as TextBox;
            tmp += double.Parse(p3.Text);
            checkIfStillOk(tmp, percentage);
            TextBox p4 = this.FindName("p4") as TextBox;
            tmp += double.Parse(p4.Text);
            checkIfStillOk(tmp, percentage);
            TextBox p5 = this.FindName("p5") as TextBox;
            tmp += double.Parse(p5.Text);
            checkIfStillOk(tmp, percentage);
            TextBox p6 = this.FindName("p6") as TextBox;
            tmp += double.Parse(p6.Text);
            checkIfStillOk(tmp, percentage);
            TextBox p7 = this.FindName("p7") as TextBox;
            tmp += double.Parse(p7.Text);
            checkIfStillOk(tmp, percentage);
            TextBox p8 = this.FindName("p8") as TextBox;
            tmp += double.Parse(p8.Text);
            checkIfStillOk(tmp, percentage);
            TextBox p9 = this.FindName("p9") as TextBox;
            tmp += double.Parse(p9.Text);
            checkIfStillOk(tmp, percentage);
            TextBox p10 = this.FindName("p10") as TextBox;
            tmp += double.Parse(p10.Text);
            checkIfStillOk(tmp, percentage);
            TextBox p11 = this.FindName("p11") as TextBox;
            tmp += double.Parse(p11.Text);
            checkIfStillOk(tmp, percentage);
        }

        private void checkIfStillOk(double tmp, TextBlock percentage)
        {
            if (tmp <= 100)
            {
                percentage.Foreground = new SolidColorBrush(Colors.Green);
                percentage.Text = tmp.ToString() + "%";
            }
            else
            {
                percentage.Text = "Disse blir mer enn 100%";
                percentage.Foreground = new SolidColorBrush(Colors.Red);
            }
        }
    }
}
