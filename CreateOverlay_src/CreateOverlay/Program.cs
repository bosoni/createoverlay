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
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        static int element = 0;
        static int fontSize = 8;
        static int x, y, w, h;
        static int width = 1, height = 1;
        static string text, name;
        public static string outputOverlay = "";
        public static string outputMaterial = "";
        public static bool csLoaded = false;

        static string Div(int a, int b)
        {
            string s = "" + ((float)a / (float)b);
            s = s.Replace(",", ".");
            return s;
        }

        static void Save(int element)
        {
            if (element == 1) // label
            {
                outputOverlay +=
                    "          element TextArea(" + name + ")\n" +
                    "          {\n" +
                    "               metrics_mode relative\n" +
                    "               left " + Div(x, width) + "\n" +
                    "               top " + Div(y, height) + "\n" +
                    "               width " + Div(w, width) + "\n" +
                    "               height " + Div(h, height) + "\n" +
                    "               font_name DefaultFont\n" +
                    "               char_height " + Div(fontSize, height) + "\n" +
                    "               caption " + text + "\n" +
                    "               colour_top 1 1 1\n" +
                    "               colour_bottom 1 1 1\n" +
                    "          }\n";
            }
            else if (element == 2) // picturebox
            {
                // jos materiaalia ei ole vielä asetettu
                if (outputMaterial.Contains(text + "Material") == false)
                {
                    outputMaterial += "material " + text + "Material\n{\n" +
                            "	technique\n" +
                            "	{\n" +
                            "		pass\n" +
                            "		{\n" +
                            "			lighting off\n" +
                            "			scene_blend alpha_blend\n" +
                            "			depth_check off\n" +
                            "			texture_unit\n" +
                            "			{\n" +
                            "				texture " + text + ".jpg\n" +
                            "			}\n" +
                            "		}\n" +
                            "	}\n" +
                            "}\n\n";
                }

                outputOverlay += "          container Panel(" + name + ")\n" +
                            "          {\n" +
                            "               metrics_mode relative\n" +
                            "               horz_align left\n" +
                            "               vert_align top\n" +
                            "               left " + Div(x, width) + "\n" +
                            "               top " + Div(y, height) + "\n" +
                            "               width " + Div(w, width) + "\n" +
                            "               height " + Div(h, height) + "\n" +
                            "               material " + text + "Material\n" +
                            "          }\n";
            }
        }

        public static void CreateOverlay(string fileName)
        {
            Program.outputOverlay = "Overlay\n{\n     zorder 500\n" +
                "     container Panel(Overlay/Screen)\n" +
                "     {\n" +
                "          metrics_mode relative\n";

            Program.outputMaterial = "";

            // ensin etsitään formin koko että voidaan jakaa kaikki muut arvot sillä
            System.IO.StreamReader sr = new System.IO.StreamReader(fileName);
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                if (line.Contains(".ClientSize")) // formin koko
                {
                    int st = line.IndexOf(".Size(") + 6;
                    int end = line.IndexOf(");");
                    string[] wh = line.Substring(st, end - st).Split(',');
                    width = int.Parse(wh[0]);
                    height = int.Parse(wh[1]);
                    element = 0;
                }
            }
            sr.Close();

            sr = new System.IO.StreamReader(fileName);
            while (!sr.EndOfStream)
            {
                string line = sr.ReadLine();
                if (line.Contains(".label"))
                {
                    if (line.Contains(".Font("))
                    {
                        int st = line.IndexOf("\", ") + 2;
                        int end = line.IndexOf("F, ");
                        line = line.Replace('.', ',');
                        fontSize = (int)float.Parse(line.Substring(st, end - st));
                        element = 1;
                    }
                    if (line.Contains(".Location"))
                    {
                        int st = line.IndexOf(".Point(") + 7;
                        int end = line.IndexOf(");");
                        string[] xy = line.Substring(st, end - st).Split(',');
                        x = int.Parse(xy[0]);
                        y = int.Parse(xy[1]);
                        element = 1;
                    }
                    if (line.Contains(".Size("))
                    {
                        int st = line.IndexOf(".Size(") + 6;
                        int end = line.IndexOf(");");
                        string[] wh = line.Substring(st, end - st).Split(',');
                        w = int.Parse(wh[0]);
                        h = int.Parse(wh[1]);
                        element = 2;
                    }
                    if (line.Contains(".Text"))
                    {
                        int st = line.IndexOf("= \"") + 3;
                        int end = line.IndexOf("\";");
                        text = line.Substring(st, end - st);
                        element = 1;
                    }
                    if (line.Contains(".Name"))
                    {
                        int st = line.IndexOf("= \"") + 3;
                        int end = line.IndexOf("\";");
                        name = line.Substring(st, end - st);
                        element = 1;
                    }

                }
                else if (line.Contains(".pictureBox"))
                {
                    if (line.Contains(".Image"))
                    {
                        int st = line.IndexOf("Properties.Resources.") + 21;
                        int end = line.IndexOf(";");
                        text = line.Substring(st, end - st);
                        element = 2;
                    }
                    if (line.Contains(".Location"))
                    {
                        int st = line.IndexOf(".Point(") + 7;
                        int end = line.IndexOf(");");
                        string[] xy = line.Substring(st, end - st).Split(',');
                        x = int.Parse(xy[0]);
                        y = int.Parse(xy[1]);
                        element = 2;
                    }
                    if (line.Contains(".Size("))
                    {
                        int st = line.IndexOf(".Size(") + 6;
                        int end = line.IndexOf(");");
                        string[] wh = line.Substring(st, end - st).Split(',');
                        w = int.Parse(wh[0]);
                        h = int.Parse(wh[1]);
                        element = 2;
                    }
                    if (line.Contains(".Name"))
                    {
                        int st = line.IndexOf("= \"") + 3;
                        int end = line.IndexOf("\";");
                        name = line.Substring(st, end - st);
                        element = 2;
                    }
                }

                // kun ollaan otettu yhden elementin kaikki datat, talteen ne
                if (element != 0 && line.Contains("//"))
                {
                    Save(element);
                    element = 0;
                }
            }
            sr.Close();
            Program.outputOverlay += "     }\n}\n";
        }

        public static void Save(string fileName)
        {
            System.IO.StreamWriter sw = System.IO.File.CreateText(fileName + ".overlay");
            sw.Write(outputOverlay);
            sw.Close();

            sw = System.IO.File.CreateText(fileName + ".material");
            sw.Write(outputMaterial);
            sw.Close();
            element = 0;
        }

    }
}
