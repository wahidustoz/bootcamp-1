using System;
using Microsoft.AspNetCore.Components;
using webapp.Models;

namespace webapp.Components
{
    public partial class Button : ComponentBase
    {
        [Parameter]
        public string Content { get; set; } = "1";

        [Parameter]
        public string CssClass { get; set; } = "col-3";

        public delegate void ButtonClickedEventHandler(object sender, ButtonClickedEventArgs e);
        
        public event ButtonClickedEventHandler ButtonClicked;

        protected virtual void OnClick(string value)
        {
            var args = value switch 
            {
                "1" => new ButtonClickedEventArgs() { Value = 1, ButtonType = EButtonType.Digit },
                "2" => new ButtonClickedEventArgs() { Value = 2, ButtonType = EButtonType.Digit },
                "3" => new ButtonClickedEventArgs() { Value = 3, ButtonType = EButtonType.Digit },
                "4" => new ButtonClickedEventArgs() { Value = 4, ButtonType = EButtonType.Digit },
                "5" => new ButtonClickedEventArgs() { Value = 5, ButtonType = EButtonType.Digit },
                "6" => new ButtonClickedEventArgs() { Value = 6, ButtonType = EButtonType.Digit },
                "7" => new ButtonClickedEventArgs() { Value = 7, ButtonType = EButtonType.Digit },
                "8" => new ButtonClickedEventArgs() { Value = 8, ButtonType = EButtonType.Digit },
                "9" => new ButtonClickedEventArgs() { Value = 9, ButtonType = EButtonType.Digit },
                "0" => new ButtonClickedEventArgs() { Value = 0, ButtonType = EButtonType.Digit },
                "+" => new ButtonClickedEventArgs() { ButtonType = EButtonType.Plus },
                "-" => new ButtonClickedEventArgs() { ButtonType = EButtonType.Minus },
                "x" => new ButtonClickedEventArgs() { ButtonType = EButtonType.Multiply },
                "/" => new ButtonClickedEventArgs() { ButtonType = EButtonType.Divide },
                "AC" => new ButtonClickedEventArgs() { ButtonType = EButtonType.Clear },
                "<-" => new ButtonClickedEventArgs() { ButtonType = EButtonType.Back },
                "." => new ButtonClickedEventArgs() { ButtonType = EButtonType.Point },
                "%" => new ButtonClickedEventArgs() { ButtonType = EButtonType.Percent },
                "=" => new ButtonClickedEventArgs() { ButtonType = EButtonType.Equal },
                _ => throw new ArgumentException($"Button value is wrong: {value}")
            };

            ButtonClicked?.Invoke(this, args);
        }
    }
}