using System;

namespace webapp.Models
{
    public class ButtonClickedEventArgs : EventArgs
    {
        public EButtonType ButtonType { get; set; }
        public int Value = -1;
    }
}