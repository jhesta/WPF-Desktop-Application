using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Microsoft.Maps.MapControl.WPF;

namespace Prog1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            myMap.MouseDoubleClick += map_MouseDoubleClick;
            listBox1.Items.Add("Bing Maps control initialized");
            listBox1.Items.Add("");
        }

        private void PlaceDot(Location location, Color color)
        {
            Ellipse dot = new Ellipse();
            dot.Fill = new SolidColorBrush(color);
            double radius = 12.0;
            dot.Width = radius * 2;
            dot.Height = radius * 2;
            ToolTip tt = new ToolTip();
            tt.Content = "Location = " + location;
            dot.ToolTip = tt;
            Point p0 = myMap.LocationToViewportPoint(location);
            Point p1 = new Point(p0.X - radius, p0.Y - radius);
            Location loc = myMap.ViewportPointToLocation(p1);
            MapLayer.SetPosition(dot, loc);
            myMap.Children.Add(dot);
        }
    }
}
