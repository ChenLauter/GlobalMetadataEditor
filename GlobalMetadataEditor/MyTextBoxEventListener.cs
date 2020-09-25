using System;

namespace GlobalMetadataEditor
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
