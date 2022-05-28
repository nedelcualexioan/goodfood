using System;
using System.Windows.Forms;
using System.Drawing;

namespace goodfood
{
    public class IconTextBox : Panel
    {
        private PictureBox pctIcon;
        private TextBox txtBox;

        private String text;

        public String Text
        {
            get => this.text;
        }

        public IconTextBox(String text, String image)
        {
            this.Size = new Size(241, 26);
            this.BorderStyle = BorderStyle.FixedSingle;
            this.BackColor = Color.White;

            this.text = text;

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

            txtBox.Click += new EventHandler(txtBox_Click);
            txtBox.Leave += new EventHandler(txtBox_Leave) ;
            txtBox.KeyPress += new KeyPressEventHandler(txtBox_KeyPress);
        }

        private void txtBox_Click(object sender, EventArgs e)
        {
            if (txtBox.Text.Equals(text))
            { 
                txtBox.Text = "";

                txtBox.ForeColor = SystemColors.ControlText;
            }
        }

        private void txtBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (txtBox.Text.Equals(text))
            {
                txtBox.Text = "";

                txtBox.ForeColor = SystemColors.ControlText;
            }
        }

        public void txtBox_Leave(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtBox.Text))
            {
                Reset();
            }
        }

        public void Reset()
        {
            txtBox.Text = text;

            txtBox.ForeColor = SystemColors.ControlDark;
        }

        public bool IsDefault()
        {
            if (txtBox.Text.Equals(text))
                return true;
            return false;
        }
    }
}