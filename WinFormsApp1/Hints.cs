using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrackBar;

namespace WinFormsApp1
{
    public class Hints
    {
        Form1 f1 = new Form1();

        public Hints(Form1 f)
        {
            f1 = f;
        }

        public void NormalHint()
        {
            var leftCats = new List<Panel>();
            foreach (Control c in f1.Controls)
            {
                if ((c is Panel) && (c.BackColor != Color.FromArgb(100, 0, 255, 0)))
                {
                    leftCats.Add((Panel)c);
                }
            }
            var panel = leftCats.FirstOrDefault();
            if (leftCats.Count != 0) HintColor(panel);
        }

        public void IntelligentHint()
        {
            var leftCats = new Dictionary<Panel, int>();
            foreach (Control c in f1.Controls)
            {
                if ((c is Panel) && (c.BackColor != Color.FromArgb(100, 0, 255, 0)))
                {
                    leftCats.Add((Panel)c, c.Width*c.Height);
                }
            }
            leftCats = leftCats.OrderBy(pair => pair.Value).ToDictionary(pair => pair.Key, pair => pair.Value);
            var bestPanel = leftCats.FirstOrDefault().Key;
            if (leftCats.Count != 0) HintColor(bestPanel);
        }

        public void HintColor(Panel panel)
        {
            panel.BackColor = Color.FromArgb(150, 255, 0, 0);
        }
    }
}
