using System.Windows.Controls;

namespace DoUtDes.UiElements
{
    public partial class UserInfoControl
    {
        public string ContactName { get; set; }
        public string EMail { get; set; }
        public string ImagePath { get; set; }

        public UserInfoControl()
        {
            InitializeComponent();
        }
    }
}
