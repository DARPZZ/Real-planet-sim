using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;

namespace Real_planet_sim
{
    public class Planet
    {
        
        public void StartPlanet(UIElement planetName, UIElement sun, string time, double orbitSpeed, int orbitRadius)
        {

            double planetTid = Convert.ToDouble(time);
            planetTid *= orbitSpeed/50;
            double angleInRadians = planetTid * (Math.PI / 180.0);
            double circlePosX = Math.Cos(angleInRadians) * orbitRadius;
            double circlePosY = Math.Sin(angleInRadians) * orbitRadius;

            double sunCenterX = Canvas.GetLeft(sun) + 50 / 2;
            double sunCenterY = Canvas.GetTop(sun) + 50 / 2;
        
            double planetLeft = sunCenterX + circlePosX - 25 / 2;
            double planetTop = sunCenterY + circlePosY - 25 / 2;

            Canvas.SetLeft(planetName, planetLeft);
            Canvas.SetTop(planetName, planetTop);
        }
    }
}
