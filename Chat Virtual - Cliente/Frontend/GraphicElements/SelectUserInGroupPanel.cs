using System;
using System.Drawing;
using System.Windows.Forms;

namespace Chat_Virtual___Cliente.Frontend {
    public class SelectUserInGroupPanel : Panel {

        public bool Selected { get; private set; }
        private int Displacement;

        public SelectUserInGroupPanel(int Displacement) {
            this.Displacement = Displacement;
        }

        public void Create(ShippingData.Profile profile, int i) {
            CircularPictureBox photo = new CircularPictureBox();
            Label user = new Label();
            Label status = new Label();
            int size = 200;
            this.Controls.Add(photo);
            this.Controls.Add(user);
            this.Controls.Add(status);

            //panel
            this.Cursor = Cursors.Hand;
            this.Size = new Size(this.Parent.Width-size, 50);
            this.Anchor = (AnchorStyles)(AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom); ;
            this.Location = new Point(size/2, Displacement + (this.Size.Height * i));
            this.BorderStyle = BorderStyle.None;
            this.BackColor = Color.Transparent;
            this.TabStop = false;
            this.Name = profile.Name;
            this.Click += new EventHandler(Mouse_Click);
            this.MouseEnter += new EventHandler(Mouse_Enter);
            this.MouseLeave += new EventHandler(Mouse_Leave);

            //pictureBox
            photo.Cursor = Cursors.Hand;
            photo.Size = new Size(40, 40);
            photo.Location = new Point(5, 5);
            photo.SizeMode = PictureBoxSizeMode.StretchImage;
            if(profile.Image != null)
                photo.Image = ShippingData.Serializer.DeserializeImage(profile.Image);
            photo.Click += new EventHandler(Mouse_Click);
            photo.MouseEnter += new EventHandler(Mouse_Enter);
            photo.MouseLeave += new EventHandler(Mouse_Leave);

            //label user
            user.Cursor = Cursors.Hand;
            user.AutoSize = false;
            user.Name = "User";
            user.Size = new Size(this.Width - 60, 20);
            user.Location = new Point(50, 6);
            user.Anchor = (AnchorStyles)(AnchorStyles.Left | AnchorStyles.Right);
            user.Text = profile.Name;
            user.TextAlign = ContentAlignment.MiddleLeft;
            user.BackColor = Color.Transparent;
            user.ForeColor = Color.FromArgb(200, 200, 200);
            user.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            user.Click += new EventHandler(Mouse_Click);
            user.MouseEnter += new EventHandler(Mouse_Enter);
            user.MouseLeave += new EventHandler(Mouse_Leave);

            //lastMessage
            status.Cursor = Cursors.Hand;
            status.AutoSize = false;
            status.Size = new Size(this.Width - 60, 20);
            status.Location = new Point(50, 25);
            status.Anchor = (AnchorStyles)(AnchorStyles.Left | AnchorStyles.Right);
            status.Text = profile.Status;
            status.TextAlign = ContentAlignment.MiddleLeft;
            status.BackColor = Color.Transparent;
            status.ForeColor = Color.FromArgb(200, 200, 200);
            status.Font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            status.Name = "Status";
            status.AutoEllipsis = true;
            status.Click += new EventHandler(Mouse_Click);
            status.MouseEnter += new EventHandler(Mouse_Enter);
            status.MouseLeave += new EventHandler(Mouse_Leave);
        }

        private void Mouse_Enter(object Sender, EventArgs e) {
            if (Sender is Panel panel && !this.Selected) {
                this.BackColor = Color.FromArgb(120, 60, 60, 64);
            } else if (Sender is Control control) {
                Mouse_Enter(control.Parent, e);
            }
        }

        private void Mouse_Leave(object Sender, EventArgs e) {
            if(Sender is Panel panel && !this.Selected) {
                this.BackColor = Color.Transparent;
            } else if (Sender is Control control) {
                Mouse_Leave(control.Parent, e);
            }
        }

        private void Mouse_Click(object Sender, EventArgs e) {
            if (Sender is Panel panel) {
                if (this.Selected) {
                    this.Selected = false;
                    this.BackColor = Color.Transparent;
                } else {
                    this.Selected = true;
                    this.BackColor = Color.FromArgb(60, 60, 64);
                }
            } else if (Sender is Control control) {
                Mouse_Click(control.Parent, e);
            }
        }
    }
}
