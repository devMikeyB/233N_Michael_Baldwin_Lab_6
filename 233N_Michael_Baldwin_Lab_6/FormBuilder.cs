using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.ConstrainedExecution;
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
        GroupBox[] colgroupBoxes;
        FormParameter[] newControlParams;
        Label[] detLabels;
        Label[] numLabels;
        Button[] colButtons;
        Button[] controlButtons;
        Button[] slButtons;
        ComboBox[] slComboBoxes;

        List<FormParameter> savedParameterList;

        Color defaultFormBGColor = SystemColors.Control;
        Color defaultSaveBGColor = SystemColors.InactiveCaption;

        public FormBuilder()
        {
            InitializeComponent();
        }


        private void FormBuilder_Load(object sender, EventArgs e)
        {

            newControlParams = new FormParameter[31]; //Array containing parameters for each control to be added.
            newControlParams[0] = new FormParameter("objectSelectionGroupBox", "Select Object", 31, 27, 352, 107, "GroupBox");
            newControlParams[1] = new FormParameter("sizeAndLocationGroupBox", "Size and Location", 31, 140, 352, 107, "GroupBox");
            newControlParams[2] = new FormParameter("nameAndTextGroupBox", "Set Name and Text", 31, 253, 352, 107, "GroupBox");
            newControlParams[3] = new FormParameter("colorGroupBox", "Choose Color", 31, 366, 352, 107, "GroupBox");
            newControlParams[4] = new FormParameter("controlGroupBox", "Controls", 31, 496, 436, 107, "GroupBox");
            newControlParams[5] = new FormParameter("saveLoadGroupBox", "Save, Load, or Remove", 389, 85, 379, 100, "GroupBox");
            newControlParams[6] = new FormParameter("radioRadioButton", "Radio Button", 57, 30, 87, 17, "RadioButton");
            newControlParams[7] = new FormParameter("textBoxRadioButton", "Text Box", 206, 30, 64, 17, "RadioButton");
            newControlParams[8] = new FormParameter("checkBoxRadioButton", "Check Box", 57, 70, 77, 17, "RadioButton");
            newControlParams[9] = new FormParameter("buttonRadioButton", "Button", 206, 70, 56, 17, "RadioButton");
            newControlParams[10] = new FormParameter("locationLabel", "Location (X, Y)", 23, 31, 77, 13, "numLabel");
            newControlParams[11] = new FormParameter("sizeLabel", "Size (W, H)", 23, 63, 61, 13, "numLabel");
            newControlParams[12] = new FormParameter("xTextBox", "", 112, 24, 31, 20, "numTextBox");
            newControlParams[13] = new FormParameter("yTextBox", "", 172, 25, 31, 20, "numTextBox");
            newControlParams[14] = new FormParameter("wTextBox", "", 112, 59, 31, 20, "numTextBox");
            newControlParams[15] = new FormParameter("hTextBox", "", 172, 60, 31, 20, "numTextBox");
            newControlParams[16] = new FormParameter("nameLabel", "Name: ", 57, 38, 35, 13, "detLabel");
            newControlParams[17] = new FormParameter("textLabel", "Text: ", 57, 74, 28, 13, "detLabel");
            newControlParams[18] = new FormParameter("nameTextBox", "", 153, 35, 100, 20, "TextBox");
            newControlParams[19] = new FormParameter("textTextBox", "", 153, 71, 100, 20, "TextBox");
            newControlParams[20] = new FormParameter("bgColorGroupBox", "", 153, 29, 19, 23, "colGroupBox");
            newControlParams[21] = new FormParameter("fgColorGroupBox", "", 153, 69, 19, 23, "colGroupBox");
            newControlParams[22] = new FormParameter("bgColorButton", "Back Color", 26, 29, 108, 23, "colButton");
            newControlParams[23] = new FormParameter("fgColorButton", "Fore Color", 26, 69, 108, 23, "colButton");
            newControlParams[24] = new FormParameter("createButton", "Create", 26, 48, 86, 23, "controlButton");
            newControlParams[25] = new FormParameter("clearButton", "Clear", 172, 48, 75, 23, "controlButton");
            newControlParams[26] = new FormParameter("exitButton", "Exit", 315, 48, 75, 23, "controlButton");
            newControlParams[27] = new FormParameter("saveButton", "Save", 6, 71, 75, 23, "slButton");
            newControlParams[28] = new FormParameter("loadButton", "Load", 144, 71, 75, 23, "slButton");
            newControlParams[29] = new FormParameter("removeButton", "Remove", 298, 71, 75, 23, "slButton");
            newControlParams[30] = new FormParameter("controlSelectionComboBox", "", 119, 28, 121, 21, "slComboBox");


            groupBoxes = new GroupBox[8]; //Array of groupboxes.
            colgroupBoxes = new GroupBox[2];
            radioButtons = new RadioButton[4]; //Array of radioButtons
            textBoxes = new TextBox[2]; //Array of textboxes for name and text values
            numTextBoxes = new TextBox[4]; //Array of textboxes expected to contain ints
            numLabels = new Label[2]; //Array of labels for number related fields
            detLabels = new Label[2]; //Array of labels for string related fields
            colButtons = new Button[2]; //Array of buttons for Color group box
            controlButtons = new Button[3]; //Array of buttons for Control group box
            slButtons = new Button[3]; //Array of buttons for Save and Load group box
            slComboBoxes = new ComboBox[1]; //Array containing ComboBox for Save and Load functionality

            handleControls();

            savedParameterList = new List<FormParameter> { }; //Array to handle save and load data

        }

        private Control getControlByName(Array enumerable, string name)
        {   //Returns a Control within an array.
            Control blankControl = new Control();
            foreach (Control control in enumerable)
            {
                if (control.Name == name)
                {
                    return control;
                }
            }
            return blankControl;
        }

        private void handleControls()
        {   //A function to handle the adding of controls to the appropriate areas given their corresponding FormParameter object.
            foreach (FormParameter param in newControlParams)
            {
                switch (param.controlType)
                {
                    case "GroupBox": //If it's a GroupBox
                        GroupBox newBox = buildGroupBox(param.Name, param.Text, param.Location, param.Size); //Create GroupBox
                        if (newBox.Name == "saveLoadGroupBox")
                            newBox.BackColor = defaultSaveBGColor;
                        int iterable = 0; //Reset iterable
                        foreach (GroupBox box in groupBoxes)
                        {   //Check for next null value in groupBox array
                            if (box == null)
                            {   //If null
                                groupBoxes[Array.IndexOf(groupBoxes, box)] = newBox; //Get index of current box and overwrite with new box
                                this.Controls.Add(groupBoxes[iterable]); //Add groupBox array item to Controls
                                break;
                            }
                            iterable++;
                        }
                        break;

                    case "colGroupBox": //If it's a GroupBox
                        GroupBox newColBox = buildGroupBox(param.Name, param.Text, param.Location, param.Size); //Create GroupBox
                        applyControls(colgroupBoxes, newColBox, "colorGroupBox");
                        break;

                    case "RadioButton": //If RadioButton
                        RadioButton newRadioButton = buildRadioButton(param.Name, param.Text, param.Location, param.Size); //Create RadioButton
                        applyControls(radioButtons, newRadioButton, "objectSelectionGroupBox"); //Add to form
                        break;

                    case "TextBox":
                        TextBox newTextBox = buildTextBox(param.Name, param.Text, param.Location, param.Size); //Create TextBox
                        applyControls(textBoxes, newTextBox, "nameAndTextGroupBox"); //Add to form
                        break;

                    case "numTextBox":
                        TextBox newnumTextBox = buildTextBox(param.Name, param.Text, param.Location, param.Size); //Create numTextBox
                        applyControls(numTextBoxes, newnumTextBox, "sizeAndLocationGroupBox"); //Add to form
                        break;

                    case "numLabel":
                        Label newnumLabel = buildLabel(param.Name, param.Text, param.Location, param.Size); //Create label
                        applyControls(numLabels, newnumLabel, "sizeAndLocationGroupBox"); //Add to form
                        break;

                    case "detLabel":
                        Label newdetLabel = buildLabel(param.Name, param.Text, param.Location, param.Size); //Create Label
                        applyControls(detLabels, newdetLabel, "nameAndTextGroupBox"); //Add to form
                        break;

                    case "colButton":
                        Button newButton = buildButton(param.Name, param.Text, param.Location, param.Size); //Create button
                        applyControls(colButtons, newButton, "colorGroupBox"); //Add to form
                        break;

                    case "controlButton":
                        Button newControlButton = buildButton(param.Name, param.Text, param.Location, param.Size);
                        applyControls(controlButtons, newControlButton, "controlGroupBox");
                        break;

                    case "slButton":
                        Button newslButton = buildButton(param.Name, param.Text, param.Location, param.Size);
                        applyControls(slButtons, newslButton, "saveLoadGroupBox");
                        break;

                    case "slComboBox":
                        ComboBox newslComboBox = buildComboBox(param.Name, param.Text, param.Location, param.Size);
                        applyControls(slComboBoxes, newslComboBox, "saveLoadGroupBox");
                        break;
                }

            }
        }

        private void buttonHandler(object sender, EventArgs e)
        { //This button handler function is used so that buttons may be dynamically constructed and function can be added afterward.
            switch (sender.ToString())
            {
                case "System.Windows.Forms.Button, Text: Back Color":
                    bgColorButton_Click(sender, e); //Sets backColor
                    break;

                case "System.Windows.Forms.Button, Text: Fore Color":
                    fgColorButton_Click(sender, e); //Sets Forecolor
                    break;

                case "System.Windows.Forms.Button, Text: Create":
                    createButton_Click(sender, e); //Create Form
                    break;

                case "System.Windows.Forms.Button, Text: Clear":
                    clearButton_Click(sender, e); //Clears Form
                    break;
                case "System.Windows.Forms.Button, Text: Exit":
                    exitButton_Click(sender, e);
                    break;
                case "System.Windows.Forms.Button, Text: Save":
                    saveButton_Click(sender, e);  //Save parameters to combobox
                    break;
                case "System.Windows.Forms.Button, Text: Load":
                    loadButton_Click(sender, e); //Load parameter from combobox
                    break;
                case "System.Windows.Forms.Button, Text: Remove":
                    removeButton_Click(sender, e); //Remove from combobox
                    break;
            }


        }

        private void applyControls(Control[] controlArray, Control controlToAdd, string groupBoxName)
        {
            int iterable = 0;
            foreach (Control control in controlArray)
            {   //Check for next null value in control array
                if (control == null) //Check for null space in array, interpret null as empty and apply valid data.
                {   //If null
                    controlArray[Array.IndexOf(controlArray, control)] = controlToAdd; //Get index of current control and overwrite with new control
                    this.Controls.Add(controlArray[iterable]); //Add control array item to Controls
                    controlArray[iterable].Parent = getControlByName(groupBoxes, groupBoxName);
                    break;
                }
                iterable++;
            }
        }

        private GroupBox buildGroupBox(string name, string text, Point point, Size size)
        {   /// Takes pertinent information and returns a GroupBox object.
            GroupBox groupBox = new GroupBox();
            groupBox.Name = name;
            groupBox.Text = text;
            groupBox.Location = point;
            groupBox.Size = size;
            return groupBox;
        }

        private RadioButton buildRadioButton(string name, string text, Point point, Size size)
        {/// Takes pertinent information and returns a RadioButton object.
            RadioButton radioButton = new RadioButton();
            radioButton.Name = name;
            radioButton.Text = text;
            radioButton.Location = point;
            radioButton.Size = size;
            return radioButton;
        }
        private TextBox buildTextBox(string name, string text, Point point, Size size)
        {/// Takes pertinent information and returns a TextBox object.
            TextBox textBox = new TextBox();
            textBox.Name = name;
            textBox.Text = text;
            textBox.Location = point;
            textBox.Size = size;
            return textBox;
        }
        private Label buildLabel(string name, string text, Point point, Size size)
        {/// Takes pertinent information and returns a Label object.
            Label label = new Label();
            label.Name = name;
            label.Text = text;
            label.Location = point;
            label.Size = size;
            return label;
        }
        private Button buildButton(string name, string text, Point point, Size size)
        {/// Takes pertinent information and returns a Label object.
            Button button = new Button();
            button.Name = name;
            button.Text = text;
            button.Location = point;
            button.Size = size;
            button.Click += buttonHandler;
            return button;
        }
        private ComboBox buildComboBox(string name, string text, Point point, Size size)
        {/// Takes pertinent information and returns a Label object.
            ComboBox comBox = new ComboBox();
            comBox.Name = name;
            comBox.Text = text;
            comBox.Location = point;
            comBox.Size = size;
            return comBox;
        }
        private CheckBox buildCheckBox(string name, string text, Point point, Size size)
        {/// Takes pertinent information and returns a Checkbox object.
            CheckBox checkBox = new CheckBox();
            checkBox.Name = name;
            checkBox.Text = text;
            checkBox.Location = point;
            checkBox.Size = size;
            return checkBox;
        }

        private void resetRadios()
        {//Resets all radio buttons
            foreach (RadioButton radioButton in radioButtons)
            {
                radioButton.Checked = false;
            }
        }

        private void resetTextBoxes()
        {//Resets all textboxes
            foreach (TextBox textBox in textBoxes)
            {   //Reset textBoxes
                textBox.Text = string.Empty;
            }
            foreach (TextBox textBox in numTextBoxes)
            {
                textBox.Text = string.Empty;
            }
        }

        private void resetGroupBoxes()
        {   //Resets all groupboxes
            foreach (GroupBox groupBox in groupBoxes)
            {
                if (groupBox != null)
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
            foreach (GroupBox groupBox in colgroupBoxes)
                groupBox.BackColor = defaultFormBGColor;
        }

        private bool isFormFilledOut()
        {   //Returns true if form is filled out
            bool[] formReqs = new bool[5];
            formReqs[0] = false; formReqs[1] = true; formReqs[2] = true; formReqs[3] = true; formReqs[4] = true;



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

        private FormParameter collectFormInfo() //Returns FormParameter object containing information from the form.
        {
            FormParameter returnParam = new FormParameter(getControlByName(textBoxes, "nameTextBox").Text,
                                                          getControlByName(textBoxes, "textTextBox").Text,
                                                          Int32.Parse(getControlByName(numTextBoxes, "xTextBox").Text),
                                                          Int32.Parse(getControlByName(numTextBoxes, "yTextBox").Text),
                                                          Int32.Parse(getControlByName(numTextBoxes, "hTextBox").Text),
                                                          Int32.Parse(getControlByName(numTextBoxes, "wTextBox").Text)
                                                          );
            return returnParam;
        }

        private FormParameter buildControlProps()
        {   //Returns a FormParameter object complete with the optional controlType property.
            foreach (RadioButton radioButton in radioButtons)
            {
                if (radioButton.Checked)
                {
                    FormParameter formParameter = collectFormInfo();
                    switch (radioButton.Name)
                    {
                        case "radioRadioButton":
                            formParameter.controlType = "RadioButton";
                            return formParameter;

                        case "textBoxRadioButton":
                            formParameter.controlType = "TextBox";
                            return formParameter;

                        case "checkBoxRadioButton":
                            formParameter.controlType = "CheckBox";
                            return formParameter;

                        case "buttonRadioButton":
                            formParameter.controlType = "Button";
                            return formParameter;
                    }
                }
            }
            return new FormParameter();
        }

        private FormParameter returnFormInfo()
        {   //Return FormParameter object complete with all fields and custom colors.
            int locationX = Int32.Parse(getControlByName(numTextBoxes, "xTextBox").Text);
            int locationY = Int32.Parse(getControlByName(numTextBoxes, "yTextBox").Text);
            int sizeW = Int32.Parse(getControlByName(numTextBoxes, "wTextBox").Text);
            int sizeH = Int32.Parse(getControlByName(numTextBoxes, "hTextBox").Text);
            string controlName = getControlByName(textBoxes, "nameTextBox").Text;
            string controlText = getControlByName(textBoxes, "textTextBox").Text;
            string controlfType = String.Empty;
            Color bgColor = getControlByName(colgroupBoxes, "bgColorGroupBox").BackColor;
            Color fgColor = getControlByName(colgroupBoxes, "fgColorGroupBox").BackColor;


            foreach (RadioButton radioButton in radioButtons)
            {
                if (radioButton.Checked)
                {
                    controlfType = radioButton.Text;
                }
            }
            FormParameter formDets = new FormParameter(controlName,
                                                        controlText,
                                                        locationX,
                                                        locationY,
                                                        sizeH,
                                                        sizeW,
                                                        controlfType);
            formDets.BackgroundColor = bgColor;
            formDets.ForegroundColor = fgColor;
            return formDets;
        }

        public ComboBox getComboBoxByName(Array enumerable, string name)
        {//Return a combobox given a name. This could instead be an override inside the getControlByName function to expand capability.
            foreach (ComboBox comboBox in enumerable)
            {
                if (comboBox.Name == name) return comboBox;
            }
            return null;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {   //To maintain congruency between design-oriented .net development, button functions are named similarly to 
            //the auto-generated ones.
            //This function saves data to a list of FormParameters and changes the combobox accordingly.
            if (isFormFilledOut())
            {
                FormParameter myParams = returnFormInfo();
                savedParameterList.Add(myParams);
                getComboBoxByName(slComboBoxes, "controlSelectionComboBox").Items.Add(myParams.Name);
                Debug.WriteLine(savedParameterList);
                foreach (FormParameter myParam in savedParameterList)
                    Debug.WriteLine(myParam.Name);

                return;
            }

        }

        private void filloutForm(FormParameter formParameter)
        {
            //Populates the main form with appropriate data.
            getControlByName(numTextBoxes, "xTextBox").Text = formParameter.poX.ToString();
            getControlByName(numTextBoxes, "yTextBox").Text = formParameter.poY.ToString();
            getControlByName(numTextBoxes, "wTextBox").Text = formParameter.sizeW.ToString();
            getControlByName(numTextBoxes, "hTextBox").Text = formParameter.sizeH.ToString();
            getControlByName(textBoxes, "nameTextBox").Text = formParameter.Name.ToString();
            getControlByName(textBoxes, "textTextBox").Text = formParameter.Text.ToString();
            getControlByName(colgroupBoxes, "fgColorGroupBox").BackColor = formParameter.ForegroundColor;
            getControlByName(colgroupBoxes, "bgColorGroupBox").BackColor = formParameter.BackgroundColor;

            foreach (RadioButton radioButton in radioButtons)
            {
                if (radioButton.Text == formParameter.controlType)
                    radioButton.Checked = true;
                else
                    radioButton.Checked = false;
            }

        }

        private void loadButton_Click(object sender, EventArgs e)
        {   //Loads data saved previously.
            if (getComboBoxByName(slComboBoxes, "controlSelectionComboBox").SelectedIndex != -1)
            {
                foreach (FormParameter pam in savedParameterList)
                {
                    if (pam.Name == getComboBoxByName(slComboBoxes, "controlSelectionComboBox").SelectedItem.ToString())
                    {
                        filloutForm(pam);
                        return;
                    }
                }
                MessageBox.Show("Unable to load");
            }
            MessageBox.Show("Please select something to load. \nIf there are no options, please save some data.");
        }

        private void removeButton_Click(object sender, EventArgs e)
        {   //Remove saved data.
            if (getComboBoxByName(slComboBoxes, "controlSelectionComboBox").SelectedIndex != -1)
            {
                foreach (FormParameter pam in savedParameterList)
                {
                    if (pam.Name == getComboBoxByName(slComboBoxes, "controlSelectionComboBox").SelectedItem.ToString())
                    {
                        savedParameterList.Remove(pam);
                        getComboBoxByName(slComboBoxes, "controlSelectionComboBox").Items.Remove(getComboBoxByName(slComboBoxes, "controlSelectionComboBox").SelectedItem);
                        getComboBoxByName(slComboBoxes, "controlSelectionComboBox").SelectedIndex = -1;
                        if (getComboBoxByName(slComboBoxes, "controlSelectionComboBox").Text != String.Empty)
                            getComboBoxByName(slComboBoxes, "controlSelectionComboBox").Text = String.Empty;
                        return;
                    }
                }
            }

        }

        private void exitButton_Click(object sender, EventArgs e)
        {   //Exit application
            Application.Exit();
        }

        private void clearButton_Click(object sender, EventArgs e)
        {//Clear form
            resetRadios();
            resetTextBoxes();
            resetGroupBoxes();
        }

        private void handleColorSelection(Control control)
        {//Deal with color selection
            if (getControlByName(colgroupBoxes, "bgColorGroupBox").BackColor != defaultFormBGColor)
                control.BackColor = getControlByName(colgroupBoxes, "bgColorGroupBox").BackColor;
            if (getControlByName(colgroupBoxes, "fgColorGroupBox").BackColor != defaultFormBGColor)
                control.ForeColor = getControlByName(colgroupBoxes, "fgColorGroupBox").BackColor;
        }

        private void createButton_Click(object sender, EventArgs e)
        {//Create new form with control added
            if (isFormFilledOut())
            {
                //MessageBox.Show("Form complete.");
                FormParameter formToBe = buildControlProps();
                Debug.WriteLine(formToBe.controlType);
                switch (formToBe.controlType)
                {
                    case "RadioButton": //Pass radio button to form
                        RadioButton radiobutton = buildRadioButton(formToBe.Name, formToBe.Text, formToBe.Location, formToBe.Size);
                        handleColorSelection(radiobutton);
                        displayForm radioForm = new displayForm(radiobutton);

                        break;
                    case "TextBox": //Pass textbox to form
                        TextBox textBox = buildTextBox(formToBe.Name, formToBe.Text, formToBe.Location, formToBe.Size);
                        handleColorSelection(textBox);
                        displayForm textForm = new displayForm(textBox);
                        break;
                    case "Button": //Pass button to form
                        Button button = buildButton(formToBe.Name, formToBe.Text, formToBe.Location, formToBe.Size);
                        handleColorSelection(button);
                        displayForm buttonForm = new displayForm(button);
                        break;
                    case "CheckBox": //Pass checkbox to form
                        CheckBox checkbox = buildCheckBox(formToBe.Name, formToBe.Text, formToBe.Location, formToBe.Size);
                        handleColorSelection(checkbox);
                        displayForm checkForm = new displayForm(checkbox);
                        break;
                }

            }

        }

        private void fgColorButton_Click(object sender, EventArgs e)
        {//Save fgColor
            ColorDialog colorPicker = new ColorDialog();
            colorPicker.AllowFullOpen = false; colorPicker.ShowHelp = true;
            if (colorPicker.ShowDialog() == DialogResult.OK)
            {
                getControlByName(colgroupBoxes, "fgColorGroupBox").BackColor = colorPicker.Color;
            }
        }

        private void bgColorButton_Click(object sender, EventArgs e)
        {//Save bgColor
            ColorDialog colorPicker = new ColorDialog(); //Select color
            colorPicker.AllowFullOpen = false; colorPicker.ShowHelp = true;
            if (colorPicker.ShowDialog() == DialogResult.OK) //If ok
            {   //Assign color to bgColorGroupBox for simple storage and user simplicity.
                getControlByName(colgroupBoxes, "bgColorGroupBox").BackColor = colorPicker.Color;
            }
        }


    }
}
