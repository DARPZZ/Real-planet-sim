using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Numerics;
using System.Threading;
using System.Windows;
using System.Windows.Controls;

namespace Real_planet_sim
{
  
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        private System.Threading.Timer thTimer;
        Planet mars = new Planet();
        Planet mercury = new Planet();
        Planet uranus = new Planet();
        Planet venus = new Planet();
        Planet earth = new Planet();
        Planet saturn = new Planet();
        Planet neptune = new Planet();
        Planet jupiter = new Planet();
        Planet pluto = new Planet();
        Timer timer = new Timer();
        int thCounter = 0;

        public event PropertyChangedEventHandler? PropertyChanged;

        public MainWindow()
        {

           
            InitializeComponent();
            PositionWindowAtTopLeft();
            timer.Start();

           

            timer.TimeChanged += UpdateTidText;
            thTimer = new System.Threading.Timer(run, null, 0, 1);
            Closing += SletTimer;
        }
        /*
         * Bruger System.Threading.Timer  til at opdatere planeternes position
         */
        public void run(Object arg)
        {

            thCounter++;
            Application.Current.Dispatcher.BeginInvoke(new Action(() =>
            {

                CreatePlanets(thCounter.ToString());
            }));
        }
        /*
         * Bruger dispatch timeren til at opdatere planeternes position
         */
        public void UpdateTidText(string time)
        {


           // CreatePlanets(time);

        }
        public void CreatePlanets(string time)
        {
            mercury.StartPlanet(Merkur, sun, time, 47.87, 70,slider);
            venus.StartPlanet(Venus, sun, time, 35.02, 108, slider);
            earth.StartPlanet(Eeath, sun, time, 29.78, 146, slider);
            mars.StartPlanet(Mars, sun, time, 24.077, 184, slider);
            jupiter.StartPlanet(Jupiter, sun, time, 13.07, 222, slider);
            saturn.StartPlanet(Saturn, sun, time, 9.69, 260, slider);
            uranus.StartPlanet(Uranus, sun, time, 6.81, 298, slider);
            neptune.StartPlanet(Neptune, sun, time, 5.43, 336, slider);
            pluto.StartPlanet(Pluto, sun, time, 4.74, 374, slider);
        }
        private void PositionWindowAtTopLeft()
        {
            Left = 0;
            Top = 0;
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

            if (sender is ListBox listBox)
            {
                if (listBox.SelectedItem is ListBoxItem selectedItem)
                {
                    string planet = selectedItem.Content.ToString().ToLower();
                    string googleSearchUrl = $"https://en.wikipedia.org/wiki/{planet}";

                    Process.Start(new ProcessStartInfo
                    {
                        FileName = googleSearchUrl,
                        UseShellExecute = true
                    });
                }
            }
        }
        /*
         * Sørgere for at man ikke for worker thread fejæ, når man lukker programmet
         */
        private void SletTimer(object sender, System.ComponentModel.CancelEventArgs e)
        {
            thTimer.Change(Timeout.Infinite, Timeout.Infinite);
            thTimer.Dispose();
        }

        
    }

}
