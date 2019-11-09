using Chat_Virtual___Cliente.Backend;
using Chat_Virtual___Cliente.Communication;
using DataStructures;
using ShippingData;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

enum CurrentView {
    InChat, InGroup, InHome, InProfile, ViewChats, ViewGroups
};

namespace Chat_Virtual___Cliente.Frontend {
    public partial class HomeView : Form {

        private bool maximized;
        private bool subprocess;
        private MainModel model;
        private ShippingData.Message FirstMessage;
        private Panel LastGroup;
        private Panel LastChat;
        private CurrentView currentView;
        private LinkedList<Control> AditionalComponents;
        private LinkedStack<Panel> RecentMessages;
        private LinkedStack<Panel> OldMessages;

        public HomeView() {
            InitializeComponent();
            model = new MainModel();
            maximized = false;
            subprocess = true;
            AditionalComponents = new LinkedList<Control>();
            RecentMessages = OldMessages = new LinkedStack<Panel>();
            LastChat = LastChat = null;
            FirstMessage = null;
            this.currentView = CurrentView.InHome;
            receptor.RunWorkerAsync();
        }

        //Estado: Listo
        private void MinButton_Click(object sender, EventArgs e) {
            WindowState = FormWindowState.Minimized;
        }

        //Estado: Listo
        private void MinButton_MouseEnter(object sender, EventArgs e) {
            minButtonPanel.BackColor = Color.FromArgb(100, 100, 100);
        }

        //Estado: Listo
        private void MinButton_MouseLeave(object sender, EventArgs e) {
            minButtonPanel.BackColor = topPane.BackColor;
        }

        //Estado: Listo
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

        //Estado: Listo
        private void ResizeButton_MouseEnter(object sender, EventArgs e) {
            resizeButtonPanel.BackColor = Color.FromArgb(100, 100, 100);
        }

        //Estado: Listo
        private void ResizeButton_MouseLeave(object sender, EventArgs e) {
            resizeButtonPanel.BackColor = topPane.BackColor;
        }

        //Estado: Listo
        private void ExitButton_Click(object sender, EventArgs e) {
            model.Disconnect();
            subprocess = false;
            Application.Exit();
        }

        //Estado: Listo
        private void ExitButton_MouseEnter(object sender, EventArgs e) {
            closeButtonPanel.BackColor = Color.FromArgb(100, 100, 100);
        }

        //Estado: Listo
        private void ExitButton_MouseLeave(object sender, EventArgs e) {
            closeButtonPanel.BackColor = topPane.BackColor;
        }
        

        //Subproceso encargado de recibir los mensajes dados por el servidor
        //Estado: Pendiente
        private void Receptor_DoWork(object sender, DoWorkEventArgs e) {
            while (subprocess) {
                model.CanRead.WaitOne();
                bool emptyQueue = model.toRead.IsEmpty();
                model.CanRead.Release();
                if (!emptyQueue) {
                    model.CanRead.WaitOne();
                    Data data = model.toRead.Dequeue();
                    model.CanRead.Release();
                    if (data is ShippingData.Message) {
                        if (data is ChatMessage chatMessage) {
                            Console.WriteLine("Sender: " + chatMessage.Sender);
                            Console.WriteLine("Receiver: " + chatMessage.Receiver);
                            Console.WriteLine("Content: " + chatMessage.Content);
                            UserChat receiver = model.chats.Search(chatMessage.Receiver);
                            if (receiver == default) {
                                //Hay que crear el nuevo chat
                            } else
                                receiver.NewMessages.Enqueue(chatMessage);
                        } else if (data is GroupMessage groupMessage) {
                            Console.WriteLine("Sender: " + groupMessage.Sender);
                            Console.WriteLine("Id group receiver: " + groupMessage.IdGroupReceiver);
                            Console.WriteLine("Content: " + groupMessage.Content);
                            Group receiver = model.groups.Search(groupMessage.IdGroupReceiver);
                            receiver.NewMessages.Enqueue(groupMessage);
                        }
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

        //Estado: Listo
        private void RemoveMessages() {
            FirstMessage = null;
            if (currentView == CurrentView.InChat) {
                ChatMessage ms;
                UserChat uc = model.chats.Search(model.CurrentChat);
                while (!RecentMessages.IsEmpty()) {
                    ms = new ChatMessage();
                    Panel p = RecentMessages.Pop();
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
                    this.ViewPanel.Controls.Remove(p);
                }
                while (!OldMessages.IsEmpty()) {
                    Panel p = OldMessages.Pop();
                    this.ViewPanel.Controls.Remove(p);
                }
            } else if (currentView == CurrentView.InGroup){ 
                GroupMessage gm;
                Group group = model.groups.Search(model.CurrentGroup);
                while (!RecentMessages.IsEmpty()) {
                    gm = new GroupMessage(group.code);
                    Panel p = RecentMessages.Pop();
                    foreach (Control c in p.Controls) {
                        if (c is Label l) {
                            if (l.Name.Equals("UserName")) {
                                gm.Sender = l.Text;
                            } else if (l.Name.Equals("Content")) {
                                gm.Content = l.Text;
                            } else if (l.Name.Equals("Time")) {

                            }
                        }
                    }
                    group.messages.Push(gm);
                    this.ViewPanel.Controls.Remove(p);
                }
                while (!OldMessages.IsEmpty()) {
                    Panel p = OldMessages.Pop();
                    this.ViewPanel.Controls.Remove(p);
                }
            }
        }

        //Estado: Listo
        private void RemoveComponents() {
            LastChat = LastGroup = null;
            while (!AditionalComponents.IsEmpty()) {
                Control c = AditionalComponents.Remove(0);
                this.ViewPanel.Controls.Remove(c);
                this.descriptionPanel.Controls.Remove(c);
                this.InfoPanel.Controls.Remove(c);
            }
            RemoveMessages();
        }

        //Estado: Listo
        private void AddChatBox() {
            bool exist = false;
            ChainNode<Control> c = AditionalComponents.GetNode(0);
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

                AditionalComponents.Add(chat);
                AditionalComponents.Add(sendButton);
            }
        }

        //Estado: Listo
        private void AddChatSearchElements() {
            Panel NewChatPanel = new Panel();
            Label NewChatLabel = new Label();
            TextBox NewChatTextBox = new TextBox();
            this.InfoPanel.Controls.Add(NewChatPanel);

            NewChatPanel.Location = new Point(0, 0);
            NewChatPanel.Size = new Size(actionPanel.Width, InfoPanel.Height);
            NewChatPanel.BackColor = Color.Transparent;
            NewChatPanel.Anchor = (AnchorStyles)(AnchorStyles.Left | AnchorStyles.Top);
            NewChatPanel.BorderStyle = BorderStyle.FixedSingle;
            NewChatPanel.Controls.Add(NewChatLabel);
            NewChatPanel.Controls.Add(NewChatTextBox);

            NewChatLabel.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            NewChatLabel.ForeColor = Color.FromArgb(220, 220, 220);
            NewChatLabel.Location = new Point(5, 5);
            NewChatLabel.Size = new Size(actionPanel.Width-10, 18);
            NewChatLabel.Text = "Busca o inicia un nuevo chat";

            NewChatTextBox.Anchor = (AnchorStyles)(AnchorStyles.Top | AnchorStyles.Left);
            NewChatTextBox.BackColor = Color.FromArgb(64, 64, 64);
            NewChatTextBox.BorderStyle = BorderStyle.FixedSingle;
            NewChatTextBox.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            NewChatTextBox.ForeColor = Color.FromArgb(224, 224, 224);
            NewChatTextBox.ImeMode = ImeMode.NoControl;
            NewChatTextBox.Name = "NewChat";
            NewChatTextBox.Size = new Size(NewChatPanel.Width - 10, 20);
            NewChatTextBox.Location = new Point(5, 28);
            NewChatTextBox.TabIndex = 2;
            NewChatTextBox.Multiline = false;
            NewChatTextBox.TabStop = true;
            AditionalComponents.Add(NewChatPanel);
        }

        //Estado: Pendiente
        private void Home_Click(object sender, EventArgs e) {
            RemoveComponents();
            currentView = CurrentView.InHome;
        }

        //Estado: Listo
        private void Chats_Click(object sender, EventArgs e) {
            RemoveComponents();
            AddChatSearchElements();
            currentView = CurrentView.ViewChats;
            if (model.chats.IsEmpty()) {
                Label l = new Label();
                this.actionPanel.Controls.Add(l);
                AditionalComponents.Add(l);

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
                while (!chats.IsEmpty()) {
                    UserChat c = chats.Remove(0);
                    AddChat(c);
                }
            }
        }

        //Estado: Listo
        private void Groups_Click(object sender, EventArgs e) {
            RemoveComponents();
            AddChatSearchElements();
            currentView = CurrentView.ViewGroups;
            if (model.groups.IsEmpty()) {
                Label l = new Label();
                this.actionPanel.Controls.Add(l);
                AditionalComponents.Add(l);

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
                while (!groups.IsEmpty()) {
                    Group c = groups.Remove(0);
                    AddGroup(c);
                }
            }
        }

        //Estado: Pendiente
        private void Options_Click(object sender, EventArgs e) {
            RemoveComponents();
            currentView = CurrentView.InProfile;
            Profile profile = new Profile();
            profile.Show();
        }

        //Estado: Listo
        private void Send_Click(object sender, EventArgs e) {
            string content = "";
            ChainNode<Control> c = AditionalComponents.GetNode(0);
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
                model.CanWrite.WaitOne();
                model.toWrite.Enqueue(ms);
                model.CanWrite.Release();
            } else if (currentView == CurrentView.InGroup) {
                GroupMessage ms = new GroupMessage(model.CurrentGroup, model.singleton.userName, content);
                model.CanWrite.WaitOne();
                model.toWrite.Enqueue(ms);
                model.CanWrite.Release();
            }
        }

        //Estado: Listo
        private EventHandler Chat_Click(Panel sender) {
            AddChatBox();
            currentView = CurrentView.InChat;
            model.CurrentChat = sender.Name;
            return default;
        }

        //Estado: Listo
        private EventHandler Group_Click(Panel sender) {
            AddChatBox();
            currentView = CurrentView.InGroup;
            model.CurrentGroup = int.Parse(sender.Name);
            return default;
        }

        //Estado: Creo que falta un delegado
        private EventHandler Chat_MouseEnter(Panel newPanel) {
            newPanel.BackColor = Color.FromArgb(100, 100, 100);
            return default;
        }

        //Estado: Creo que falta un delegado
        private EventHandler Chat_MouseLeave(Panel newPanel) {
            newPanel.BackColor = Color.Transparent;
            return default;
        }

        private void AddChatMessage(UserChat chat) {
            Panel message = new Panel();
            Label user = new Label();
            Label content = new Label();
            Label time = new Label();
            ChatMessage ms;
            if (!chat.NewMessages.IsEmpty()) {
                ms = chat.NewMessages.Dequeue();
            } else if (!chat.messages.IsEmpty()) {
                ms = chat.messages.Pop();
            } else {
                return;
            }
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
            time.Text = ms.Hour.ToString();
            time.Location = new Point(ViewPanel.Width - time.Width - 3, ViewPanel.Height - 16);
            //message panel
            message.BorderStyle = BorderStyle.FixedSingle;
            message.Anchor = (AnchorStyles)(AnchorStyles.Left | AnchorStyles.Right);
            message.Name = "Message";
            message.Size = new Size(ViewPanel.Width, time.Height + content.Height + user.Height + 20);
            message.TabStop = false;
            if (FirstMessage == null) {
                FirstMessage = ms;
                message.Location = new Point(0, 0);
            } else {
                if (ms.date.Year < FirstMessage.date.Year) {
                    message.Location = new Point(0, OldMessages.Peek().Location.Y - message.Height);
                    OldMessages.Push(message);
                } else if (ms.date.Year > FirstMessage.date.Year) {
                    message.Location = new Point(0, RecentMessages.Peek().Location.Y + message.Height);
                    RecentMessages.Push(message);
                } else if (ms.date.Month < ms.date.Month) {
                    message.Location = new Point(0, OldMessages.Peek().Location.Y - message.Height);
                    OldMessages.Push(message);
                } else if (ms.date.Month > ms.date.Month) {
                    message.Location = new Point(0, RecentMessages.Peek().Location.Y + message.Height);
                    RecentMessages.Push(message);
                } else if (ms.date.Day < ms.date.Day) {
                    message.Location = new Point(0, OldMessages.Peek().Location.Y - message.Height);
                    OldMessages.Push(message);
                } else if (ms.date.Day > ms.date.Day) {
                    message.Location = new Point(0, RecentMessages.Peek().Location.Y + message.Height);
                    RecentMessages.Push(message);
                } else if (ms.Hour < ms.Hour) {
                    message.Location = new Point(0, OldMessages.Peek().Location.Y - message.Height);
                    OldMessages.Push(message);
                } else {
                    message.Location = new Point(0, RecentMessages.Peek().Location.Y + message.Height);
                    RecentMessages.Push(message);
                }
            }
        }

        private void AddGroupMessage(Group chat) {
            Panel message = new Panel();
            Label user = new Label();
            Label content = new Label();
            Label time = new Label();
            GroupMessage ms;
            if (!chat.NewMessages.IsEmpty()) {
                ms = chat.NewMessages.Dequeue();
            } else if (!chat.messages.IsEmpty()) {
                ms = chat.messages.Pop();
            } else {
                return;
            }
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
            time.Text = ms.Hour.ToString();
            time.Location = new Point(ViewPanel.Width - time.Width - 3, ViewPanel.Height - 16);
            //message panel
            message.BorderStyle = BorderStyle.FixedSingle;
            message.Anchor = (AnchorStyles)(AnchorStyles.Left | AnchorStyles.Right);
            message.Name = "Message";
            message.Size = new Size(ViewPanel.Width, time.Height + content.Height + user.Height + 20);
            message.TabStop = false;
            if (FirstMessage == null) {
                FirstMessage = ms;
                message.Location = new Point(0, 0);
            } else {
                if (ms.date.Year < FirstMessage.date.Year) {
                    message.Location = new Point(0, OldMessages.Peek().Location.Y - message.Height);
                    OldMessages.Push(message);
                } else if (ms.date.Year > FirstMessage.date.Year) {
                    message.Location = new Point(0, RecentMessages.Peek().Location.Y + message.Height);
                    RecentMessages.Push(message);
                } else if (ms.date.Month < ms.date.Month) {
                    message.Location = new Point(0, OldMessages.Peek().Location.Y - message.Height);
                    OldMessages.Push(message);
                } else if (ms.date.Month > ms.date.Month) {
                    message.Location = new Point(0, RecentMessages.Peek().Location.Y + message.Height);
                    RecentMessages.Push(message);
                } else if (ms.date.Day < ms.date.Day) {
                    message.Location = new Point(0, OldMessages.Peek().Location.Y - message.Height);
                    OldMessages.Push(message);
                } else if (ms.date.Day > ms.date.Day) {
                    message.Location = new Point(0, RecentMessages.Peek().Location.Y + message.Height);
                    RecentMessages.Push(message);
                } else if (ms.Hour < ms.Hour) {
                    message.Location = new Point(0, OldMessages.Peek().Location.Y - message.Height);
                    OldMessages.Push(message);
                } else {
                    message.Location = new Point(0, RecentMessages.Peek().Location.Y + message.Height);
                    RecentMessages.Push(message);
                }
            }
        }

        /// <summary>
        /// Añade un panel con la informacion del chat en el ActionPanel
        /// </summary>
        /// <param name="c">El chat que se va a agregar</param>
        /// Estado: Listo
        private void AddChat(UserChat c) {
            Panel newPanel = new Panel();
            PictureBox photo = new PictureBox();
            Label user = new Label();
            this.actionPanel.Controls.Add(newPanel);
            newPanel.Controls.Add(photo);
            newPanel.Controls.Add(user);

            //panel
            if (LastChat == null)
                newPanel.Location = new Point(0, 0);
            else
                newPanel.Location = new Point(0, LastChat.Height + LastChat.Location.Y);
            newPanel.Size = new Size(actionPanel.Width, 50);
            newPanel.Anchor = (AnchorStyles)(AnchorStyles.Left | AnchorStyles.Right);
            newPanel.BackColor = Color.Transparent;
            newPanel.Name = c.member;
            newPanel.TabStop = false;
            newPanel.MouseEnter += new EventHandler(Chat_MouseEnter(newPanel));
            newPanel.MouseLeave += new EventHandler(Chat_MouseLeave(newPanel));
            newPanel.Click += new EventHandler(Chat_Click(newPanel));

            //pictureBox
            photo.Size = new Size(40, 40);
            photo.SizeMode = PictureBoxSizeMode.StretchImage;
            //photo.Image = c.photo;
            photo.Location = new Point(10, 10);
            photo.TabStop = false;

            //label
            user.Text = c.member;
            user.Location = new Point(50, 10);
            user.Size = new Size(newPanel.Width - 60, 20);
            user.Anchor = (AnchorStyles)(AnchorStyles.Left | AnchorStyles.Right);
            user.BackColor = Color.Transparent;
            user.ForeColor = Color.FromArgb(200, 200, 200);
            user.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));

            AditionalComponents.Add(newPanel);
            LastChat = newPanel;
        }

        /// <summary>
        /// Añade un panel con la información del grupo en el ActionPanel
        /// </summary>
        /// <param name="c">La información del grupo que se va a gregar</param>
        /// Estado: Listo
        private void AddGroup(Group c) {
            Panel newPanel = new Panel();
            PictureBox photo = new PictureBox();
            Label user = new Label();
            this.actionPanel.Controls.Add(newPanel);
            newPanel.Controls.Add(photo);
            newPanel.Controls.Add(user);

            //panel
            if (LastGroup == null)
                newPanel.Location = new Point(0, 0);
            else
                newPanel.Location = new Point(0, LastGroup.Height + LastGroup.Location.Y);
            newPanel.Size = new Size(actionPanel.Width, 50);
            newPanel.Anchor = (AnchorStyles)(AnchorStyles.Left | AnchorStyles.Right);
            newPanel.BackColor = Color.Transparent;
            newPanel.Name = c.code.ToString();
            newPanel.TabStop = false;
            newPanel.MouseEnter += new EventHandler(Chat_MouseEnter(newPanel));
            newPanel.MouseLeave += new EventHandler(Chat_MouseLeave(newPanel));
            newPanel.Click += new EventHandler(Group_Click(newPanel));

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

            AditionalComponents.Add(newPanel);
            LastGroup = newPanel;
        }

        private void TopPane_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ActionPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}