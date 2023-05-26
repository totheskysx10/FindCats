using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Timers;
using System.Threading;
using System.Security.Cryptography;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        Label levelInfo = new Label()
        {
            Location = new Point(10, 10),
            Size = new Size(100, 28),
            Text = "Уровень: " + (Levels.CurrentLevel + 1).ToString(),
            Font = new Font("Calibri", 14, FontStyle.Bold)
        };

        Label leftCats = new Label()
        {
            Location = new Point(200, 10),
            Size = new Size(170, 28),
            Text = "Осталось котов: ",
            Font = new Font("Calibri", 14, FontStyle.Bold)
        };
        Label instruction = new Label()
        {
            Location = new Point(50, 125),
            Size = new Size(500, 500),
            Text = "Привет! \n Смысл игры прост - нужно просто искать котиков. Всех, которые есть на картинке (их количество указано сверху) :) \n \n" +
            "Есть 2 типа подсказок: стандартная и интеллектуальная. Стандартная - указывает на случайного кота и отнимает 10% оставшегося времени. Умная - указывает на самого труднодоступного кота и отнимает 25% времени. \n \n" +
            "Оставшееся время показано внизу экрана. \n \n Желаем удачи! :)",
            Font = new Font("Calibri", 18)
        };
        Label final = new Label()
        {
            Location = new Point(50, 250),
            Size = new Size(500, 500),
            Text = "Поздравляем! \n \n Вы прошли игру! :)",
            Font = new Font("Calibri", 18)
        };

        public Form1()
        {
            InitializeComponent();
            Height = 800;
            Width = 1383;
            BackgroundImage = null;

            var Next = new Button()
            {
                Location = new Point(1302, 720),
                Size = new Size(64, 32),
                Text = "Далее >"
            };
            Next.Click += (sender, args) => NextLevel();
            Controls.Add(Next);

            var Back = new Button()
            {
                Location = new Point(1, 720),
                Size = new Size(64, 32),
                Text = "< Назад"
            };
            Back.Click += (sender, args) => PrevLevel();
            Controls.Add(Back);

            var Hint = new Button()
            {
                Location = new Point(1000, 720),
                Size = new Size(100, 32),
                Text = "Подсказка"
            };
            Hint.Click += (sender, args) =>
            {
                var nh = new Hints(this);
                nh.NormalHint();
                if (Time.progressBar.Value > 15)
                    Time.progressBar.Value -= 10;
            };
            Controls.Add(Hint);

            var iHint = new Button()
            {
                Location = new Point(250, 720),
                Size = new Size(120, 32),
                Text = "Умная подсказка"
            };
            iHint.Click += (sender, args) =>
            {
                var ih = new Hints(this);
                ih.IntelligentHint();
                if (Time.progressBar.Value > 30)
                    Time.progressBar.Value -= 25;
            };
            Controls.Add(iHint);
            Controls.Add(levelInfo);
            Controls.Add(leftCats);
            Controls.Add(instruction);
        }

        public void CreatePanel(Point point, Size size)
        {
            var Cat = new Panel()
            {
                BackColor = Color.Transparent,
                Location = point,
                Size = size
            };
            Controls.Add(Cat);
            Cat.Click += (sender, args) =>
            {
                if (Time.progressBar.Value > 0)
                {
                    Cat.BackColor = Color.FromArgb(100, 0, 255, 0);
                    Levels.catsCount[Levels.CurrentLevel]--;
                    if (Levels.catsCount[Levels.CurrentLevel] == 0)
                    {
                        Levels.CountCats();
                        if (Levels.CurrentLevel == Levels.levels.Count-1)
                        {
                            Controls.Add(final);
                            BackColor = default;
                            BackgroundImage = null;
                            HidePanels();
                            leftCats.Hide();
                            levelInfo.Hide();
                            Time.timer.Stop();
                            Time.progressBar.Value = 100;
                        }
                        else
                        {
                            Levels.Completed += 1;
                            NextLevel();
                        }
                    }
                }
                CheckCats();
            };
        }

        public void NextLevel()
        {
            if (Levels.Completed > Levels.CurrentLevel)
            {
                if (Levels.CurrentLevel < Levels.levels.Count - 1)
                {
                    Time.timer.Stop();
                    Time.progressBar.Value = 100;
                    HidePanels();
                    Levels.CurrentLevel += 1;
                    ShowImage(Levels.CurrentLevel);


                    foreach (var area in Levels.levels[Levels.CurrentLevel])
                    {
                        CreatePanel(area.point, area.size);
                    }
                    levelInfo.Text = "Уровень: " + (Levels.CurrentLevel + 1).ToString();

                    Time.StartTimer(Levels.intervals[Levels.CurrentLevel]);

                    foreach (Control c in Controls)
                        if (c is PictureBox) c.Hide();
                }
                CheckCats();
                instruction.Hide();
            }
        }

        public void PrevLevel()
        {
            if (Levels.CurrentLevel > 0)
            {
                Time.timer.Stop();
                Time.progressBar.Value = 100;
                HidePanels();
                Levels.CurrentLevel -= 1;
                ShowImage(Levels.CurrentLevel);

                
                foreach (var area in Levels.levels[Levels.CurrentLevel])
                    CreatePanel(area.point, area.size);
                levelInfo.Text = "Уровень: " + (Levels.CurrentLevel + 1).ToString();

                Time.StartTimer(Levels.intervals[Levels.CurrentLevel]);

                foreach (Control c in Controls)
                    if (c is PictureBox) c.Hide();
            }
            CheckCats();
        }

        public void CheckCats()
        {
            leftCats.Text = "Осталось котов: " + Levels.catsCount[Levels.CurrentLevel].ToString();
        }

        public void HidePanels()
        {
            foreach (Control c in Controls)
                if (c is Panel) c.Hide();
        }

        public void ShowImage(int level)
        {
            Images.SetLevels();
            Image image = new Bitmap(Images.images[Levels.CurrentLevel]);
            BackgroundImage = image;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var t = new Time(this);
            t.AddProgress();
            Levels.SetLevelValues();
            Levels.CountCats();
        }

        private void Form1_Click(object sender, EventArgs e)
        {
            if (Time.progressBar.Value != 0)
            {
                Time.timer.Stop();
                MessageBox.Show("Это НЕ кот");
                Time.timer.Start();
                if (Time.progressBar.Value >= 10)
                    Time.progressBar.Value -= 10;
            }
            else
                MessageBox.Show("Это НЕ кот");
        }
    }
}