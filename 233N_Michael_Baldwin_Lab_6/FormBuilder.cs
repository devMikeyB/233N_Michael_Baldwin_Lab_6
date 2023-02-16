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
        TextBox[] textBoxes;
        TextBox[] numTextBoxes;


        public FormBuilder()
        {
            InitializeComponent();
        }

        private void FormBuilder_Load(object sender, EventArgs e)
        {
            radioButtons= new RadioButton[4]; //Array of Radio Buttons within form.
            radioButtons[0] = radioControlRadioButton;
            radioButtons[1] = buttonControlRadioButton;
            radioButtons[2] = checkControlRadioButton;
            radioButtons[3] = textBoxControlRadioButton;

            textBoxes= new TextBox[6]; //Array of textboxes within main form.
            textBoxes[0] = xTextBox;
            textBoxes[1] = yTextBox;
            textBoxes[2] = wTextBox;
            textBoxes[3] = hTextBox;
            textBoxes[4] = nameTextBox;
            textBoxes[5] = textTextBox;

            numTextBoxes= new TextBox[4]; //Array of textboxes that should contain number values.
            numTextBoxes[0] = xTextBox;
            numTextBoxes[1] = yTextBox;
            numTextBoxes[2] = wTextBox;
            numTextBoxes[3] = hTextBox;

        }


        private bool isFormFilledOut()
        {
            bool[] formReqs = new bool[4];
            formReqs[0] = false; formReqs[1] = true; formReqs[2] = true; formReqs[3] = true;



            foreach ( RadioButton button in radioButtons )
            {   //Check if there is a radiobutton selected.
                if (button.Checked){
                    formReqs[0]= true;
                }
            }

            foreach (TextBox textBox in textBoxes)
            { //Check all textboxes for a lack of data.
                if (textBox.Text == String.Empty)
                { 
                    MessageBox.Show("Please fill out all textboxes.");
                    formReqs[1] = false;
                    return false;
                }
            }

            foreach (TextBox textBox in numTextBoxes)
            {   //Check if number textboxes contain a whole number.
                if(!Int32.TryParse(textBox.Text, out int result)){
                    MessageBox.Show("Size and Location values must be whole numbers.");
                    formReqs[2] = false;
                    return false;
                }
            }

            if (nameTextBox.Text.Contains(" "))
            {   //Check if there is a space in the name value.
                MessageBox.Show("Name value may not contain a space.");
                formReqs[3] = false;
                return false;
            }

            foreach(bool req in formReqs)
            {
                if (!req)
                {   //Check all requirements for a false value.
                    MessageBox.Show("Please fill out the form accurately and try again.");
                    return false;
                }
            }

            return true;
            
        }

        private void buildControlProps()
        {
            
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
            if(isFormFilledOut()){
                MessageBox.Show("Form complete.");
            }
        }

        private void fgColorButton_Click(object sender, EventArgs e)
        {

        }

        private void bgColorButton_Click(object sender, EventArgs e)
        {

        }


    }
}
