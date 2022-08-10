using System;
using System.Drawing;
using System.Windows.Forms;

namespace LanguagePlayer
{
    public class MyLabel : Label
    {

        protected override void OnPaint(PaintEventArgs e)
        {
            //base.OnPaint(e);
            //TextRenderer.DrawText(e.Graphics, this.Text.ToString(), this.Font, ClientRectangle, ForeColor);

            //Rectangle rc = this.ClientRectangle;
            //StringFormat fmt = new StringFormat(StringFormat.GenericTypographic);
            using (var br = new SolidBrush(this.ForeColor))
            {
                //e.Graphics.DrawString(this.Text, this.Font, br, rc, fmt);
                e.Graphics.DrawString(this.Text, this.Font, br, 0, 0);
            }

        }
    }
}
