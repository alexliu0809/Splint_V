using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

using System.Windows.Forms.DataVisualization;
using System.Windows.Forms.DataVisualization.Charting;





namespace SplintWForm
{

    public partial class Form2 : Form
    {
        public string[] ansArray2;
        public Form2()
        {
            InitializeComponent();
        }
        int a1 = 2, a2 = 5, a3 = 4, a4 = 7;
        int a = 10, b = 20, c = 30, d = 40;
        int dengji0 = 0, dengji1 = 0, dengji2 = 1, dengji3 = 0;
        private void Form2_Load(object sender, EventArgs e)
        {
            MainForm f = (MainForm)this.Owner;
            List<string> mess = new List<string>();
            List<string> error0 = new List<string>();
            List<string> error1 = new List<string>();
            List<string> error2 = new List<string>();
            List<string> error3 = new List<string>();
            //==========error0的数据等级
            error0.Add("bounds");
            //======结束0
            //======error1的数据等级
            error1.Add("usedef");
            error1.Add("impouts");
            error1.Add("unrecog");
            error1.Add("type");
            error1.Add("noret");
            error1.Add("evalorderuncon");
            error1.Add("infloopsuncon");
            error1.Add("macroredef");
            error1.Add("isoreserved");
            //======结束1
            //======error2的数据等级
            error2.Add("charint");
            error2.Add("enumint");
            error2.Add("checks");
            error2.Add("mustmod");
            error2.Add("distinctinternalnames");
            //======结束2
            //======error3的数据等级
            error3.Add("nullderef");
            error3.Add("noparams");
            error3.Add("charindex");
            error3.Add("enumindex");
            error3.Add("exportlocal");
            error3.Add("exportheader");
            //======结束3

            ansArray2 = f.ansArray1;
            int flag = 0;
            for (int i = 0; i < ansArray2.Length; i++)//把数据提取到mess里
            {
                if (flag > 0)
                    mess.Add(ansArray2[i]);
                if (ansArray2[i].Contains("==="))
                    flag = (flag + 1) % 2;
            }

            mess.RemoveAt(mess.Count - 1);     //去掉最后一行的======

            for (int i = 0; i < error0.Count; i++)
            {
                for (int j = 0; j < mess.Count; j++)
                {
                    if (mess[j].Contains(error0[i]))
                    {
                        Regex regex = new Regex(@"[0-9]+");
                        Match m = regex.Match(mess[j]);
                        string num = m.Value;       //提取了m的数据
                        dengji0 += int.Parse(num);
                    }
                }
            }

            for (int i = 0; i < error1.Count; i++)
            {
                for (int j = 0; j < mess.Count; j++)
                {
                    if (mess[j].Contains(error1[i]))
                    {
                        Regex regex = new Regex(@"[0-9]+");
                        Match m = regex.Match(mess[j]);
                        string num = m.Value;       //提取了m的数据
                        dengji1 += int.Parse(num);
                    }
                }
            }

            for (int i = 0; i < error2.Count; i++)
            {
                for (int j = 0; j < mess.Count; j++)
                {
                    if (mess[j].Contains(error2[i]))
                    {
                        Regex regex = new Regex(@"[0-9]+");
                        Match m = regex.Match(mess[j]);
                        string num = m.Value;       //提取了m的数据
                        dengji2 += int.Parse(num);
                    }
                }
            }

            for (int i = 0; i < error3.Count; i++)
            {
                for (int j = 0; j < mess.Count; j++)
                {
                    if (mess[j].Contains(error3[i]))
                    {
                        Regex regex = new Regex(@"[0-9]+");
                        Match m = regex.Match(mess[j]);
                        string num = m.Value;       //提取了m的数据
                        dengji3 += int.Parse(num);
                    }
                }
            }


            List<int> x = new List<int>();
            List<int> y = new List<int>();
            List<string> xData = new List<string>() { "0级错误", "1级错误", "2级错误", "3级错误" };

            List<int> yData = new List<int>() { dengji0, dengji1, dengji2, dengji3 };
            chart1.Series[0]["PieLabelStyle"] = "Outside";//将文字移到外侧
            chart1.Series[0]["PieLineColor"] = "Black";//绘制黑色的连线。
            chart1.Series[0].Points.DataBindXY(xData, yData);
            a1 = dengji0;
            a2 = dengji1;
            a3 = dengji2;
            a4 = dengji3;
            for (int i = 0; i < 4; i++)
            {
                x.Add(i);
                y.Add(i);
            }
            this.chart2.Series[0].Points.AddXY(0, a1);
            this.chart2.Series[0].Points.AddXY(1, a2);
            this.chart2.Series[0].Points.AddXY(2, a3);
            this.chart2.Series[0].Points.AddXY(3, a4);
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            // Create a new save file dialog
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            // Sets the current file name filter string, which determines 
            // the choices that appear in the "Save as file type" or 
            // "Files of type" box in the dialog box.
            saveFileDialog1.Filter = "Bitmap (*.bmp)|*.bmp|JPEG (*.jpg)|*.jpg|EMF (*.emf)|*.emf|PNG (*.png)|*.png|SVG (*.svg)|*.svg|GIF (*.gif)|*.gif|TIFF (*.tif)|*.tif";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            // Set image file format
            ChartImageFormat format = ChartImageFormat.Bmp;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {


                if (saveFileDialog1.FileName.EndsWith("bmp"))
                {
                    format = ChartImageFormat.Bmp;
                }
                else if (saveFileDialog1.FileName.EndsWith("jpg"))
                {
                    format = ChartImageFormat.Jpeg;
                }
                else if (saveFileDialog1.FileName.EndsWith("emf"))
                {
                    format = ChartImageFormat.Emf;
                }
                else if (saveFileDialog1.FileName.EndsWith("gif"))
                {
                    format = ChartImageFormat.Gif;
                }
                else if (saveFileDialog1.FileName.EndsWith("png"))
                {
                    format = ChartImageFormat.Png;
                }
                else if (saveFileDialog1.FileName.EndsWith("tif"))
                {
                    format = ChartImageFormat.Tiff;
                }
                else if (saveFileDialog1.FileName.EndsWith("svg"))
                {
                    format = ChartImageFormat.Bmp;
                }
                string s2 = null;
                //s2 = saveFileDialog1.FileName.ToString();
                // Save image
                this.chart1.SaveImage(saveFileDialog1.FileName, format);//

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Create a new save file dialog
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();

            // Sets the current file name filter string, which determines 
            // the choices that appear in the "Save as file type" or 
            // "Files of type" box in the dialog box.
            saveFileDialog1.Filter = "Bitmap (*.bmp)|*.bmp|JPEG (*.jpg)|*.jpg|EMF (*.emf)|*.emf|PNG (*.png)|*.png|SVG (*.svg)|*.svg|GIF (*.gif)|*.gif|TIFF (*.tif)|*.tif";
            saveFileDialog1.FilterIndex = 2;
            saveFileDialog1.RestoreDirectory = true;

            // Set image file format
            ChartImageFormat format = ChartImageFormat.Bmp;
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {


                if (saveFileDialog1.FileName.EndsWith("bmp"))
                {
                    format = ChartImageFormat.Bmp;
                }
                else if (saveFileDialog1.FileName.EndsWith("jpg"))
                {
                    format = ChartImageFormat.Jpeg;
                }
                else if (saveFileDialog1.FileName.EndsWith("emf"))
                {
                    format = ChartImageFormat.Emf;
                }
                else if (saveFileDialog1.FileName.EndsWith("gif"))
                {
                    format = ChartImageFormat.Gif;
                }
                else if (saveFileDialog1.FileName.EndsWith("png"))
                {
                    format = ChartImageFormat.Png;
                }
                else if (saveFileDialog1.FileName.EndsWith("tif"))
                {
                    format = ChartImageFormat.Tiff;
                }
                else if (saveFileDialog1.FileName.EndsWith("svg"))
                {
                    format = ChartImageFormat.Bmp;
                }
                string s2 = null;
                //s2 = saveFileDialog1.FileName.ToString();
                // Save image
                this.chart2.SaveImage(saveFileDialog1.FileName, format);//

            }
        }


    }
}
