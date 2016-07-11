using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Printing;
using System.Diagnostics;
using System.IO;

namespace ImagePrint
{
    class Program
    {
        static void Main(string[] args)
        {
            Font printFont = new Font("Arial", 10);

            using (StreamReader printFile = new StreamReader(""))
            {
                PrintDocument pd = new PrintDocument();
                pd.DocumentName = "FileThatIsPrinting";
                pd.PrintPage += (s, ev) =>
                {
                    float linesPerPage = 0, yPos = 0, leftMar = ev.MarginBounds.Left, topMar = ev.MarginBounds.Top;
                    int count = 0;
                    string line = null;

                    linesPerPage = ev.MarginBounds.Height / printFont.GetHeight(ev.Graphics);

                    while (count < linesPerPage && ((line = printFile.ReadLine()) != null))
                    {
                        yPos = topMar + (count * printFont.GetHeight(ev.Graphics));
                        ev.Graphics.DrawString(line, printFont, Brushes.Black, leftMar, yPos, new StringFormat());
                        count++;
                    }

                    if (line != null)
                    {
                        ev.HasMorePages = true;
                    }
                    else
                    {
                        ev.HasMorePages = false;
                    }
    
                };
            }
            //ProcessStartInfo info = new ProcessStartInfo();
            //info.Verb = "print";
            //info.FileName = "";
            //info.CreateNoWindow = true;
            //info.WindowStyle = ProcessWindowStyle.Hidden;

            //Process p = new Process();
            //p.StartInfo = info;
            //p.Start();

            //p.WaitForInputIdle();



        }
    }
}
