using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _233N_Michael_Baldwin_Lab_6
{
    internal class FormParameter
    {
        public FormParameter()
        {
            this.Name= string.Empty;
            this.Text= string.Empty;
            this.poX = -1;
            this.poY = -1;
            this.sizeH= -1;
            this.sizeW= -1;
            this.controlType= string.Empty;
        }

        public FormParameter(string name, string text, int pox, int poy, int sizeh, int sizew, string controlType = "")
        {
            this.Name = name;
            this.Text = text;
            this.poX = pox;
            this.poY = poy;
            this.Location = new Point(pox, poy);
            this.sizeH = sizeh;
            this.sizeW = sizew;
            this.Size = new Size(sizeH, sizeW);
            this.controlType = controlType;
        }

        public string Name { get; set; }
        public string Text { get; set; }
        public int poX { get; set; }
        public int poY { get; set; }
        public Point Location { get; set; }
        public int sizeH { get; set; }
        public int sizeW { get; set; }
        public Size Size { get; set; }
        public string controlType { get; set; }

        public override string ToString()
        {
            return this.Name.ToString();
        }
    }
}
