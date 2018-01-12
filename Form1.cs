using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ATLTime
{
    public partial class Form1 : Form
    {
        int seconds;
        int minutes;
        int hours;

        public Form1()
        {
            InitializeComponent();
            seconds = minutes = hours = 0;
        }

        private void lbTime_Click(object sender, EventArgs e)
        {

        }
        //Display for StopWatch
        private void displayTime()
        {
            lblSeconds.Text = DateTime.Now.ToShortTimeString();
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }
        //Stop Watch timer calculations
        private void timer1_Tick(object sender, EventArgs e)
        {
            seconds++;

            if(seconds > 59)
            {
                minutes++;
                seconds = 0;
            }

            if (minutes > 59)
            {
                hours++;
                minutes = 0;
            }

            lblHours.Text = appendZero(hours);
            lblMinutes.Text = appendZero(minutes);
            lblSeconds.Text = appendZero(seconds);
        }
         //This is for the 00 effect on the stopwatch timer
        private string appendZero(double str)
        {
            if (str <= 9)
                return "0" + str;
            else
                return str.ToString();

        }
        //Start Button & Clock In Start
        private void btnStart_Click(object sender, EventArgs e)
        {
            StopWatchTimer.Start();
            ClockIn.Text = DateTime.Now.ToString();
        }
        //Stop Button: all digits fall back to zero when pressed
        private void btnStop_Click(object sender, EventArgs e)
        {
            StopWatchTimer.Stop();
            seconds = minutes = hours = 0;
            lblHours.Text = appendZero(hours);
            lblMinutes.Text = appendZero(minutes);
            lblSeconds.Text = appendZero(seconds);
        }
        //Pause Button
        private void button1_Click(object sender, EventArgs e)
        {
            StopWatchTimer.Stop();
        }
        //Clock time, seconds, date, day
        private void TimeDateTimer_Tick(object sender, EventArgs e)
        {
            lblTime.Text = DateTime.Now.ToString("HH:mm");
            lblSecond.Text = DateTime.Now.ToString("ss");
            lblDate.Text = DateTime.Now.ToString("MMM dd yyyy");
            lblDay.Text = DateTime.Now.ToString("dddd");
        }
        //When program starts, TimeDateTimer is started
        private void Form1_Load(object sender, EventArgs e)
        {
            TimeDateTimer.Start();
        }
    }
}
