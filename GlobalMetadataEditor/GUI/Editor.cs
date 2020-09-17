using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GlobalMetadataEditor.GUI
{
    public partial class Editor : Form
    {
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
            this.checkBox1.Location = new Point(textBoxWidth + 80, 29);
            this.checkBox2.Location = new Point(textBoxWidth + 150, 29);
            
        }
        protected override void OnSizeChanged(EventArgs e)
        {
            base.OnSizeChanged(e);
            ResetSize();
        }


    }
}
