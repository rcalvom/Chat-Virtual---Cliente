﻿using Chat_Virtual___Cliente.Backend;
using Chat_Virtual___Cliente.Communication;
using DataStructures;
using ShippingData;
using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Threading;
using static ShippingData.Message;

struct ControlParameters {
    //General
    public bool tabStop;
    public string name;
    public Size size;
    public Size maxSize;
    public AnchorStyles anchor;
    public Point location;
    //Para panel
    public BorderStyle borderStyle;
    //Para picture box
    public Image image;
    public PictureBoxSizeMode pictureBoxSizeMode;
    //Para label
    public string text;
    public ContentAlignment contentAlignment;
    //Para panel y label
    public bool autoSize;
    public Font font;
    public Color foreColor;
    public Color backColor;
};

enum CurrentView {
    InChat, ViewChats, SearchingChats, InGroup, ViewGroups, SearchingGroups, InHome, InProfile
};

namespace Chat_Virtual___Cliente.Frontend {
    public partial class HomeView : Form {

        //Control de vista
        private bool maximized;
        private bool subprocess;
        private MainModel model;
        private CurrentView lastView;
        private CurrentView currentView;

        //Chats-Grupos
        private Panel ActiveChat;                           //Panel que muestra la información del chat o grupo que está activo
        private ShippingData.Message FirstMessage;          //Primer mensaje del cual se creó un panel en el grupo o chat
        private Panel OldestMessage;                        //Panel con el mensaje que se está mostrando que tiene la fecha más antigua (Se usa para posicionar si llega otro mensaje más antiguo)
        private LinkedStack<Panel> RecentMessages;          //Paneles con los mensajes que se están mostrando

        //Controles
        private LinkedList<Control> ChatsControls;          //Controles que se muestran cuando los chats o grupos están activos
        private LinkedList<Control> HomeControls;           //Controles que se muestran cuando la vista principal está activa

        //Delgados
        private delegate void AddIn(Control toAdd, Control In);
        private delegate void AddIn2(Control toAdd, Control In);
        private delegate void DeleteIn(Control toAdd, Control In);
        private delegate void DeleteControlsOf(Control control);
        private delegate void CopyParametersOf(Control controlOne, ControlParameters controlTwo);
        private delegate void ChangeImageOf(PictureBox pb, Image image);
        private delegate void ChangeVisibilityState(Control control, bool Visible);
        private delegate void ChangeSizeOf(Control control, Size size);
        private delegate void ChangeLocationOf(Control control, Point point);
        private delegate void DisposeAControl(Control control);

        //Semaforos
        private Semaphore SGraficControl;

        public HomeView() {
            InitializeComponent();
            model = new MainModel();
            maximized = false;
            subprocess = true;
            ChatsControls = new LinkedList<Control>();
            HomeControls = new LinkedList<Control>();
            RecentMessages = new LinkedStack<Panel>();
            SGraficControl = new Semaphore(1, 1);
            FirstMessage = null;
            this.currentView = this.lastView = CurrentView.InHome;
            Thread graficControl = new Thread(GraficControl);
            graficControl.Start();

            receptor.RunWorkerAsync();
        }

        //Main events

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

        private void Home_Click(object sender, EventArgs e) {
            SGraficControl.WaitOne();
            currentView = CurrentView.InHome;
            SGraficControl.Release();
        }

        private void Chats_Click(object sender, EventArgs e) {
            SGraficControl.WaitOne();
            currentView = CurrentView.ViewChats;
            SGraficControl.Release();
        }

        private void Groups_Click(object sender, EventArgs e) {
            SGraficControl.WaitOne();
            currentView = CurrentView.ViewGroups;
            SGraficControl.Release();
        }

        private void Options_Click(object sender, EventArgs e) {
            SGraficControl.WaitOne();
            currentView = CurrentView.InProfile;
            SGraficControl.Release();
            Profile profile = new Profile(model);
            profile.ShowDialog();
        }  //Pendiente

        private void Settings_Click(object sender, EventArgs e) {

        }

        private void TreeButton_Click(object sender, EventArgs e) {
            new TreeView(model).ShowDialog();
        }

        //Remove controls
        private void RemoveHomeElements() {

        }  //Pendiente

        private void RemoveChatsElements() {
            Iterator<Control> controls = ChatsControls.Iterator();
            while (controls.HasNext()) {
                Control control = controls.Next();
                DeleteControl(control, InfoPanel);
                DeleteControl(control, actionPanel);
            }
            ChatsControls = new LinkedList<Control>();
            ChangeVisible(InfoPanel, false);
            ChangeVisible(actionPanel, false);
            RemoveChatBox();
            RemoveActiveChatPanel();
            RemoveActiveChats();
        }

        private void RemoveChatBox() {
            if (ChatBoxPanel.Visible) {
                ChangeVisible(ChatBoxPanel, false);
                ChangeSize(ViewPanel, new Size(ViewPanel.Width, ViewPanel.Height + ChatBoxPanel.Height));
            }
        }

        private void RemoveMessages() {
            if (FirstMessage == null)
                return;
            FirstMessage = null;
            OldestMessage = null;
            DeleteControls(ViewPanel);
            if (lastView == CurrentView.InChat || lastView == CurrentView.ViewChats) {
                ChatMessage ms;
                UserChat uc = SearchChat(RecentMessages.Peek().Name);
                int count = 0;
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
                                ms.date.StringToDate(l.Text);
                            }
                        } else if (c is PictureBox image) {
                            ms.Image = Serializer.SerializeImage(image.Image);
                        }
                    }
                    if (ms.Sender.Equals(model.singleton.userName)) {
                        ms.Receiver = uc.Name;
                    } else {
                        ms.Receiver = model.singleton.userName;
                    }
                    if (count < 20)
                        uc.OldMessagesPush(ms);
                    count++;
                }
            } else if (lastView == CurrentView.InGroup || lastView == CurrentView.ViewGroups) {
                GroupMessage gm;
                Group group = SearchGroup(int.Parse(RecentMessages.Peek().Name));
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
                    group.OldMessagesPush(gm);
                }
            }
        }

        private void RemoveActiveChats() {
            DeleteControls(actionPanel);
            model.SearchedChats = new LinkedList<UserChat>();
            model.SearchedGroups = new LinkedList<Group>();

            if (lastView == CurrentView.InChat || lastView == CurrentView.ViewChats || lastView == CurrentView.SearchingChats) {
                Iterator<UserChat> uc = model.Chats.Iterator();
                while (uc.HasNext()) {
                    UserChat chat = uc.Next();
                    chat.Visible = false;
                    chat.Panel = null;
                }
            } else if (lastView == CurrentView.InGroup || lastView == CurrentView.ViewGroups || lastView == CurrentView.SearchingGroups) {
                Iterator<Group> g = model.Groups.Iterator();
                while (g.HasNext()) {
                    Group group = g.Next();
                    group.Visible = false;
                    group.Panel = null;
                }
            }
        }

        private void RemoveActiveChatPanel() {
            if(ActiveChat != null) {
                DeleteControl(ActiveChat, InfoPanel);
                DisposeControl(ActiveChat);
                ActiveChat = null;
            }
        }

        //Events

        private void Send_Click(object sender, EventArgs e) {
            string content = chat.Text.Trim();
            chat.Clear();
            if (content.Length == 0)
                return;
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

        private void SendImage_Click(object sender, EventArgs e) {
            SendImage sendImage = new SendImage();
            sendImage.ShowDialog();
            if(sendImage.ImageSelected != null) {
                if (currentView == CurrentView.InChat) {
                    ChatMessage chatMessage = new ChatMessage(model.singleton.userName, model.CurrentChat, sendImage.Coment.Trim());
                    chatMessage.Image = sendImage.ImageSelected;
                    model.ToWriteEnqueue(chatMessage);
                } else {
                    GroupMessage groupMessage = new GroupMessage(model.CurrentGroup, model.singleton.userName, sendImage.Coment);
                    groupMessage.Image = sendImage.ImageSelected;
                    model.ToWriteEnqueue(groupMessage);
                }
            }
        }

        private void SearchChat(object sender, EventArgs e) {
            if (sender is TextBox textBox) {
                if (textBox.Text.Length == 0) {
                    if (currentView == CurrentView.SearchingChats)
                        currentView = CurrentView.ViewChats;
                    else if (currentView == CurrentView.SearchingGroups)
                        currentView = CurrentView.ViewGroups;
                } else {
                    SGraficControl.WaitOne();
                    if (currentView == CurrentView.ViewChats || currentView == CurrentView.InChat) {
                        currentView = CurrentView.SearchingChats;
                    } else {
                        currentView = CurrentView.SearchingGroups;
                    }
                    lastView = currentView;

                    if (currentView == CurrentView.SearchingChats) {
                        ShippingData.Profile p = new ShippingData.Profile();
                        p.Name = textBox.Text;
                        model.ToWriteEnqueue(new Chat(model.singleton.userName, p, true));
                    } else {
                        model.ToWriteEnqueue(new ChatGroup(-1, textBox.Text, true));
                    }
                    SGraficControl.Release();
                }
            }
        }

        private void Chat_Click(object sender, EventArgs e) {
            if (sender is Panel s) {
                string currentChat = s.Name;
                if (!currentChat.Equals(model.CurrentChat)) {
                    SGraficControl.WaitOne();
                    currentView = CurrentView.InChat;
                    lastView = CurrentView.ViewChats;
                    model.CurrentChat = currentChat;
                    AddActiveChatPanel(s);
                    SGraficControl.Release();
                }
            } else if (sender is Control c) {
                Chat_Click(c.Parent, e);
            }
        }

        private void Group_Click(object sender, EventArgs e) {
            int currentGroup = -1;
            if (sender is Panel sn) {
                currentGroup = int.Parse(sn.Name);
                if (currentGroup != model.CurrentGroup) {
                    SGraficControl.WaitOne();
                    currentView = CurrentView.InGroup;
                    lastView = CurrentView.ViewGroups;
                    model.CurrentGroup = currentGroup;
                    AddActiveChatPanel(sn);
                    SGraficControl.Release();
                }
            } else if (sender is Control c) {
                Chat_Click(c.Parent, e);
            }
        }

        private void Chat_MouseEnter(object sender, EventArgs e) {
            if (sender is Panel newPanel)
                newPanel.BackColor = Color.FromArgb(100, 100, 100);
            else if (sender is Control s)
                Chat_MouseEnter(s.Parent, e);
        }

        private void Chat_MouseLeave(object sender, EventArgs e) {
            if (sender is Panel newPanel)
                newPanel.BackColor = Color.Transparent;
            else if (sender is Control s)
                Chat_MouseLeave(s.Parent, e);
        }

        private void ChatBoxEnter(object sender, KeyEventArgs e) {
            if(e.Shift && e.KeyCode == Keys.Enter) {
                TextBox textBox = sender as TextBox;
                textBox.AppendText("\n");
            } else if (e.KeyCode == Keys.Enter) {
                Send_Click(sender, new EventArgs());
            }
        }

        private void ChatBoxTextChanged(object sender, EventArgs e) {
            TextBox txtBody = sender as TextBox;
            const int padding = 3;
            int numLines = txtBody.GetLineFromCharIndex(txtBody.TextLength) + 1;
            int border = txtBody.Height - txtBody.ClientSize.Height;
            int newHeight = txtBody.Font.Height * numLines + padding + border;
            if(newHeight < 100)
                txtBody.Height = txtBody.Font.Height * numLines + padding + border;
        }

        //Add controls
        private void AddHomeElements() {

        }  //Pendiente

        private void AddChatSearchElements(string LabelText) {
            bool Exist = false;
            Label text = new Label();
            Iterator<Control> controls = ChatsControls.Iterator();
            while (controls.HasNext()) {
                Control control = controls.Next();
                if (control.Name.Equals("Search")) {
                    Exist = true;
                    foreach(Control control1 in control.Controls) {
                        if(control1 is Label l) {
                            text = l;
                        }
                    }
                    break;
                }
            }
            if (!Exist) {
                ControlParameters cp = new ControlParameters();
                Panel NewChatPanel = new Panel();
                Label NewChatLabel = new Label();
                TextBox NewChatTextBox = new TextBox();
                AddControl(NewChatPanel, InfoPanel);

                cp.location = new Point(0, 0);
                cp.size = new Size(actionPanel.Width, InfoPanel.Height);
                cp.backColor = Color.Transparent;
                cp.anchor = (AnchorStyles)(AnchorStyles.Left | AnchorStyles.Top);
                cp.borderStyle = BorderStyle.FixedSingle;
                cp.name = "Search";
                AddControl(NewChatLabel, NewChatPanel);
                AddControl(NewChatTextBox, NewChatPanel);
                CopyParameters(NewChatPanel, cp);

                cp = new ControlParameters();
                cp.font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
                cp.foreColor = Color.FromArgb(220, 220, 220);
                cp.location = new Point(5, 5);
                cp.size = new Size(actionPanel.Width - 10, 18);
                cp.text = LabelText;
                CopyParameters(NewChatLabel, cp);

                cp = new ControlParameters();
                cp.anchor = (AnchorStyles)(AnchorStyles.Top | AnchorStyles.Left);
                cp.backColor = Color.FromArgb(64, 64, 64);
                cp.borderStyle = BorderStyle.FixedSingle;
                cp.font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
                cp.foreColor = Color.FromArgb(224, 224, 224);
                cp.name = "NewChat";
                cp.size = new Size(NewChatPanel.Width - 20, 20);
                cp.location = new Point(10, 28);
                cp.tabStop = true;
                NewChatTextBox.TextChanged += new EventHandler(SearchChat);
                CopyParameters(NewChatTextBox, cp);

                ChatsControls.Add(NewChatPanel);
            } else {
                ControlParameters cp = new ControlParameters();
                cp.font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
                cp.foreColor = Color.FromArgb(220, 220, 220);
                cp.location = new Point(5, 5);
                cp.size = new Size(actionPanel.Width - 10, 18);
                cp.text = LabelText;
                CopyParameters(text, cp);
            }
        }

        private void AddChatBox() {
            if (!ChatBoxPanel.Visible) {
                ChangeVisible(ChatBoxPanel, true);
                ChangeSize(ViewPanel, new Size(ViewPanel.Width, ViewPanel.Height - ChatBoxPanel.Height));
            }
        }

        private void AddChatMessage(UserChat chat) {
            Panel message = new Panel();
            Panel line = new Panel();
            Label user = new Label();
            Label content = new Label();
            Label time = new Label();
            PictureBox image = new PictureBox();
            if (chat == default)
                return;
            ChatMessage ms = chat.OldMessagePop();
            if (ms == default) {
                ms = chat.NewMessageDequeue();
                if (ms == default)
                    return;
            }
            AddControl(message, ViewPanel);
            AddControl(line, message);
            AddControl(user, message);
            AddControl(content, message);
            AddControl(time, message);

            //user label
            ControlParameters cp = new ControlParameters();
            cp.autoSize = true;
            cp.anchor = (AnchorStyles)((AnchorStyles.Top | AnchorStyles.Left) | AnchorStyles.Right);
            cp.location = new Point(2, 7);
            cp.size = new Size(ViewPanel.Width - 4, 18);
            cp.text = ms.Sender;
            cp.contentAlignment = ContentAlignment.MiddleLeft;
            cp.font = new Font("Microsoft Sans Serif", 11F, FontStyle.Bold, GraphicsUnit.Point, (0));
            cp.foreColor = Color.FromArgb(234, 234, 234);
            cp.name = "UserName";
            cp.tabStop = false;
            CopyParameters(user, cp);

            //content label
            cp = new ControlParameters();
            if (ms.Content.Length == 0) {
                cp.autoSize = false;
                cp.size = new Size(0, 0);
            } else {
                cp.anchor = (AnchorStyles)(AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom);
                cp.autoSize = true;
                cp.size = new Size(ViewPanel.Width - 10, 10);
                cp.maxSize = new Size(ViewPanel.Width - 4, 0);
                cp.text = ms.Content;
                cp.contentAlignment = ContentAlignment.MiddleLeft;
                cp.font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
                cp.foreColor = Color.FromArgb(200, 200, 200);
            }
            cp.location = new Point(2, 33);
            cp.name = "Content";
            cp.tabStop = false;
            CopyParameters(content, cp);

            //image pictureBox
            cp = new ControlParameters();
            cp.autoSize = false;
            cp.anchor = (AnchorStyles)(AnchorStyles.Top | AnchorStyles.Left);
            cp.tabStop = false;
            if (ms.Image != null) {
                AddControl(image, message);
                cp.size = new Size(ViewPanel.Width - 100, ViewPanel.Width/2);
                cp.location = new Point(10, content.Location.Y + content.Height + 5);
                cp.pictureBoxSizeMode = PictureBoxSizeMode.AutoSize;
                cp.image = Serializer.DeserializeImage(ms.Image);
            } else {
                cp.size = new Size(0, 0);
            }
            CopyParameters(image, cp);

            //time label
            cp = new ControlParameters();
            cp.autoSize = true;
            cp.anchor = ((AnchorStyles)((AnchorStyles.Bottom | AnchorStyles.Right)));
            cp.size = new Size(100, 18);
            cp.font = new Font("Microsoft Sans Serif", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cp.text = ms.date.FormatHourAndMinute(false);
            cp.contentAlignment = ContentAlignment.MiddleRight;
            cp.location = new Point(actionPanel.Width - 110, content.Location.Y + 18 + 30);
            cp.foreColor = Color.FromArgb(150, 150, 150);
            cp.name = "Time";
            cp.tabStop = false;
            CopyParameters(time, cp);

            //message panel
            cp = new ControlParameters();
            cp.autoSize = false;
            cp.anchor = (AnchorStyles)(AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top);
            cp.borderStyle = BorderStyle.None;
            cp.size = new Size(ViewPanel.Width, time.Height + content.Height + user.Height + 27 + image.Height);
            if (FirstMessage == null) {
                FirstMessage = ms;
                cp.location = new Point(0, 0);
                OldestMessage = message;
                RecentMessages.Push(message);
            } else {
                if (ms.date.CompareTo(FirstMessage.date) < 0) {
                    cp.location = new Point(0, OldestMessage.Location.Y - cp.size.Height);
                    OldestMessage = message;
                } else {
                    cp.location = new Point(0, RecentMessages.Peek().Location.Y + RecentMessages.Peek().Height);
                    RecentMessages.Push(message);
                }
            }
            cp.name = chat.Name;
            cp.tabStop = false;
            CopyParameters(message, cp);

            cp = new ControlParameters();
            cp.autoSize = false;
            cp.anchor = (AnchorStyles)(AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom); ;
            cp.borderStyle = BorderStyle.None;
            cp.size = new Size(message.Width-20, 1);
            cp.backColor = Color.FromArgb(70, 70, 70);
            cp.tabStop = false;
            cp.location = new Point(10, message.Height - 1);
            CopyParameters(line, cp);
        }

        private void AddGroupMessage(Group group) {
            Panel message = new Panel();
            Label user = new Label();
            Label content = new Label();
            Label time = new Label();
            if (group == default)
                return;
            GroupMessage ms = group.OldMessagePop();
            if (ms == default) {
                ms = group.NewMessageDequeue();
                if (ms == default)
                    return;
            }
            AddControl(message, ViewPanel);
            AddControl(user, message);
            AddControl(content, message);
            AddControl(time, message);
            //user label
            ControlParameters cp = new ControlParameters();
            cp.autoSize = true;
            cp.anchor = (AnchorStyles)((AnchorStyles.Top | AnchorStyles.Left) | AnchorStyles.Right);
            cp.location = new Point(2, 2);
            cp.size = new Size(ViewPanel.Width - 24, 18);
            cp.text = ms.Sender;
            cp.contentAlignment = ContentAlignment.MiddleLeft;
            cp.font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point, (0));
            cp.foreColor = Color.FromArgb(224, 224, 224);
            cp.name = "UserName";
            cp.tabStop = false;
            CopyParameters(user, cp);
            //content label
            cp = new ControlParameters();
            cp.autoSize = true;
            cp.anchor = (AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Left) | AnchorStyles.Right) | AnchorStyles.Bottom);
            cp.location = new Point(2, 30);
            cp.size = new Size(ViewPanel.Width - 24, 20);
            cp.text = ms.Content;
            cp.contentAlignment = ContentAlignment.MiddleLeft;
            cp.font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cp.foreColor = Color.FromArgb(200, 200, 200);
            cp.name = "Content";
            cp.tabStop = false;
            CopyParameters(content, cp);
            //time label
            cp = new ControlParameters();
            cp.anchor = ((AnchorStyles)((AnchorStyles.Bottom | AnchorStyles.Right)));
            cp.size = new Size(42, 18);
            cp.font = new Font("Microsoft Sans Serif", 8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cp.text = "Huele a pudin!";
            cp.location = new Point(ViewPanel.Width - 25 - cp.text.Length * 2, content.Location.Y + content.Height + 5);
            cp.contentAlignment = ContentAlignment.MiddleRight;
            cp.autoSize = true;
            cp.foreColor = Color.FromArgb(200, 200, 200);
            cp.name = "Time";
            cp.tabStop = false;
            CopyParameters(time, cp);
            //message panel
            cp = new ControlParameters();
            cp.autoSize = false;
            cp.anchor = (AnchorStyles)(AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top);
            cp.borderStyle = BorderStyle.FixedSingle;
            cp.size = new Size(ViewPanel.Width, time.Height + content.Height + user.Height + 20);
            if (FirstMessage == null) {
                FirstMessage = ms;
                cp.location = new Point(0, 0);
                OldestMessage = message;
                RecentMessages.Push(message);
            } else {
                if (ms.date.CompareTo(FirstMessage.date) < 0) {
                    cp.location = new Point(0, OldestMessage.Location.Y - cp.size.Height);
                    OldestMessage = message;
                } else {
                    cp.location = new Point(0, RecentMessages.Peek().Location.Y + RecentMessages.Peek().Height);
                    RecentMessages.Push(message);
                }
            }
            cp.name = group.code.ToString();
            cp.tabStop = false;
            CopyParameters(message, cp);
        }

        private void AddChat(ChatBase chatBase, int i) {
            Panel newPanel = new Panel();
            Panel line = new Panel();
            CircularPictureBox photo = new CircularPictureBox();
            Label user = new Label();
            Label lastMessage = new Label();
            AddControl(newPanel, actionPanel);
            AddControl(photo, newPanel);
            AddControl(user, newPanel);
            AddControl(line, newPanel);

            //panel
            ControlParameters cp = new ControlParameters();
            cp.size = new Size(actionPanel.Width, 50);
            cp.anchor = (AnchorStyles)(AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top); ;
            cp.location = new Point(0, cp.size.Height * i);
            cp.borderStyle = BorderStyle.None;
            cp.backColor = Color.Transparent;
            if (chatBase is Group group) {
                user.Click += new EventHandler(Group_Click);
                cp.name = group.code.ToString();
            } else {
                user.Click += new EventHandler(Chat_Click);
                cp.name = chatBase.Name;
            }
            cp.tabStop = false;
            CopyParameters(newPanel, cp);
            newPanel.MouseEnter += new EventHandler(Chat_MouseEnter);
            newPanel.MouseLeave += new EventHandler(Chat_MouseLeave);
            newPanel.Click += new EventHandler(Chat_Click);
            chatBase.Panel = newPanel;

            //pictureBox
            cp = new ControlParameters();
            cp.size = new Size(40, 40);
            cp.location = new Point(5, 5);
            cp.pictureBoxSizeMode = PictureBoxSizeMode.StretchImage;
            if (chatBase.Photo != null) {
                cp.image = Serializer.DeserializeImage(chatBase.Photo);
            }
            CopyParameters(photo, cp);
            photo.MouseEnter += new EventHandler(Chat_MouseEnter);
            photo.MouseLeave += new EventHandler(Chat_MouseLeave);
            photo.Click += new EventHandler(Chat_Click);

            //label user
            cp = new ControlParameters();
            cp.autoSize = false;
            cp.name = "User";
            cp.size = new Size(newPanel.Width - 60, 20);
            cp.location = new Point(50, 6);
            cp.anchor = (AnchorStyles)(AnchorStyles.Left | AnchorStyles.Right);
            cp.text = chatBase.Name;
            cp.contentAlignment = ContentAlignment.MiddleLeft;
            cp.backColor = Color.Transparent;
            cp.foreColor = Color.FromArgb(200, 200, 200);
            cp.font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            CopyParameters(user, cp);
            user.MouseEnter += new EventHandler(Chat_MouseEnter);
            user.MouseLeave += new EventHandler(Chat_MouseLeave);

            /*//lastMessage
            cp = new ControlParameters();
            cp.autoSize = false;
            cp.size = new Size(newPanel.Width - 60, 20);
            cp.location = new Point(50, 25);
            cp.anchor = (AnchorStyles)(AnchorStyles.Left | AnchorStyles.Right);
            cp.text = chatBase.LastMessage.Content;
            cp.contentAlignment = ContentAlignment.MiddleLeft;
            cp.backColor = Color.Transparent;
            cp.foreColor = Color.FromArgb(200, 200, 200);
            cp.font = new Font("Microsoft Sans Serif", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            CopyParameters(user, cp);
            user.MouseEnter += new EventHandler(Chat_MouseEnter);
            user.MouseLeave += new EventHandler(Chat_MouseLeave);*/

            //line
            cp = new ControlParameters();
            cp.autoSize = false;
            cp.anchor = (AnchorStyles)(AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom); ;
            cp.borderStyle = BorderStyle.None;
            cp.size = new Size(newPanel.Width - 20, 1);
            cp.backColor = Color.FromArgb(70, 70, 70);
            cp.tabStop = false;
            cp.location = new Point(10, newPanel.Height - 1);
            CopyParameters(line, cp);

            chatBase.Visible = true;
        }

        private void AddActiveChatPanel(Panel ClickPanel) {
            Label user = new Label(), status = new Label(); ;
            CircularPictureBox photo = new CircularPictureBox(); ;
            if(ActiveChat == null) {
                ActiveChat = new Panel();
                user.Name = "User";
                status.Name = "Status";
                ActiveChat.Controls.Add(user);
                ActiveChat.Controls.Add(status);
                ActiveChat.Controls.Add(photo);
                InfoPanel.Controls.Add(ActiveChat);
            } else {
                foreach(Control c in ActiveChat.Controls) {
                    if (c is Label label) {
                        if (label.Name.Equals("User"))
                            user = label;
                        else
                            status = label;
                    } else if (c is CircularPictureBox pictureBox) {
                        photo = pictureBox;
                    }
                }
            }

            foreach(Control c in ClickPanel.Controls) {
                if(c is Label label) {
                    if (label.Name.Equals("User"))
                        user.Text = label.Text;
                    else
                        status.Text = label.Text;
                } else if(c is PictureBox pictureBox) {
                    photo.Image = pictureBox.Image;
                }
            }

            ActiveChat.Size = new Size(ViewPanel.Width + 1, InfoPanel.Height);
            ActiveChat.Location = new Point(actionPanel.Width - 1, 0);
            ActiveChat.BackColor = user.BackColor = status.BackColor = Color.Transparent;
            ActiveChat.AutoSize = user.AutoSize = status.AutoSize = false;
            ActiveChat.Visible = user.Visible = status.Visible = true;
            ActiveChat.BorderStyle = BorderStyle.None;
            ActiveChat.Anchor = (AnchorStyles)(AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom);

            photo.Location = new Point(10, 10);
            photo.Size = new Size(ActiveChat.Height-20, ActiveChat.Height-20);
            photo.Anchor = (AnchorStyles)(AnchorStyles.Top | AnchorStyles.Left);
            photo.SizeMode = PictureBoxSizeMode.StretchImage;

            user.Font = new Font("Microsoft Sans Serif", 11F, FontStyle.Bold, GraphicsUnit.Point, 0);
            status.Font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            user.ForeColor = status.ForeColor = Color.FromArgb(200, 200, 200);
            user.Size = status.Size = new Size(ViewPanel.Width - photo.Width - 30, 20);
            user.Location = new Point(photo.Width + 20, 10); status.Location = new Point(photo.Width + 20, InfoPanel.Height - 30);
        }

        //Funciones
        private UserChat SearchChat(string name) {
            Iterator<UserChat> i = model.Chats.Iterator();
            while (i.HasNext()) {
                UserChat c = i.Next();
                if (c.Name.Equals(name)) {
                    return c;
                }
            }
            return default;
        }

        private Group SearchGroup(int code) {
            Iterator<Group> i = model.Groups.Iterator();
            while (i.HasNext()) {
                Group c = i.Next();
                if (c.code == code) {
                    return c;
                }
            }
            return default;
        }

        private void OrganizeChats(bool InChats) {
            ArrayMaxHeap<Panel> ActiveChats = new ArrayMaxHeap<Panel>();
            Iterator<ChatBase> iterator;
            if (InChats) 
                iterator = model.Chats.Iterator() as Iterator<ChatBase>;
            else
                iterator = model.Groups.Iterator() as Iterator<ChatBase>;

            while (iterator.HasNext()) {
                ChatBase chat = iterator.Next();
                if(chat.Panel != null)
                    ActiveChats.Insert((int)chat.LastMessage.date.ToLong(), chat.Panel);
            }

            int i = 0;
            while(!ActiveChats.IsEmpty()) {
                Panel chat = ActiveChats.ExtractMax();
                ChangeLocation(chat, new Point(0, i*chat.Height));
                i++;
            }
        }

        private void GraficControl() {
            while (subprocess) {
                SGraficControl.WaitOne();
                if (lastView != currentView) {

                    if (lastView == CurrentView.InChat)
                        model.CurrentChat = null;
                    else if (lastView == CurrentView.InGroup)
                        model.CurrentGroup = -1;

                    RemoveMessages();
                    if(currentView == CurrentView.InChat) {
                        AddChatBox();
                    } else if(currentView == CurrentView.ViewChats) {
                        AddChatSearchElements("Busca o inicia un chat");
                        ChangeVisible(actionPanel, true);
                        ChangeVisible(InfoPanel, true);
                        RemoveActiveChatPanel();
                        if (lastView != CurrentView.InChat) {
                            RemoveActiveChats();
                        }
                    } else if (currentView == CurrentView.SearchingChats || currentView == CurrentView.SearchingGroups) {
                        RemoveActiveChats();
                    } else if (currentView == CurrentView.InGroup) {
                        AddChatBox();
                    } else if(currentView == CurrentView.ViewGroups) {
                        AddChatSearchElements("Busca un grupo");
                        ChangeVisible(actionPanel, true);
                        ChangeVisible(InfoPanel, true);
                        RemoveActiveChatPanel();
                        if (lastView != CurrentView.InGroup) {
                            RemoveActiveChats();
                        }
                    } else { //currentView == CurrentView.InHome
                        RemoveChatsElements();
                        AddHomeElements();
                    }

                    lastView = currentView;
                }
                if(currentView == CurrentView.InChat || currentView == CurrentView.ViewChats) {
                    Iterator<UserChat> iterator = model.Chats.Iterator();
                    int count = 0;
                    bool NeedChange = false;
                    while (iterator.HasNext()) {
                        UserChat chat = iterator.Next();
                        if (!chat.Visible) {
                            AddChat(chat, count);
                            NeedChange = true;
                        }
                        count++;
                    }
                    if (currentView == CurrentView.InChat)
                        AddChatMessage(SearchChat(model.CurrentChat));
                    if (NeedChange) 
                        OrganizeChats(true);
                } else if (currentView == CurrentView.SearchingChats) {
                    Iterator<UserChat> iterator = model.SearchedChats.Iterator();
                    int count = 0;
                    while (iterator.HasNext()) {
                        UserChat chat = iterator.Next();
                        if (!chat.Visible)
                            AddChat(chat, count);
                        count++;
                    }
                } else if (currentView == CurrentView.InGroup || currentView == CurrentView.ViewGroups) {
                    Iterator<Group> iterator = model.Groups.Iterator();
                    int count = 0;
                    bool NeedChange = false;
                    while (iterator.HasNext()) {
                        Group chat = iterator.Next();
                        if (!chat.Visible) { 
                            AddChat(chat, count);
                            NeedChange = true;
                        }
                        count++;
                    }
                    if (currentView == CurrentView.InGroup)
                        AddGroupMessage(SearchGroup(model.CurrentGroup));
                    if (NeedChange)
                        OrganizeChats(false);
                } else if (currentView == CurrentView.SearchingGroups) {
                    Iterator<Group> iterator = model.SearchedGroups.Iterator();
                    int count = 0;
                    while (iterator.HasNext()) {
                        Group chat = iterator.Next();
                        if (!chat.Visible)
                            AddChat(chat, count);
                        count++;
                    }
                }
                SGraficControl.Release();
            }
        }

        //Subproceso encargado de recibir los mensajes dados por el servidor
        //Estado: Pendiente
        private void Receptor_DoWork(object sender, DoWorkEventArgs e) {
            //Tester();
            while (subprocess) {
                if (model.singleton.ProfileHasChanged) {
                    model.ToWriteEnqueue(new ShippingData.Profile(model.singleton.userName, model.singleton.ProfilePicture, model.singleton.Status));
                    model.singleton.ProfileHasChanged = false;
                    ChangeImage(Profile, Serializer.DeserializeImage(model.singleton.ProfilePicture));
                }

                if (model.IsConnected()) {
                    model.DataControl();
                } else {
                    model.Connect();
                }
                
                Data data = model.ToReadDequeue();
                if (data == default)
                    continue;
                if (data is ShippingData.Message) {
                    if (data is ChatMessage chatMessage) {
                        ShippingData.Profile user = new ShippingData.Profile();
                        if (model.singleton.userName.Equals(chatMessage.Sender))
                            user.Name = chatMessage.Receiver;
                        else
                            user.Name = chatMessage.Sender;
                        UserChat SearchedChat = SearchChat(user.Name);
                        if (SearchedChat == default) {
                            model.Chats.Add(new UserChat(user));
                            model.ToWriteEnqueue(new Chat(model.singleton.userName, user, false));
                        }
                        SearchedChat.NewMessagesEnqueue(chatMessage);
                        if (SearchedChat.Panel != null)
                            OrganizeChats(true);
                    } else if (data is GroupMessage groupMessage) {
                        
                    }
                } else if (data is ChatGroup chatGroup) {
                    
                } else if (data is Chat chat) {
                    UserChat newChat = new UserChat(chat.memberTwo);
                    if (chat.Searched) {
                        model.SearchedChats.RemoveElement(newChat);
                        model.SearchedChats.Add(newChat);
                    } else {
                        UserChat oldChat = SearchChat(newChat.Name);
                        if (oldChat != default) {
                            oldChat.Photo = newChat.Photo;
                            oldChat.Status = newChat.Status;
                        } else { 
                            model.Chats.Add(newChat);
                        }
                    }
                } else if (data is RequestAnswer requestAnswer) {

                } else if (data is RequestError requestError) {

                } else if (data is ShippingData.Profile p) {
                    Singleton.GetSingleton().ProfilePicture = p.Image;
                    Singleton.GetSingleton().Status = p.Status;
                    ChangeImage(Profile, Serializer.DeserializeImage(model.singleton.ProfilePicture));
                } else if (data is TreeActivities tree) {
                    Singleton.GetSingleton().tree = tree.Node;
                }
            }
            while (!model.toWrite.IsEmpty())
                model.Write();
        }

        //Delegados
        private void AddControl(Control toAdd, Control In) {
            if (In.InvokeRequired) {
                var d = new AddIn(AddControl);
                In.Invoke(d, new object[] {toAdd, In});
            } else {
                AddControl2(toAdd, In);
            }
        }

        private void AddControl2(Control toAdd, Control In) {
            if (toAdd.InvokeRequired) {
                var d = new AddIn2(AddControl2);
                toAdd.Invoke(d, new object[] { toAdd, In });
            } else {
                In.Controls.Add(toAdd);
            }
        }

        private void DeleteControl(Control toDelete, Control In) {
            if (In.InvokeRequired) {
                var d = new DeleteIn(DeleteControl);
                In.Invoke(d, new object[] { toDelete, In });
            } else {
                In.Controls.Remove(toDelete);
            }
        }

        private void DeleteControls(Control control) {
            if (control.InvokeRequired) {
                var d = new DeleteControlsOf(DeleteControls);
                control.Invoke(d, control);
            } else {
                control.Controls.Clear();
            }
        }

        private void CopyParameters(Control inWhichIWillCopy, ControlParameters theOther) {
            if (inWhichIWillCopy.InvokeRequired) {
                var d = new CopyParametersOf(this.CopyParameters);
                inWhichIWillCopy.Invoke(d, inWhichIWillCopy, theOther);
            } else {
                inWhichIWillCopy.TabStop = theOther.tabStop;
                inWhichIWillCopy.Size = theOther.size;
                inWhichIWillCopy.Anchor = theOther.anchor;
                inWhichIWillCopy.Location = theOther.location;
                inWhichIWillCopy.Name = theOther.name;
                inWhichIWillCopy.MaximumSize = theOther.maxSize;
                if (inWhichIWillCopy is Panel panel) {
                    panel.AutoSize = theOther.autoSize;
                    panel.BorderStyle = theOther.borderStyle;
                    panel.ForeColor = theOther.foreColor;
                    panel.BackColor = theOther.backColor;
                    panel.Font = theOther.font;
                } else if (inWhichIWillCopy is PictureBox pictureBox) {
                    pictureBox.Image = theOther.image;
                    pictureBox.SizeMode = theOther.pictureBoxSizeMode;
                } else if (inWhichIWillCopy is Label label) {
                    label.AutoSize = theOther.autoSize;
                    label.Text = theOther.text;
                    //label.TextAlign = theOther.contentAlignment;
                    label.ForeColor = theOther.foreColor;
                    label.BackColor = theOther.backColor;
                    label.Font = theOther.font;
                } else if(inWhichIWillCopy is TextBox textBox) {
                    textBox.BackColor = theOther.backColor;
                    textBox.BorderStyle = theOther.borderStyle;
                    textBox.ForeColor = theOther.foreColor;
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

        private void ChangeVisible(Control ToChange, bool Visible) {
            if (ToChange.InvokeRequired) {
                var d = new ChangeVisibilityState(this.ChangeVisible);
                ToChange.Invoke(d, ToChange, Visible);
            } else {
                ToChange.Visible = Visible;
            }
        }

        private void ChangeSize(Control ToChange, Size size) {
            if (ToChange.InvokeRequired) {
                var d = new ChangeSizeOf(this.ChangeSize);
                ToChange.Invoke(d, ToChange, size);
            } else {
                ToChange.Size = new Size(size.Width, size.Height);
            }
        }

        private void ChangeLocation(Control ToChange, Point Location) {
            if (ToChange.InvokeRequired) {
                var d = new ChangeLocationOf(ChangeLocation);
                ToChange.Invoke(d, ToChange, Location);
            } else {
                ToChange.Location = Location;
            }
        }

        private void DisposeControl(Control ToDispose) {
            if (ToDispose.InvokeRequired) {
                var d = new DisposeAControl(this.DisposeControl);
                ToDispose.Invoke(d, ToDispose);
            } else {
                ToDispose.Dispose();
            }
        }
    }
}