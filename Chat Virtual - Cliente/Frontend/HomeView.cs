using Chat_Virtual___Cliente.Backend;
using Chat_Virtual___Cliente.Communication;
using DataStructures;
using ShippingData;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

enum CurrentView {
    InChat, InGroup, InHome, InProfile, None
};

namespace Chat_Virtual___Cliente.Frontend {
    public partial class HomeView : Form {

        private MainModel model;
        private bool maximized;
        private bool subprocess;
        private LinkedList<Control> aditionalComponents;
        private LinkedStack<Panel> messages;
        private CurrentView currentView;

        public HomeView() {
            InitializeComponent();
            model = new MainModel();
            maximized = false;
            subprocess = true;
            aditionalComponents = new LinkedList<Control>();
            messages = new LinkedStack<Panel>();
            this.currentView = CurrentView.InHome;
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
            model.Disconnect();
            subprocess = false;
            Application.Exit();
        }

        private void ExitButton_MouseEnter(object sender, EventArgs e) {
            closeButtonPanel.BackColor = Color.FromArgb(100, 100, 100);
        }

        private void ExitButton_MouseLeave(object sender, EventArgs e) {
            closeButtonPanel.BackColor = topPane.BackColor;
        }
        
        private void Receptor_DoWork(object sender, DoWorkEventArgs e) {
            while (subprocess) {
                if (!model.toRead.IsEmpty()) {
                    Data data = model.toRead.Dequeue();

                    if (data is ChatMessage chatMessage) {
                        Console.WriteLine("Sender: " + chatMessage.Sender);
                        Console.WriteLine("Receiver: " + chatMessage.Receiver);
                        Console.WriteLine("Content: " + chatMessage.Content);
                        UserChat receiver = model.chats.Search(chatMessage.Receiver);
                        if(receiver == default) {
                            
                        }
                        else
                            receiver.messages.Push(chatMessage);
                    } else if (data is GroupMessage groupMessage) {
                        Console.WriteLine("Sender: " + groupMessage.Sender);
                        Console.WriteLine("Id group receiver: " + groupMessage.IdGroupReceiver);
                        Console.WriteLine("Content: " + groupMessage.Content);
                        Group receiver = model.groups.Search(groupMessage.IdGroupReceiver);
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

                if (currentView == CurrentView.InChat) {
                    AddChatMessage(model.chats.Search(model.CurrentChat));
                } else if (currentView == CurrentView.InGroup) {
                    AddGroupMessage(model.groups.Search(model.CurrentGroup));
                }
            }
        }

        private void AddChatMessage(UserChat chat) {
            Panel message = new Panel();
            Label user = new Label();
            Label content = new Label();
            Label time = new Label();
            ChatMessage ms;
            if (!chat.messages.IsEmpty()) {
                ms = chat.messages.Pop();

                this.ViewPanel.Controls.Add(message);
                message.Controls.Add(user);
                message.Controls.Add(content);
                message.Controls.Add(time);
                //user label
                user.AutoSize = true;
                user.Anchor = (AnchorStyles)((AnchorStyles.Top | AnchorStyles.Left) | AnchorStyles.Right);
                user.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                user.ForeColor = Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
                user.Location = new Point(2, 2);
                user.Name = "UserName";
                user.Size = new Size(ViewPanel.Width-4, 18);
                user.TabStop = false;
                user.Text = ms.Sender;
                //content label
                content.AutoSize = true;
                content.Anchor = (AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Left) | AnchorStyles.Right) | AnchorStyles.Bottom);
                content.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                content.ForeColor = Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
                content.Location = new Point(2, 30);
                content.Name = "Content";
                content.Size = new Size(ViewPanel.Width - 4, 20);
                content.TabStop = false;
                content.Text = ms.Content;
                //time label
                time.Anchor = ((AnchorStyles)((AnchorStyles.Bottom | AnchorStyles.Right)));
                time.AutoSize = true;
                time.ForeColor = Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
                time.Name = "Time";
                time.Size = new Size(42, 13);
                time.TabStop = false;
                time.Text = "11:31 am";
                time.Location = new Point(ViewPanel.Width - time.Width - 3, ViewPanel.Height - 16);
                //message panel
                message.BorderStyle = BorderStyle.FixedSingle;
                message.Anchor = (AnchorStyles)(AnchorStyles.Left | AnchorStyles.Right);
                message.Location = new Point(0, 0);
                message.Name = "Message";
                message.Size = new Size(ViewPanel.Width, time.Height + content.Height + user.Height + 20);
                message.TabStop = false;

                messages.Push(message);
            }
            while (!chat.messages.IsEmpty()) {
                ms = chat.messages.Pop();

                message = new Panel();
                user = new Label();
                content = new Label();
                time = new Label();

                this.ViewPanel.Controls.Add(message);
                message.Controls.Add(user);
                message.Controls.Add(content);
                message.Controls.Add(time);
                //user label
                user.AutoSize = true;
                user.Anchor = (AnchorStyles)((AnchorStyles.Top | AnchorStyles.Left) | AnchorStyles.Right);
                user.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                user.ForeColor = Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
                user.Location = new Point(2, 2);
                user.Name = "UserName";
                user.Size = new Size(ViewPanel.Width - 4, 18);
                user.TabStop = false;
                user.Text = ms.Sender;
                //content label
                content.AutoSize = true;
                content.Anchor = (AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Left) | AnchorStyles.Right) | AnchorStyles.Bottom);
                content.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                content.ForeColor = Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
                content.Location = new Point(2, 30);
                content.Name = "Content";
                content.Size = new Size(ViewPanel.Width - 4, 20);
                content.TabStop = false;
                content.Text = ms.Content;
                //time label
                time.Anchor = ((AnchorStyles)((AnchorStyles.Bottom | AnchorStyles.Right)));
                time.AutoSize = true;
                time.ForeColor = Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
                time.Name = "Time";
                time.Size = new Size(42, 13);
                time.TabStop = false;
                time.Text = "11:31 am";
                time.Location = new Point(ViewPanel.Width - time.Width - 3, ViewPanel.Height - 16);
                //message panel
                message.BorderStyle = BorderStyle.FixedSingle;
                message.Anchor = (AnchorStyles)(AnchorStyles.Left | AnchorStyles.Right);
                message.Name = "Message";
                message.Size = new Size(ViewPanel.Width, time.Height + content.Height + user.Height + 20);
                message.Location = new Point(0, messages.Peek().Location.Y + message.Height);
                message.TabStop = false;

                messages.Push(message);
            }
        }

        private void AddGroupMessage(Group chat) {
            Panel message = new Panel();
            Label user = new Label();
            Label content = new Label();
            Label time = new Label();
            GroupMessage ms;
            if (!chat.messages.IsEmpty()) {
                ms = chat.messages.Pop();

                this.ViewPanel.Controls.Add(message);
                message.Controls.Add(user);
                message.Controls.Add(content);
                message.Controls.Add(time);
                //user label
                user.AutoSize = true;
                user.Anchor = (AnchorStyles)((AnchorStyles.Top | AnchorStyles.Left) | AnchorStyles.Right);
                user.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                user.ForeColor = Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
                user.Location = new Point(2, 2);
                user.Name = "UserName";
                user.Size = new Size(ViewPanel.Width - 4, 18);
                user.TabStop = false;
                user.Text = ms.Sender;
                //content label
                content.AutoSize = true;
                content.Anchor = (AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Left) | AnchorStyles.Right) | AnchorStyles.Bottom);
                content.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                content.ForeColor = Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
                content.Location = new Point(2, 30);
                content.Name = "Content";
                content.Size = new Size(ViewPanel.Width - 4, 20);
                content.TabStop = false;
                content.Text = ms.Content;
                //time label
                time.Anchor = ((AnchorStyles)((AnchorStyles.Bottom | AnchorStyles.Right)));
                time.AutoSize = true;
                time.ForeColor = Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
                time.Name = "Time";
                time.Size = new Size(42, 13);
                time.TabStop = false;
                time.Text = "11:31 am";
                time.Location = new Point(ViewPanel.Width - time.Width - 3, ViewPanel.Height - 16);
                //message panel
                message.BorderStyle = BorderStyle.FixedSingle;
                message.Anchor = (AnchorStyles)(AnchorStyles.Left | AnchorStyles.Right);
                message.Location = new Point(0, 0);
                message.Name = "Message";
                message.Size = new Size(ViewPanel.Width, time.Height + content.Height + user.Height + 20);
                message.TabStop = false;

                messages.Push(message);
            }
            while (!chat.messages.IsEmpty()) {
                ms = chat.messages.Pop();

                message = new Panel();
                user = new Label();
                content = new Label();
                time = new Label();

                this.ViewPanel.Controls.Add(message);
                message.Controls.Add(user);
                message.Controls.Add(content);
                message.Controls.Add(time);
                //user label
                user.AutoSize = true;
                user.Anchor = (AnchorStyles)((AnchorStyles.Top | AnchorStyles.Left) | AnchorStyles.Right);
                user.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                user.ForeColor = Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
                user.Location = new Point(2, 2);
                user.Name = "UserName";
                user.Size = new Size(ViewPanel.Width - 4, 18);
                user.TabStop = false;
                user.Text = ms.Sender;
                //content label
                content.AutoSize = true;
                content.Anchor = (AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Left) | AnchorStyles.Right) | AnchorStyles.Bottom);
                content.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                content.ForeColor = Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
                content.Location = new Point(2, 30);
                content.Name = "Content";
                content.Size = new Size(ViewPanel.Width - 4, 20);
                content.TabStop = false;
                content.Text = ms.Content;
                //time label
                time.Anchor = ((AnchorStyles)((AnchorStyles.Bottom | AnchorStyles.Right)));
                time.AutoSize = true;
                time.ForeColor = Color.FromArgb(((int)(((byte)(200)))), ((int)(((byte)(200)))), ((int)(((byte)(200)))));
                time.Name = "Time";
                time.Size = new Size(42, 13);
                time.TabStop = false;
                time.Text = "11:31 am";
                time.Location = new Point(ViewPanel.Width - time.Width - 3, ViewPanel.Height - 16);
                //message panel
                message.BorderStyle = BorderStyle.FixedSingle;
                message.Anchor = (AnchorStyles)(AnchorStyles.Left | AnchorStyles.Right);
                message.Name = "Message";
                message.Size = new Size(ViewPanel.Width, time.Height + content.Height + user.Height + 20);
                message.Location = new Point(0, messages.Peek().Location.Y + message.Height);
                message.TabStop = false;

                messages.Push(message);
            }
        }

        private void RemoveComponents() {
            while (!aditionalComponents.IsEmpty()) {
                Control c = aditionalComponents.Remove(0);
                this.Controls.Remove(c);
                this.ViewPanel.Controls.Remove(c);
                this.descriptionPanel.Controls.Remove(c);
                this.actionPanel.Controls.Remove(c);
            }
            if (currentView == CurrentView.InChat) {
                ChatMessage ms;
                UserChat uc = model.chats.Search(model.CurrentChat);
                while (!messages.IsEmpty()) {
                    ms = new ChatMessage();
                    Panel p = messages.Pop();
                    foreach (Control c in p.Controls) {
                        if (c is Label l) {
                            if (l.Name.Equals("UserName")) {
                                ms.Sender = l.Text;
                            } else if (l.Name.Equals("Content")) {
                                ms.Content = l.Text;
                            } else if (l.Name.Equals("Time")) {

                            }
                        }
                    }
                    if (ms.Sender.Equals(model.singleton.userName)) {
                        ms.Receiver = uc.member;
                    } else {
                        ms.Receiver = model.singleton.userName;
                    }
                    uc.messages.Push(ms);
                }
            } else if (currentView == CurrentView.InGroup) {
                GroupMessage ms;
                Group group = model.groups.Search(model.CurrentGroup);
                while (!messages.IsEmpty()) {
                    ms = new GroupMessage(group.code);
                    Panel p = messages.Pop();
                    foreach (Control c in p.Controls) {
                        if (c is Label l) {
                            if (l.Name.Equals("UserName")) {
                                ms.Sender = l.Text;
                            } else if (l.Name.Equals("Content")) {
                                ms.Content = l.Text;
                            } else if (l.Name.Equals("Time")) {

                            }
                        }
                    }
                    group.messages.Push(ms);
                }
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
                PictureBox sendButton = new PictureBox();
                this.ViewPanel.Controls.Add(chat);
                this.ViewPanel.Controls.Add(sendButton);
                chat.Anchor = ((AnchorStyles)(((AnchorStyles.Bottom | AnchorStyles.Left) | AnchorStyles.Right)));
                chat.BackColor = Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
                chat.BorderStyle = BorderStyle.FixedSingle;
                chat.Font = new Font("Microsoft Sans Serif", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
                chat.ForeColor = Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
                chat.ImeMode = ImeMode.NoControl;
                chat.Name = "chatBox";
                chat.MinimumSize = new Size(0, 24);
                chat.MaximumSize = new Size(1000000, 150);
                chat.Size = new Size(ViewPanel.Width - 50, 35);
                chat.Location = new Point(6, ViewPanel.Height - 30);
                chat.TabIndex = 1;
                chat.Multiline = true;
                chat.TabStop = true;
                chat.Visible = true;
                chat.Enabled = true;

                sendButton.BackColor = Color.Transparent;
                //sendButton.Image = ;
                sendButton.Cursor = Cursors.Hand;
                sendButton.Anchor = (AnchorStyles)(AnchorStyles.Bottom | AnchorStyles.Right);
                sendButton.Location = new Point(this.ViewPanel.Width-41, this.ViewPanel.Height-30);
                sendButton.Name = "SendButton";
                sendButton.TabStop = false;
                sendButton.Size = new Size(35, 35);
                sendButton.SizeMode = PictureBoxSizeMode.StretchImage;
                sendButton.Click += new EventHandler(this.Send_Click);

                aditionalComponents.Add(chat);
                aditionalComponents.Add(sendButton);
            }
        }

        private void Home_Click(object sender, EventArgs e) {
            RemoveComponents();
            currentView = CurrentView.InHome;
        }

        private void Chats_Click(object sender, EventArgs e) {
            RemoveComponents();
            currentView = CurrentView.None;
            if (model.chats.IsEmpty()) {
                Label l = new Label();
                this.actionPanel.Controls.Add(l);
                aditionalComponents.Add(l);

                l.Text = "Aún no tienes ningún chat";
                l.Size = new Size(actionPanel.Width-6, 20);
                l.TextAlign = ContentAlignment.MiddleCenter;
                l.Anchor = (AnchorStyles)((AnchorStyles.Left | AnchorStyles.Right) | AnchorStyles.Top);
                l.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                l.ForeColor = Color.FromArgb(200, 200, 200);
                l.AutoSize = false;
                l.Location = new Point(3, 3);
            } else {
                LinkedList<UserChat> chats = model.chats.GetAll();
                Panel lastPanel = null;
                while (!chats.IsEmpty()) {
                    UserChat c = chats.Remove(0);
                    Panel newPanel = new Panel();
                    PictureBox photo = new PictureBox();
                    Label user = new Label();
                    this.actionPanel.Controls.Add(newPanel);
                    newPanel.Controls.Add(photo);
                    newPanel.Controls.Add(user);

                    //panel
                    if (lastPanel == null)
                        newPanel.Location = new Point(0, 0);
                    else
                        newPanel.Location = new Point(0, lastPanel.Height+lastPanel.Location.Y);
                    newPanel.Size = new Size(actionPanel.Width, 50);
                    newPanel.Anchor = (AnchorStyles)(AnchorStyles.Left | AnchorStyles.Right);
                    newPanel.BackColor = Color.Transparent;
                    newPanel.Name = c.member;
                    newPanel.TabStop = false;
                    newPanel.MouseEnter += new EventHandler(Chat_MouseEnter(newPanel));
                    newPanel.MouseLeave += new EventHandler(Chat_MouseLeave(newPanel));
                    newPanel.Click += new EventHandler(Chat_MouseEnter(newPanel));

                    //pictureBox
                    photo.Size = new Size(40, 40);
                    photo.SizeMode = PictureBoxSizeMode.StretchImage;
                    //photo.Image = c.photo;
                    photo.Location = new Point(10, 10);
                    photo.TabStop = false;

                    //label
                    user.Text = c.member;
                    user.Location = new Point(50, 10);
                    user.Size = new Size(newPanel.Width-60, 20);
                    user.Anchor = (AnchorStyles)(AnchorStyles.Left | AnchorStyles.Right);
                    user.BackColor = Color.Transparent;
                    user.ForeColor = Color.FromArgb(200, 200, 200);
                    user.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));

                    aditionalComponents.Add(newPanel);
                    lastPanel = newPanel;
                }
            }
        }

        private void Groups_Click(object sender, EventArgs e) {
            RemoveComponents();
            currentView = CurrentView.None;
            if (model.groups.IsEmpty()) {
                Label l = new Label();
                this.actionPanel.Controls.Add(l);
                aditionalComponents.Add(l);

                l.Size = new Size(actionPanel.Width - 6, 20);
                l.TextAlign = ContentAlignment.MiddleCenter;
                l.Anchor = (AnchorStyles)((AnchorStyles.Left | AnchorStyles.Right) | AnchorStyles.Top);
                l.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                l.ForeColor = Color.FromArgb(200, 200 ,200);
                l.AutoSize = true;
                l.Location = new Point(3, 3);
                l.Text = "Aún no tienes ningún grupo";
            } else {
                LinkedList<Group> groups = model.groups.GetAll();
                Panel lastPanel = null;
                while (!groups.IsEmpty()) {
                    Group c = groups.Remove(0);
                    Panel newPanel = new Panel();
                    PictureBox photo = new PictureBox();
                    Label user = new Label();
                    this.actionPanel.Controls.Add(newPanel);
                    newPanel.Controls.Add(photo);
                    newPanel.Controls.Add(user);

                    //panel
                    if (lastPanel == null)
                        newPanel.Location = new Point(0, 0);
                    else
                        newPanel.Location = new Point(0, lastPanel.Height + lastPanel.Location.Y);
                    newPanel.Size = new Size(actionPanel.Width, 50);
                    newPanel.Anchor = (AnchorStyles)(AnchorStyles.Left | AnchorStyles.Right);
                    newPanel.BackColor = Color.Transparent;
                    newPanel.Name = c.code.ToString();
                    newPanel.TabStop = false;
                    newPanel.MouseEnter += new EventHandler(Chat_MouseEnter(newPanel));
                    newPanel.MouseLeave += new EventHandler(Chat_MouseLeave(newPanel));
                    newPanel.Click += new EventHandler(Chat_MouseEnter(newPanel));

                    //pictureBox
                    photo.Size = new Size(40, 40);
                    photo.SizeMode = PictureBoxSizeMode.StretchImage;
                    //photo.Image = c.photo;
                    photo.Location = new Point(10, 10);
                    photo.TabStop = false;

                    //label
                    user.Text = c.name;
                    user.Location = new Point(50, 10);
                    user.Size = new Size(newPanel.Width - 60, 20);
                    user.Anchor = (AnchorStyles)(AnchorStyles.Left | AnchorStyles.Right);
                    user.BackColor = Color.Transparent;
                    user.ForeColor = Color.FromArgb(200, 200, 200);
                    user.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));

                    aditionalComponents.Add(newPanel);
                    lastPanel = newPanel;
                }
            }
        }

        private void Options_Click(object sender, EventArgs e) {
            RemoveComponents();
            currentView = CurrentView.InProfile;
        }

        private EventHandler Chat_Click(Panel sender) {
            AddTextBox();
            currentView = CurrentView.InChat;
            model.CurrentChat = sender.Name;
            return default;
        }

        private EventHandler Group_Click(Panel sender) {
            AddTextBox();
            currentView = CurrentView.InGroup;
            model.CurrentGroup = int.Parse(sender.Name);
            return default;
        }

        private void Send_Click(object sender, EventArgs e) {
            string content = "";
            ChainNode<Control> c = aditionalComponents.GetNode(0);
            while (c!=null) {
                if (c.element.Name.Equals("chatBox")) {
                    if(c.element is TextBox tx) {
                        content = tx.Text;
                        tx.Clear();
                    }
                }
            }
            if (currentView == CurrentView.InChat) {
                ChatMessage ms = new ChatMessage();
                ms.Sender = model.singleton.userName;
                ms.Receiver = model.CurrentChat;
                ms.Content = content;
                model.toWrite.Enqueue(ms);
            } else if (currentView == CurrentView.InGroup) {
                GroupMessage ms = new GroupMessage(model.CurrentGroup, model.singleton.userName, content);
                model.toWrite.Enqueue(ms);
            }
        }


        private EventHandler Chat_MouseEnter(Panel newPanel) {
            newPanel.BackColor = Color.FromArgb(100, 100, 100);
            return default;
        }

        private EventHandler Chat_MouseLeave(Panel newPanel) {
            newPanel.BackColor = Color.Transparent;
            return default;
        }
    }
}
