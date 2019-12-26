using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace Chat_Virtual___Cliente.Frontend { 

    class CircularPictureBox : PictureBox {

        public CircularPictureBox() {
            this.BackColor = Color.Transparent;
        }

        protected override void OnPaint(PaintEventArgs e) {
            base.OnPaint(e);
            using (GraphicsPath gp = new GraphicsPath()) {
                gp.AddEllipse(1, 1, this.Width - 2, this.Height - 2);
                Region = new Region(gp);
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                e.Graphics.DrawEllipse(new Pen(new SolidBrush(this.BackColor), 1), 0, 0, this.Width - 1, this.Height - 1);
            }
        }
    }
}