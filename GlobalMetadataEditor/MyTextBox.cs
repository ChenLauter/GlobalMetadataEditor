using System;
using System.Windows.Forms;

namespace GlobalMetadataEditor
{
    class MyTextBox : TextBox
    {
        private MyTextBoxEventListener mListener;
        public void SetOnEventListener(MyTextBoxEventListener listener)
        {
            this.mListener = listener;
        }


        protected override void OnLostFocus(EventArgs e)
        {
            mListener.OnLostFocus(Text);
            base.OnLostFocus(e);
        }

        protected override void OnKeyDown(KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                mListener.OnLostFocus(Text);
                
            }
            base.OnKeyDown(e);
        }




    }
}
