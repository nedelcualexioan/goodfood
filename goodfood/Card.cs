using System;
using System.Drawing;
using System.Net.Mail;
using System.Windows.Forms;
using FontAwesome.Sharp;

namespace goodfood
{
    public class Card : Panel
    {
        private PictureBox pctFood;
        private IconPictureBox pctFav;
        private Label lblSep;
        private IconPictureBox[] pctBoxes;
        private Label lblName;

        public Card(Form par)
        {
            this.Parent = par;
            this.Size = new Size(250, 250);
            this.BorderStyle = BorderStyle.FixedSingle;

            pctBoxes = new IconPictureBox[5];

            for (int i = 0; i < pctBoxes.Length; i++)
            {
                pctBoxes[i] = new IconPictureBox()
                {
                    Parent = this,
                    IconSize = 32,
                    Size=new Size(32,32),
                    IconChar = IconChar.Star,
                    IconFont = IconFont.Regular,
                    SizeMode = PictureBoxSizeMode.Normal
                };

                if(i == 0)
                    pctBoxes[i].Location = new Point(45, 158);
                else
                {
                    pctBoxes[i].Location = new Point(pctBoxes[i - 1].Location.X + 32, 158);
                }
            }



        }
    }
}