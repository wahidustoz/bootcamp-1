using Microsoft.AspNetCore.Components;
using webapp.Components;
using webapp.Models;

namespace webapp.Pages
{
    public partial class Index : ComponentBase
    {
        private Button One;
        private Button Two;
        private string InputValue { get; set; } = string.Empty;
        
        protected override void OnInitialized()
        {
            
        }

        protected override void OnAfterRender(bool firstRender)
        {
            One.ButtonClicked += ButtonClicked;
            Two.ButtonClicked += ButtonClicked;
        }

        private void ButtonClicked(object sender, ButtonClickedEventArgs e)
        {
            InputValue = $"{e.ButtonType}: {e.Value}";
        }
    }
}