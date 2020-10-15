using System;
using System.Drawing;
using System.Windows.Forms;
using static System.Windows.Forms.ListViewItem;

namespace GlobalMetadataEditor
{
    class EditableListView : ListView
    {
        public MyTextBox textBox;
        private Point point;
        private MyTextBoxEventListener listener;
        public EditableListView() : base()
        {
            textBox = new MyTextBox
            {
                Visible = false,
                AutoSize = false,
                Height = 16,
                
            };
            listener = new MyTextBoxEventListener();
            textBox.SetOnEventListener(listener);
            this.Controls.Add(this.textBox);
        }

        protected override void OnMouseDown(MouseEventArgs e)
        {
            GetListViewFocus();
            base.OnMouseDown(e);
        }

        private void GetListViewFocus()
        {
            point = this.PointToClient(Control.MousePosition);
            ListViewItem item = this.GetItemAt(point.X, point.Y);
            if (item != null)
            {
                ListViewSubItem subItem = item.GetSubItemAt(point.X, point.Y);
                if (subItem != null)
                {
                    if (item.SubItems.IndexOf(subItem) == 2)
                    {
                        textBox.Text = subItem.Text;
                        textBox.Bounds = subItem.Bounds;
                        textBox.Visible = true;
                        //失去焦点时，把内容传给listview
                        listener.LostFocus = (string text) =>
                        {
                            this.Focus();
                            subItem.Text = text;
                            textBox.Clear();
                            this.textBox.Visible = false;
                            if (!text.Equals(""))
                            {
                                item.SubItems[3].Text = "*";
                            }
                            else
                            {
                                item.SubItems[3].Text = "";
                            }
                        };

                    }
                    if (item.SubItems.IndexOf(subItem) == 1)
                    {
                        Clipboard.SetText(subItem.Text);
                    }
                }
                return;
            }
            ToHideTextBox();
        }


        private void ToHideTextBox()
        {
            textBox.Clear();
            textBox.Visible = false;

        }

        protected override void OnSizeChanged(EventArgs e)
        {
            if (textBox.Visible)
            {
                textBox.Bounds = this.SelectedItems[0].SubItems[2].Bounds;
            }
            base.OnSizeChanged(e);
        }

        protected override void OnMouseWheel(MouseEventArgs e)
        {
            //让textbox跟列表一起滑动
            if (textBox.Visible)
            {
                Rectangle rectangle = this.SelectedItems[0].SubItems[2].Bounds;
                if(e.Delta < 0)
                {
                    int showItemCount = (int)(this.Height / 16.5f) - 2;
                    if(this.TopItem.Index == this.Items.Count - showItemCount)
                    {
                        return;
                    }
                    textBox.Bounds = new Rectangle(rectangle.X, rectangle.Y - 48, rectangle.Width, rectangle.Height);
                }
                else
                {
                    if (this.TopItem.Index == 0)
                    {
                        return;
                    }
                    textBox.Bounds = new Rectangle(rectangle.X, rectangle.Y + 48, rectangle.Width, rectangle.Height);
                }
            }
            base.OnMouseWheel(e);
        }
    }
}
