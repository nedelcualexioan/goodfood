using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using recipes;

namespace goodfood
{
    public partial class FrmHome : Form
    {

        private ControllerRecipes recipes;
        private ControllerUsers users;

        private Panel pnlHeader;
        private Panel pnlHome;
        public FrmHome()
        {
            InitializeComponent();

            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            this.WindowState = FormWindowState.Maximized;

            recipes = new ControllerRecipes();
            users = new ControllerUsers();

            foreach (Control c in this.Controls)
            {
                c.Hide();
            }

            pnlHeader = new Header(this);
            pnlHome = new ViewHome(this, recipes);

        }

        private void FrmHome_Load(object sender, EventArgs e)
        {

        }
    }
}
