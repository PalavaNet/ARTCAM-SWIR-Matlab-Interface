using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AcquisitionInc
{
    public class ConsoleWriter : TextWriter
    {
        private Control textbox;
        public ConsoleWriter(Control textbox)
        {
            this.textbox = textbox;
        }

        public override void Write(char value)
        {
            if (textbox.InvokeRequired)
            {
                textbox.Invoke(new MethodInvoker(() => textbox.Text += value));
            }
            else
            {
                textbox.Text += value;
            }
        }

        public override void Write(string value)
        {
            if (textbox.InvokeRequired)
            {
                textbox.Invoke(new MethodInvoker(() => textbox.Text += value));
            }
            else
            {
                textbox.Text += value;
            }
        }

        public override Encoding Encoding
        {
            get { return Encoding.ASCII; }
        }
    }
}
