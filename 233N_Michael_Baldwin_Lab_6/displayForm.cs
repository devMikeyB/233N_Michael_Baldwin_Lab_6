using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _233N_Michael_Baldwin_Lab_6
{
    internal class displayForm : Form
    {
        public displayForm(Control controlToDisplay)
        {
            GroupBox oneGroup = new GroupBox();
            oneGroup.Width = this.Width;
            oneGroup.Height = this.Height;
            this.Controls.Add(controlToDisplay);
            controlToDisplay.Parent = oneGroup;
            this.Show();
        }

    }
}
