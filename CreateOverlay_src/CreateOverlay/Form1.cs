/**
Create overlay
Copyright (c) 2009-2010 mjt (mixut@hotmail.com)

Permission is hereby granted, free of charge, to any person obtaining
a copy of this software and associated documentation files (the
"Software"), to deal in the Software without restriction, including
without limitation the rights to use, copy, modify, merge, publish,
distribute, sublicense, and/or sell copies of the Software, and to
permit persons to whom the Software is furnished to do so, subject to
the following conditions:

The above copyright notice and this permission notice shall be included
in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF
MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT.
IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY
CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT,
TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE
SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
*/

using System;
using System.Windows.Forms;

namespace CreateOverlay
{
    public partial class Form1 : Form
    {
        const string COVersion = "3.0";
        public Form1()
        {
            InitializeComponent();
        }

        // open cs file
        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                System.Windows.Forms.MessageBox.Show(openFileDialog1.FileName + " loaded.", "Load");
                Program.csLoaded = true;
                Program.CreateOverlay(openFileDialog1.FileName);
            }
        }

        // save overlay
        private void button2_Click(object sender, EventArgs e)
        {
            if (Program.csLoaded == false) return;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Program.Save(saveFileDialog1.FileName);
                System.Windows.Forms.MessageBox.Show(saveFileDialog1.FileName + ".overlay and\n" + saveFileDialog1.FileName + ".material saved.", "Save");
            }
        }

        // about
        private void button3_Click(object sender, EventArgs e)
        {
            string txt = "Create dialog with Microsoft Visual C# 2008 Express edition (only tested),\n" +
            "using Label (for text) and PictureBox (for images).\n" +
            "Save *.Designer.cs file, open it in CreateOverlay and save .overlay and .material files.\n\n" +
            "After saving, you must modify .material file if you used some other images than .jpg " +
            "(program writes .jpg extension always, no matter if your image is .png).";

            System.Windows.Forms.MessageBox.Show(txt, "Help");
            System.Windows.Forms.MessageBox.Show("Create overlay " + COVersion + "\nCopyright (c) 2009-2010 mjt (mixut@hotmail.com)", "Help");
        }

        // exit
        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

    }
}
