using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GlobalMetadataEditor.GUI
{
    class MyTextBoxEventListener
    {
        public Action<string> LostFocus { set; get; }
        public virtual void OnLostFocus(string text)
        {
            LostFocus?.Invoke(text);
        }

    }
}
