using System;
using System.Drawing;
using System.Windows.Forms;
using static System.Windows.Forms.ListViewItem;

namespace GlobalMetadataEditor.GUI
{
    class EditableListView : ListView
    {
        private TextBox textBox;
        private Point point;
        public EditableListView() : base()
        {
            this.LabelEdit = false;
            textBox = new TextBox();
            textBox.Visible = false;
            textBox.AutoSize = false;
            textBox.Height = 16;
            this.Controls.Add(this.textBox);
            
            for (int i = 0;i < 10; i++)
            {
                ListViewItem item = new ListViewItem(i+1+"");
                item.SubItems.Add("1");
                item.SubItems.Add("");
                item.SubItems.Add("");
                this.Items.Add(item);
            }
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            point = this.PointToClient(Control.MousePosition);
            ListViewItem item = this.GetItemAt(point.X, point.Y);
            if(item != null)
            {
                ListViewSubItem subItem =  item.GetSubItemAt(point.X, point.Y);
                if(subItem != null)
                {
                    if(item.SubItems.IndexOf(subItem) == 2)
                    {
                        textBox.Clear();
                        textBox.Bounds = subItem.Bounds;
                        textBox.Visible = true;
                    }
                }
                return;
            }
            ToHideTextBox();
            base.OnMouseDown(e);
            
        }

        private void ToHideTextBox()
        {
            textBox.Clear();
            textBox.Visible = false;

        }

        protected override void OnSizeChanged(EventArgs e)
        {
            textBox.Visible = false;
            base.OnSizeChanged(e);
        }



    }
}
