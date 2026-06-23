using System.Windows.Forms;

namespace MyDaniel
{
    public partial class AccessDeniedPanel : UserControl
    {
        public AccessDeniedPanel()
        {
            InitializeComponent();
        }

        private void btn_back_Click(object sender, System.EventArgs e)
        {
            MainForm.showPanel(new HomePanel());
        }
    }
}
