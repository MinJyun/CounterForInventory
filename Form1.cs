using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 計數器
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 計數 
        /// </summary>
        private Label[] counter;

        /// <summary>
        /// 品項名稱
        /// </summary>
        private Label[] itemsName;

        /// <summary>
        /// 目錄名稱
        /// </summary>
        private Label[] catalog;

        /// <summary>
        /// 讀取的目錄名稱
        /// </summary>
        private List<string> cataName = new List<string>();

        /// <summary>
        /// 紀錄該目錄名稱在第幾行
        /// </summary>
        private List<int> cataNumber = new List<int>();

        /// <summary>
        /// 加法按鈕功能
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void ButtonsPlus_Click(object sender, EventArgs e)
        {
            int number = int.Parse((sender as Button).Name);
            int count = int.Parse(counter[number].Text);
            count++;
            counter[number].Text = $"{count}";
        }

        /// <summary>
        /// 減法功能
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        void ButtonsMinus_Click(object sender, EventArgs e)
        {
            int number = int.Parse((sender as Button).Name);
            int count = int.Parse(counter[number].Text);
            count--;
            counter[number].Text = $"{count}";
        }

        /// <summary>
        /// 載入檔案按鈕
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //選擇檔案
                OpenFileDialog itemListFile = new OpenFileDialog();
                itemListFile.ShowDialog();
                ShowLoadingPath.Text = itemListFile.FileName;
                List<string> items = LoadFile(ShowLoadingPath.Text);
                int number = items.Count();

                //控制元件的初始設定
                Button[] buttonsPlus = new Button[number];
                Button[] buttonsMinus = new Button[number];
                itemsName = new Label[number];
                counter = new Label[number];
                catalog = new Label[cataName.Count()];

                int front = 0;
                int last = 0;
                //分類數目
                int j = 0;
                foreach (var cata in cataName)
                {
                    front = cataNumber[j];
                    last = cataNumber[j+1];
                    catalog[j] = new Label();
                    catalog[j].Name = "Cata" + j;
                    catalog[j].Text = cata;
                    catalog[j].Location = new Point(10 + 180*j, 60);
                    for (int i = front; i < last; i++)
                    {
                        buttonsPlus[i] = new Button();
                        buttonsPlus[i].Name = $"{i}";
                        buttonsPlus[i].Text = "+";
                        buttonsPlus[i].Location = new Point(100 + 180 * j, 80 + 30 * (i-front));
                        buttonsPlus[i].Width = 25;

                        buttonsMinus[i] = new Button();
                        buttonsMinus[i].Name = $"{i}";
                        buttonsMinus[i].Text = "-";
                        buttonsMinus[i].Location = new Point(125 + 180 * j, 80 + 30 * (i - front));
                        buttonsMinus[i].Width = 25;

                        itemsName[i] = new Label();
                        itemsName[i].Name = "Item" + i;
                        itemsName[i].Text = items[i];
                        itemsName[i].Location = new Point(10 + 180 * j, 85 + 30 * (i - front));

                        counter[i] = new Label();
                        counter[i].Name = "Counter" + i;
                        counter[i].Text = "0";
                        counter[i].Location = new Point(70 + 180 * j, 85 + 30 * (i - front));

                        buttonsPlus[i].Click += new EventHandler(ButtonsPlus_Click);
                        buttonsMinus[i].Click += new EventHandler(ButtonsMinus_Click);
                    }
                    j++;
                }
                this.Controls.AddRange(buttonsPlus);
                this.Controls.AddRange(catalog);
                this.Controls.AddRange(buttonsMinus);
                this.Controls.AddRange(counter);
                this.Controls.AddRange(itemsName);
                showLabel.Text = "讀取完成";
            }
            catch (Exception)
            {
                MessageBox.Show("請選擇正確的檔案");
            }
        }

        // 讀取檔案資料，並且存為類別list的function
        public List<string> LoadFile(string File)
        {
            List<string> items = new List<string>();
            //Loading File
            string everyLine;
            StreamReader file = new StreamReader(@File);
            while ((everyLine = file.ReadLine()) != null)
            {
                if (everyLine.Contains(":"))
                {
                    cataName.Add(everyLine.Replace(":", string.Empty));
                    cataNumber.Add(items.Count());
                }
                else if(everyLine != string.Empty)
                {
                    items.Add(everyLine);
                }
            }
            cataNumber.Add(items.Count());
            return items;
        }

        /// <summary>
        /// 存檔
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OutPutFile_Click(object sender, EventArgs e)
        {
            string docPath = @"D:\";
            //抓取今日時間
            string today = DateTime.Now.ToString("yyyyMMdd");
            string file = $"品項,數量{Environment.NewLine}";
            for(int i = 0; i < itemsName.Count(); i++)
            {
                file = $"{file}{itemsName[i].Text},{counter[i].Text}{Environment.NewLine}";
            }
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(docPath, $"{today}.csv"), false, Encoding.UTF8))
            {
                outputFile.WriteLine(file);
            }
            showLabel.Text = "存檔完成";
        }
    }
}
