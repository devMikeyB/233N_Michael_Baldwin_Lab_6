using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace _233N_Michael_Baldwin_Lab_6
{
    internal class displayForm : Form
    {
        public displayForm(Control controlToDisplay)
        {
            this.Controls.Add(controlToDisplay);
            this.Show();
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // displayForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "displayForm";
            this.Load += new System.EventHandler(this.displayForm_Load);
            this.ResumeLayout(false);

        }

        private void displayForm_Load(object sender, EventArgs e)
        {

        }
    }
}
