using Parkeringssimulering;
using Windows.Foundation;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;

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
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            main.clearForReRun();
            this.Frame.Navigate(typeof(MainPage));
        }
    }
}
