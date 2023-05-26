using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WinFormsApp1
{
    public static class Levels
    {
        public static int Completed;
        public static int CurrentLevel = -1;
        public static Dictionary<int, List<CatArea>> levels = new Dictionary<int, List<CatArea>>();
        public static List<int> catsCount = new List<int>();
        public static int[] intervals = { 500, 500, 500, 500, 500, 500, 500 };

        public static void SetLevelValues()
        {
            levels[0] = new List<CatArea> { new CatArea(new Point(140, 110), new Size(35, 60)),
                                            new CatArea(new Point(790, 410), new Size(40, 25)),
                                            new CatArea(new Point(793, 347), new Size(20, 25))};

            levels[1] = new List<CatArea> { new CatArea(new Point(238, 630), new Size(163, 73)),
                                            new CatArea(new Point(410, 626), new Size(150, 77)),
                                            new CatArea(new Point(411, 493), new Size(93, 51)),
                                            new CatArea(new Point(580, 353), new Size(126, 67)),
                                            new CatArea(new Point(653, 190), new Size(116, 142)),
                                            new CatArea(new Point(894, 250), new Size(308, 150)),
                                            new CatArea(new Point(155, 87), new Size(151, 121)),
                                            new CatArea(new Point(423, 69), new Size(40, 64))};

            levels[2] = new List<CatArea> { new CatArea(new Point(126, 157), new Size(115, 45)),
                                            new CatArea(new Point(148, 336), new Size(69, 71)),
                                            new CatArea(new Point(123, 431), new Size(175, 263)),
                                            new CatArea(new Point(508, 427), new Size(157, 138)),
                                            new CatArea(new Point(677, 222), new Size(75, 106)),
                                            new CatArea(new Point(1061, 256), new Size(78, 83)),
                                            new CatArea(new Point(1133, 237), new Size(168, 114))};

            levels[3] = new List<CatArea> { new CatArea(new Point(15, 367), new Size(100, 140)),
                                            new CatArea(new Point(247, 114), new Size(43, 31)),
                                            new CatArea(new Point(314, 516), new Size(263, 188)),
                                            new CatArea(new Point(369, 436), new Size(146, 92)),
                                            new CatArea(new Point(1302, 180), new Size(51, 49)),
                                            new CatArea(new Point(972, 596), new Size(280, 108)),
                                            new CatArea(new Point(727, 489), new Size(116, 210)),
                                            new CatArea(new Point(839, 431), new Size(141, 85)),
                                            new CatArea(new Point(803, 266), new Size(40, 80)),
                                            new CatArea(new Point(817, 338), new Size(197, 102)),
                                            new CatArea(new Point(913, 502), new Size(347, 113))};

            levels[4] = new List<CatArea> { new CatArea(new Point(248, 473), new Size(135, 230)),
                                            new CatArea(new Point(610, 269), new Size(130, 420)),
                                            new CatArea(new Point(557, 320), new Size(224, 260)),
                                            new CatArea(new Point(878, 370), new Size(108, 172)),
                                            new CatArea(new Point(1104, 624), new Size(247, 79)),
                                            new CatArea(new Point(1292, 474), new Size(62, 111)),
                                            new CatArea(new Point(1169, 66), new Size(123, 153))};

            levels[5] = new List<CatArea> { new CatArea(new Point(96, 456), new Size(75, 44)),
                                            new CatArea(new Point(32, 513), new Size(155, 74)),
                                            new CatArea(new Point(196, 509), new Size(183, 101)),
                                            new CatArea(new Point(399, 473), new Size(458, 230)),
                                            new CatArea(new Point(797, 294), new Size(35, 71)),
                                            new CatArea(new Point(886, 380), new Size(112, 42)),
                                            new CatArea(new Point(1043, 420), new Size(264, 99)),
                                            new CatArea(new Point(1177, 394), new Size(104, 59)),
                                            new CatArea(new Point(1190, 643), new Size(114, 60)),
                                            new CatArea(new Point(231, 72), new Size(268, 175))};

            levels[6] = new List<CatArea> { new CatArea(new Point(14, 167), new Size(184, 72)),
                                            new CatArea(new Point(86, 231), new Size(196, 122)),
                                            new CatArea(new Point(254, 246), new Size(82, 76)),
                                            new CatArea(new Point(421, 606), new Size(248, 99)),
                                            new CatArea(new Point(940, 633), new Size(195, 72)),
                                            new CatArea(new Point(1161, 598), new Size(120, 107)),
                                            new CatArea(new Point(584, 172), new Size(140, 129)),
                                            new CatArea(new Point(1292, 68), new Size(61, 86)),
                                            new CatArea(new Point(162, 69), new Size(62, 22))};
        }

        public static void CountCats()
        {
            SetLevelValues();
            catsCount.Clear();
            for (int i = 0; i < levels.Count; i++)
                catsCount.Add(levels[i].Count);
        }
    }
}
