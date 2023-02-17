using System;
using System.Windows.Forms;
using System.Drawing;

public class customGroupBox : System.Windows.Forms.GroupBox
{

    public customGroupBox()
    {
        constructCustomGroupBox();
    }
    public customGroupBox(string name, string text, Point point, Size size)
    {
        constructCustomGroupBox(name, text, point, size);    
    }

    public GroupBox constructCustomGroupBox()
    {
        GroupBox groupBox= new GroupBox();

        groupBox.Name = string.Empty;
        groupBox.Text = string.Empty;
        groupBox.Location = new Point(0, 0);
        groupBox.Size = new Size(0, 0);
        return groupBox;
    }
    public GroupBox constructCustomGroupBox(string name, string text, Point point, Size size)
    {
        GroupBox groupBox = new GroupBox();

        groupBox.Name = name;
        groupBox.Text = text;
        groupBox.Location = point;
        groupBox.Size = size;
        return groupBox;
    }

    public string Name { get; set; }
    public string Text { get; set; }
    public Point point { get; set; }
    public Size size { get; set; }

}
