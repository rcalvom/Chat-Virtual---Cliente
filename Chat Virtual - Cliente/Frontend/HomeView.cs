using Chat_Virtual___Cliente.Backend;
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
    InChat, InGroup, InHome, InProfile, ViewChats, ViewGroups, SearchingChats, SearchingGroups
};

namespace Chat_Virtual___Cliente.Frontend {
    public partial class HomeView : Form {

        private bool maximized;
        private bool subprocess;
        private MainModel model;
        private ShippingData.Message FirstMessage;
        private CurrentView lastView;
        private CurrentView currentView;

        private LinkedList<Control> AditionalComponents;
        private LinkedStack<Panel> RecentMessages;
        private LinkedStack<Panel> OldMessages;
        private LinkedList<Panel> ActiveChats;

        private delegate void AddIn(Control toAdd, Control In);
        private delegate void AddIn2(Control toAdd, Control In);
        private delegate void DeleteIn(Control toAdd, Control In);
        private delegate void DeleteIn2(Control toAdd, Control In);
        private delegate void CopyParametersOf(Control controlOne, ControlParameters controlTwo);
        private delegate void ChangeImageOf(PictureBox pb, Image image);
        private delegate void ChangeVisibilityState(Control control, bool Visible);
        private delegate void ChangeSizeOf(Control control, Size size);

        //Semaforos
        private Semaphore SGraficControl;

        public HomeView() {
            InitializeComponent();
            model = new MainModel();
            maximized = false;
            subprocess = true;
            AditionalComponents = new LinkedList<Control>();
            RecentMessages = OldMessages = new LinkedStack<Panel>();
            ActiveChats = new LinkedList<Panel>();
            SGraficControl = new Semaphore(1, 1);
            FirstMessage = null;
            this.currentView = CurrentView.InHome;
            Thread graficControl = new Thread(GraficControl);
            graficControl.Start();
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

        private void RemoveComponents() {
            while (!AditionalComponents.IsEmpty()) {
                Control c = AditionalComponents.Remove(0);
                DeleteControl(c, ViewPanel);
                DeleteControl(c, descriptionPanel);
                DeleteControl(c, InfoPanel);
                DeleteControl(c, actionPanel);
            }
            if (ChatBoxPanel.Visible) {
                ChangeSize(ViewPanel, new Size(ViewPanel.Width, ViewPanel.Height + ChatBoxPanel.Height));
            }
            ChangeVisible(ChatBoxPanel, false);
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

        //Pendiente
        private void Options_Click(object sender, EventArgs e) {
            SGraficControl.WaitOne();
            currentView = CurrentView.InProfile;
            SGraficControl.Release();
            Profile profile = new Profile();
            profile.ShowDialog();
        }

        private void Settings_Click(object sender, EventArgs e) {
            
        }

        private void Send_Click(object sender, EventArgs e) {
            string content = chat.Text;
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

        private void AddChatSearchElements() {
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
            AddControl(NewChatLabel, NewChatPanel);
            AddControl(NewChatTextBox, NewChatPanel);
            CopyParameters(NewChatPanel, cp);

            cp = new ControlParameters();
            cp.font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cp.foreColor = Color.FromArgb(220, 220, 220);
            cp.location = new Point(5, 5);
            cp.size = new Size(actionPanel.Width - 10, 18);
            cp.text = "Busca o inicia un nuevo chat";
            CopyParameters(NewChatLabel, cp);

            cp = new ControlParameters();
            cp.anchor = (AnchorStyles)(AnchorStyles.Top | AnchorStyles.Left);
            cp.backColor = Color.FromArgb(64, 64, 64);
            cp.borderStyle = BorderStyle.FixedSingle;
            cp.font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cp.foreColor = Color.FromArgb(224, 224, 224);
            cp.name = "NewChat";
            cp.size = new Size(NewChatPanel.Width - 10, 20);
            cp.location = new Point(5, 28);
            cp.tabStop = true;
            NewChatTextBox.KeyPress += new KeyPressEventHandler(SearchChat);
            CopyParameters(NewChatTextBox, cp);

            AditionalComponents.Add(NewChatPanel);
        }

        //Pendiente
        private void SearchChat(object sender, KeyPressEventArgs e) {
            if (e.KeyChar == (int)Keys.Enter) { 
                if (sender is TextBox textBox) {
                    SGraficControl.WaitOne();
                    if (currentView == CurrentView.ViewChats || currentView == CurrentView.InChat) {
                        currentView = CurrentView.SearchingChats;
                        lastView = currentView;
                    } else {
                        currentView = CurrentView.SearchingGroups;
                        lastView = currentView;
                    }

                    if (currentView == CurrentView.SearchingChats) {
                        RemoveActiveChats();
                        ShippingData.Profile p = new ShippingData.Profile();
                        p.Name = textBox.Text;
                        model.ToWriteEnqueue(new Chat(model.singleton.userName, p, true));
                    } else {
                        RemoveActiveChats();
                        model.ToWriteEnqueue(new ChatGroup(-1, textBox.Text));
                    }
                    textBox.Clear();
                    SGraficControl.Release();
                }
            }
        }

        private void AddChatBox() {
            if (!ChatBoxPanel.Visible) {
                ChangeVisible(ChatBoxPanel, true);
                ChangeSize(ViewPanel, new Size(ViewPanel.Width, ViewPanel.Height - ChatBoxPanel.Height));
            }
        }

        //Pendiente
        private void AddChatMessage(UserChat chat) {
            Panel message = new Panel();
            Label user = new Label();
            Label content = new Label();
            Label time = new Label();
            if (chat == default)
                return;
            ChatMessage ms = chat.OldMessagePop();
            if (ms == default) {
                ms = chat.NewMessageDequeue();
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
            cp.size = new Size(ViewPanel.Width - 4, 18);
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
            cp.size = new Size(ViewPanel.Width - 4, 20);
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
            cp.location = new Point(ViewPanel.Width - time.Width - 3, ViewPanel.Height - 16);
            cp.size = new Size(42, 13);
            cp.text = ms.date.Hour.ToString();
            cp.contentAlignment = ContentAlignment.MiddleRight;
            cp.autoSize = true;
            cp.foreColor = Color.FromArgb(200, 200, 200);
            cp.name = "Time";
            cp.tabStop = false;
            CopyParameters(time, cp);
            //message panel
            cp = new ControlParameters();
            cp.anchor = (AnchorStyles)(AnchorStyles.Left | AnchorStyles.Right);
            cp.borderStyle = BorderStyle.FixedSingle;
            cp.size = new Size(ViewPanel.Width, time.Height + content.Height + user.Height + 20);
            if (FirstMessage == null) {
                FirstMessage = ms;
                cp.location = new Point(0, 0);
                OldMessages.Push(message);
                RecentMessages.Push(message);
            } else {
                if (ms.date.CompareTo(FirstMessage.date) < 0) {
                    cp.location = new Point(0, OldMessages.Peek().Location.Y - cp.size.Height);
                    OldMessages.Push(message);
                } else {
                    cp.location = new Point(0, RecentMessages.Peek().Location.Y + cp.size.Height);
                    RecentMessages.Push(message);
                }
            }
            cp.name = chat.profile.Name;
            cp.tabStop = false;
            CopyParameters(message, cp);
        }

        //Pendiente
        private void AddGroupMessage(Group group) {
            Panel message = new Panel();
            Label user = new Label();
            Label content = new Label();
            Label time = new Label();
            GroupMessage ms = group.NewMessageDequeue();
            if(ms == default) {
                ms = group.OldMessagePop();
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
            cp.font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            cp.foreColor = Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            cp.location = new Point(2, 2);
            cp.name = "UserName";
            cp.size = new Size(ViewPanel.Width - 4, 18);
            cp.tabStop = false;
            cp.text = ms.Sender;
            CopyParameters(user, cp);
            //content label
            cp = new ControlParameters();
            cp.autoSize = true;
            cp.anchor = (AnchorStyles)(((AnchorStyles.Top | AnchorStyles.Left) | AnchorStyles.Right) | AnchorStyles.Bottom);
            cp.font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
            cp.foreColor = Color.FromArgb(200, 200, 200);
            cp.location = new Point(2, 30);
            cp.name = "Content";
            cp.size = new Size(ViewPanel.Width - 4, 20);
            cp.tabStop = false;
            cp.text = ms.Content;
            CopyParameters(content, cp);
            //time label
            cp = new ControlParameters();
            cp.anchor = ((AnchorStyles)((AnchorStyles.Bottom | AnchorStyles.Right)));
            cp.autoSize = true;
            cp.foreColor = Color.FromArgb(200, 200, 200);
            cp.name = "Time";
            cp.size = new Size(42, 13);
            cp.tabStop = false;
            cp.text = ms.date.Hour.ToString();
            cp.location = new Point(ViewPanel.Width - time.Width - 3, ViewPanel.Height - 16);
            CopyParameters(time, cp);
            //message panel
            cp = new ControlParameters();
            cp.borderStyle = BorderStyle.FixedSingle;
            cp.anchor = (AnchorStyles)(AnchorStyles.Left | AnchorStyles.Right);
            cp.name = group.code.ToString();
            cp.size = new Size(ViewPanel.Width, time.Height + content.Height + user.Height + 20);
            cp.tabStop = false;
            if (FirstMessage == null) {
                FirstMessage = ms;
                cp.location = new Point(0, 0);
            } else {
                if (ms.date.CompareTo(FirstMessage.date) < 0) {
                    cp.location = new Point(0, OldMessages.Peek().Location.Y - cp.size.Height);
                    OldMessages.Push(message);
                } else {
                    cp.location = new Point(0, RecentMessages.Peek().Location.Y + cp.size.Height);
                    RecentMessages.Push(message);
                }
            }
            CopyParameters(message, cp);
        }

        //Pendiente
        private void RemoveMessages() {
            if (FirstMessage == null)
                return;
            FirstMessage = null;
            if (lastView == CurrentView.InChat || lastView == CurrentView.ViewChats) {
                ChatMessage ms;
                UserChat uc = SearchChat(RecentMessages.Peek().Name);
                Console.WriteLine(RecentMessages.ToString());
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
                                //ms.date = new Date(DateTime.Parse(l.Text));
                            }
                        }
                    }
                    if (ms.Sender.Equals(model.singleton.userName)) {
                        ms.Receiver = uc.profile.Name;
                    } else {
                        ms.Receiver = model.singleton.userName;
                    }
                    uc.OldMessagesPush(ms);
                    DeleteControl(p, ViewPanel);
                }
                while (!OldMessages.IsEmpty()) {
                    Panel p = OldMessages.Pop();
                    DeleteControl(p, ViewPanel);
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
                    DeleteControl(p, ViewPanel);
                }
                while (!OldMessages.IsEmpty()) {
                    Panel p = OldMessages.Pop();
                    DeleteControl(p, ViewPanel);
                }
            }
        }

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
            cp.location = new Point(0, cp.size.Height * i);
            cp.borderStyle = BorderStyle.FixedSingle;
            cp.backColor = Color.Transparent;
            cp.name = c.profile.Name;
            cp.tabStop = false;
            CopyParameters(newPanel, cp);
            newPanel.MouseEnter += new EventHandler(Chat_MouseEnter);
            newPanel.MouseLeave += new EventHandler(Chat_MouseLeave);
            newPanel.Click += new EventHandler(Chat_Click);

            //pictureBox
            cp = new ControlParameters();
            cp.size = new Size(40, 40);
            cp.location = new Point(10, 10);
            cp.pictureBoxSizeMode = PictureBoxSizeMode.StretchImage;
            if (c.profile.Image != null) {
                cp.image = Serializer.DeserializeImage(c.profile.Image);
            }
            CopyParameters(photo, cp);

            //label
            cp = new ControlParameters();
            cp.size = new Size(newPanel.Width - 60, 20);
            cp.location = new Point(50, 10);
            cp.anchor = (AnchorStyles)(AnchorStyles.Left | AnchorStyles.Right);
            cp.text = c.profile.Name;
            cp.contentAlignment = ContentAlignment.MiddleLeft;
            cp.backColor = Color.Transparent;
            cp.foreColor = Color.FromArgb(200, 200, 200);
            cp.font = new Font("Microsoft Sans Serif", 10F, FontStyle.Regular, GraphicsUnit.Point, 0);
            CopyParameters(user, cp);

            ActiveChats.Add(newPanel);
        }

        //Pendiente
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

        //Pendiente
        private void ManagmentChat() {
            /*if (model.chats.IsEmpty()) {
                if (ActiveChats.IsEmpty()) {
                    Panel p = new Panel();
                    Label l = new Label();
                    AddControl(p, actionPanel);
                    ActiveChats.Add(p);

                    ControlParameters cp = new ControlParameters();
                    cp.text = "Aún no tienes ningún chat";
                    cp.size = new Size(actionPanel.Width - 6, 20);
                    cp.anchor = (AnchorStyles)((AnchorStyles.Left | AnchorStyles.Right) | AnchorStyles.Top);
                    cp.font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point, 0);
                    cp.foreColor = Color.FromArgb(200, 200, 200);
                    cp.autoSize = false;
                    cp.location = new Point(0, 0);
                    CopyParameters(l, cp);
                    l.TextAlign = ContentAlignment.MiddleCenter;

                    AddControl(l, p);
                    cp = new ControlParameters();
                    cp.location = new Point(3, 3);
                    cp.anchor = (AnchorStyles)((AnchorStyles.Left | AnchorStyles.Right) | AnchorStyles.Top);
                    cp.size = l.Size;
                    cp.name = "EmptyChat";
                    cp.backColor = Color.Transparent;
                    CopyParameters(p, cp);
                    return;
                }
            } else {
                if (!ActiveChats.IsEmpty()) {
                    Panel p = ActiveChats.Get(0);
                    if (p.Name.Equals("EmptyChat")) {
                        DeleteControl(p, actionPanel);
                        ActiveChats.RemoveElement(p);
                    }

                }
            }*/
            Iterator<UserChat> i = model.chats.Iterator();
            int count = 0;
            while (i.HasNext()) {
                UserChat c = i.Next();
                if (currentView == CurrentView.SearchingChats) {
                    if (c.searched) {
                        if (!c.visible) {
                            AddChat(c, count);
                        }
                        count++;
                    }
                } else {
                    if (!c.searched) {
                        if (!c.visible) {
                            AddChat(c, count);
                            c.visible = true;
                        }
                        count++;
                    }
                }/*
                if (c.profile.Image == null) {
                    UserChat userChat = SearchChat(c.profile.Name);
                    if (userChat == default || userChat.profile.Image == null)
                        continue;
                    foreach (Control control in ActiveChats.Get(imageCount).Controls) {
                        if(control is PictureBox picture) {
                            ChangeImage(picture, Serializer.DeserializeImage(userChat.profile.Image));
                        }
                    }
                }
                imageCount++;*/
            }
        }

        //Pendiente
        private void ManagmentGroup() {
            if (model.groups.IsEmpty()) {
                if (ActiveChats.IsEmpty()) {
                    Panel p = new Panel();
                    Label l = new Label();
                    AddControl(l, actionPanel);
                    ActiveChats.Add(p);

                    ControlParameters cp = new ControlParameters();
                    cp.text = "Aún no tienes ningún grupo";
                    cp.size = new Size(actionPanel.Width - 6, 20);
                    cp.contentAlignment = ContentAlignment.MiddleCenter;
                    cp.anchor = (AnchorStyles)((AnchorStyles.Left | AnchorStyles.Right) | AnchorStyles.Top);
                    cp.location = new Point(0, 0);
                    cp.font = new Font("Microsoft Sans Serif", 11F, FontStyle.Regular, GraphicsUnit.Point, ((byte)(0)));
                    cp.foreColor = Color.FromArgb(200, 200, 200);
                    cp.autoSize = false;
                    CopyParameters(p, cp);

                    AddControl(l, p);
                    cp = new ControlParameters();
                    cp.location = new Point(3, 3);
                    cp.anchor = (AnchorStyles)((AnchorStyles.Left | AnchorStyles.Right) | AnchorStyles.Top);
                    cp.size = l.Size;
                    cp.name = "EmptyChat";
                    cp.backColor = Color.Transparent;
                    CopyParameters(p, cp);
                    return;
                }
            } else {
                if (!ActiveChats.IsEmpty()) {
                    Panel p = ActiveChats.Get(0);
                    if (p.Name.Equals("EmptyChat")) {
                        DeleteControl(p, actionPanel);
                        ActiveChats.RemoveElement(p);
                    }

                }
            }
            Iterator<Group> i = model.groups.Iterator();
            int count = 0;
            while (i.HasNext()) {
                Group c = i.Next();
                if (currentView == CurrentView.SearchingChats) {
                    if (c.searched) {
                        if (!c.visible) {
                            AddGroup(c, count);
                        }
                        count++;
                    }
                } else {
                    if (!c.searched) {
                        if (!c.visible) {
                            AddGroup(c, count);
                        }
                        count++;
                    }
                }
            }
        }

        private void RemoveActiveChats() {
            Iterator<Panel> i = ActiveChats.Iterator();
            while (i.HasNext())
                DeleteControl(i.Next(), actionPanel);
            ActiveChats = new LinkedList<Panel>();

            if (lastView == CurrentView.InChat || lastView == CurrentView.ViewChats || lastView == CurrentView.SearchingChats) {
                Iterator<UserChat> uc = model.chats.Iterator();
                while (uc.HasNext()) {
                    UserChat chat = uc.Next();
                    chat.visible = false;
                    if (chat.searched)
                        model.chats.RemoveElement(chat);
                }
            } else if (lastView == CurrentView.InGroup || lastView == CurrentView.ViewGroups || lastView == CurrentView.SearchingGroups) {
                Iterator<Group> g = model.groups.Iterator();
                while (g.HasNext()) {
                    Group group = g.Next();
                    group.visible = false;
                    if (group.searched)
                        model.groups.Remove(group.code);
                }
            }
        }

        private void Chat_Click(object sender, EventArgs e) {
            SGraficControl.WaitOne();
            currentView = CurrentView.InChat;
            lastView = CurrentView.ViewChats;
            SGraficControl.Release();
            if (sender is Panel s)
                model.CurrentChat = s.Name;
        }

        private void Group_Click(object sender, EventArgs e) {
            SGraficControl.WaitOne();
            currentView = CurrentView.InGroup;
            lastView = CurrentView.ViewGroups;
            SGraficControl.Release();
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

        private UserChat SearchChat(string name) {
            Iterator<UserChat> i = model.chats.Iterator();
            while (i.HasNext()) {
                UserChat c = i.Next();
                if (c.profile.Name.Equals(name)) {
                    return c;
                }
            }
            return default;
        }

        private Group SearchGroup(int code) {
            Iterator<Group> i = model.groups.Iterator();
            while (i.HasNext()) {
                Group c = i.Next();
                if (c.code == code) {
                    return c;
                }
            }
            return default;
        }

        private void GraficControl() {
            while (subprocess) {
                SGraficControl.WaitOne();
                if (lastView != currentView) {
                    RemoveComponents();
                    RemoveMessages();
                    RemoveActiveChats();
                    lastView = currentView;
                    switch (currentView) {
                        case CurrentView.InChat:
                        case CurrentView.InGroup:
                            AddChatSearchElements();
                            AddChatBox();
                            break;
                        case CurrentView.ViewGroups:
                        case CurrentView.ViewChats:
                            AddChatSearchElements();
                            break;
                    }
                }
                bool InChat = currentView == CurrentView.InChat, InGroup = currentView == CurrentView.InGroup;
                if(InChat || currentView == CurrentView.ViewChats || currentView == CurrentView.SearchingChats) {
                    ManagmentChat();
                    if (InChat) {
                        AddChatMessage(SearchChat(model.CurrentChat));
                    }
                } else if (InGroup || currentView == CurrentView.ViewGroups || currentView == CurrentView.SearchingGroups) {
                    ManagmentGroup();
                    if (InGroup) {
                        AddGroupMessage(SearchGroup(model.CurrentGroup));
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
                        if (SearchChat(user.Name) == default) {
                            model.chats.Add(new UserChat(user));
                            model.ToWriteEnqueue(new Chat(model.singleton.userName, user, false));
                        }
                        SearchChat(user.Name).NewMessagesEnqueue(chatMessage);
                    } else if (data is GroupMessage groupMessage) {
                        Console.WriteLine("Sender: " + groupMessage.Sender);
                        Console.WriteLine("Id group receiver: " + groupMessage.IdGroupReceiver);
                        Console.WriteLine("Content: " + groupMessage.Content);
                        /*Group receiver = model.groups.Search(groupMessage.IdGroupReceiver);
                        receiver.NewMessagesEnqueue(groupMessage);*/
                    }
                } else if (data is ChatGroup chatGroup) {
                    /*Group newGroup = new Group();
                    newGroup.code = chatGroup.idGroup;
                    newGroup.name = chatGroup.name;
                    if (currentView == CurrentView.SearchingGroups)
                        newGroup.searched = true;
                    else
                        newGroup.searched = false;
                    model.groups.AddElement(newGroup.code, newGroup);*/
                } else if (data is Chat chat) {
                    UserChat newChat = new UserChat(chat.memberTwo);
                    newChat.searched = chat.Searched;
                    if (SearchChat(newChat.profile.Name) == default) {
                        model.chats.Add(newChat);
                    } else {
                        model.chats.RemoveElement(newChat);
                        model.chats.Add(newChat);
                    }
                } else if (data is RequestAnswer requestAnswer) {

                } else if (data is RequestError requestError) {

                } else if (data is ShippingData.Profile p) {
                    Singleton.GetSingleton().ProfilePicture = p.Image;
                    Singleton.GetSingleton().Status = p.Status;
                    ChangeImage(Profile, Serializer.DeserializeImage(model.singleton.ProfilePicture));
                }
            }
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
                ToChange.Size = Size;
            }
        }

        private void TreeButton_Click(object sender, EventArgs e) {
            new TreeView().ShowDialog();
        }
    }
}