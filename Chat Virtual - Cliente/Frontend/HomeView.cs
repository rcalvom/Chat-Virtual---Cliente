﻿using Chat_Virtual___Cliente.Backend;
using Chat_Virtual___Cliente.Communication;
using DataStructures;
using ShippingData;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

struct ControlParameters {
    //General
    public Size size;
    public AnchorStyles anchor;
    public Point position;
    //Para panel
    public BorderStyle borderStyle;
    //Para picture box
    public Image image;
    public PictureBoxSizeMode pictureBoxSizeMode;
    //Para label
    public string text;
};

enum CurrentView {
    InChat, InGroup, InHome, InProfile, ViewChats, ViewGroups
};

namespace Chat_Virtual___Cliente.Frontend {
    public partial class HomeView : Form {

        private bool maximized;
        private bool subprocess;
        private MainModel model;
        private ShippingData.Message FirstMessage;
        private CurrentView currentView;
        private LinkedList<Control> AditionalComponents;
        private LinkedStack<Panel> RecentMessages;
        private LinkedStack<Panel> OldMessages;

        private DynamicArray<Panel> ActiveChats;

        private delegate void AddIn(Control toAdd, Control In);
        private delegate void DeleteIn(Control toAdd, Control In);
        private delegate void CopyParametersOf(Control controlOne, ControlParameters controlTwo);
        private delegate void ChangeImageOf(PictureBox pb, Image image);

        public HomeView() {
            InitializeComponent();
            model = new MainModel();
            maximized = false;
            subprocess = true;
            AditionalComponents = new LinkedList<Control>();
            RecentMessages = OldMessages = new LinkedStack<Panel>();
            ActiveChats = new DynamicArray<Panel>();
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

        //Estado: Listo
        private void RemoveComponents() {
            while (!AditionalComponents.IsEmpty()) {
                Control c = AditionalComponents.Remove(0);
                this.ViewPanel.Controls.Remove(c);
                this.descriptionPanel.Controls.Remove(c);
                this.InfoPanel.Controls.Remove(c);
                this.actionPanel.Controls.Remove(c);
            }
            RemoveMessages();
        }

        //Estado: Pendiente
        private void Home_Click(object sender, EventArgs e) {
            RemoveComponents();
            RemoveActiveChats();
            currentView = CurrentView.InHome;
        }

        //Estado: Listo
        private void Chats_Click(object sender, EventArgs e) {
            RemoveComponents();
            RemoveActiveChats();
            AddChatSearchElements();
            currentView = CurrentView.ViewChats;
        }

        //Estado: Listo
        private void Groups_Click(object sender, EventArgs e) {
            RemoveComponents();
            RemoveActiveChats();
            AddChatSearchElements();
            currentView = CurrentView.ViewGroups;
        }

        //Estado: Pendiente
        private void Options_Click(object sender, EventArgs e) {
            RemoveComponents();
            RemoveActiveChats();
            currentView = CurrentView.InProfile;
            Profile profile = new Profile();
            profile.ShowDialog();
        }

        private void Settings_Click(object sender, EventArgs e) {
            
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
                        break;
                    }
                }
            }
            if (currentView == CurrentView.InChat) {
                ChatMessage ms = new ChatMessage();
                ms.Sender = model.singleton.userName;
                ms.Receiver = model.CurrentChat;
                ms.Content = content;
                model.ToWriteEnqueue(ms);
            } else if (currentView == CurrentView.InGroup) {
                GroupMessage ms = new GroupMessage(model.CurrentGroup, model.singleton.userName, content);
                model.ToWriteEnqueue(ms);
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
            NewChatLabel.Size = new Size(actionPanel.Width - 10, 18);
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
            NewChatTextBox.KeyPress += new KeyPressEventHandler(Search_Chat);
            AditionalComponents.Add(NewChatPanel);
        }

        private void Search_Chat(object sender, KeyPressEventArgs e) {
            string a = "";
            if (e.KeyChar == (int)Keys.Enter) {
                if (sender is TextBox t) {
                    a = t.Text;
                    t.Clear();
                }
                model.ToWriteEnqueue(new Chat(model.singleton.userName, a));
            }
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
                chat.BackColor = Color.FromArgb(64, 64, 64);
                chat.BorderStyle = BorderStyle.FixedSingle;
                chat.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
                chat.ForeColor = Color.FromArgb(224, 224, 224);
                chat.ImeMode = ImeMode.NoControl;
                chat.Name = "chatBox";
                chat.MinimumSize = new Size(0, 24);
                chat.Size = new Size(ViewPanel.Width - 50, 25);
                chat.Location = new Point(6, ViewPanel.Height - 30);
                chat.TabIndex = 1;
                chat.Multiline = true;
                chat.TabStop = true;
                chat.Visible = true;
                chat.Enabled = true;

                sendButton.BackColor = Color.Transparent;
                sendButton.Image = Properties.Resources.SendIcon;
                sendButton.Cursor = Cursors.Hand;
                sendButton.Anchor = (AnchorStyles)(AnchorStyles.Bottom | AnchorStyles.Right);
                sendButton.Location = new Point(this.ViewPanel.Width - 41, this.ViewPanel.Height - 30);
                sendButton.Name = "SendButton";
                sendButton.TabStop = false;
                sendButton.Size = new Size(25, 25);
                sendButton.SizeMode = PictureBoxSizeMode.StretchImage;
                sendButton.Click += new EventHandler(this.Send_Click);

                AditionalComponents.Add(chat);
                AditionalComponents.Add(sendButton);
            }
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
            AddControl(message, ViewPanel);
            AddControl(user, message);
            AddControl(content, message);
            AddControl(time, message);
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
            time.Text = ms.date.Hour.ToString();
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
                } else if (ms.date.Hour < ms.date.Hour) {
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
            AddControl(message, ViewPanel);
            AddControl(user, message);
            AddControl(content, message);
            AddControl(time, message);
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
            time.Text = ms.date.Hour.ToString();
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
                } else if (ms.date.Hour < ms.date.Hour) {
                    message.Location = new Point(0, OldMessages.Peek().Location.Y - message.Height);
                    OldMessages.Push(message);
                } else {
                    message.Location = new Point(0, RecentMessages.Peek().Location.Y + message.Height);
                    RecentMessages.Push(message);
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
                        ms.Receiver = uc.profile.Name;
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
            } else if (currentView == CurrentView.InGroup) {
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

        /// <summary>
        /// Añade un panel con la informacion del chat en el ActionPanel
        /// </summary>
        /// <param name="c">El chat que se va a agregar</param>
        /// Estado: Listo
        private void AddChat(UserChat c, int i) {
            Panel newPanel = new Panel();
            PictureBox photo = new PictureBox();
            Label user = new Label();
            AddControl(newPanel, actionPanel);
            AddControl(photo, newPanel);
            AddControl(user, newPanel);

            //panel
            ControlParameters cp = new ControlParameters();
            cp.size = new Size(actionPanel.Width, 50);
            cp.anchor = (AnchorStyles)(AnchorStyles.Left | AnchorStyles.Right); ;
            cp.position = new Point(0, newPanel.Height * i);
            cp.borderStyle = BorderStyle.FixedSingle;
            CopyParameters(newPanel, cp);
            newPanel.BackColor = Color.Transparent;
            newPanel.Name = c.profile.Name;
            newPanel.TabStop = false;
            newPanel.MouseEnter += new EventHandler(Chat_MouseEnter);
            newPanel.MouseLeave += new EventHandler(Chat_MouseLeave);
            newPanel.Click += new EventHandler(Chat_Click);

            //pictureBox
            cp = new ControlParameters();
            cp.size = new Size(40, 40);
            cp.position = new Point(10, 10);
            cp.pictureBoxSizeMode = PictureBoxSizeMode.StretchImage;
            if (c.profile.Image != null) {
                cp.image = Serializer.DeserializeImage(c.profile.Image);
            }
            CopyParameters(photo, cp);

            //label
            cp = new ControlParameters();
            cp.size = new Size(newPanel.Width - 60, 20);
            cp.position = new Point(50, 10);
            cp.anchor = (AnchorStyles)(AnchorStyles.Left | AnchorStyles.Right);
            cp.text = c.profile.Name;
            CopyParameters(user, cp);
            user.BackColor = Color.Transparent;
            user.ForeColor = Color.FromArgb(200, 200, 200);
            user.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));

            c.visible = true;
            ActiveChats.Add(newPanel);
        }

        /// <summary>
        /// Añade un panel con la información del grupo en el ActionPanel
        /// </summary>
        /// <param name="c">La información del grupo que se va a gregar</param>
        /// Estado: Listo
        private void AddGroup(Group c, int i) {
            Panel newPanel = new Panel();
            PictureBox photo = new PictureBox();
            Label group = new Label();
            AddControl(newPanel, actionPanel);
            AddControl(photo, newPanel);
            AddControl(group, newPanel);
 
            newPanel.Size = new Size(actionPanel.Width, 50);
            newPanel.Anchor = (AnchorStyles)(AnchorStyles.Left | AnchorStyles.Right);
            newPanel.BackColor = Color.Transparent;
            newPanel.Name = c.code.ToString();
            newPanel.TabStop = false;
            newPanel.MouseEnter += new EventHandler(Chat_MouseEnter);
            newPanel.MouseLeave += new EventHandler(Chat_MouseLeave);
            newPanel.Click += new EventHandler(Group_Click);
            newPanel.Location = new Point(0, newPanel.Height*i);

            //pictureBox
            photo.Size = new Size(40, 40);
            photo.SizeMode = PictureBoxSizeMode.StretchImage;
            //photo.Image = c.photo;
            photo.Location = new Point(10, 10);
            photo.TabStop = false;

            //label
            group.Text = c.name;
            group.Location = new Point(50, 10);
            group.Size = new Size(newPanel.Width - 60, 20);
            group.Anchor = (AnchorStyles)(AnchorStyles.Left | AnchorStyles.Right);
            group.BackColor = Color.Transparent;
            group.ForeColor = Color.FromArgb(200, 200, 200);
            group.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));

            c.visible = true;
            ActiveChats.Add(newPanel);
        }

        private void ManagmentChat() {
            if (!(currentView == CurrentView.InChat || currentView == CurrentView.ViewChats)) {
                return;
            } else if (model.chats.IsEmpty()) {
                if (ActiveChats.IsEmpty()) {
                    Panel p = new Panel();
                    Label l = new Label();
                    AddControl(p, actionPanel);
                    ActiveChats.Add(p);

                    l.Text = "Aún no tienes ningún chat";
                    l.Size = new Size(actionPanel.Width - 6, 20);
                    l.TextAlign = ContentAlignment.MiddleCenter;
                    l.Anchor = (AnchorStyles)((AnchorStyles.Left | AnchorStyles.Right) | AnchorStyles.Top);
                    l.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                    l.ForeColor = Color.FromArgb(200, 200, 200);
                    l.AutoSize = false;
                    l.Location = new Point(0, 0);

                    AddControl(l, p);
                    ControlParameters cp = new ControlParameters();
                    cp.position = new Point(3, 3);
                    cp.anchor = (AnchorStyles)((AnchorStyles.Left | AnchorStyles.Right) | AnchorStyles.Top);
                    cp.size = l.Size;
                    CopyParameters(p, cp);
                    p.Name = "EmptyChat";
                    p.BackColor = Color.Transparent;
                    return;
                }
            } else {
                if (ActiveChats.Size>=2) {
                    Panel p = ActiveChats.Get(0);
                    if (p.Name.Equals("EmptyChat")) {
                        DeleteControl(p, actionPanel);
                        ActiveChats.RemoveElement(p);
                    }

                }
            }
            Iterator<UserChat> i = model.chats.GetAll().Iterator();
            int count = 0;
            while (i.HasNext()) {
                UserChat c = i.Next();
                if (!c.visible) {
                    AddChat(c, count);
                }
                if (c.profile.Image == null) {
                    UserChat userChat = model.chats.Search(c.profile.Name);
                    if (userChat != default)
                        if (userChat.profile.Image == null)
                            continue;
                    foreach (Control control in ActiveChats.Get(count).Controls) {
                        if(control is PictureBox picture) {
                            picture.Image = Serializer.DeserializeImage(userChat.profile.Image);
                        }
                    }
                }
                count++;
            }
        }

        private void ManagmentGroup() {
            if (!(currentView == CurrentView.InChat || currentView == CurrentView.ViewChats)) {
                return;
            } else if (model.groups.IsEmpty()) {
                if (ActiveChats.IsEmpty()) {
                    Panel p = new Panel();
                    Label l = new Label();
                    AddControl(l, actionPanel);
                    ActiveChats.Add(p);

                    l.Text = "Aún no tienes ningún grupo";
                    l.Size = new Size(actionPanel.Width - 6, 20);
                    l.TextAlign = ContentAlignment.MiddleCenter;
                    l.Anchor = (AnchorStyles)((AnchorStyles.Left | AnchorStyles.Right) | AnchorStyles.Top);
                    l.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                    l.ForeColor = Color.FromArgb(200, 200, 200);
                    l.AutoSize = false;
                    l.Location = new Point(0, 0);

                    AddControl(l, p);
                    ControlParameters cp = new ControlParameters();
                    cp.position = new Point(3, 3);
                    cp.anchor = (AnchorStyles)((AnchorStyles.Left | AnchorStyles.Right) | AnchorStyles.Top);
                    cp.size = l.Size;
                    CopyParameters(p, cp);
                    p.Name = "EmptyChat";
                    p.BackColor = Color.Transparent;
                    return;
                }
            } else {
                if (!ActiveChats.IsEmpty()) {
                    Panel p = ActiveChats.Get(0);
                    if (p.Name.Equals("EmptyChat")) {
                        actionPanel.Controls.Remove(p);
                        ActiveChats.RemoveElement(p);
                    }

                }
            }
            Iterator<Group> i = model.groups.GetAll().Iterator();
            int count = 0;
            while (i.HasNext()) {
                Group c = i.Next();
                if (!c.visible) {
                    AddGroup(c, count);
                }
                count++;
            }
        }

        private void RemoveActiveChats() {
            Iterator<Panel> i = ActiveChats.Iterator();
            while (i.HasNext())
                actionPanel.Controls.Remove(i.Next());
            ActiveChats = new DynamicArray<Panel>();
        }

        private void Chat_Click(object sender, EventArgs e) {
            AddChatBox();
            currentView = CurrentView.InChat;
            if (sender is Panel s)
                model.CurrentChat = s.Name;
        }

        private void Group_Click(object sender, EventArgs e) {
            AddChatBox();
            currentView = CurrentView.InGroup;
            if (sender is Panel sn)
                model.CurrentGroup = int.Parse(sn.Name);
        }

        private void Chat_MouseEnter(object sender, EventArgs e) {
            if (sender is Panel newPanel)
                newPanel.BackColor = Color.FromArgb(100, 100, 100);
        }

        private void Chat_MouseLeave(object sender, EventArgs e) {
            if (sender is Panel newPanel)
                newPanel.BackColor = Color.Transparent;
        }

        //Subproceso encargado de recibir los mensajes dados por el servidor
        //Estado: Pendiente
        private void Receptor_DoWork(object sender, DoWorkEventArgs e) {
            while (subprocess) {
                if (currentView == CurrentView.InChat) {
                    AddChatMessage(model.chats.Search(model.CurrentChat));
                } else if (currentView == CurrentView.InGroup) {
                    AddGroupMessage(model.groups.Search(model.CurrentGroup));
                } else {
                    RemoveMessages();
                }

                ManagmentChat();
                ManagmentGroup();
                Data data = model.ToReadDequeue();
                if (data == default)
                    continue;
                if (data is ShippingData.Message) {
                    if (data is ChatMessage chatMessage) {
                        Console.WriteLine("Sender: " + chatMessage.Sender);
                        Console.WriteLine("Receiver: " + chatMessage.Receiver);
                        Console.WriteLine("Content: " + chatMessage.Content);
                        string user;
                        if (model.singleton.userName.Equals(chatMessage.Sender))
                            user = chatMessage.Receiver;
                        else
                            user = chatMessage.Sender;
                        model.chats.AddElement(user, new UserChat(user));
                        model.chats.Search(user).NewMessages.Enqueue(chatMessage);
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
                    Console.WriteLine("Me ha llegado un chat");
                    UserChat newChat;
                    if (chat.memberOne.Equals(model.singleton.userName))
                        newChat = new UserChat(chat.memberTwo);
                    else
                        newChat = new UserChat(chat.memberOne);
                    model.chats.AddElement(newChat.profile.Name, newChat);
                } else if (data is RequestAnswer requestAnswer) {

                } else if (data is RequestError requestError) {

                } else if (data is ShippingData.Profile p) {
                    Singleton.GetSingleton().ProfilePicture = p.Image;
                    Singleton.GetSingleton().Status = p.Status;
                } else if (data is TreeActivities ta) {
                    TaskTree.Nodes.Add(ta.Tree[0]);
                    TaskTree.Nodes[0].Nodes.Add(ta.Tree[1]);
                    TaskTree.Nodes[0].Nodes.Add(ta.Tree[2]);
                    TaskTree.Nodes[1].Nodes.Add(ta.Tree[3]);
                    TaskTree.Nodes[1].Nodes.Add(ta.Tree[4]);
                } else if (data is ShippingData.Profile profile) {
                    UserChat uc = model.chats.Search(profile.Name);
                    if (uc != default) {
                        uc.profile = profile;
                    }
                    if (profile.Name.Equals(model.singleton.userName)) {
                        model.singleton.Status = profile.Status;
                        model.singleton.ProfilePicture = profile.Image;
                    }
                }
            }
        }


        //Delegados
        private void AddControl(Control toAdd, Control In) {
            if (In.InvokeRequired) {
                var d = new AddIn(AddControl);
                In.Invoke(d, toAdd, In);
            } else {
                In.Controls.Add(toAdd);
            }
        }

        private void DeleteControl(Control toDelete, Control In) {
            if (In.InvokeRequired) {
                var d = new AddIn(DeleteControl);
                In.Invoke(d, toDelete, In);
            } else {
                In.Controls.Remove(toDelete);
            }
        }

        private void CopyParameters(Control inWhichIWillCopy, ControlParameters theOther) {
            if (inWhichIWillCopy.InvokeRequired) {
                var d = new CopyParametersOf(this.CopyParameters);
                inWhichIWillCopy.Invoke(d, inWhichIWillCopy, theOther);
            } else {
                inWhichIWillCopy.Size = theOther.size;
                inWhichIWillCopy.Anchor = theOther.anchor;
                inWhichIWillCopy.Location = theOther.position;
                if (inWhichIWillCopy is Panel panel) {
                    panel.BorderStyle = theOther.borderStyle;
                } else if (inWhichIWillCopy is PictureBox pictureBox) {
                    pictureBox.Image = theOther.image;
                    pictureBox.SizeMode = theOther.pictureBoxSizeMode;
                } else if (inWhichIWillCopy is Label label) {
                    label.Text = theOther.text;
                }
            }
        }

        private void ChangeImage(PictureBox pictureBox, Image image) {
            if (pictureBox.InvokeRequired) {
                var d = new ChangeImageOf(this.ChangeImage);
                pictureBox.Invoke(d, pictureBox, image);
            } else {
                pictureBox.Image = image;
            }
        }
    }
}