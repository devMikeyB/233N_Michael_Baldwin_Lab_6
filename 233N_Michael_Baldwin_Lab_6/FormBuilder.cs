using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
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
        GroupBox[] groupBoxes;

        Color defaultFormBGColor;
        Color defaultSaveBGColor;

        public FormBuilder()
        {
            InitializeComponent();
        }


        private void FormBuilder_Load(object sender, EventArgs e)
        {


            /*GroupBox testBox= new GroupBox();
            testBox.Name = "Test"; 
            testBox.Text = "Test";
            testBox.Location = new Point(31, 27);
            testBox.Size = new Size(352, 115);
            testBox.Visible= true;
            testBox.BackColor= Color.Red;
            */
            GroupBox testGroupBox = buildGroupBox("Test", "test", new Point(20, 10), new Size(20, 50));


            this.Controls.Add(testGroupBox);
            foreach (Control control in this.Controls)
            {
                Debug.WriteLine(control.ToString());
                Debug.WriteLine(control.GetType());
            }

            defaultFormBGColor = objectSelectionGroupBox.BackColor;
            defaultSaveBGColor = saveLoadGroupBox.BackColor;


            radioButtons = new RadioButton[4]; //Array of Radio Buttons within form.
            radioButtons[0] = radioControlRadioButton;
            radioButtons[1] = buttonControlRadioButton;
            radioButtons[2] = checkControlRadioButton;
            radioButtons[3] = textBoxControlRadioButton;

            textBoxes = new TextBox[6]; //Array of textboxes within main form.
            textBoxes[0] = xTextBox;
            textBoxes[1] = yTextBox;
            textBoxes[2] = wTextBox;
            textBoxes[3] = hTextBox;
            textBoxes[4] = nameTextBox;
            textBoxes[5] = textTextBox;

            numTextBoxes = new TextBox[4]; //Array of textboxes that should contain number values.
            numTextBoxes[0] = xTextBox;
            numTextBoxes[1] = yTextBox;
            numTextBoxes[2] = wTextBox;
            numTextBoxes[3] = hTextBox;

            groupBoxes = new GroupBox[8]; //Array of groupboxes.
            groupBoxes[0] = objectSelectionGroupBox;
            groupBoxes[1] = bgColorGroupBox;
            groupBoxes[2] = colorGroupBox;
            groupBoxes[3] = controlGroupBox;
            groupBoxes[4] = fcGroupBox;
            groupBoxes[5] = nameAndTextGroupBox;
            groupBoxes[6] = saveLoadGroupBox;
            groupBoxes[7] = sizeAndLocationGroupBox;
            resetRadios();

        }


        private GroupBox buildGroupBox(string name, string text, Point point, Size size)
        {
            GroupBox groupBox = new GroupBox();
            groupBox.Name = name;
            groupBox.Text = text;
            groupBox.Location = point;
            groupBox.Size = size;
            return groupBox;
        }
        private void resetRadios()
        {
            foreach (RadioButton radioButton in radioButtons)
            {
                radioButton.Checked = false;
            }
        }

        private void resetTextBoxes()
        {
            foreach (TextBox textBox in textBoxes)
            {   //Reset textBoxes
                textBox.Text = string.Empty;
            }
        }

        private void resetGroupBoxes()
        {
            foreach (GroupBox groupBox in groupBoxes)
            {
                if (groupBox.Name == "saveLoadGroupBox")
                {
                    groupBox.BackColor = defaultSaveBGColor;
                }
                else
                {
                    groupBox.BackColor = defaultFormBGColor;
                }
            }
        }

        private bool isFormFilledOut()
        {
            bool[] formReqs = new bool[4];
            formReqs[0] = false; formReqs[1] = true; formReqs[2] = true; formReqs[3] = true;



            foreach (RadioButton button in radioButtons)
            {   //Check if there is a radiobutton selected.
                if (button.Checked)
                {
                    formReqs[0] = true;
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
                if (!Int32.TryParse(textBox.Text, out int result))
                {
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

            foreach (bool req in formReqs)
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
            foreach (RadioButton radioButton in radioButtons)
            {
                if (radioButton.Checked)
                {
                    switch (radioButton.Name)
                    {
                        case "radioControlRadioButton":
                            Form radioForm = new Form();
                            radioForm.Name = "radioForm";
                            radioForm.Text = "Custom Control";
                            MessageBox.Show("Radio");
                            break;
                        case "textBoxControlRadioButton":
                            MessageBox.Show("text");
                            break;
                        case "checkControlRadioButton":
                            MessageBox.Show("check");
                            break;
                        case "buttonControlRadioButton":
                            MessageBox.Show("button");
                            break;
                    }
                }
            }
        }

        private FormParameter returnFormInfo()
        {
            int locationX = Int32.Parse(xTextBox.Text);
            int locationY = Int32.Parse(yTextBox.Text);
            int sizeW = Int32.Parse(wTextBox.Text);
            int sizeH = Int32.Parse(hTextBox.Text);
            string controlName = nameTextBox.Text;
            string controlText = textTextBox.Text;
            string controlfType = String.Empty;

            foreach (RadioButton radioButton in radioButtons)
            {
                if (radioButton.Checked)
                {
                    controlfType = radioButton.Text;
                }
            }

            //
            FormParameter formDets = new FormParameter(controlName,
                                                        controlText,
                                                        locationX,
                                                        locationY,
                                                        sizeH,
                                                        sizeW,
                                                        controlfType);
            return formDets;
        }


        private void saveButton_Click(object sender, EventArgs e)
        {

            if (isFormFilledOut())
            {
                FormParameter myParams = returnFormInfo();
                MessageBox.Show("Form complete.");
            }


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
            resetRadios();
            resetTextBoxes();

        }

        private void createButton_Click(object sender, EventArgs e)
        {
            if (isFormFilledOut())
            {
                MessageBox.Show("Form complete.");
            }
            buildControlProps();
        }

        private void fgColorButton_Click(object sender, EventArgs e)
        {
            ColorDialog colorPicker = new ColorDialog();
            colorPicker.AllowFullOpen = false; colorPicker.ShowHelp = true;
            colorPicker.Color = fcGroupBox.BackColor;

            if (colorPicker.ShowDialog() == DialogResult.OK)
            {
                fcGroupBox.BackColor = colorPicker.Color;
            }
        }

        private void bgColorButton_Click(object sender, EventArgs e)
        {
            ColorDialog colorPicker = new ColorDialog();
            colorPicker.AllowFullOpen = false; colorPicker.ShowHelp = true;
            colorPicker.Color = bgColorGroupBox.BackColor;

            if (colorPicker.ShowDialog() == DialogResult.OK)
            {
                bgColorGroupBox.BackColor = colorPicker.Color;
            }
        }


    }
}
