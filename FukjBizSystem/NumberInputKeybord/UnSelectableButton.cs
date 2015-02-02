using System.ComponentModel;
using System.Windows.Forms;
namespace NumberInputKeybord
{
    public class UnSelectableButton : Button
    {
        public UnSelectableButton()
        : base()
        {
            this.SetStyle(ControlStyles.Selectable, false);
        }

        public UnSelectableButton(IContainer container)
            : base()
        {
            container.Add(this);

            SetStyle(ControlStyles.Selectable, false);
        }
    }
}
