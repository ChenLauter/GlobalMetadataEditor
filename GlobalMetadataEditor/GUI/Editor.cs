using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GlobalMetadataEditor.GUI
{
    public partial class Editor : Form
    {
        enum SearchMode
        {
            IgnoreCase,//忽略大小写，默认
            Sensitive,//大小写
            WholeWordIgnoreCase,//整词匹配，忽略大小写
            WholeWordSensitive//整词大小写
        }
        private MetadataFile file;
        public Editor()
        {
            InitializeComponent();
            ResetSize();
            
        }

        private void ResetSize()
        {
            //设置listview列尺寸
            int listViewWidth = this.Width - 40;
            this.editableListView.Width = listViewWidth;
            this.editableListView.Height = this.Height - 100;
            int columnSize = (this.editableListView.Width - 114) / 2;
            this.original.Width = columnSize;
            this.replace.Width = columnSize;
            //搜索栏尺寸
            int textBoxWidth = listViewWidth - 185;
            this.textBox1.Width = textBoxWidth;
            this.button1.Location = new Point(textBoxWidth + 15, 25);
            this.letterCase.Location = new Point(textBoxWidth + 80, 29);
            this.wholeWord.Location = new Point(textBoxWidth + 150, 29);
            
        }
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            ResetSize();
        }

        private void AddItemToListView(List<string> list)
        {
            this.editableListView.BeginUpdate();
            for (int i = 0; i < list.Count; i++)
            {
                ListViewItem item = new ListViewItem(i + 1 + "");
                item.SubItems.Add(list[i]);
                item.SubItems.Add("");
                item.SubItems.Add("");
                this.editableListView.Items.Add(item);
            }
            this.editableListView.EndUpdate();
        }



        private void OpenFile(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                ThreadPool.QueueUserWorkItem(delegate {
                    try
                    {
                        CloseFile(sender,e);
                        file = new MetadataFile(openFileDialog1.FileName);
                        Invoke(new Action<List<string>>(AddItemToListView), file.stringList);

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                        file?.Dispose();
                        file = null;
                    }
                });
            }
        }

        private void SaveFile(object sender, EventArgs e)
        {

        }

        private void SaveAs(object sender, EventArgs e)
        {
            List<byte[]> byteList = new List<byte[]>();
            List<string> stringlist = new List<string>();
            for (int i = 0; i < this.editableListView.Items.Count; i++)
            {
                string originaltext = this.editableListView.Items[i].SubItems[1].Text;
                string replacetext = this.editableListView.Items[i].SubItems[2].Text;
                //Console.WriteLine(originaltext);
                //Console.WriteLine(replacetext);
                if (replacetext.Equals(""))
                {
                    stringlist.Add(originaltext);
                    byteList.Add(Encoding.UTF8.GetBytes(originaltext));
                    continue;
                }
                byteList.Add(Encoding.UTF8.GetBytes(replacetext));
                stringlist.Add(replacetext);
                
            }
            foreach(string item in stringlist){
                Console.WriteLine(item);
            }
            if (saveFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                ThreadPool.QueueUserWorkItem(delegate
                {
                    file.WriteToNewFile(saveFileDialog1.FileName, byteList);
                });
            }
        }

        private void CloseFile(object sender, EventArgs e)
        {
            file?.Dispose();
            Invoke(new Action(delegate { this.editableListView.Items.Clear(); }));
        }

        private void OnButtonClick(object sender, EventArgs e)
        {
            string text = this.textBox1.Text;
            if (!this.letterCase.Checked && !this.wholeWord.Checked)
            {
                Console.WriteLine(SearchMode.IgnoreCase);
                Console.WriteLine("appleApple".Contains(text));
            }
            else if (this.letterCase.Checked && !this.wholeWord.Checked)
            {
                Console.WriteLine(SearchMode.Sensitive);
            }
            else if (!this.letterCase.Checked && this.wholeWord.Checked)
            {
                Console.WriteLine(SearchMode.WholeWordIgnoreCase);
            }
            else
            {
                Console.WriteLine(SearchMode.WholeWordSensitive);
            }
            
            Console.WriteLine();
            
        }

        private bool CompareString(SearchMode mode,string pattern,string text)
        {
            if (mode.Equals(SearchMode.IgnoreCase))
            {
                return false;
            }
            else if (mode.Equals(SearchMode.Sensitive))
            {
                return text.Contains(pattern);
            }
            else if (mode.Equals(SearchMode.WholeWordIgnoreCase))
            {
                return false;
            }
            else if (mode.Equals(SearchMode.WholeWordSensitive))
            {
                return false;
            }
            else
            {
                return false;
            }
        }

    }
}
