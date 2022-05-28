using System;
using System.Collections.Generic;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Documents;
using System.Windows.Forms;
using recipes;

namespace goodfood
{
    public class ViewHome : Panel
    {
        private Label lblSepa;
        private Label lblFilters;
        private Panel pnlFilters;
        private Panel pnlContainer;
        private Label lblResults;

        private List<Panel> cards;

        public ViewHome(Form par, ControllerRecipes recipes)
        {
            this.Parent = par;
            this.Location = new Point(0, 72);
            this.Size = new Size(par.Size.Width, par.Size.Height - 72);
            this.BackColor = Color.White;

            Initialize();

            cards = new List<Panel>();

            PopulateContainer(recipes);

            Filters filters = pnlFilters as Filters;
            filters.showClick += btnShow_Click;


        }

        private void Initialize()
        {
            lblSepa = new Label
            {
                Parent = this,
                AutoSize = false,
                Text = "",
                Location = new Point(19, 1),
                Size = new Size(1880, 2),
                BorderStyle = BorderStyle.FixedSingle
            };

            lblFilters = new Label
            {
                Parent = this,
                AutoSize = true,
                Font = new Font("Arial", 11.25f, FontStyle.Bold),
                Text = "Filters",
                Location = new Point(57, 20)
            };
            lblFilters.BringToFront();

            pnlFilters = new Filters(this)
            {
                Location = new Point(19, 28)
            };

            pnlContainer = new Panel()
            {
                Parent = this,
                Location = new Point(462, 28),
                Size = new Size(1169, 782)
            };

            lblResults = new Label()
            {
                Parent = pnlContainer,
                AutoSize = true,
                Font = new Font("Arial", 11.25f, FontStyle.Regular),
                Location = new Point(32, 22),
                Text = "X Results"
            };
            lblResults.Hide();
        }

        public void PopulateContainer(ControllerRecipes recipes)
        {

            List<Recipe> list = recipes.GetList();

            int x = 34, y = 67;

            for (int i = 0; i < list.Count; i++)
            {
                Card card = new Card(pnlContainer, (Recipe)recipes.GetItem(i));
                card.Location = new Point(x, y);

                cards.Add(card);

                x += card.Width + 40;

                if ((i + 1) % 4 == 0)
                {
                    x = 34;
                    y += card.Height + 20;
                }
            }

        }

        // populate filters ???

        private void PopulateFilters(ControllerRecipes recipes, Filters filters)
        {
            List<Recipe> list = recipes.GetList();

            int x = 34, y = 67;

            for (int i = 0; i < list.Count; i++)
            {
                Card card = new Card(pnlContainer, (Recipe)recipes.GetItem(i));
                card.Location = new Point(x, y);

                cards.Add(card);

                x += card.Width + 40;

                if ((i + 1) % 4 == 0)
                {
                    x = 34;
                    y += card.Height + 20;
                }
            }
        }

        private void btnShow_Click(object sender, EventArgs e, ControllerRecipes recipes)
        {
            Filters filters = sender as Filters;

            if (filters.TxtRecipe.IsDefault() && filters.TxtIngredient.IsDefault() && filters.TxtTag.IsDefault())
            {
                PopulateContainer(recipes);
            }
            else
            {
                PopulateFilters(recipes, filters);
            }
        }
        
    }
}