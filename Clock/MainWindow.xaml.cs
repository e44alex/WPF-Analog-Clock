using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
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

namespace Clock
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        DateTime currentTime = new DateTime();

        int currentTimeInSeconds;

        const int HoursHandLength = 125;

        const int MinutesHandLength = 135;

        const int SecondsHandLength = 135;

        private double startX=150, startY = 150;

        public MainWindow()
        {
            InitializeComponent();
            ClockStart();
            
            

        }

        async Task ClockStart()
        {
            DrawCurrentTime();
            int i = 0;
            while (true)
            {
                await Task.Delay(1);
                DrawLines(i);
                i += 6;
                //if (i == 360) i = 0;
            }
            


        }

        public void DrawCurrentTime()
        {
            currentTime = DateTime.UtcNow;
            currentTimeInSeconds = currentTime.Hour * 3600 + currentTime.Minute * 60 + currentTime.Second;
            DrawLines(currentTimeInSeconds*6);
            startX = MinutesHand.X1;
            startY = MinutesHand.Y1;
        }

        public void DrawLines(int i)
        {
            SecondsHand.X1 = 150 + (Math.Sin((Math.PI / 180) * i) * SecondsHandLength);
            SecondsHand.Y1 = 150 - (Math.Cos((Math.PI / 180) * i) * SecondsHandLength);
            MinutesHand.X1 = 150 + (Math.Sin((Math.PI / 180) * (i/60)) * MinutesHandLength);
            MinutesHand.Y1 = 150 - (Math.Cos((Math.PI / 180) * (i/60)) * MinutesHandLength);
            HoursHand.X1 = 150 + (Math.Sin((Math.PI / 180) * (i / 3600)) * MinutesHandLength);
            HoursHand.Y1 = 175 - (Math.Cos((Math.PI / 180) * (i / 3600)) * MinutesHandLength);
        }

    }
}
