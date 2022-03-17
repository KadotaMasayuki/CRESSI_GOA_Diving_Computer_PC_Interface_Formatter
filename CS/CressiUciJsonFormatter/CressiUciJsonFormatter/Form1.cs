using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Text.Json;
using System.Text.Json.Nodes;



namespace CressiUciJsonFormatter
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            this.Text = "CRESSI UCI JSON FORMATTER - MAIN";

            label1.Text = "";

            this.AllowDrop = true;
            this.DragEnter += Form1_DragEnter;
            this.DragDrop += Form1_DragDrop;
        }

        private void Form1_DragEnter(object sender, DragEventArgs e)
        {
            // ファイルのドラッグ&ドロップのみ受け付ける
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

        private void Form1_DragDrop(object sender, DragEventArgs e)
        {
            // ドラッグ&ドロップされた最初のファイルのフルパスを取得
            foreach (string fn in (string[])e.Data.GetData(DataFormats.FileDrop))
            {
                label1.Text = fn;
                break;
            }
        }

        private void helpButton_Click(object sender, EventArgs e)
        {
           new Form2().Show();
        }

        private void doitButton_Click(object sender, EventArgs e)
        {
            if (label1.Text == "")
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "JSONファイル|*.json";
                if (ofd.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
                if (ofd.FileName == "")
                {
                    return;
                }
                label1.Text = ofd.FileName;
            }
            doitdo(label1.Text);
        }

        private void doitdo(string path)
        {
            System.IO.StreamReader sr = new System.IO.StreamReader(path);
            string jsonStr = sr.ReadToEnd();
            sr.Close();
            JsonNode jsNode = JsonNode.Parse(jsonStr);

            List<List<string>> rslt1 = new List<List<string>>();

            //FreeDive
            foreach (JsonNode diveNode in jsNode["FreeDive"].AsArray())
            {
                List<string> aDive = new List<string>();
                string diveId = (string)diveNode["ID"];
                string diveDate = (string)diveNode["DiveStart"];
                diveDate = diveDate.Substring(6, 4) + "/" + diveDate.Substring(3, 2) + "/" + diveDate.Substring(0, 2) + " " + diveDate.Substring(11, 8);
                aDive.Add(diveDate);
                aDive.Add("FreeDive");
                aDive.Add(diveId);
                foreach (JsonNode profilePointNode in jsNode["FreeProfilePoint"].AsArray())
                {
                    if (((string)profilePointNode["ID_FreeDive"]).Equals(diveId))
                    {
                        aDive.Add((string)profilePointNode["Depth"]);
                    }
                }
                // 日付の新しい順に並べ換える
                bool sorted = false;
                for (int i = 0; i < rslt1.Count; i ++)
                {
                    if (diveDate.CompareTo((rslt1[i])[0]) >= 0)
                    {
                        rslt1.Insert(i, aDive);
                        sorted = true;
                        break;
                    }
                }
                if (!sorted)
                {
                    rslt1.Add(aDive);
                }
            }
            //FreeDive
            foreach (JsonNode diveNode in jsNode["ScubaDive"].AsArray())
            {
                List<string> aDive = new List<string>();
                string diveId = (string)diveNode["ID"];
                string diveDate = (string)diveNode["DiveStart"];
                diveDate = diveDate.Substring(6, 4) + "/" + diveDate.Substring(3, 2) + "/" + diveDate.Substring(0, 2) + " " + diveDate.Substring(11, 8);
                aDive.Add(diveDate);
                aDive.Add("ScubaDive");
                aDive.Add(diveId);
                foreach (JsonNode profilePointNode in jsNode["ScubaProfilePoint"].AsArray())
                {
                    if (((string)profilePointNode["ID_ScubaDive"]).Equals(diveId))
                    {
                        aDive.Add((string)profilePointNode["Depth"]);
                    }
                }
                // 日付の新しい順に並べ換える
                bool sorted = false;
                for (int i = 0; i < rslt1.Count; i++)
                {
                    if (diveDate.CompareTo((rslt1[i])[0]) >= 0)
                    {
                        rslt1.Insert(i, aDive);
                        sorted = true;
                        break;
                    }
                }
                if (!sorted)
                {
                    rslt1.Add(aDive);
                }
            }
            // 行列入れ換えのため、最大行数、最大列数を取得する
            int maxColCount = rslt1.Count;
            int maxRowCount = 0;
            foreach (List<string> ls in rslt1)
            {
                if (maxRowCount < ls.Count)
                {
                    maxRowCount = ls.Count;
                }
            }
            // 行列入れ換え
            string[,] rslt2 = new string[maxRowCount, maxColCount];
            for (int c = 0; c < rslt1.Count; c++)
            {
                for (int r = 0; r < (rslt1[c]).Count; r++)
                {
                    rslt2[r, c] = (rslt1[c])[r];
                }
            }
            // タブ区切りで出力
            StringBuilder sb = new StringBuilder();
            for (int r = 0; r < maxRowCount; r++)
            {
                for (int c = 0; c < maxColCount; c++)
                {
                    sb.Append(rslt2[r, c]);
                    sb.Append("\t");
                }
                sb.Append("\n");
            }

            string fileBase = System.IO.Path.GetFileNameWithoutExtension(path);
            string parentPath = System.IO.Directory.GetParent(path).ToString();
            string outFilePath = parentPath + System.IO.Path.DirectorySeparatorChar + "out_" + fileBase + "_" + System.DateTime.Now.ToString("yyyyMMdd-HHmmss") + ".txt";
            System.IO.StreamWriter sw = new System.IO.StreamWriter(outFilePath, false);
            sw.Write(sb.ToString());
            sw.Close();

            MessageBox.Show("成功");
            label1.Text = "";
        }
    }
}
