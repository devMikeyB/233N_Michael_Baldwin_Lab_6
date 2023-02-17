using System;
using System.Drawing;

public class customGroupBox : System.Windows.Forms.GroupBox
{

    public GroupBox customGroupBox()
    {


        this.Name = string.Empty;
        this.Text = string.Empty;
        this.point = new Point(0, 0);
        this.size = new Size(0, 0);
    }
    public GroupBox customGroupBox(string name, string text, Point point, Size size)
    {
        GroupBox groupBox = new GroupBox();

        groupBox.Name = name;
        groupBox.Text = text;
        groupBox.point = point;
        groupBox.size = size;
    }

    public string Name { get; set; }
    public string Text { get; set; }
    public Point point { get; set; }
    public Size size { get; set; }

}
