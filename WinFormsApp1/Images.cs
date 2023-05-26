using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsApp1
{
    public static class Images
    {
        public static string[] images = new string[7];

        public static void SetLevels()
        {
            images[0] = (@"C:\Users\User\source\repos\WinFormsApp1\WinFormsApp1\images\1.png");
            images[1] = (@"C:\Users\User\source\repos\WinFormsApp1\WinFormsApp1\images\2.png");
            images[2] = (@"C:\Users\User\source\repos\WinFormsApp1\WinFormsApp1\images\3.png");
            images[3] = (@"C:\Users\User\source\repos\WinFormsApp1\WinFormsApp1\images\4.png");
            images[4] = (@"C:\Users\User\source\repos\WinFormsApp1\WinFormsApp1\images\5.png");
            images[5] = (@"C:\Users\User\source\repos\WinFormsApp1\WinFormsApp1\images\6.png");
            images[6] = (@"C:\Users\User\source\repos\WinFormsApp1\WinFormsApp1\images\7.png");
        }
    }
}
