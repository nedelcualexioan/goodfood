using System;
using System.Drawing;
using System.Net.Mail;
using System.Windows.Forms;
using System.Windows.Media.Animation;
using FontAwesome.Sharp;
using recipes;

namespace goodfood
{
    public class Card : Panel
    {
        private PictureBox pctFood;
        private IconPictureBox pctFav;
        private Label lblSep;
        private IconPictureBox[] pctBoxes;
        private Label lblName;

        public Card(Control par, Recipe recipe)
        {
            this.Parent = par;
            this.Size = new Size(250, 250);
            this.BorderStyle = BorderStyle.FixedSingle;

            Initialize(recipe);

            pctFav.Click += new EventHandler(pctFav_Click);
        }

        private void Initialize(Recipe recipe)
        {
            pctBoxes = new IconPictureBox[5];

            for (int i = 0; i < pctBoxes.Length; i++)
            {
                pctBoxes[i] = new IconPictureBox()
                {
                    Parent = this,
                    IconSize = 32,
                    Size = new Size(32, 32),
                    IconChar = IconChar.Star,
                    IconFont = IconFont.Regular,
                    SizeMode = PictureBoxSizeMode.Normal
                };

                if (i == 0)
                    pctBoxes[i].Location = new Point(45, 164);
                else
                {
                    pctBoxes[i].Location = new Point(pctBoxes[i - 1].Location.X + 32, 164);
                }

                pctBoxes[i].Click += new EventHandler(pctBox_Click);
            }

            pctFood = new PictureBox()
            {
                Parent = this,
                ImageLocation = Application.StartupPath + String.Format(@"\images\{0}", recipe.Picture),
                Size = new Size(227, 140),
                Location = new Point(0, 4),
                SizeMode = PictureBoxSizeMode.Zoom
            };

            lblSep = new Label()
            {
                Parent = this,
                Text = "",
                AutoSize = false,
                Location = new Point(0, 148),
                Size = new Size(this.Width, 2),
                BorderStyle = BorderStyle.FixedSingle
            };

            lblName = new Label()
            {
                Parent = this,
                AutoSize = false,
                Font = new Font("Georgia", 12, FontStyle.Regular),
                Text = recipe.Title,
                Location = new Point(0, 198),
                Size = new Size(this.Width, 23),
                TextAlign = ContentAlignment.MiddleCenter
            };

            pctFav = new IconPictureBox()
            {
                Parent = this,
                Location = new Point(217, 4),
                Size = new Size(32, 32),
                IconSize = 32,
                IconChar = IconChar.Heart,
                IconFont = IconFont.Regular
            };

            pctFav.BringToFront();
        }

        private void pctFav_Click(object sender, EventArgs e)
        {
            if (pctFav.IconFont.Equals(IconFont.Regular))
            {
                pctFav.IconFont = IconFont.Solid;
            }
            else
            {
                pctFav.IconFont = IconFont.Regular;
            }
        }

        private void pctBox_Click(object sender, EventArgs e)
        {
            int index = Array.IndexOf(pctBoxes, sender);

            for (int i = 0; i <= index; i++)
            {
                pctBoxes[i].IconFont = IconFont.Solid;
            }

            for (int i = index + 1; i < pctBoxes.Length; i++)
            {
                pctBoxes[i].IconFont = IconFont.Regular;
            }
        }
    }
}