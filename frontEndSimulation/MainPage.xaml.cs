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
using Parkeringssimulering;
using System.Threading.Tasks;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace frontEndSimulation
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public static int amountOfCars {get; set;}
        public static int timeFrom {get; set;}
        public static int timeTo {get; set;}
        public static int simulationSpeed {get; set;}
        public static int[] parkeringsPlasserArray = new int[11];
        public static String[] parkeringsPlasserArrayPrint = {"plasser_Inspiria", "plasser_InspiriaBak", "plasser_Superland", "plasser_Quality", "plasser_Kiwi",
            "plasser_Politiet", "plasser_Caverion", "plasser_K5", "plasser_TuneSeteret", "plasser_AdeccoOgIf", "plasser_Fagforbundet"};
        public static int[] parkeringsPercentArray = new int[11];
        public static String[] parkeringsPercentArrayPrint = {"percentage_Inspiria", "percentage_InspiriaBak", "percentage_Superland", "percentage_Quality", "percentage_Kiwi",
            "percentage_Politiet", "percentage_Caverion", "percentage_K5", "percentage_TuneSeteret", "percentage_AdeccoOgIf", "percentage_Fagforbundet"};

        public MainPage()
        {
            this.InitializeComponent();
            ApplicationView.PreferredLaunchViewSize = new Size(1280, 720);
            ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.PreferredLaunchViewSize;

        }

        private void startButton_Click(object sender, RoutedEventArgs e)
        {
            updateMaxParkingSpots();
            updateArrivingPercentage();
            printArrayInfo();
            TextBlock percentage = this.FindName("percentage") as TextBlock;
            string percentagecheck = percentage.Text.ToString();
            percentagecheck = percentagecheck.Remove(percentagecheck.Length - 1);
            if (double.TryParse(percentagecheck, out double tmp) && tmp == 100)
            {
                Debug.WriteLine("Nå skal simuleringen starte");
                TextBox cars = this.FindName("cars") as TextBox;
                amountOfCars = int.Parse(cars.Text);
                TextBox from = this.FindName("fromTime") as TextBox;
                timeFrom = 0;
                TextBox to = this.FindName("toTime") as TextBox;
                timeTo = 1080;
                TextBox s = this.FindName("speed") as TextBox;
                simulationSpeed = (int.Parse(s.Text) * 10);
                this.Frame.Navigate(typeof(BlankPage1));
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
            parkeringsPlasserArray[0] = int.Parse(p1.Text);
            TextBox p2 = this.FindName("pplass2") as TextBox;
            tmp += double.Parse(p2.Text);
            parkeringsPlasserArray[1] = int.Parse(p2.Text);
            TextBox p3 = this.FindName("pplass3") as TextBox;
            tmp += double.Parse(p3.Text);
            parkeringsPlasserArray[2] = int.Parse(p3.Text);
            TextBox p4 = this.FindName("pplass4") as TextBox;
            tmp += double.Parse(p4.Text);
            parkeringsPlasserArray[3] = int.Parse(p4.Text);
            TextBox p5 = this.FindName("pplass5") as TextBox;
            tmp += double.Parse(p5.Text);
            parkeringsPlasserArray[4] = int.Parse(p5.Text);
            TextBox p6 = this.FindName("pplass6") as TextBox;
            tmp += double.Parse(p6.Text);
            parkeringsPlasserArray[5] = int.Parse(p6.Text);
            TextBox p7 = this.FindName("pplass7") as TextBox;
            tmp += double.Parse(p7.Text);
            parkeringsPlasserArray[6] = int.Parse(p7.Text);
            TextBox p8 = this.FindName("pplass8") as TextBox;
            tmp += double.Parse(p8.Text);
            parkeringsPlasserArray[7] = int.Parse(p8.Text);
            TextBox p9 = this.FindName("pplass9") as TextBox;
            tmp += double.Parse(p9.Text);
            parkeringsPlasserArray[8] = int.Parse(p9.Text);
            TextBox p10 = this.FindName("pplass10") as TextBox;
            tmp += double.Parse(p10.Text);
            parkeringsPlasserArray[9] = int.Parse(p10.Text);
            TextBox p11 = this.FindName("pplass11") as TextBox;
            tmp += double.Parse(p11.Text);
            parkeringsPlasserArray[10] = int.Parse(p11.Text);
            pMax.Text = tmp.ToString();
        }

        private void updateArrivingPercentage()
        {
            double tmp = 0;
            TextBlock percentage = this.FindName("percentage") as TextBlock;
            TextBox p1 = this.FindName("p1") as TextBox;
            tmp += double.Parse(p1.Text);
            parkeringsPercentArray[0] = (int) tmp;
            checkIfStillOk(tmp, percentage);
            TextBox p2 = this.FindName("p2") as TextBox;
            tmp += double.Parse(p2.Text);
            parkeringsPercentArray[1] = (int)tmp;
            checkIfStillOk(tmp, percentage);
            TextBox p3 = this.FindName("p3") as TextBox;
            tmp += double.Parse(p3.Text);
            parkeringsPercentArray[2] = (int)tmp;
            checkIfStillOk(tmp, percentage);
            TextBox p4 = this.FindName("p4") as TextBox;
            tmp += double.Parse(p4.Text);
            parkeringsPercentArray[3] = (int)tmp;
            checkIfStillOk(tmp, percentage);
            TextBox p5 = this.FindName("p5") as TextBox;
            tmp += double.Parse(p5.Text);
            parkeringsPercentArray[4] = (int)tmp;
            checkIfStillOk(tmp, percentage);
            TextBox p6 = this.FindName("p6") as TextBox;
            tmp += double.Parse(p6.Text);
            parkeringsPercentArray[5] = (int)tmp;
            checkIfStillOk(tmp, percentage);
            TextBox p7 = this.FindName("p7") as TextBox;
            tmp += double.Parse(p7.Text);
            parkeringsPercentArray[6] = (int)tmp;
            checkIfStillOk(tmp, percentage);
            TextBox p8 = this.FindName("p8") as TextBox;
            tmp += double.Parse(p8.Text);
            parkeringsPercentArray[7] = (int)tmp;
            checkIfStillOk(tmp, percentage);
            TextBox p9 = this.FindName("p9") as TextBox;
            tmp += double.Parse(p9.Text);
            parkeringsPercentArray[8] = (int)tmp;
            checkIfStillOk(tmp, percentage);
            TextBox p10 = this.FindName("p10") as TextBox;
            tmp += double.Parse(p10.Text);
            parkeringsPercentArray[9] = (int)tmp;
            checkIfStillOk(tmp, percentage);
            TextBox p11 = this.FindName("p11") as TextBox;
            tmp += double.Parse(p11.Text);
            parkeringsPercentArray[10] = (int)tmp;
            checkIfStillOk(tmp, percentage);
        }

        private void checkIfStillOk(double tmp, TextBlock percentage)
        {
            if (tmp == 100)
            {
                percentage.Foreground = new SolidColorBrush(Colors.Green);
                percentage.Text = tmp.ToString() + "%";
            }
            else if (tmp < 100)
            {
                percentage.Foreground = new SolidColorBrush(Colors.Red);
                percentage.Text = tmp.ToString() + "%";
            }
            else
            {
                percentage.Text = "Disse blir mer enn 100%";
                percentage.Foreground = new SolidColorBrush(Colors.Red);
            }
        }

        private void printArrayInfo()
        {
            Debug.WriteLine("Plasser: ");
            for (int i = 0; i < parkeringsPlasserArray.Length; i++)
            {
                Debug.WriteLine(parkeringsPlasserArrayPrint[i] + ": " + parkeringsPlasserArray[i]);
            }
            Debug.WriteLine("");
            Debug.WriteLine("Prosenter: ");
            for (int i = 0; i < parkeringsPercentArray.Length; i++)
            {
                Debug.WriteLine(parkeringsPercentArrayPrint[i] + ": " + parkeringsPercentArray[i]);
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            string clearString = button.Content.ToString();
            double d = double.Parse(clearString.Remove(clearString.Length - 1));
            reduceParkingSpots(1 - (d / 100));
        }

        private void reduceParkingSpots(double percentage)
        {
            TextBox p1 = this.FindName("pplass1") as TextBox;
            p1.Text = ((int)(150 * percentage)).ToString();
            TextBox p2 = this.FindName("pplass2") as TextBox;
            p2.Text = ((int)(40 * percentage)).ToString();
            TextBox p3 = this.FindName("pplass3") as TextBox;
            p3.Text = ((int)(175 * percentage)).ToString();
            TextBox p4 = this.FindName("pplass4") as TextBox;
            p4.Text = ((int)(205 * percentage)).ToString();
            TextBox p5 = this.FindName("pplass5") as TextBox;
            p5.Text = ((int)(210 * percentage)).ToString();
            TextBox p6 = this.FindName("pplass6") as TextBox;
            p6.Text = ((int)(170 * percentage)).ToString();
            TextBox p7 = this.FindName("pplass7") as TextBox;
            p7.Text = ((int)(45 * percentage)).ToString();
            TextBox p8 = this.FindName("pplass8") as TextBox;
            p8.Text = ((int)(40 * percentage)).ToString();
            TextBox p9 = this.FindName("pplass9") as TextBox;
            p9.Text = ((int)(115 * percentage)).ToString();
            TextBox p10 = this.FindName("pplass10") as TextBox;
            p10.Text = ((int)(110 * percentage)).ToString();
            TextBox p11 = this.FindName("pplass11") as TextBox;
            p11.Text = ((int)(110 * percentage)).ToString();

        }
        
    }
}