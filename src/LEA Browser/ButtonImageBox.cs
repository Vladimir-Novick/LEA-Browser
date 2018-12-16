using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace LEA_Browser
{
    public partial class ButtonImageBox : PictureBox
    {

        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
        public virtual Image EnableImage { get; set; }

        [Browsable(true), EditorBrowsable(EditorBrowsableState.Always)]
        public virtual Image DisableImage { get; set; }

        public ButtonImageBox() : base()
        {
            InitializeComponent();
        }

        protected override void OnMouseEnter(EventArgs e)
        {
            base.OnMouseEnter(e);
            if (this.Enabled)
                base.Cursor = Cursors.Hand;
        }

        protected override void OnEnabledChanged(EventArgs e)
        {
            base.OnEnabledChanged(e);
            if (this.Enabled)
            {
                this.Image = EnableImage;
            }
            else
            {
                this.Image = DisableImage;
            }
        }

        protected override void OnMouseLeave(EventArgs e)

        {
            base.OnMouseLeave(e);
            if (this.Enabled)
                base.Cursor = Cursors.Default;
        }

        protected override void OnClick(EventArgs e)
        {
            if (this.Enabled)
                 base.OnClick(e);
        }
    }
}
