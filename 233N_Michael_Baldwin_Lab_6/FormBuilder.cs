using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _233N_Michael_Baldwin_Lab_6
{
    public partial class FormBuilder : Form
    {
        RadioButton[] radioButtons;

        public FormBuilder()
        {
            InitializeComponent();
        }

        private void FormBuilder_Load(object sender, EventArgs e)
        {
            radioButtons= new RadioButton[4];
            radioButtons[0] = radioControlRadioButton;
            radioButtons[1] = buttonControlRadioButton;
            radioButtons[2] = checkControlRadioButton;
            radioButtons[3] = textBoxControlRadioButton;
        }


        private bool isFormFilledOut()
        {


            return true;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {

        }

        private void loadButton_Click(object sender, EventArgs e)
        {

        }

        private void removeButton_Click(object sender, EventArgs e)
        {

        }

        private void exitButton_Click(object sender, EventArgs e)
        {

        }

        private void clearButton_Click(object sender, EventArgs e)
        {

        }

        private void createButton_Click(object sender, EventArgs e)
        {

        }

        private void fgColorButton_Click(object sender, EventArgs e)
        {

        }

        private void bgColorButton_Click(object sender, EventArgs e)
        {

        }


    }
}
