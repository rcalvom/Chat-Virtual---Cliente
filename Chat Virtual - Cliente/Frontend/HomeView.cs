using Chat_Virtual___Cliente.Backend;
using Chat_Virtual___Cliente.Communication;
using DataStructures;
using ShippingData;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Chat_Virtual___Cliente.Frontend {
    public partial class HomeView : Form {

        //private MainModel model;
        private bool maximized;
        private bool subprocess;
        private LinkedList<Control> aditionalComponents;

        public HomeView() {
            InitializeComponent();
            //model = new MainModel();
            maximized = false;
            subprocess = true;
            aditionalComponents = new LinkedList<Control>();
            receptor.RunWorkerAsync();
        }

        private void MinButton_Click(object sender, EventArgs e) {
            WindowState = FormWindowState.Minimized;
        }

        private void MinButton_MouseEnter(object sender, EventArgs e) {
            minButtonPanel.BackColor = Color.FromArgb(100, 100, 100);
        }

        private void MinButton_MouseLeave(object sender, EventArgs e) {
            minButtonPanel.BackColor = topPane.BackColor;
        }

        private void ResizeButton_Click(object sender, EventArgs e) {
            if (maximized) {
                WindowState = FormWindowState.Normal;
                resizeButton.Image = global::Chat_Virtual___Cliente.Properties.Resources.Maximize_Window_2_48px;
            } else {
                WindowState = FormWindowState.Maximized;
                resizeButton.Image = global::Chat_Virtual___Cliente.Properties.Resources.Restore_Window_2_48px;
            }
            maximized = !maximized;
        }

        private void ResizeButton_MouseEnter(object sender, EventArgs e) {
            resizeButtonPanel.BackColor = Color.FromArgb(100, 100, 100);
        }

        private void ResizeButton_MouseLeave(object sender, EventArgs e) {
            resizeButtonPanel.BackColor = topPane.BackColor;
        }

        private void ExitButton_Click(object sender, EventArgs e) {
            //model.Disconnect();
            subprocess = false;
            Application.Exit();
        }

        private void ExitButton_MouseEnter(object sender, EventArgs e) {
            closeButtonPanel.BackColor = Color.FromArgb(100, 100, 100);
        }

        private void ExitButton_MouseLeave(object sender, EventArgs e) {
            closeButtonPanel.BackColor = topPane.BackColor;
        }

        private void AddMessage() {

        }
        
        private void Receptor_DoWork(object sender, DoWorkEventArgs e) {
            /*while (subprocess) {
                if (!model.toRead.IsEmpty()) {
                    Data data = model.toRead.Dequeue();

                    if (data is ChatMessage chatMessage) {
                        Console.WriteLine("Sender: " + chatMessage.Sender);
                        Console.WriteLine("Receiver: " + chatMessage.Receiver);
                        Console.WriteLine("Content: " + chatMessage.Content);
                        UserChat receiver = model.chats.Search(chatMessage.Receiver);
                        if (receiver.IsActive)
                            AddMessage();
                        else
                            model.chats.Search(chatMessage.Receiver).messages.Push(chatMessage);
                    } else if (data is GroupMessage groupMessage) {
                        Console.WriteLine("Sender: " + groupMessage.Sender);
                        Console.WriteLine("Id group receiver: " + groupMessage.IdGroupReceiver);
                        Console.WriteLine("Content: " + groupMessage.Content);
                        Group receiver = model.groups.Search(groupMessage.IdGroupReceiver);
                        if (receiver.IsActive)
                            AddMessage();
                        else 
                            receiver.messages.Push(groupMessage);
                    } else if (data is ChatGroup chatGroup) {
                        Group newGroup = new Group(chatGroup.idGroup, chatGroup.name);
                        model.groups.AddElement(newGroup.code, newGroup);
                    } else if (data is Chat chat) {
                        UserChat newChat;
                        if (chat.memberOne.Equals(model.singleton.userName))
                            newChat = new UserChat(chat.memberTwo);
                        else
                            newChat = new UserChat(chat.memberOne);
                        model.chats.AddElement(newChat.member, newChat);
                    } else if(data is RequestAnswer requestAnswer) {

                    } else if (data is RequestError requestError) {

                    }
                }
            }*/
        }

        private void RemoveComponents() {
            while (!aditionalComponents.IsEmpty()) {
                this.Controls.Remove(aditionalComponents.Remove(0));
            }
        }

        private void AddTextBox() {
            bool exist = false;
            ChainNode<Control> c = aditionalComponents.GetNode(0);
            while (c != null) {
                if (c.element.Name.Equals("chatBox")) {
                    exist = true;
                    break;
                }
                c = c.next;
            }
            if (!exist) {
                TextBox chat = new TextBox();
                this.ViewPanel.Controls.Add(chat);
                chat.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
            |   System.Windows.Forms.AnchorStyles.Right)));
                chat.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
                chat.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
                chat.Font = new System.Drawing.Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                chat.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
                chat.ImeMode = System.Windows.Forms.ImeMode.NoControl;
                chat.Name = "chatBox";
                chat.MinimumSize = new System.Drawing.Size(0, 24);
                chat.MaximumSize = new System.Drawing.Size(1000000, 150);
                chat.Size = new System.Drawing.Size(ViewPanel.Width - 50, 35);
                chat.Location = new System.Drawing.Point(6, ViewPanel.Height - 30);
                chat.TabIndex = 0;
                chat.Visible = true;
                chat.Enabled = true;
                aditionalComponents.Add(chat);
                Console.WriteLine("Se creó");
            }
        }

        private void Home_Click(object sender, EventArgs e) {
            RemoveComponents();
        }

        private void Chats_Click(object sender, EventArgs e) {
            RemoveComponents();
            AddTextBox();
        }

        private void Groups_Click(object sender, EventArgs e) {
            RemoveComponents();
        }

        private void Options_Click(object sender, EventArgs e) {
            RemoveComponents();
        }

        private void Chat_Click(object sender, EventArgs e) {
            AddTextBox();
        }

        private void Group_Click(object sender, EventArgs e) {
            AddTextBox();
        }
    }
}
