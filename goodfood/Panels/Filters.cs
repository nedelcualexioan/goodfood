using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Windows.Forms;

namespace goodfood
{
    public class Filters : Panel
    {
        private Button btnClear;
        private IconTextBox txtRecipe;
        private IconTextBox txtTag;
        private IconTextBox txtIngredient;
        private Button btnShow;

        public event EventHandler showClick;

        public IconTextBox TxtRecipe
        {
            get => this.txtRecipe;
        }

        public IconTextBox TxtTag
        {
            get => this.txtTag;
        }

        public IconTextBox TxtIngredient
        {
            get => this.txtIngredient;
        }

        public Filters(Control par)
        {
            this.Parent = par;
            this.Size = new Size(285, 686);
            this.BackColor = Color.White;
            this.BorderStyle = BorderStyle.FixedSingle;

            Initialize();

            btnClear.Click += new EventHandler(btnClear_Click);
            btnShow.Click += new EventHandler(btnShow_Click);
        }

        private void Initialize()
        {
            btnClear = new Button()
            {
                Parent = this,
                FlatStyle = FlatStyle.Flat,
                Location = new Point(183, 12),
                Size = new Size(86, 34),
                Text = "Clear All",
                Font = new Font("Arial", 12, FontStyle.Bold),
                FlatAppearance =
                {
                    BorderSize = 2,
                    MouseOverBackColor = Color.FromArgb(224, 224, 224)
                }
            };

            txtRecipe = new IconTextBox("Recipe Keyword", "magnifying-glass-solid.png");
            txtTag = new IconTextBox("Tag", "magnifying-glass-solid.png");
            txtIngredient = new IconTextBox("Ingredient", "magnifying-glass-solid.png");

            txtRecipe.Parent = this;
            txtTag.Parent = this;
            txtIngredient.Parent = this;

            txtRecipe.Location = new Point(13, 149);
            txtTag.Location = new Point(13, txtRecipe.Top + 45);
            txtIngredient.Location = new Point(13, txtTag.Top + 45);

            btnShow = new Button()
            {
                Parent = this,
                FlatStyle = FlatStyle.Flat,
                Location = new Point(142, 630),
                Size = new Size(127, 34),
                Text = "Show Results",
                Font = new Font("Arial", 12, FontStyle.Bold),
                FlatAppearance = { BorderSize = 2, MouseOverBackColor = Color.FromArgb(224, 224, 224) }
            };
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtRecipe.Reset();
            txtIngredient.Reset();
            txtTag.Reset();
        }

        private void btnShow_Click(object sender, EventArgs e)
        {
            if (showClick != null)
            {
                showClick(this, null);
            }
        }

    }
}
