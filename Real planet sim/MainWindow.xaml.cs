using System;
using System.Diagnostics;
using System.Threading;
using System.Windows;
using System.Windows.Controls;

namespace Real_planet_sim
{
  
    public partial class MainWindow : Window
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

        public MainWindow()
        {

           
            InitializeComponent();
            PositionWindowAtTopLeft();

            timer.Start();

            timer.TimeChanged += UpdateTidText;
            thTimer = new System.Threading.Timer(run, null, 0, 1);
            Closing += SletTimer;
        }
        public void run(Object arg)
        {

            thCounter++;
            Application.Current.Dispatcher.BeginInvoke(new Action(() =>
            {
                Tid.Text = thCounter.ToString();
                CreatePlanets(thCounter.ToString());
            }));
        }

        public void UpdateTidText(string time)
        {


            //Tid.Text = time;
            //CreatePlanets(time);


        }
        public void CreatePlanets(string time)
        {
            mercury.StartPlanet(Merkur, sun, time, 47.87, 55);
            venus.StartPlanet(Venus, sun, time, 35.02, 80);
            earth.StartPlanet(Eeath, sun, time, 29.78, 105);
            mars.StartPlanet(Mars, sun, time, 24.077, 130);
            jupiter.StartPlanet(Jupiter, sun, time, 13.07, 155);
            saturn.StartPlanet(Saturn, sun, time, 9.69, 180);
            uranus.StartPlanet(Uranus, sun, time, 6.81, 205);
            neptune.StartPlanet(Neptune, sun, time, 5.43, 230);
            pluto.StartPlanet(Pluto, sun, time, 4.74, 260);
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
