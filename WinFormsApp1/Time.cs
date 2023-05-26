using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Diagnostics;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public class Time
    {
        Form1 f1 = new Form1();
        public static ProgressBar progressBar = new ProgressBar();
        delegate void Progress(int value);
        public static System.Timers.Timer timer = new System.Timers.Timer();

        public Time(Form1 f)
        {
            f1 = f;
        }

        public void AddProgress()
        {
            progressBar.Location = new Point(f1.Width / 2 - 250, 720);
            progressBar.Size = new Size(500, 32);
            f1.Controls.Add(progressBar);
        }

        public static void StartTimer(int interval)
        {
            Levels.CountCats();
            timer.Stop();
            timer.Dispose();
            timer = new System.Timers.Timer();
            timer.Interval = interval;
            timer.Elapsed += Tick;
            timer.Start();
        }

        public static void Tick(object sender, EventArgs e)
        {
            progressBar.Invoke(new Progress((s) => progressBar.Value = s), progressBar.Value != 0 ? progressBar.Value - 1 : progressBar.Value = 0);
            if (progressBar.Value == 0)
            {
                timer.Stop();
                MessageBox.Show("Время вышло!");
                Levels.CurrentLevel -= 1;
            }
        }
    }
}
