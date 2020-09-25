using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
        private MetadataFile file;
        private string filePath;
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
            this.editableListView.Height = this.Height - 110;
            int columnSize = (this.editableListView.Width - 114) / 2;
            this.original.Width = columnSize;
            this.replace.Width = columnSize;
            //搜索栏尺寸
            int textBoxWidth = listViewWidth - 225;
            this.textBox1.Width = textBoxWidth;
            this.button1.Location = new Point(textBoxWidth + 15, 25);
            this.button2.Location = new Point(textBoxWidth + 75, 25);
            this.letterCase.Location = new Point(textBoxWidth + 140, 29);
            this.wholeWord.Location = new Point(textBoxWidth + 200, 29);
            
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
                ReadDataToList(sender, e);
            }
        }

        private void ReadDataToList(object sender, EventArgs e)
        {
            ThreadPool.QueueUserWorkItem(delegate {
                try
                {
                    CloseFile(sender, e);
                    filePath = openFileDialog1.FileName;
                    file = new MetadataFile(filePath);
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

        private void SaveFile(object sender, EventArgs e)
        {
            if(file == null)
            {
                return;
            }
            MessageBoxButtons messageBoxButtons = MessageBoxButtons.OKCancel;
            DialogResult result = MessageBox.Show("该操作无法撤回！", "注意！", messageBoxButtons);
            if (result == DialogResult.OK)
            {
                List<byte[]> byteList = GetModifyByteList();
                ThreadPool.QueueUserWorkItem(delegate
                {
                    string tempFile = filePath + ".temp";
                    file.WriteToNewFile(tempFile, byteList);
                    file?.Dispose();
                    File.Delete(filePath);
                    FileInfo info = new FileInfo(tempFile);
                    info.MoveTo(filePath);
                    ReadDataToList(sender, e);
                });
            }
            

        }

        private void SaveAs(object sender, EventArgs e)
        {
            if (file == null)
            {
                return;
            }
            List<byte[]> byteList = GetModifyByteList();
            if (saveFileDialog1.ShowDialog(this) == DialogResult.OK)
            {
                ThreadPool.QueueUserWorkItem(delegate
                {
                    file.WriteToNewFile(saveFileDialog1.FileName, byteList);
                });
            }
        }

        private List<byte[]> GetModifyByteList()
        {
            List<byte[]> byteList = new List<byte[]>();
            List<string> stringlist = new List<string>();
            for (int i = 0; i < this.editableListView.Items.Count; i++)
            {
                string originaltext = this.editableListView.Items[i].SubItems[1].Text;
                string replacetext = this.editableListView.Items[i].SubItems[2].Text;
                if (replacetext.Equals(""))
                {
                    stringlist.Add(originaltext);
                    byteList.Add(Encoding.UTF8.GetBytes(originaltext));
                    continue;
                }
                byteList.Add(Encoding.UTF8.GetBytes(replacetext));
                stringlist.Add(replacetext);

            }
            return byteList;
        }

        private void CloseFile(object sender, EventArgs e)
        {
            file?.Dispose();
            Invoke(new Action(delegate { this.editableListView.Items.Clear(); }));
        }

        private void OnNextButtonClick(object sender, EventArgs e)
        {
            string text = this.textBox1.Text;
            if (text == "")
            {
                return;
            }
            int index = this.editableListView.SelectedIndices.Count > 0 ? this.editableListView.SelectedIndices[0] : -1;
            int listCount = this.editableListView.Items.Count;
            for (int i=0;i<listCount-index-1;i++)
            {
                var item = this.editableListView.Items[i+index+1];
                if (CompareString(text,item.SubItems[1].Text))
                {
                    this.editableListView.Focus();
                    item.Selected = true;
                    item.EnsureVisible();
                    this.toolStripStatusLabel1.Text = String.Format("已找到字符串：{0}", text);
                    return;
                }
            }
            this.editableListView.SelectedIndices.Clear();
            this.toolStripStatusLabel1.Text = String.Format("未能找到字符串：{0}，指针回到列表头部", text);
        }

        private bool CompareString(string value,string text)
        {
            if (!this.letterCase.Checked && !this.wholeWord.Checked)
            {
                return text.ToLower().Contains(value.ToLower());
            }
            else if (this.letterCase.Checked && !this.wholeWord.Checked)
            {
                return text.Contains(value);
            }
            else if (!this.letterCase.Checked && this.wholeWord.Checked)
            {
                string pattern = String.Format(@"\b{0}\b", value);
                return Regex.Match(text, pattern,RegexOptions.IgnoreCase).Length != 0;
            }
            else
            {
                string pattern = String.Format(@"\b{0}\b", value);
                return Regex.Match(text, pattern).Length != 0;
            }
        }

        private void OnPreButtonClick(object sender, EventArgs e)
        {
            string text = this.textBox1.Text;
            if (text == "")
            {
                return;
            }
            int listCount = this.editableListView.Items.Count;
            int index = this.editableListView.SelectedIndices.Count > 0 ? this.editableListView.SelectedIndices[0] : listCount;
            for (int i = 0; i<index; i++)
            {
                var item = this.editableListView.Items[index-i-1];
                if (CompareString(text, item.SubItems[1].Text))
                {
                    this.editableListView.Focus();
                    item.Selected = true;
                    item.EnsureVisible();
                    this.toolStripStatusLabel1.Text = String.Format("已找到字符串：{0}", text);
                    return;
                }
            }
            this.editableListView.SelectedIndices.Clear();
            this.toolStripStatusLabel1.Text = String.Format("未能找到字符串：{0}，指针回到列表头部", text);
        }

    }
}
