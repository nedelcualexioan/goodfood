using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;
using FontAwesome.Sharp;

namespace goodfood
{
    public class Header : Panel
    {
        private Label lblTitle;
        private PictureBox pctIcon;

        private Panel pnlOptions;
        private Label lblRecipes;
        private Label lblFavourites;
        private Label lblNew;

        private IconPictureBox pctUser;
        public Header(Form par)
        {
            this.Parent = par;
            this.Location = new Point(0, 0);
            this.Size = new Size(par.Size.Width, 72);
            this.BackColor = Color.White;
            
            Initialize();
        }

        private void Initialize()
        {
            lblTitle = new Label()
            {
                Parent = this,
                AutoSize = false,
                Size = new Size(140, 46),
                Location = new Point(17, 11),
                Font = new Font("Arial", 14.25f, FontStyle.Regular),
                TextAlign = ContentAlignment.MiddleCenter,
                BorderStyle = BorderStyle.FixedSingle,
                Text = "Recipes Book",
            };

            pctIcon = new PictureBox()
            {
                Parent = this,
                Location = new Point(183, 4),
                Size = new Size(52, 57),
                SizeMode = PictureBoxSizeMode.Zoom,
                ImageLocation = Application.StartupPath + @"\images\chef-icon.png"
            };

            pnlOptions = new Panel()
            {
                Parent = this,
                Size = new Size(406, 50),
                Location = new Point(1450, 11),
                BorderStyle = BorderStyle.FixedSingle
            };

            lblRecipes = new Label()
            {
                Parent = pnlOptions,
                AutoSize = false,
                Size = new Size(128, pnlOptions.Height),
                Location = new Point(0, 0),
                Font = new Font("Arial", 14.25f, FontStyle.Regular),
                Text = "My Recipes",
                TextAlign = ContentAlignment.MiddleCenter,
                Cursor = Cursors.Hand
            };

            lblNew = new Label()
            {
                Parent = pnlOptions,
                AutoSize = false,
                Size = new Size(128, pnlOptions.Height),
                Location = new Point(277, 0),
                Font = new Font("Arial", 14.25f, FontStyle.Regular),
                Text = "New Recipe",
                TextAlign = ContentAlignment.MiddleCenter,
                Cursor = Cursors.Hand
            };

            lblFavourites = new Label()
            {
                Parent = pnlOptions,
                AutoSize = false,
                Size = new Size(pnlOptions.Width - lblRecipes.Width - lblNew.Width, pnlOptions.Height),
                Location = new Point(lblRecipes.Width, 0),
                Font = new Font("Arial", 14.25f, FontStyle.Regular),
                Text = "My Favourites",
                TextAlign = ContentAlignment.MiddleCenter,
                Cursor = Cursors.Hand
            };

            pctUser = new IconPictureBox()
            {
                Parent = this,
                Size = new Size(54, 51),
                IconFont = IconFont.Solid,
                IconChar = IconChar.UserCircle,
                IconSize = 51,
                Location = new Point(1862, 14),
                Cursor = Cursors.Hand
            };
        }

    }
}
