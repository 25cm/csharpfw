using System.Windows.Forms;

namespace NumberInputKeybord
{
    public class UnSelectableForm : Form
    {
        public UnSelectableForm()
            : base()
        {
            this.SetStyle(ControlStyles.Selectable, false);
        }
    }
}
