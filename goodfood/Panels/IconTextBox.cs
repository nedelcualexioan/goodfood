using System;
using System.Windows.Forms;
using System.Drawing;

namespace goodfood
{
    public class IconTextBox : Panel
    {
        private PictureBox pctIcon;
        private TextBox txtBox;
        public IconTextBox(String text, String image)
        {
            this.Size = new Size(241, 26);
            this.BorderStyle = BorderStyle.FixedSingle;
            this.BackColor = Color.White;

            pctIcon = new PictureBox()
            {
                Parent = this,
                Location = new Point(3, 2),
                Size = new Size(21, 20),
                SizeMode = PictureBoxSizeMode.Zoom,
                ImageLocation = Application.StartupPath + @"\images\" + image,
            };

            txtBox = new TextBox()
            {
                Parent = this,
                Font = new Font("Arial", 12.75f, FontStyle.Regular),
                ForeColor = SystemColors.ControlDark,
                Size = new Size(210, 20),
                Location = new Point(30,2),
                BorderStyle = BorderStyle.None,
                Text = text,
            };
            txtBox.SelectionStart = 0;
            txtBox.SelectionLength = 0;
            txtBox.TabIndex = 0;

            txtBox.Click += new EventHandler((s, e) => txtBox_Click(s, e, text));
            txtBox.Leave += new EventHandler((s, e) => txtBox_Leave(s, e, text));
            txtBox.KeyPress += new KeyPressEventHandler((s, e) => txtBox_KeyPress(s, e, text));
        }

        private void txtBox_Click(object sender, EventArgs e, String text)
        {
            if (txtBox.Text.Equals(text))
            { 
                txtBox.Text = "";
            }
        }

        private void txtBox_KeyPress(object sender, KeyPressEventArgs e, String text)
        {
            if (txtBox.Text.Equals(text))
            {
                txtBox.Text = "";
            }
        }

        private void txtBox_Leave(object sender, EventArgs e, String text)
        {
            if (String.IsNullOrWhiteSpace(txtBox.Text))
            {
                txtBox.Text = text;
            }
        }
    }
}