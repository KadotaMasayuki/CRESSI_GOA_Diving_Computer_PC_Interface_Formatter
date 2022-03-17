using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CressiUciJsonFormatter
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();

            this.Text = "CRESSI UCI JSON FORMATTER - HOW TO USE";

            // スクロールする画像パネル
            panel1.Dock = DockStyle.Fill;
            panel1.AutoScroll = true;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.SizeMode = PictureBoxSizeMode.AutoSize;

            // 画像をリソースから取得
            System.Reflection.Assembly a = System.Reflection.Assembly.GetExecutingAssembly();
            ////このアセンブリのリソース名を表示
            //foreach (string resource in a.GetManifestResourceNames())
            //{
            //    Console.WriteLine(resource);
            //}
            Bitmap bmp = new Bitmap(a.GetManifestResourceStream("CressiUciJsonFormatter.images.説明画像.png"));
            pictureBox1.Image = bmp;
        }
    }
}
