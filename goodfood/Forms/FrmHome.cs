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
        public FrmHome()
        {
            InitializeComponent();

            this.Size = Screen.PrimaryScreen.WorkingArea.Size;
            this.WindowState = FormWindowState.Maximized;

            foreach (Control c in this.Controls)
            {
                c.Hide();
            }
            

            recipes = new ControllerRecipes();
            users = new ControllerUsers();
        }

        private void FrmHome_Load(object sender, EventArgs e)
        {

        }
    }
}
